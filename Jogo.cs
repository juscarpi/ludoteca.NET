using System;
public class Jogo
{
    public string Nome { get; private set; }
    public string Fabricante { get; private set; }
    public int AnoLancamento { get; private set; }
    public bool EstaEmprestado { get; private set; }

    public Jogo(string nome, string fabricante, int anoLancamento)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do jogo não pode ser vazio.\n");
        }

        int anoAtual = DateTime.Now.Year;
        if (anoLancamento < 1000 || anoLancamento > anoAtual)
        {
            throw new ArgumentException($"O ano de lançamento deve ser um valor entre 1000 e {anoAtual}.\n");
        }

        Nome = nome;
        Fabricante = fabricante;
        AnoLancamento = anoLancamento;
        EstaEmprestado = false;
    }
    public void Emprestar()
    {
        if (EstaEmprestado)
        {
            throw new InvalidOperationException("Este jogo já está emprestado.\n");
        }
        EstaEmprestado = true;
    }

    public void Devolver()
    {
        EstaEmprestado = false;
    }
    
    public virtual int PrazoDevolucaoDias 
    { 
        get { return 7; } 
    }

}

