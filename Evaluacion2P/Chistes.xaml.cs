using Newtonsoft.Json;

namespace Evaluacion2P;

public partial class Chistes : ContentPage
{
    private readonly HttpClient _httpClient = new();

    public Chistes()
    {
        InitializeComponent();
        ObtenerChisteAsync();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await ObtenerChisteAsync();
    }

    private async Task ObtenerChisteAsync()
    {
        try
        {
            ChisteLabel.Text = "Aqui va el chiste xd";

            var response = await _httpClient.GetStringAsync("https://official-joke-api.appspot.com/random_joke");
            var chiste = JsonConvert.DeserializeObject<ChisteModel>(response);

            ChisteLabel.Text = $"{chiste.Setup}\n\n{chiste.Punchline}";
        }
        catch (Exception ex)
        {
            ChisteLabel.Text = $"Error: {ex.Message}";
        }
    }

    public class ChisteModel
    {
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }
}