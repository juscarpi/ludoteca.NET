using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// Implementação da classe BibliotecaJogos, conforme item 2 da AV1
public class Biblioteca
{
    // 1. As três listas de dados - MUDANÇA AQUI: set é privado para melhor encapsulamento.
    public List<Jogo> Jogos { get; private set; }
    public List<Membro> Membros { get; private set; }
    public List<Emprestimo> Emprestimos { get; private set; }

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
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        // Converte este objeto inteiro (com as 3 listas dentro) para texto JSON
        // [AV1-3]
        string jsonString = JsonSerializer.Serialize(this, options);

        // Salva o texto no ficheiro "biblioteca.json"
        File.WriteAllText("biblioteca.json", jsonString);

        Console.WriteLine("\nDados salvos com sucesso em biblioteca.json!");
    }
    
    // 4. O método para CARREGAR os dados do ficheiro JSON, conforme item 3 da AV1
    public static Biblioteca Carregar()
    {
        string caminhoFicheiro = "biblioteca.json";

        if (File.Exists(caminhoFicheiro))
        {
            string jsonString = File.ReadAllText(caminhoFicheiro);
            
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return new Biblioteca();
            }
            
            // "Desserializa": Converte o texto JSON de volta para um objeto Biblioteca
            // [AV1-3]
            return JsonSerializer.Deserialize<Biblioteca>(jsonString);
        }
        else
        {
            return new Biblioteca();
        }
    }
}