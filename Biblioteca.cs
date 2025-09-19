using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Implementação da classe BibliotecaJogos, conforme item 2 da AV1
public class Biblioteca
{
    // 1. As três listas de dados
    public List<Jogo> Jogos { get; set; }
    public List<Membro> Membros { get; set; }
    public List<Emprestimo> Emprestimos { get; set; }

    // 2. O construtor para INICIALIZAR as listas vazias
    public Biblioteca()
    {
        Jogos = new List<Jogo>();
        Membros = new List<Membro>();
        Emprestimos = new List<Emprestimo>();
    }

    // 3. O método para SALVAR os dados em ficheiro JSON, conforme item 3 da AV1
    public void Salvar()
    {
        // Configura o JSON para ser formatado e legível
        // MUDANÇA AQUI: Trocamos 'var' pelo tipo explícito 'JsonSerializerOptions' [cite: 1972]
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        // Converte este objeto inteiro (com as 3 listas dentro) para texto JSON
        string jsonString = JsonSerializer.Serialize(this, options);

        // Salva o texto no ficheiro "biblioteca.json"
        File.WriteAllText("biblioteca.json", jsonString);

        Console.WriteLine("\nDados salvos com sucesso em biblioteca.json!");
    }
    
    // 4. O método para CARREGAR os dados do ficheiro JSON, conforme item 3 da AV1
    public static Biblioteca Carregar()
    {
        string caminhoFicheiro = "biblioteca.json";

        // Verifica se o ficheiro de salvamento já existe
        if (File.Exists(caminhoFicheiro))
        {
            // Lê todo o texto do ficheiro
            string jsonString = File.ReadAllText(caminhoFicheiro);
            
            // "Desserializa": Converte o texto JSON de volta para um objeto Biblioteca
            // Adicionamos uma verificação para o caso do ficheiro estar vazio
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return new Biblioteca();
            }
            return JsonSerializer.Deserialize<Biblioteca>(jsonString);
        }
        else
        {
            // Se o ficheiro não existe (primeira vez a rodar), cria uma biblioteca nova e vazia
            return new Biblioteca();
        }
    }
}