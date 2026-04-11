using System.ComponentModel.DataAnnotations;
using Aura.Web.Models;
using Xunit;

namespace Aura.Tests;

public class TarefaValidacaoTests
{
    [Fact]
    public void Tarefa_ComCustoInvalido_DeveFalharNaValidacao()
    {
        var tarefa = new Tarefa { Titulo = "Tarefa Teste", CustoEnergia = 10 }; // Máximo é 5
        var context = new ValidationContext(tarefa);
        var resultados = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(tarefa, context, resultados, true);

        Assert.False(isValid);
        Assert.Contains(resultados, r => r.ErrorMessage.Contains("entre 1 e 5 colheres"));
    }
}