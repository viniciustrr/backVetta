using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportXExame.Config;
using SportXExame.Entity;
using SportXExame.Models;
using SportXExame.Repositories;

namespace SportXExame.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ITelefoneRepository _telefoneRepository;



        public ClienteController(IClienteRepository clienteRepository, ITelefoneRepository telefoneRepository)
        {
            _clienteRepository = clienteRepository;
            _telefoneRepository = telefoneRepository;


        }


        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _clienteRepository.Get();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var clienteDB = await _clienteRepository.Get(id);
            return clienteDB;
        }


        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] CLienteModel cliente)
        {
            var clienteDB = new Cliente() { nome = cliente.nome };
            var newCliente = await _clienteRepository.Create(clienteDB);
            return CreatedAtAction(nameof(GetCliente), new { id = newCliente.id }, newCliente);
        }



        [HttpPost("telefone/novo")]
        public async Task<ActionResult<Telefone>> PostTelefoneNovo(TelefoneModel telefone)
        {
            var clienteDB = _clienteRepository.Get(telefone.IdCliente);
            if (clienteDB != null)
            {
                foreach (var item in telefone.Numeros)
                {
                    await _telefoneRepository.Create(new Telefone() { ClienteId = telefone.IdCliente, telefone = item });
                }
                return Ok(clienteDB);
            }
            else
            {
                return BadRequest("Cliente não existe!");
            }
            
        }

        [HttpPost("dados")]
        public async Task<ActionResult<bool>> TodosDados(ClienteDadosModel clienteDadosModel)
        {
            var clienteDB = await _clienteRepository.Create(new Cliente
            {
                nome = clienteDadosModel.cLienteModel.nome,
                email = clienteDadosModel.cLienteModel.email,
                cpfCNPJ = clienteDadosModel.cLienteModel.cpfCNPJ,
                cep = clienteDadosModel.cLienteModel.cep,
                classificacao = clienteDadosModel.cLienteModel.classificacao
            });

            foreach (var item in clienteDadosModel.telefones)
            {
                await _telefoneRepository.Create(new Telefone() { ClienteId = clienteDB.id, telefone = item });
            }

            return Ok(true);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutCliente(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.id)
            {
                return BadRequest();
            }

            await _clienteRepository.Update(cliente);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            var clienteToDelete = await _clienteRepository.Get(id);
            if (clienteToDelete == null)
            {
                return NotFound();
            }
            await _clienteRepository.Delete(id);
            return NoContent();
        }










    }
}
