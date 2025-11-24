using System;

public class Emprestimo
{
    public Jogo JogoEmprestado { get; private set; }
    public Membro Membro { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime? DataDevolucao { get; private set; }
    
    public DateTime DataDevolucaoPrevista { get; private set; }

    public Emprestimo(Jogo jogo, Membro membro)
    {
        if (jogo.EstaEmprestado)
        {
            throw new InvalidOperationException("Este jogo já está emprestado.");
        }

        JogoEmprestado = jogo;
        Membro = membro;
        DataEmprestimo = DateTime.Now;

        DataDevolucaoPrevista = DataEmprestimo.AddDays(jogo.PrazoDevolucaoDias);

        jogo.Emprestar();
    } 

    public void RegistrarDevolucao()
    {
        DataDevolucao = DateTime.Now;
        JogoEmprestado.Devolver();
    }
}