using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Technology.gRPC
{
    public class PersonService : Person.PersonBase
    {
        private readonly ILogger<PersonService> _logger;

        public PersonService(ILogger<PersonService> logger)
        {
            _logger = logger;
        }

        public override Task<PersonReply> InsertPerson(
            PersonRequest request,
            ServerCallContext context)
        {
            return Task.FromResult( new PersonReply
            {
                Message = $"Person '{request.Name}' inserted"
            });
        }
    }

    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(
            HelloRequest request,
            ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = $"Hello {request.Name}, your age is {request.Age}, right?"
            });
        }
    }
}
