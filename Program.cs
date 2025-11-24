using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Biblioteca biblioteca = Biblioteca.Carregar();
        RelatorioService relatorioService = new RelatorioService();

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
                    try
                    {
                        // 1. Dados comuns a todos os jogos
                        Console.Write("\nNome do Jogo (ou digite '0' para voltar): ");
                        string nome = Console.ReadLine();
                        if (nome == "0") break;

                        Console.Write("Fabricante: ");
                        string fabricante = Console.ReadLine();

                        Console.Write("Ano de Lançamento: ");
                        int ano = Convert.ToInt32(Console.ReadLine());

                        // 2. Pergunta o Tipo (Aqui entra a Herança/Polimorfismo)
                        Console.WriteLine("\nSelecione o Tipo de Jogo:");
                        Console.WriteLine("1 - Comum");
                        Console.WriteLine("2 - Premium (Lançamento/Raro)");
                        Console.WriteLine("3 - Expansão (DLC/Add-on)");
                        Console.Write("Tipo: ");
                        string tipo = Console.ReadLine();

                        // Variável polimórfica: 'novoJogo' pode ser qualquer um dos 3 tipos!
                        Jogo novoJogo = null;

                        if (tipo == "1")
                        {
                            novoJogo = new Jogo(nome, fabricante, ano);
                        }
                        else if (tipo == "2")
                        {
                            novoJogo = new JogoPremium(nome, fabricante, ano);
                        }
                        else if (tipo == "3")
                        {
                            Console.Write("Qual o jogo original desta expansão?: ");
                            string jogoOriginal = Console.ReadLine();
                            novoJogo = new JogoExpansao(nome, fabricante, ano, jogoOriginal);
                        }
                        else
                        {
                            Console.WriteLine("Tipo inválido! Cadastrando como Comum por padrão.");
                            novoJogo = new Jogo(nome, fabricante, ano);
                        }

                        // 3. Adiciona à lista (Polimorfismo: a lista aceita filhos de Jogo)
                        biblioteca.Jogos.Add(novoJogo);
                        Console.WriteLine($"\nJogo '{novoJogo.Nome}' cadastrado com sucesso!");
                        Console.ReadKey();
                        break;
                    }
                    catch (FormatException) { Console.WriteLine("\nErro: O ano deve ser um número."); Console.ReadKey(); }
                    catch (Exception ex) { Console.WriteLine($"\nErro: {ex.Message}"); Console.ReadKey(); }
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
                relatorioService.ListarJogos(biblioteca.Jogos);
            }

            else if (opcao == "4")
            {
                relatorioService.ListarMembros(biblioteca.Membros);
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
                // Agora o RelatorioService cuida de tudo!
                // Ele vai listar os empréstimos e mostrar as datas calculadas (3 ou 7 dias).
                relatorioService.ListarEmprestimos(biblioteca.Emprestimos);
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