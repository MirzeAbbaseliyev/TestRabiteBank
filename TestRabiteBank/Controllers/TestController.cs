using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceReference1;
using TestRabiteBank.Tool;

namespace TestRabiteBank.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {

        private CalculatorSoapClient client;

        public TestController()
        {
            client = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);
        }
       

        [HttpGet]
        public  int Add(int a,int b)
        {
            return  Worker.CreateLog(client.AddAsync, a, b, "Add");
        }

        [HttpGet]
        public int Divide(int a, int b)
        {
           return Worker.CreateLog(client.DivideAsync, a, b, "Divide");
           
        }

        [HttpGet]
        public int Multiply(int a, int b)
        {
           return Worker.CreateLog(client.MultiplyAsync, a, b, "Multiply");
        }

        [HttpGet]
        public  int Subtract(int a, int b)
        {
            return Worker.CreateLog(client.SubtractAsync, a, b, "Subtract");
        }
    }
}
