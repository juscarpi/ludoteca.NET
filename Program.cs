using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var jogos = new List<Jogo>();
        var membros = new List<Membro>();

        while (true) //menu
        {
            Console.Clear();
            Console.WriteLine("===LUDOTECA .NET===");
            Console.WriteLine("1- Cadastrar jogo");
            Console.WriteLine("2- Cadastrar membro");
            Console.WriteLine("3- Listar jogos");
            Console.WriteLine("4- Listar membros");
            Console.WriteLine("0- Sair");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();// le a escolha do usuario

            if (opcao == "1")
            {
                Console.Clear();
                Console.WriteLine("---Cadastro de Novo Jogo---\n");
                Console.WriteLine("Digite '0' para voltar ao menu.\n");
                while (true)//Para capturar os erros de validação no construtor da classe Jogo
                {
                    try
                    {
                        Console.Write("Nome do Jogo: ");
                        string nome = Console.ReadLine();
                        if (nome == "0") break;

                        Console.Write("Fabricante: ");
                        string fabricante = Console.ReadLine();
                        if (fabricante == "0") break;

                        Console.Write("Ano de Lançamento : ");
                        string inputAno = Console.ReadLine(); 
                        if (inputAno == "0") break;           
                        int ano = Convert.ToInt32(inputAno);   

                        Jogo novoJogo = new Jogo(nome, fabricante, ano);
                        jogos.Add(novoJogo);
                        Console.WriteLine("Jogo cadastrado com sucesso!");

                        Console.ReadKey();
                        break;
                    }
                    catch (ArgumentException ex) 
                    {
                        Console.WriteLine($"\nErro de validação: {ex.Message}");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nErro de formato: O ano de lançamento deve ser um número.");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        // Mensagem genérica para qualquer outro erro que não previmos
                        Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message}");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                }
            }

            else if (opcao == "2")
            {
                Console.Clear();
                Console.WriteLine("---Cadastro de Novo Membro---\n");
                Console.Write("Digite '0' para voltar ao menu.");
                while (true)//Para capturar os erros de validação no construtor da classe Membro
                {
                    try
                    {                       
                        Console.Write("\nNome do Membro: ");
                        string nome = Console.ReadLine();
                        if (nome == "0") break;

                        Console.Write("Matricula: ");
                        string matricula = Console.ReadLine();
                        if (nome == "0") break;

                        Membro novoMembro = new Membro(nome, matricula);
                        membros.Add(novoMembro);
                        Console.Write("Membro cadastrado com sucesso!");
                        Console.ReadKey();
                        break;
                    }
                    catch (ArgumentException ex) 
                    {
                        Console.WriteLine($"\nErro de validação: {ex.Message}");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                }
            }

            else if (opcao == "3")
            {
                Console.Clear();
                Console.WriteLine("---Lista de Jogos---\n");
                if (jogos.Count == 0)
                {
                    Console.WriteLine("Nenhum jogo cadastrado ainda.");
                }
                else
                {
                    foreach (var jogo in jogos)
                    {
                        string status = jogo.EstaEmprestado ? "Emprestado" : "Disponivel";
                        Console.WriteLine($"Nome: {jogo.Nome} ({jogo.AnoLancamento}) - Fabricante: {jogo.Fabricante} | Status {status}");
                    }
                }
            }

            else if (opcao == "0")
            {
                Console.WriteLine("Obrigado por usar o sistema!");
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}