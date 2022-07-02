using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{        
    [Route("api/")]
    public class AlunoController: ControllerBase
    {
        private readonly IAlunoRepository repository;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoController(IAlunoRepository alunoRepository, IUnitOfWork unitOfWork)
        {
            this.repository = alunoRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("aluno")]
        public async Task<IActionResult> GetAllAsync()
        {
            var alunosList = await repository.GetAllAsync();
            List<AlunoDTO> alunosDTO = new List<AlunoDTO>();
            
            foreach(Aluno aluno in alunosList){
                var alunoDTO = new AlunoDTO()
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Endereco = aluno.Endereco,
                    Escola = aluno.Escola
                };
                alunosDTO.Add(alunoDTO);
            }
            return Ok(alunosDTO);
        }

        [HttpGet("aluno/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var aluno = await repository.GetByIdAsync(id);

            if(aluno == null)
                return NotFound();
            else
            {
                var alunoDTO = new AlunoDTO()
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Endereco = aluno.Endereco,
                    Escola = aluno.Escola,
                };
                return Ok(alunoDTO);
            }
        }

        [HttpPost("aluno")]
        public async Task<IActionResult> PostAsync([FromBody]AlunoCreate model)
        {
            var aluno = new Aluno()
            {
                Nome = model.Nome,
                Endereco = model.Endereco,
                EscolaID = model.EscolaID,
                MotoristaID = model.MotoristaID,
                ResponsavelID = model.ResponsavelID
            };

            repository.Save(aluno);
            await _unitOfWork.CommitAsync();

            return Ok(new
            {
                message = "Aluno " + aluno.Nome + " foi adicionado com sucesso!"
            });
        }
        
        [HttpDelete("aluno/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var alunoDeleted = repository.Delete(id);
            await _unitOfWork.CommitAsync();

            if(alunoDeleted == false)
                return NotFound();
            else
                return Ok(new   
            {
                message = "Aluno deletado com sucesso!",
                id = id
            });   
        }

        // Edita as informações dos alunos
        [HttpPatch("aluno/{id:int}")]
        public async Task<IActionResult> PatchAsyncEndereco([FromRoute] int id, [FromBody] AlunoUpdateEndereco model)
        {
            var aluno = await repository.GetByIdAsync(id);
            if (aluno == null) return NotFound();

            aluno.Endereco = model.Endereco;

            repository.Update(aluno);
            await _unitOfWork.CommitAsync();
            return Ok(aluno);
        }

        [HttpPatch("aluno/{id:int}")]
        public async Task<IActionResult> PatchAsyncEscola([FromRoute] int id, [FromBody] AlunoUpdateEscola model)
        {
            var aluno = await repository.GetByIdAsync(id);
            if (aluno == null) return NotFound();

            aluno.EscolaID = model.EscolaID;

            repository.Update(aluno);
            await _unitOfWork.CommitAsync();
            return Ok(aluno);
        }
    }
}