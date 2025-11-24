using System;

// [AV2-2] Herança
public class JogoExpansao : Jogo
{
    // Expansões geralmente precisam saber a qual jogo original elas pertencem.
    public string JogoOriginal { get; private set; }

    public JogoExpansao(string nome, string fabricante, int ano, string jogoOriginal) 
        : base(nome, fabricante, ano)
    {
        JogoOriginal = jogoOriginal;
    }
}