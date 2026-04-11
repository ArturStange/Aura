using Aura.Web.Models;
using Xunit;

namespace Aura.Tests;

public class GestaoEnergiaTests
{
    [Fact]
    public void Teste2_CaminhoFeliz_DeveSomarCustoDeTodasAsTarefasPendentes()
    {
        // Arrange (Preparação do cenário)
        var tarefas = new List<Tarefa>
        {
            new Tarefa { Titulo = "Responder e-mails curtos", CustoEnergia = 1 },
            new Tarefa { Titulo = "Reunião de alinhamento", CustoEnergia = 3 }
        };

        // Act (Ação: a mesma lógica que o nosso Dashboard usa para calcular)
        var energiaGasta = tarefas.Where(t => !t.Concluida).Sum(t => t.CustoEnergia);

        // Assert (Verificação)
        // 1 + 3 = 4 colheres. Se der 4, o teste passa.
        Assert.Equal(4, energiaGasta);
    }

    [Fact]
    public void Teste3_CasoLimite_TarefasConcluidasNaoDevemConsumirEnergia()
    {
        // Arrange (Cenário: Uma tarefa já foi concluída, outra não)
        var tarefas = new List<Tarefa>
        {
            new Tarefa { Titulo = "Fazer café", CustoEnergia = 1, Concluida = true },
            new Tarefa { Titulo = "Focar no código do projeto", CustoEnergia = 5, Concluida = false }
        };

        // Act
        var energiaGasta = tarefas.Where(t => !t.Concluida).Sum(t => t.CustoEnergia);

        // Assert
        // Apenas a tarefa de custo 5 está pendente, logo a energia gasta atual deve ser 5.
        Assert.Equal(5, energiaGasta);
    }
}