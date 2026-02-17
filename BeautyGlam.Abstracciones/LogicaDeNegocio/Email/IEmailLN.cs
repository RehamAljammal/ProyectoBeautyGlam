using System.Threading.Tasks;

namespace BeautyGlam.Abstracciones.LogicaDeNegocio.Email
{
    public interface IEmailLN
    {
        Task Enviar(string para, string asunto, string htmlBody);
    }
}
