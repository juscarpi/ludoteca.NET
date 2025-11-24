using System;

// [AV2-2] Herança: JogoPremium é um tipo especializado de Jogo
public class JogoPremium : Jogo
{
    // O construtor recebe os dados e repassa para a classe pai (base)
    public JogoPremium(string nome, string fabricante, int ano)
        : base(nome, fabricante, ano)
    {
        // No futuro, podemos colocar regras especiais aqui,
        // como um valor de multa mais alto.
    }
    
    // [AV2-4] Polimorfismo: Alteramos o comportamento padrão
    public override int PrazoDevolucaoDias
    {
        get { return 3; } // Premium devolve em apenas 3 dias!
    }
}