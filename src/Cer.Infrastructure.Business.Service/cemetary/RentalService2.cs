//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Cer.Core.Dtos;
//using Cer.Core.Interfaces;
//using Cer.Core.Interfaces.Services;
//using Cer.Core.Models;
//using Cer.Infrastructure.Business.Service.Specifications;

//namespace Cer.Infrastructure.Business.Service.cemetary
//{
//    public class RentalService2 : IRentalService
//    {
//        public RentalService2(ICommandFactoryProvider commandFactoryProvider) {}


//        public EquipmentViewDto GetAvailableEquipmentWithPaging(PagingDto pagingDto)
//        {
//            return _equipmentViewDtoProvider.GetAvailableEquipmentWithPaging(page);
//        }

//        public CartDto SubmitRentRequest(EquipmentRentRequestDto equipmentRentRequestDto)
//        {
//            return _cartDtoProvider.SubmitRentRequest(equipmentRentRequestDto);
//        }

//        public InvoiceDto GetInvoice(CartDto cart)
//        {
//            return _invoiceDtoProvider.GetInvoice(cart);
//        }
//    }


//    public interface ICommandHandler
//    {
//        TOutput Handler<TOutput, TInput>(TInput input);
//    }

//    public interface ICommandHandler<in TInput, out TOutput>
//    {
//        Func<TInput, TOutput> Handler { get; }
//    }

//    /// <summary>
//    ///  CQRS stands for Command Query Responsibility Segregation.
//    /// ///////////////////////
//    /// </summary>
//    public interface ICommandHandler<in TCommand>
//    {
//        void Handle(TCommand command);
//    }

//    public interface IQuery<TResult> {}

//    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
//    {
//        TResult Handle(TQuery query);
//    }

//    /// <summary>
//    /// ///////////////////////
//    /// </summary>
//    public class GetAvailableEquipmentHandler : ICommandHandler<PagingDto, EquipmentViewDto>
//    {
//        private readonly IRepository<Equipment> _equipments;
//        private readonly IMapper<Equipment, EquipmentDto> _mapEquipmentDto;
//        private readonly IDateTimeProvider _dateTimeProvider;
//        private readonly EquipmentAvailabilitySpecification _equipmentAvailabilitySpecification;
//        public int PageSize { get; set; } = 25;

//        public GetAvailableEquipmentHandler(
//            IRepository<Equipment> equipments,
//            IMapper<Equipment, EquipmentDto> mapEquipmentDto,
//            IDateTimeProvider dateTimeProvider,
//            EquipmentAvailabilitySpecification equipmentAvailabilitySpecification)
//        {
//            if (equipments == null)
//                throw new ArgumentNullException(nameof(equipments));
//            if (mapEquipmentDto == null)
//                throw new ArgumentNullException(nameof(mapEquipmentDto));
//            if (dateTimeProvider == null)
//                throw new ArgumentNullException(nameof(dateTimeProvider));
//            if (equipmentAvailabilitySpecification == null)
//                throw new ArgumentNullException(nameof(equipmentAvailabilitySpecification));

//            _equipments = equipments;
//            _mapEquipmentDto = mapEquipmentDto;
//            _dateTimeProvider = dateTimeProvider;
//            _equipmentAvailabilitySpecification = equipmentAvailabilitySpecification;
//        }

//        public Func<PagingDto, EquipmentViewDto> Handler => command =>
//        {
//            var page = Math.Max(command.Page, 0);
//            var availableEquipmentCount = _equipments.Total(_equipmentAvailabilitySpecification);
//            var availableEquipment = _equipments.Filter(o => o.CartEquipments, _equipmentAvailabilitySpecification, page);
//            var availableEquipmentDtos = availableEquipment.Select(_mapEquipmentDto.Create).ToList();
//            var viewDto = new ViewDto
//            {
//                ViewStateTime = _dateTimeProvider.Now,
//                Page = page,
//                PageSize = PageSize,
//                Total = availableEquipmentCount
//            };
//            var equipmentViewDto = new EquipmentViewDto
//            {
//                EquipmentDtos = availableEquipmentDtos,
//                ViewDto = viewDto
//            };

//            return equipmentViewDto;
//        };
//    }


//    public interface ICommand
//    {
//        void Execute();
//    }

//    public interface ICommand<out T>
//    {
//        T Execute { get; }
//    }

//    public interface ICommandFactory : ICommand
//    {
//        string CommandName { get; }
//        string Description { get; }
//        ICommand Create(string[] arguments);
//    }

//    public interface ICommandFactoryProvider<out T> : ICommand<T> {}

//    public class CommandParser
//    {
//        readonly IEnumerable<ICommandFactory> _availableCommands;

//        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
//        {
//            _availableCommands = availableCommands;
//        }

//        internal ICommand ParseCommand(string requestedCommandName)
//        {
//            var command = FindRequestedCommand(requestedCommandName);

//            return null == command
//                ? new NotFoundCommand {Name = requestedCommandName}
//                : command.Create(args);
//        }

//        ICommandFactory FindRequestedCommand(string commandName)
//        {
//            return _availableCommands
//                .FirstOrDefault(cmd => cmd.CommandName == commandName);
//        }
//    }

//    public class NotFoundCommand : ICommand
//    {
//        public string Name { get; set; }

//        public void Execute()
//        {
//            Console.WriteLine("Couldn't find command: " + Name);
//        }
//    }

//    public class RentalServiceCommandFactoryProvider : ICommandFactoryProvider<IEnumerable<ICommandFactory>>
//    {
//        public IEnumerable<ICommandFactory> Execute =>
//            new ICommandFactory[]
//            {
//                new CreateOrderCommand(),
//                new UpdateQuantityCommand(),
//                new ShipOrderCommand(),
//            };
//    }

//    public class CreateOrderCommand : ICommandFactory
//    {
//        public void Execute()
//        {
//            throw new NotImplementedException();
//        }

//        public string CommandName => "CreateOrder";
//        public string Description => CommandName;

//        public ICommand Create(string[] arguments)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class UpdateQuantityCommand : ICommandFactory
//    {
//        public int NewQuantity { get; set; }

//        public void Execute()
//        {
//            // simulate updating a database
//            const int oldQuantity = 5;
//            Console.WriteLine("DATABASE: Updated");

//            // simulate logging
//            Console.WriteLine("LOG: Updated order quantity from {0} to {1}", oldQuantity, NewQuantity);
//        }

//        public string CommandName
//        {
//            get { return "UpdateQuantity"; }
//        }

//        public string Description
//        {
//            get { return "UpdateQuantity number"; }
//        }

//        public ICommand Create(string[] arguments)
//        {
//            return new UpdateQuantityCommand {NewQuantity = int.Parse(arguments[1])};
//        }
//    }

//    public class ShipOrderCommand : ICommandFactory
//    {
//        public void Execute()
//        {
//            throw new NotImplementedException();
//        }

//        public string CommandName => "ShipOrder";
//        public string Description => CommandName;

//        public ICommand Create(string[] arguments)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}