using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaRepository repository;
        private readonly IUnitOfWork _unitOfWork;

        public EscolaController(IEscolaRepository escolaRepository, IUnitOfWork unitOfWork)
        {
            this.repository = escolaRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            var escolaList = await repository.GetAllAsync();
            List<EscolaDTO> escolasDTO = new List<EscolaDTO>();
            
            foreach(Escola escola in escolaList){
                var escolaDTO = new EscolaDTO()
                {
                    Id = escola.Id,
                    Nome = escola.Nome,
                    Endereco = escola.Endereco,
                };
                escolasDTO.Add(escolaDTO);
            }
            return Ok(escolasDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var escola = await repository.GetByIdAsync(id);

            if(escola == null)
                return NotFound();
            else
            {
                var escolaDTO = new EscolaDTO()
                {
                    Id = escola.Id,
                    Nome = escola.Nome,
                    Endereco = escola.Endereco,
                };
                return Ok(escolaDTO);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> PostAsync([FromBody]EscolaCreate model)
        {
            var escola = new Escola()
            {
                Nome = model.Nome,
                Endereco = model.Endereco,
            };

            repository.Save(escola);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Escola " + escola.Nome + " foi adicionado com sucesso!"
            });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var escolaDeleted = repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if(escolaDeleted == false)
                return NotFound();
            else
                return Ok(id);   
        }

        [HttpPatch("{id}")] //vai editar uma pessoa de acordo com o id informado e com os dados alterados
        public async Task<IActionResult> PatchAsync([FromRoute] int id, [FromBody] EscolaUpdateEndereco model)
        {
            var escola = await repository.GetByIdAsync(id);
            if (escola == null) return NotFound();

            escola.Endereco = model.Endereco;

            repository.Update(escola);
            await _unitOfWork.CommitAsync();
            return Ok(escola);
        }
    }
}