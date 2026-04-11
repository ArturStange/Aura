using System.ComponentModel.DataAnnotations;

namespace Aura.Web.Models;

public class Tarefa
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Dê um nome à tarefa.")]
    public string Titulo { get; set; } = string.Empty;

    // A regra de negócio não-genérica: Custo em 'Colheres' (Energia)
    // 1 = Leve, 3 = Moderada, 5 = Exaustiva
    [Range(1, 5, ErrorMessage = "O custo deve ser entre 1 e 5 colheres.")]
    public int CustoEnergia { get; set; } = 1;

    public bool Concluida { get; set; } = false;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}