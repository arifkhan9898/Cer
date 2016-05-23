$(function () {
    (function ($) {
        $.Rental = $.Rental || {};
        $.Rental.Path = "http://localhost:16731/";
        $.Rental.Format = function () {
            var args = Array.prototype.slice.call(arguments, 1);
            return arguments[0].replace(/{(\d+)}/g,
                function (match, number) {
                    return typeof args[number] != "undefined" ? args[number] : match;
                });
        }
        $.Rental.OnLoad = function () {
            $("#detailsContainer").hide();
            $("#cart").hide();
            $("#subscribtions").hide();

            $("#detailsCancel").click(function () {
                $("#detailsContainer").hide();
                $("#catalog").show();
            });
            $("#detailsAdd").click(function () {
                $("#detailsContainer").hide();
                $("#catalog").show();
                $("#cart").show();

                //add to chart
                var template = $.Rental.Format("<tr data-id='{0}' data-name='{1}' data-type='{2}' data-duration='{3}'><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                    $("#detailsId").text(), $("#detailsName").val(), $("#detailsType").val(), $("#detailsDuration").val());
                $("#grid-2").append(template);
            });
            $("#cartCancel").click(function () {
                $("#grid-2 tr").remove();
                $("#cart").hide();
            });
            $("#cartAdd").click(function () {
                //Todo
            });

            $.Rental.LoadEquipment(0);
        }
        $.Rental.EnumType = function (dataIndex) {
            switch (dataIndex) {
                case 1:
                    return "Heavy";
                case 2:
                    return "Regular";
                case 3:
                    return "Specialized";
            }
            return "Unknown";
        }
        $.Rental.LoadEquipment = function (page) {
            $.ajax({
                url: $.Rental.Path + $.Rental.Format("api/Equipment?page={0}", page),
                jsonp: "callback",
                dataType: "jsonp",
                success: function (data) {
                    console.log("data loaded");
                    $("#grid-1").html = "";
                    $.each(data.Equipment, function (i, item) {
                        var template = $.Rental.Format("<tr data-id='{0}' data-name='{1}' data-type='{2}'><td>{1}</td><td>{3}</td></tr>", item.Id, item.Name, item.Type, $.Rental.EnumType(item.Type));
                        $("#grid-1").append(template);
                    });
                    $("#grid-1 td").click(function () {
                        var id = $(this).parent().data("id");
                        var name = $(this).parent().data("name");
                        var type = $(this).parent().data("type");

                        $("#detailsId").text(id);
                        $("#detailsType").val($.Rental.EnumType(type));
                        $("#detailsName").val(name);
                        $("#detailsDuration").val(1);

                        $("#detailsContainer").show();
                        $("#catalog").hide();
                        
                    });
                    //Todo: find out why bootgrid does not work: $("#grid-basic").bootgrid();
                },
                error: function () {
                    console.log("Equipment data failed to loaded");
                }
            });
        }
    })($);

    $.Rental.OnLoad();
});