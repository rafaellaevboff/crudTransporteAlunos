using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{        
    [Route("api/")]
    public class MotoristaController : ControllerBase
    {
        private readonly IMotoristaRepository repository;
        private readonly IUnitOfWork _unitOfWork;

        public MotoristaController(
            IMotoristaRepository motoristaRepository,
            IUnitOfWork unitOfWork)
        {
            this.repository = motoristaRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("v1/motoristas")]
        public async Task<IActionResult> GetAllAsync()
        {
            var motoristasList = await repository.GetAllAsync();

            List<MotoristaDTO> motoristasDTO = new List<MotoristaDTO>();
            
            foreach(Motorista motorista in motoristasList)
            {
                var motoristaDTO = new MotoristaDTO()
            {
                Id = motorista.Id,
                Nome = motorista.Nome,
                Cpf = motorista.Cpf,
                Telefone = motorista.Telefone,
                Email = motorista.Email
            };
            
            motoristasDTO.Add(motoristaDTO);
        }

        return Ok(motoristasDTO);
    }

        [HttpGet("v1/motoristas/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var motorista = await repository.GetByIdAsync(id);

            if (motorista == null)
                return NotFound();
            else
            {
                var motoristaDTO = new MotoristaDTO()
            {
                Id = motorista.Id,
                Nome = motorista.Nome,
                Cpf = motorista.Cpf,
                Telefone = motorista.Telefone,
                Email = motorista.Email
            };
            
            return Ok(motoristaDTO);
        }
    }

        [HttpPost("v1/motoristas")]
        public async Task<IActionResult> PostAsync([FromBody] MotoristaCreate model)
        {
            var motorista = new Motorista()
            {
                Nome = model.Nome,
                Cpf = model.Cpf,
                Telefone = model.Telefone,
                Email = model.Email,
                Veiculo = model.Veiculo
            };

            repository.Save(motorista);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Motorista " + motorista.Nome + " foi cadastrado com sucesso!"
            });
        }

        [HttpDelete("v1/motoristas/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var motoristaDeleted = repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if (motoristaDeleted == false)
                return NotFound();
            else
                return Ok(new
            {
                message = "Motorista deletado com sucesso!",
                id = id
            });
        }

        [HttpPatch("v1/motoristas/{id:int}")] //vai editar uma pessoa de acordo com o id informado e com os dados alterados
        public async Task<IActionResult> PutAsync([FromRoute]int id, [FromBody] MotoristaUpdate model)
        {
            var motorista = await repository.GetByIdAsync(id);

            if (motorista == null) 
                return NotFound();
            else
            {
                motorista.Nome = model.Nome;
                motorista.Telefone = model.Telefone;
                motorista.Email = model.Email;

                repository.Update(motorista);
                await _unitOfWork.CommitAsync();
                
                var motoristaDTO = new MotoristaDTO()
                {
                    Id = motorista.Id,
                    Nome = motorista.Nome,
                    Cpf = motorista.Cpf,
                    Telefone = motorista.Telefone,
                    Email = motorista.Email
                };

                return Ok(motoristaDTO);
            }
        }
    }
}