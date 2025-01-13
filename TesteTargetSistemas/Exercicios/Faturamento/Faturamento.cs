using System.Text.Json;
using System.Text.Json.Serialization;

namespace TesteTargetSistemas.Exercicios.Faturamento;

public class Faturamento : IComparable
{
    public int dia { get; set; }
    public decimal valor { get; set; }

    public int CompareTo(object? obj)
    {
        if (obj == null) { return -1;}
        Faturamento f = (Faturamento) obj;
        return decimal.Compare(valor, f.valor);
    }

    public override string? ToString()
    {
        return $"Dia: {dia} - Valor:{valor}";
    }
}

public class CalculoFaturamento
{
    private List<Faturamento> _faturamentos;
    public List<Faturamento> Faturamentos { get => _faturamentos; }
    public decimal Media { get; private set; } = decimal.Zero;
    public CalculoFaturamento()
    {
        using (StreamReader dados = new StreamReader("Exercicios/Faturamento/Dados/dados.json"))
        {
            string json = dados.ReadToEnd();
            _faturamentos = JsonSerializer
                                .Deserialize<List<Faturamento>>(json)
                                ?.Where(x => x.valor != 0).ToList() 
                                ?? new List<Faturamento>();

            if (_faturamentos.Count == 0) {throw new FileLoadException("Não foi possível carregar o arquivo dados.js");}
        }

        CalculaMedia();
    }

    public Faturamento? GetMenorFaturamento()
    {
        return _faturamentos.Min(f => f);
    }

    public Faturamento? GetMaiorFaturamento()
    {
        return _faturamentos.Max(f => f);
    }

    private void CalculaMedia()
    {
        Media = _faturamentos.Sum(x => x.valor) / _faturamentos.Count;
    }

    public List<Faturamento> ListaFaturamentoAcimaDaMedia()
    {        
        return _faturamentos.Where(x => x.valor > Media).ToList();
    }
}
