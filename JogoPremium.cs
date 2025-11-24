using System;

public class JogoPremium : Jogo
{
    public JogoPremium(string nome, string fabricante, int ano)
        : base(nome, fabricante, ano)
    {
    }
    
    public override int PrazoDevolucaoDias
    {
        get { return 3; }
    }
}