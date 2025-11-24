using System;

public class Emprestimo
{
    public Jogo JogoEmprestado { get; private set; }
    public Membro Membro { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime? DataDevolucao { get; private set; }
    
    // [NOVO] Propriedade para guardar a data calculada
    public DateTime DataDevolucaoPrevista { get; private set; }

    public Emprestimo(Jogo jogo, Membro membro)
    {
        // Validação
        if (jogo.EstaEmprestado)
        {
            throw new InvalidOperationException("Este jogo já está emprestado.");
        }

        // Atribuição dos dados
        JogoEmprestado = jogo;
        Membro = membro;
        DataEmprestimo = DateTime.Now;

        // [AV2-4] POLIMORFISMO AQUI:
        // O sistema calcula a data sozinho baseada no tipo do jogo.
        // Se for Jogo Comum -> soma 7 dias.
        // Se for Jogo Premium -> soma 3 dias.
        DataDevolucaoPrevista = DataEmprestimo.AddDays(jogo.PrazoDevolucaoDias);

        // Atualização do status do jogo
        jogo.Emprestar();
    } 

    public void RegistrarDevolucao()
    {
        DataDevolucao = DateTime.Now;
        JogoEmprestado.Devolver();
    }
}