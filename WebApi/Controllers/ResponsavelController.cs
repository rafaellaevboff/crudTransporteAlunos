using Domain.DTO;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelRepository repository;
        private readonly IUnitOfWork _unitOfWork;

        public ResponsavelController(IResponsavelRepository responsavelRepository, IUnitOfWork unitOfWork)
        {
            this.repository = responsavelRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("responsavel")]
        public async Task<IActionResult> GetAllAsync()
        {
            var responsavelList = await repository.GetAllAsync();
            List<ResponsavelDTO> responsaveisDTO = new List<ResponsavelDTO>();
            
            foreach(Responsavel responsavel in responsavelList){
                var responsavelDTO = new ResponsavelDTO()
                {
                    Id = responsavel.Id,
                    Nome = responsavel.Nome,
                    Endereco = responsavel.Endereco,
                };
                responsaveisDTO.Add(responsavelDTO);
            }
            return Ok(responsaveisDTO);
        }

        [HttpGet("responsavel/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var responsavel = await repository.GetByIdAsync(id);

            if(responsavel == null)
                return NotFound();
            else
            {
                var responsavelDTO = new ResponsavelDTO()
                {
                    Id = responsavel.Id,
                    Nome = responsavel.Nome,
                    Endereco = responsavel.Endereco,
                };
                return Ok(responsavelDTO);
            }
        }

        [HttpPost("responsavel")]
        public async Task<IActionResult> PostAsync([FromBody]ResponsavelCreate model)
        {
            var responsavel = new Responsavel()
            {
                Nome = model.Nome,
                Endereco = model.Endereco,
                Cpf = model.Cpf,
            };

            repository.Save(responsavel);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Responsavel " + responsavel.Nome + " foi adicionado com sucesso!"
            });
        }
        
        [HttpDelete("responsavel/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var responsavelDeleted = repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if(responsavelDeleted == false)
                return NotFound();
            else
                return Ok(new   
            {
                message = "Responsavel deletado com sucesso!",
                id = id
            });
        }
        [HttpPatch("responsavel/{id:int}")] //vai editar uma pessoa de acordo com o id informado e com os dados alterados
        public async Task<IActionResult> PatchAsync([FromRoute] int id, [FromBody] ResponsavelUpdateEndereco model)
        {
            var responsavel = await repository.GetByIdAsync(id);
            if (responsavel == null) return NotFound();

            responsavel.Endereco = model.Endereco;

            repository.Update(responsavel);
            await _unitOfWork.CommitAsync();
            return Ok(responsavel);
        }
    }
}