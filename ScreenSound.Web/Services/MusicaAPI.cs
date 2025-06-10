using ScreenSound.Web.Requests;
using ScreenSound.Web.Response;
using System.Net.Http.Json;

namespace ScreenSound.Web.Services;

public class MusicaAPI
{

    private readonly HttpClient _httpClient;
    public MusicaAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }
    public async Task<ICollection<MusicaResponse>?> GetMusicasAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("/Musicas");
        
    }

    public async Task<MusicaResponse?> GetMusicaPorNomeAsync(string nome)
    {
        return await _httpClient.GetFromJsonAsync<MusicaResponse>($"/Musicas/{nome}");

    }

    public async Task AddMusicaAsync(MusicaRequest musicaRequest)
    {
       
        var response = await _httpClient.PostAsJsonAsync("/Musicas", musicaRequest);
        
    }
    public async Task DeleteMusicaAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/Musicas/{id}");
        
    }

    public async Task EditarMusicaAsync(MusicaRequestEdit musicaRequestEdit)
    {
        await _httpClient.PutAsJsonAsync($"/Musicas", musicaRequestEdit);

    }


}
