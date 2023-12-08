using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Web.Requests;
public record ArtistaRequest([Required] string nome, [Required] string bio,string? fotoPerfil)
{
    public override string ToString()
    {
        return $"{this.nome}";
    }
}

