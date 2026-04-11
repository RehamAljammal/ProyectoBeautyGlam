using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;

public class OpenAIService
{
    private readonly string apiKey;

    public OpenAIService()
    {
        apiKey = ConfigurationManager.AppSettings["OpenAI:ApiKey"];
    }

    public async Task<string> ObtenerRecomendacion(string mensajeUsuario)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var request = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                    new {
                        role = "system",
                        content = @"Eres un experto en skincare.
                        Recomienda:
                        - Ingredientes
                        - Rutina
                        - Qué evitar
                        No des diagnósticos médicos.
                        Responde en español."
                    },
                    new {
                        role = "user",
                        content = mensajeUsuario
                    }
                },
                max_tokens = 300
            };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var result = await response.Content.ReadAsStringAsync();

            dynamic data = JsonConvert.DeserializeObject(result);

            return data.choices[0].message.content;
        }
    }
}