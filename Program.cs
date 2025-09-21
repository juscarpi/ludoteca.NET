using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = Biblioteca.Carregar();

        while (true) // Laço principal do menu
        {
            Console.Clear();
            Console.WriteLine("===LUDOTECA .NET===");
            Console.WriteLine("1- Cadastrar jogo");
            Console.WriteLine("2- Cadastrar membro");
            Console.WriteLine("3- Listar jogos");
            Console.WriteLine("4- Listar membros");
            Console.WriteLine("5- Emprestar Jogo");
            Console.WriteLine("6- Devolver Jogo");
            Console.WriteLine("7- Gerar relatório");
            Console.WriteLine("0- Sair");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                Console.Clear();
                Console.WriteLine("---Cadastro de Novo Jogo---");
                while (true)
                {
                    // [AV1-5]
                    try
                    {
                        Console.Write("\nNome do Jogo (ou digite '0' para voltar): ");
                        string nome = Console.ReadLine();
                        if (nome == "0") break;

                        Console.Write("Fabricante (ou digite '0' para voltar): ");
                        string fabricante = Console.ReadLine();
                        if (fabricante == "0") break;

                        Console.Write("Ano de Lançamento (ou digite '0' para voltar): ");
                        string inputAno = Console.ReadLine();
                        if (inputAno == "0") break;
                        int ano = Convert.ToInt32(inputAno);

                        Jogo novoJogo = new Jogo(nome, fabricante, ano);
                        biblioteca.Jogos.Add(novoJogo);
                        Console.WriteLine("\nJogo cadastrado com sucesso!");
                        Console.ReadKey();
                        break;
                    }
                    catch (ArgumentException ex) { Console.WriteLine($"\nErro: {ex.Message}"); Console.ReadKey(); }
                    catch (FormatException) { Console.WriteLine("\nErro: O ano deve ser um número."); Console.ReadKey(); }
                    catch (Exception ex) { Console.WriteLine($"\nErro inesperado: {ex.Message}"); Console.ReadKey(); }
                }
            }
            else if (opcao == "2")
            {
                Console.Clear();
                Console.WriteLine("---Cadastro de Novo Membro---");
                while (true)
                {
                    // [AV1-5]
                    try
                    {
                        Console.Write("\nNome do Membro (ou digite '0' para voltar): ");
                        string nome = Console.ReadLine();
                        if (nome == "0") break;

                        Console.Write("Matricula (8 números) (ou digite '0' para voltar): ");
                        string matricula = Console.ReadLine();
                        if (matricula == "0") break;

                        Membro novoMembro = new Membro(nome, matricula);
                        biblioteca.Membros.Add(novoMembro);
                        Console.WriteLine("\nMembro cadastrado com sucesso!");
                        Console.ReadKey();
                        break;
                    }
                    catch (ArgumentException ex) { Console.WriteLine($"\nErro: {ex.Message}"); Console.ReadKey(); }
                    catch (Exception ex) { Console.WriteLine($"\nErro inesperado: {ex.Message}"); Console.ReadKey(); }
                }
            }
            else if (opcao == "3")
            {
                Console.Clear();
                Console.WriteLine("---Lista de Jogos---");
                if (biblioteca.Jogos.Count == 0)
                {
                    Console.WriteLine("Nenhum jogo cadastrado ainda.");
                }
                else
                {
                    foreach (Jogo jogo in biblioteca.Jogos)
                    {
                        string status = jogo.EstaEmprestado ? "Emprestado" : "Disponível";
                        Console.WriteLine($"Nome: {jogo.Nome} ({jogo.AnoLancamento}) - Fabricante: {jogo.Fabricante} | Status: {status}");
                    }
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else if (opcao == "4")
            {
                Console.Clear();
                Console.WriteLine("--- Lista de Membros ---");
                if (biblioteca.Membros.Count == 0)
                {
                    Console.WriteLine("Nenhum membro cadastrado ainda.");
                }
                else
                {
                    foreach (Membro membro in biblioteca.Membros)
                    {
                        Console.WriteLine($"Nome: {membro.Nome} | Matrícula: {membro.Matricula}");
                    }
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else if (opcao == "5")
            {
                while (true)
                {
                    // [AV1-5]
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("--- Registro de Novo Empréstimo ---");

                        Console.Write("Digite a matrícula do membro (ou '0' para voltar): ");
                        string matriculaInput = Console.ReadLine();
                        if (matriculaInput == "0") break;

                        Console.Write("Digite o nome do jogo (ou '0' para voltar): ");
                        string nomeJogoInput = Console.ReadLine();
                        if (nomeJogoInput == "0") break;

                        Membro membroEncontrado = biblioteca.Membros.Find(m => m.Matricula == matriculaInput);
                        if (membroEncontrado == null) throw new Exception("Membro não encontrado com a matrícula informada.");

                        Jogo jogoEncontrado = biblioteca.Jogos.Find(j => j.Nome.ToLower() == nomeJogoInput.ToLower());
                        if (jogoEncontrado == null) throw new Exception("Jogo não encontrado com o nome informado.");

                        Emprestimo novoEmprestimo = new Emprestimo(jogoEncontrado, membroEncontrado);
                        biblioteca.Emprestimos.Add(novoEmprestimo);

                        Console.WriteLine("\nEmpréstimo registrado com sucesso!");
                        Console.WriteLine($"Jogo '{jogoEncontrado.Nome}' emprestado para '{membroEncontrado.Nome}'.");
                        Console.ReadKey();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nErro ao registrar empréstimo: {ex.Message}");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                }
            }
            else if (opcao == "6")
            {
                while (true)
                {
                    // [AV1-5]
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("--- Registro de Devolução ---");

                        Console.Write("Digite o nome do jogo a ser devolvido (ou '0' para voltar): ");
                        string nomeJogoInput = Console.ReadLine();
                        if (nomeJogoInput == "0") break;
                        
                        Emprestimo emprestimoAtivo = biblioteca.Emprestimos.Find(e =>
                            e.JogoEmprestado.Nome.ToLower() == nomeJogoInput.ToLower() &&
                            e.DataDevolucao == null);

                        if (emprestimoAtivo == null) throw new Exception("Não foi encontrado um empréstimo ativo para este jogo.");

                        emprestimoAtivo.RegistrarDevolucao();

                        Console.WriteLine("\nDevolução registrada com sucesso!");
                        Console.ReadKey();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\nErro ao registrar devolução: {ex.Message}");
                        Console.WriteLine("Pressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                    }
                }
            }
            else if (opcao == "7")
            {
                Console.Clear();
                Console.WriteLine("--- Geração de Relatório ---");
                Console.WriteLine("\nFuncionalidade completa de geração de relatório será implementada na AV2.");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
            else if (opcao == "0")
            {
                biblioteca.Salvar();
                Console.WriteLine("Obrigado por usar o sistema!");
                Console.ReadKey();
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                Console.ReadKey();
            }
        }
    }
}