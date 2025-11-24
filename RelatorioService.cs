using System;
using System.Collections.Generic;

// [AV2-1]
public class RelatorioService
{
    public void ListarJogos(List<Jogo> jogos)
    {
        Console.Clear();
        Console.WriteLine("---Lista de Jogos---");
        if (jogos.Count == 0)
        {
            Console.WriteLine("Nenhum jogo cadastrado ainda.");
        }
        else
        {
            foreach (Jogo jogo in jogos)
            {
                string status = jogo.EstaEmprestado ? "Emprestado" : "Disponível";
                Console.WriteLine($"Nome: {jogo.Nome} ({jogo.AnoLancamento}) - Fabricante: {jogo.Fabricante} | Status: {status}");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public void ListarMembros(List<Membro> membros)
    {
        Console.Clear();
        Console.WriteLine("--- Lista de Membros ---");
        if (membros.Count == 0)
        {
            Console.WriteLine("Nenhum membro cadastrado ainda.");
        }
        else
        {
            foreach (Membro membro in membros)
            {
                Console.WriteLine($"Nome: {membro.Nome} | Matrícula: {membro.Matricula}");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    // [AV2] Relatório de Empréstimos para conferir os prazos
    public void ListarEmprestimos(List<Emprestimo> emprestimos)
    {
        Console.Clear();
        Console.WriteLine("--- Relatório de Empréstimos Ativos ---");
        
        if (emprestimos.Count == 0)
        {
            Console.WriteLine("Nenhum empréstimo ativo no momento.");
        }
        else
        {
            foreach (Emprestimo emp in emprestimos)
            {
                // Aqui vamos mostrar a data calculada pelo Polimorfismo!
                string dataFormatada = emp.DataDevolucaoPrevista.ToShortDateString();
                
                Console.WriteLine($"Jogo: {emp.JogoEmprestado.Nome}");
                Console.WriteLine($"Membro: {emp.Membro.Nome}");
                Console.WriteLine($"Data Empréstimo: {emp.DataEmprestimo.ToShortDateString()}");
                Console.WriteLine($"Devolução Prevista: {dataFormatada}");
                Console.WriteLine("------------------------------------------------");
            }
        }
        
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}