using Domain;
using Application.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.MessageService;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace ExemploAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IConfiguration _configuration;        
        private readonly IRabbitMQService _rabbitMQ;
        private readonly IConnection _connection;
        private readonly ConnectionFactory _connectionFactory;

        public ClientController(IConfiguration configuration, IClientService clientService, IRabbitMQService rabbitMQ)
        {
            _configuration = configuration;
            _clientService = clientService;
            _rabbitMQ = rabbitMQ;
            _connectionFactory = _rabbitMQ.GetConnectionFactory(_configuration["HostNameRabbitMQ"], _configuration["UserNameRabbitMQ"], _configuration["PasswordRabbitMQ"]);
            _connection = _rabbitMQ.CreateConnection(_connectionFactory);
            _rabbitMQ.CreateQueue("clientesEspeciais", _connection);
        }
       
        [HttpGet]
        public async Task<IEnumerable<Client>> GetSpecialCustomers()
        {            
            
            var clientes =  await _clientService.GetSpecialsCustomers();

            //foreach (var cliente in clientes)            
            //    _rabbitMQ.PublishMessage($"{cliente.Codigo} -{cliente.Nome}.", "clientesEspeciais", _connection);
            
            return clientes;
        }

        
    }
}
