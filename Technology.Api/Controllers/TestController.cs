using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Technology.gRPC;

namespace Technologies.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            using var channel = GrpcChannel.ForAddress("http://grpc");
            //using var channel = GrpcChannel.ForAddress("https://grpc.qaybe.de");
            var client = new Greeter.GreeterClient(channel);
            var personClient = new Person.PersonClient(channel);

            var personReply = await personClient.InsertPersonAsync(
                new PersonRequest { Name = "Marcel", Age = 44, CatName = "Jerry" });

            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "GreeterClient", Age = 42 });


            return Ok(reply.Message + " " + personReply.Message);
        }
    }
}