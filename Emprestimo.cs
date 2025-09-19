using System;

public class Emprestimo
{
    public Jogo JogoEmprestado { get; private set; }
    public Membro Membro { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime? DataDevolucao { get; private set; }


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

        // Atualização do status do jogo
        jogo.Emprestar();
    } 

    public void RegistrarDevolucao()
    {
        // Define a data de devolução como a data e hora atuais
        DataDevolucao = DateTime.Now;
        
        // Avisa o objeto 'Jogo' que ele está disponível novamente
        JogoEmprestado.Devolver();
    }
}