public class Membro
{
    public string Nome { get; private set; }
    public string Matricula { get; private set; }

    public Membro(string nome, string matricula)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentException("O nome do membro não pode estar vazio.\n");
        }
        foreach (char caractere in nome)
        {
            if (char.IsDigit(caractere))
            {
                throw new ArgumentException("O nome não pode conter números.\n");
            }
        }

        if (string.IsNullOrWhiteSpace(matricula))
        {
            throw new ArgumentException("A matricula do membro não pode ser vazia.\n");
        }
        if (matricula.Length != 8)//Verifica se a matricula tem 8 números(matricula padrão unifeso)
        {
            throw new ArgumentException("A matricula deve conter 8 números.\n");
        }
        foreach (char caractere in matricula)
        {
            if (!char.IsDigit(caractere))
            {
                throw new ArgumentException("A matricula deve conter apenas números.\n");
            }
        }

        Nome = nome;
        Matricula = matricula;
    }
}