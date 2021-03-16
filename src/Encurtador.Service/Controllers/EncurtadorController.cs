using System.Threading.Tasks;
using Encurtador.Service.Filters;
using Encurtador.Service.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encurtador.Service.Controllers
{
    [Route("/")]
    [ApiController]
    public class EncurtadorController : ControllerBase
    {
        private readonly IEncurtadorRepository repo;
        public EncurtadorController(IEncurtadorRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("{http}")]
        public async Task<IActionResult> Get(string http)
        {
            try
            {
                var resposta = await repo.GetByHttpAsync(http);
                return RedirectPermanent(resposta.LinkOrig);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
        [HttpPost]
        [ApiKeyAuth]
        public async Task<IActionResult> Post(string original)
        {
            try
            {
                if (!original.ToLower().Contains("http://") || !original.ToLower().Contains("https://"))
                {
                    original = $"http://{original}";
                }
                string resposta = EncurtadorEntity.Encurtado();
                EncurtadorEntity salvar = new EncurtadorEntity();
                salvar.LinkOrig = original;
                var resp = repo.GetByHttpAsync(resposta);
                while (resp.Result != null)
                {
                    resposta = EncurtadorEntity.Encurtado();
                    resp = repo.GetByHttpAsync(resposta);
                }
                salvar.LinkEncurt = resposta;
                repo.Add<EncurtadorEntity>(salvar);
                if (await repo.SaveChangesAsync())
                {
                    return Created($"/api/evento/{salvar.LinkEncurt}", salvar);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();


        }
    }
}