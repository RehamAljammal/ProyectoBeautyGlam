using System.Threading.Tasks;
using System.Web.Mvc;

public class ChatSkincareController : Controller
{
    private readonly OpenAIService _openAI;

    public ChatSkincareController()
    {
        _openAI = new OpenAIService();
    }

    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Preguntar(string mensaje)
    {
        var respuesta = await _openAI.ObtenerRecomendacion(mensaje);

        ViewBag.Respuesta = respuesta;
        ViewBag.Pregunta = mensaje;

        return View("Index");
    }
}