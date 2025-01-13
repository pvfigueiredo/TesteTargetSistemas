namespace TesteTargetSistemas.Exercicios.ReverteString;

public static class InverteString
{
    public static string Inverte(string word)
    {
        var result = string.Empty;
        var len = word.Length;
        for (var i = len - 1; i >= 0; i--)
        {
            result += word[i];
        }
        return result;
    }
}
