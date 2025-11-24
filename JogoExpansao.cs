using System;

public class JogoExpansao : Jogo
{
    public string JogoOriginal { get; private set; }

    public JogoExpansao(string nome, string fabricante, int ano, string jogoOriginal) 
        : base(nome, fabricante, ano)
    {
        JogoOriginal = jogoOriginal;
    }
}