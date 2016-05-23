using System;
using System.Collections.Generic;
using System.Linq;
using Cer.Core.Dtos;
using Cer.Core.Enum;
using Cer.Core.Models;
using Cer.Infrastructure.Data.EfProvider.Data;
using NUnit.Framework;

namespace Cer.UnitTests.data
{
    public static class TestData
    {
        public static DateTime SampleTime = new DateTime(2000, 1, 1);
        public static SampleData Data = new SampleData();

        public static class RentalServiceTests
        {
            public static IEnumerable<TestCaseData> GetAvailableEquipmentWithPagingValidTestCases()
            {
                foreach (var dto in new[] { null, new EquipmentViewDto() })
                    yield return new TestCaseData(dto, dto, new PagingDto());
            }

            public static IEnumerable<TestCaseData> GetInvoicValidTestCases()
            {
                yield return new TestCaseData(null, null);
                yield return new TestCaseData(new CartDto(), new InvoiceDto());
            }

            public static IEnumerable<TestCaseData> SubmitRentRequestValidTestCases()
            {
                yield return new TestCaseData(null, null);
                yield return new TestCaseData(new EquipmentRentRequestDto(), new CartDto());
            }
        }

        public static class EquipmentViewDtoProviderTests
        {
            public static IEnumerable<TestCaseData> HandleValidTestCases()
            {
                var total = 0;
                var equipments = new List<Equipment>();
                Func<Equipment, EquipmentDto> mapper = _ => null;
                var page = new PagingDto();
                var expectedResult = new EquipmentViewDto
                {
                    EquipmentDtos = new List<EquipmentDto>(),
                    ViewDto = new ViewDto
                    {
                        ViewStateTime = SampleTime,
                        Page = 0,
                        PageSize = 25,
                        Total = 0
                    }
                };

                yield return new TestCaseData(total, equipments, mapper, page, expectedResult)
                    .SetName("HandleValidTestCases - No elements");

                total = 1;
                equipments = new List<Equipment> { new Equipment() };
                mapper = equipment =>
                    new EquipmentDto
                    {
                        Id = equipment.Id,
                        EquipmentName = equipment.EquipmentName,
                        EquipmentType = equipment.EquipmentType
                    };
                expectedResult = new EquipmentViewDto
                {
                    EquipmentDtos = new List<EquipmentDto> { new EquipmentDto() },
                    ViewDto = new ViewDto
                    {
                        ViewStateTime = SampleTime,
                        Page = 0,
                        PageSize = 25,
                        Total = total
                    }
                };

                yield return new TestCaseData(total, equipments, mapper, page, expectedResult)
                    .SetName("HandleValidTestCases - 1 empty element");

                total = 25;
                equipments = Enumerable.Range(0, total).Select(o => new Equipment()).ToList();
                expectedResult = new EquipmentViewDto
                {
                    EquipmentDtos = Enumerable.Range(0, total).Select(o => new EquipmentDto()).ToList(),
                    ViewDto = new ViewDto
                    {
                        ViewStateTime = SampleTime,
                        Page = 0,
                        PageSize = 25,
                        Total = total
                    }
                };

                yield return new TestCaseData(total, equipments, mapper, page, expectedResult)
                    .SetName("HandleValidTestCases - 25 empty element");


                total = Data.Equipments.Count;
                equipments = Data.Equipments;
                expectedResult = new EquipmentViewDto
                {
                    EquipmentDtos =
                        new[]
                        {
                            new EquipmentDto
                            {
                                Id = 1,
                                EquipmentType = EquipmentType.Heavy,
                                EquipmentName = "Caterpillar bulldozer"
                            },
                            new EquipmentDto
                            {
                                Id = 2,
                                EquipmentType = EquipmentType.Regular,
                                EquipmentName = "KamAZ truck"
                            },
                            new EquipmentDto
                            {
                                Id = 3,
                                EquipmentType = EquipmentType.Heavy,
                                EquipmentName = "Komatsu crane"
                            },
                            new EquipmentDto
                            {
                                Id = 4,
                                EquipmentType = EquipmentType.Regular,
                                EquipmentName = "Volvo steamroller"
                            },
                            new EquipmentDto
                            {
                                Id = 5,
                                EquipmentType = EquipmentType.Specialized,
                                EquipmentName = "Bosch jackhammer"
                            },
                        },
                    ViewDto = new ViewDto
                    {
                        ViewStateTime = SampleTime,
                        Page = 0,
                        PageSize = 25,
                        Total = total
                    }
                };

                yield return new TestCaseData(total, equipments, mapper, page, expectedResult)
                    .SetName("HandleValidTestCases - Sample data");

                //Todo page = -1, page = 1 
            }
        }

        public static class CartDtoProviderTests
        {
            public static IEnumerable<TestCaseData> HandleValidTestCases()
            {
                var input = new EquipmentRentRequestDto
                {
                    EquipmentRentDtos = Enumerable.Empty<EquipmentRentDto>(),
                    ViewStateTime = SampleTime
                };
                var expectedResult = new CartDto();

                yield return new TestCaseData(input, expectedResult)
                    .SetName("HandleValidTestCases - No elements");

                input = new EquipmentRentRequestDto
                {
                    EquipmentRentDtos = new[] { new EquipmentRentDto() },
                    ViewStateTime = SampleTime
                };
                expectedResult = new CartDto();

                yield return new TestCaseData(input, expectedResult)
                    .SetName("HandleValidTestCases - 1 empty element");

                input = new EquipmentRentRequestDto
                {
                    EquipmentRentDtos = Enumerable.Range(0, 25).Select(o => new EquipmentRentDto()).ToList(),
                    ViewStateTime = SampleTime
                };
                expectedResult = new CartDto();

                yield return new TestCaseData(input, expectedResult)
                    .SetName("HandleValidTestCases - 25 empty elements");
                
                input = new EquipmentRentRequestDto
                {
                    EquipmentRentDtos = Data.Equipments.Select(o => new EquipmentRentDto
                    {
                        EquipmentId = o.Id,
                        DurationInDays = 1
                    }).ToArray(),
                    ViewStateTime = SampleTime
                };
                expectedResult = new CartDto();

                yield return new TestCaseData(input, expectedResult)
                    .SetName("HandleValidTestCases - Sample data");
            }
        }

        public static class InvoiceDtoProviderTests
        {
            public static IEnumerable<TestCaseData> HandleValidTestCases()
            {
                var loyaltyPoints = 0;
                var cartDto = new CartDto();
                var cartEquipments = new CartEquipment[0];
                var invoiceDto = new InvoiceDto
                {
                    Title = $"Invoice id : {cartDto.CartId}",
                    Rentals = Enumerable.Empty<RentalDto>(),
                    LoyaltyPoints = 0,
                    TotalPrice = 0
                };

                yield return new TestCaseData(cartDto, cartEquipments, invoiceDto, loyaltyPoints)
                    .SetName("HandleValidTestCases - No elements");

                loyaltyPoints = 1;
                cartDto = new CartDto { CartId = 1 };
                cartEquipments = new[]
                {
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo H1",
                            EquipmentType = EquipmentType.Heavy
                        },
                        Id = 3,
                        RentDurationDays = 1
                    }
                };
                invoiceDto = new InvoiceDto
                {
                    Title = $"Invoice id : {cartDto.CartId}",
                    Rentals = new[]
                    {
                        new RentalDto
                        {
                            Name = "Kuvaldo H1",
                            Price = 1
                        }
                    },
                    LoyaltyPoints = 1,
                    TotalPrice = 1
                };

                yield return new TestCaseData(cartDto, cartEquipments, invoiceDto, loyaltyPoints)
                    .SetName("HandleValidTestCases - 1 element");

                loyaltyPoints = 2;
                cartDto = new CartDto { CartId = 1 };
                cartEquipments = new[]
                {
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo H1",
                            EquipmentType = EquipmentType.Heavy
                        },
                        RentDurationDays = 1
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo H2",
                            EquipmentType = EquipmentType.Heavy
                        },
                        RentDurationDays = 2
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo H3",
                            EquipmentType = EquipmentType.Heavy
                        },
                        RentDurationDays = 3
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo S1",
                            EquipmentType = EquipmentType.Specialized
                        },
                        RentDurationDays = 1
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo S2",
                            EquipmentType = EquipmentType.Specialized
                        },
                        RentDurationDays = 2
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo S3",
                            EquipmentType = EquipmentType.Specialized
                        },
                        RentDurationDays = 3
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo R1",
                            EquipmentType = EquipmentType.Regular
                        },
                        RentDurationDays = 1
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo R2",
                            EquipmentType = EquipmentType.Regular
                        },
                        RentDurationDays = 2
                    },
                    new CartEquipment
                    {
                        Equipment = new Equipment
                        {
                            EquipmentName = "Kuvaldo R3",
                            EquipmentType = EquipmentType.Regular
                        },
                        RentDurationDays = 3
                    }
                };

                invoiceDto = new InvoiceDto
                {
                    Title = $"Invoice id : {cartDto.CartId}",
                    Rentals = new[]
                    {
                        new RentalDto
                        {
                            Name = "Kuvaldo H1",
                            Price = 1
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo H2",
                            Price = 1
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo H3",
                            Price = 1
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo R1",
                            Price = 2
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo R2",
                            Price = 2
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo R3",
                            Price = 2
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo S1",
                            Price = 3
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo S2",
                            Price = 3
                        },
                        new RentalDto
                        {
                            Name = "Kuvaldo S3",
                            Price = 3
                        }
                    },
                    LoyaltyPoints = 2,
                    TotalPrice = 18
                };
                yield return new TestCaseData(cartDto, cartEquipments, invoiceDto, loyaltyPoints)
                    .SetName("HandleValidTestCases - 9 element variants {RentDurationDays, Equipment.EquipmentType}");

                loyaltyPoints = 1;
                cartDto = new CartDto { CartId = 1 };
                cartEquipments = Data.Equipments.Select(o => new CartEquipment
                {
                    Equipment = o,
                    Id = 1,
                    RentDurationDays = 1
                }).ToArray();
                invoiceDto = new InvoiceDto
                {
                    Title = $"Invoice id : {cartDto.CartId}",
                    Rentals = new[]
                    {
                        new RentalDto
                        {
                            Name = "Caterpillar bulldozer",
                            Price = 1
                        },
                        new RentalDto
                        {
                            Name = "KamAZ truck",
                            Price = 2
                        },
                        new RentalDto
                        {
                            Name = "Komatsu crane",
                            Price = 1
                        },
                        new RentalDto
                        {
                            Name = "Volvo steamroller",
                            Price = 2
                        },
                        new RentalDto
                        {
                            Name = "Bosch jackhammer",
                            Price = 3
                        }
                    },
                    LoyaltyPoints = 1,
                    TotalPrice = 9
                };

                yield return new TestCaseData(cartDto, cartEquipments, invoiceDto, loyaltyPoints)
                    .SetName("HandleValidTestCases - Seed data");
            }
        }
    }
}