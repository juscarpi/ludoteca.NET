using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Biblioteca
{
    public List<Jogo> Jogos { get; private set; }
    public List<Membro> Membros { get; private set; }
    public List<Emprestimo> Emprestimos { get; private set; }

    public Biblioteca()
    {
        Jogos = new List<Jogo>();
        Membros = new List<Membro>();
        Emprestimos = new List<Emprestimo>();
    }

    public void Salvar()
    {
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        string jsonString = JsonSerializer.Serialize(this, options);

        File.WriteAllText("biblioteca.json", jsonString);

        Console.WriteLine("\nDados salvos com sucesso em biblioteca.json!");
    }
    
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
            
            return JsonSerializer.Deserialize<Biblioteca>(jsonString);
        }
        else
        {
            return new Biblioteca();
        }
    }
}