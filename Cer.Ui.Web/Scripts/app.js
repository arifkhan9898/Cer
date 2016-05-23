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
            $.Rental.LoadEquipment(0);
        }
        $.Rental.LoadEquipment = function (page) {
            $.ajax({
                url: $.Rental.Path + $.Rental.Format("api/Equipment?page={0}",page),
                jsonp: "callback",
                dataType: "jsonp",
                success: function (data) {
                    console.log("data loaded");
                    $("grid-1").html = "";
                    $.each(data.Equipment,
                        function(i, item) {
                            $("grid-1").append(item);
                        });
                },
                error: function () {
                    console.log("Equipment data failed to loaded");
                }
            });
        }
    })($);

    $.Rental.OnLoad();
});