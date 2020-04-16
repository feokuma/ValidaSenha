using Microsoft.AspNetCore.Mvc;
using ValidaSenha.Models;
using ValidaSenha.Validators;

namespace ValidaSenha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidaSenhaController : ControllerBase
    {
        private readonly SenhaValidator _senhaValidator;
        public ValidaSenhaController(SenhaValidator senhaValidator)
        {
            _senhaValidator = senhaValidator;
        }

        /// <summary>
        /// Valida senha
        /// </summary>
        /// <remarks>
        /// ## Regras para validação da senha
        /// * Nove ou mais caracteres
        /// * Ao menos 1 dígito
        /// * Ao menos 1 letra minúscula
        /// * Ao menos 1 letra maiúscula
        /// * Ao menos 1 caractere especial
        /// </remarks>
        /// <param name="input"></param>  
        /// <response code="200">Caso objeto seja válido, mesmo que a senha não</response>
        /// <response code="400">Caso objeto passado como parâmetro seja inválido</response>
        [HttpPost]
        public ActionResult Post(Senha senha)
        {
            return Ok(new { output = _senhaValidator.éValida(senha) });
        }
    }
}
