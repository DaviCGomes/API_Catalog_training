using API_Catalog_training.Exceptions;
using API_Catalog_training.InputModel;
using API_Catalog_training.Services;
using API_Catalog_training.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Catalog_training.Controllers.V2 {
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase {
        private readonly IMateriaService _MateriaService;

        public MateriaController(IMateriaService MateriaService) {
            _MateriaService = MateriaService;
        }

        /// <summary>
        /// Buscar todas as matérias de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar as matérias sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de reistros por página. Mínimo 1 e máximo 50</param>
        /// <response code="200">Retorna a lista de matérias</response>
        /// <response code="204">Caso não haja matérias</response>   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MateriaViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5) {
            var Materias = await _MateriaService.Obter(pagina, quantidade);

            if(Materias.Count() == 0)
                return NoContent();

            return Ok(Materias);
        }

        /// <summary>
        /// Buscar uma matéria pelo seu Id
        /// </summary>
        /// <param name="idMateria">Id da matéria buscada</param>
        /// <response code="200">Retorna a matéria filtrada</response>
        /// <response code="204">Caso não haja matéria com este id</response>   
        [HttpGet("{idMateria:guid}")]
        public async Task<ActionResult<MateriaViewModel>> Obter([FromRoute] Guid idMateria) {
            var Materia = await _MateriaService.Obter(idMateria);

            if(Materia == null)
                return NoContent();

            return Ok(Materia);
        }

        /// <summary>
        /// Inserira uma matéria no catálogo
        /// </summary>
        /// <param name="MateriaInputModel">Dados da matéria a ser inserida</param>
        /// <response code="200">Caso a matéria seja inserida com sucesso</response>
        /// <response code="422">Caso já exista uma matéria com mesmo nome</response>   
        [HttpPost]
        public async Task<ActionResult<MateriaViewModel>> InserirMateria([FromBody] MateriaInputModel MateriaInputModel) {
            try {
                var Materia = await _MateriaService.Inserir(MateriaInputModel);

                return Ok(Materia);
            } catch(MateriaJaCadastradaException ex) {
                return UnprocessableEntity("Já existe uma matéria com este nome");
            }
        }

        /// <summary>
        /// Atualizar uma matéria no catálogo
        /// </summary>
        /// <param name="idMateria">Id da matéria a ser atualizada</param>
        /// <param name="MateriaInputModel">Novos dados para atualizar a matéria indicada</param>
        /// <response code="200">Caso a matéria seja atualizada com sucesso</response>
        /// <response code="404">Caso não exista uma matéria com este Id</response>   
        [HttpPut("{idMateria:guid}")]
        public async Task<ActionResult> AtualizarMateria([FromRoute] Guid idMateria, [FromBody] MateriaInputModel MateriaInputModel) {
            try {
                await _MateriaService.Atualizar(idMateria, MateriaInputModel);

                return Ok();
            } catch(MateriaNaoCadastradaException ex) {
                return NotFound("Não existe esta matéria");
            }
        }

        /// <summary>
        /// Atualizar o pre-requisito de uma matéria
        /// </summary>
        /// <param name="idMateria">Id da matéria a ser atualizada</param>
        /// <param name="preRequisito">Novo pre-requisito da matéria</param>
        /// <response code="200">Caso o pre-requisito seja atualizad com sucesso</response>
        /// <response code="404">Caso não exista uma matéria com este Id</response>   
        [HttpPatch("{idMateria:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarMateria([FromRoute] Guid idMateria, [FromRoute] string preRequisito) {
            try {
                await _MateriaService.Atualizar(idMateria, preRequisito);

                return Ok();
            } catch(MateriaNaoCadastradaException ex) {
                return NotFound("Não existe esta matéria");
            }
        }

        /// <summary>
        /// Excluir uma matéria
        /// </summary>
        /// <param name="idMateria">Id da matéria a ser excluída</param>
        /// <response code="200">Caso a matéria seja atualizada com sucesso</response>
        /// <response code="404">Caso não exista uma matéria com este Id</response>    
        [HttpDelete("{idMateria:guid}")]
        public async Task<ActionResult> ApagarMateria([FromRoute] Guid idMateria) {
            try {
                await _MateriaService.Remover(idMateria);

                return Ok();
            } catch(MateriaNaoCadastradaException ex) {
                return NotFound("Não existe esta matéria");
            }
        }
    }
}
