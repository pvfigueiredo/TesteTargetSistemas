namespace TesteTargetSistemas.Exercicios.FaturamentoMensal;

public enum Estado 
{
    SP = 1,
    RJ = 2,
    MG = 3,
    ES = 4,
    Outros = 5
}
public class FaturamentoEstado : IComparable
{
    public Estado Estado { get; set; } = default!;
    public decimal Valor { get; set; }

    public FaturamentoEstado(Estado estado, decimal valor)
    {
        Estado = estado;
        Valor = valor;
    }
    public int CompareTo(object? obj)
    {
        if (obj == null) { return -1; }
        var f = (FaturamentoEstado) obj;
        return decimal.Compare(Valor, f.Valor);
    }

    public override string ToString()
    {
        return $"{Estado.ToString()}  - R${Valor}";
    }
}

public class FaturamentoMensal
{
    public List<FaturamentoEstado> FaturamentoEstados { get; set; } = new ();
    public decimal Total { get; private set; }

    public FaturamentoMensal()
    {
        FaturamentoEstados.Add( new (Estado.SP, 67836.43m));
        FaturamentoEstados.Add( new (Estado.RJ, 36678.66m));
        FaturamentoEstados.Add( new (Estado.MG, 29229.88m));
        FaturamentoEstados.Add( new (Estado.ES, 27165.48m));
        FaturamentoEstados.Add( new (Estado.Outros, 19849.53m));
        Total = FaturamentoEstados.Sum(x => x.Valor);
    }

    public decimal GetPercentualByEstado(Estado estado)
    {        
        var valorEstado = FaturamentoEstados.Find(x => x.Estado == estado);
        if (valorEstado == null || valorEstado.Valor == 0m) {return 0;}
        return Total / valorEstado.Valor * 100;
    }
}
