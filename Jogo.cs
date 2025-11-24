using System;
public class Jogo
{
    public string Nome { get; private set; }
    public string Fabricante { get; private set; }
    public int AnoLancamento { get; private set; }
    public bool EstaEmprestado { get; private set; }

    public Jogo(string nome, string fabricante, int anoLancamento)
    {
        if (string.IsNullOrWhiteSpace(nome))//Valida se foi preenchido
        {
            throw new ArgumentException("O nome do jogo não pode ser vazio.\n");
        }

        int anoAtual = DateTime.Now.Year;
        if (anoLancamento < 1000 || anoLancamento > anoAtual)//Valida se foi a data está entre o ano 1000 e o ano atual
        {
            throw new ArgumentException($"O ano de lançamento deve ser um valor entre 1000 e {anoAtual}.\n");
        }

        //Se passar nas validações, atribuimos os valores
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
    
    // [AV2-4] Polimorfismo: Propriedade virtual que pode ser sobrescrita
    public virtual int PrazoDevolucaoDias 
    { 
        get { return 7; } // Padrão: 7 dias
    }

}

