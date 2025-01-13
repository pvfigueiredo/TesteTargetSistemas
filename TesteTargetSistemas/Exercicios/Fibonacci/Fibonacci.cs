using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace TesteTargetSistemas.Exercicios.Fibonacci;

public class Fibonacci
{
    private List<int> _sequenciaFibonacci;
    private long _limite = 0;
    public Fibonacci(long limite)
    {        
        _limite = limite;
        _sequenciaFibonacci = new List<int>{0, 1};
    }
    public bool Calcula()
    {
        CriaSequenciaFibonacci();        
        return _sequenciaFibonacci.Any(x => x ==_limite);
    }

    private void CriaSequenciaFibonacci()
    {
        int i = 1;
        var soma = _sequenciaFibonacci[0] + _sequenciaFibonacci[1];
        while (soma <= _limite)
        {
             _sequenciaFibonacci.Add(soma);
             soma += _sequenciaFibonacci[i];
             i++;
        }

    }
}
