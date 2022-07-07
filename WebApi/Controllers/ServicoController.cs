using Domain.DTO;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/")]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepository repository;
        private readonly IUnitOfWork _unitOfWork;

        public ServicoController(IServicoRepository servicoRepository, IUnitOfWork unitOfWork)
        {
            this.repository = servicoRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("servico")]
        public async Task<IActionResult> GetAllAsync()
        {
            var servicoList = await repository.GetAllAsync();
            List<ServicoDTO> servicosDTO = new List<ServicoDTO>();
            
            foreach(Servico servico in servicoList){
                var servicoDTO = new ServicoDTO()
                {
                    Id = servico.Id,
                    Cnpj = servico.Cnpj,
                    AlunoID = servico.AlunoID,
                    MotoristaID = servico.MotoristaID,
                    ResponsavelID = servico.ResponsavelID,
                };
                servicosDTO.Add(servicoDTO);
            }
            return Ok(servicosDTO);
        }

        [HttpGet("servico/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var servico = await repository.GetByIdAsync(id);

            if(servico == null)
                return NotFound();
            else
            {
                var servicoDTO = new ServicoDTO()
                {
                    Id = servico.Id,
                    Cnpj = servico.Cnpj,
                    AlunoID = servico.AlunoID,
                    MotoristaID = servico.MotoristaID,
                    ResponsavelID = servico.ResponsavelID,
                };
                return Ok(servicoDTO);
            }
        }

        [HttpPost("servico")]
        public async Task<IActionResult> PostAsync([FromBody]ServicoCreate model)
        {
            var servico = new Servico()
            {
                Cnpj = model.Cnpj,
                AlunoID = model.AlunoID,
                MotoristaID = model.MotoristaID,
                ResponsavelID = model.ResponsavelID,
            };

            repository.Save(servico);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Servico " + servico.Id + " foi adicionado com sucesso!"
            });
        }
        
        [HttpDelete("servico/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var servicoDeleted = repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if(servicoDeleted == false)
                return NotFound();
            else
                return Ok(new   
            {
                message = "Serviço(contrato) deletado com sucesso!",
                id = id
            });
        }
        [HttpPatch("servico/{id:int}")] //vai editar uma pessoa de acordo com o id informado e com os dados alterados
        public async Task<IActionResult> PatchAsync([FromRoute] int id, [FromBody] ServicoUpdate model)
        {
            var servico = await repository.GetByIdAsync(id);
            if (servico == null) return NotFound();

            servico.MotoristaID = model.MotoristaID;

            repository.Update(servico);
            await _unitOfWork.CommitAsync();
            return Ok(servico);
        }
    }
}