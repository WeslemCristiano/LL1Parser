using System;
using System.Collections.Generic;

class LL1Parser
{
    private ParseTable parseTable;
    private string startSymbol;
    private string input;

    public LL1Parser(ParseTable parseTable, InputReader inputReader, string startSymbol)
    {
        this.parseTable = parseTable;
        this.startSymbol = startSymbol;
        this.input = inputReader.Input;
    }

    public void Parse()
    {
        Stack<string> stack = new Stack<string>();
        stack.Push("$");
        stack.Push(startSymbol);

        int inputIndex = 0;

        while (stack.Count > 0)
        {
            string top = stack.Peek();
            string currentInput = input[inputIndex].ToString();

            Console.WriteLine($"Topo da pilha: {top}, Entrada atual: {currentInput}");

            if (top == currentInput)
            {
                stack.Pop();
                inputIndex++;
            }
            else if (parseTable.GetProduction(top, currentInput) != string.Empty)
            {
                stack.Pop();
                string production = parseTable.GetProduction(top, currentInput);
                Console.WriteLine($"Produção encontrada: {top} -> {production}");
                if (production != "ε")
                {
                    var symbols = production.Split(' ');
                    for (int i = symbols.Length - 1; i >= 0; i--)
                    {
                        stack.Push(symbols[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Erro: Nenhuma produção encontrada para {top} com entrada {currentInput}");
                return;
            }
        }

        if (inputIndex == input.Length)
        {
            Console.WriteLine("Sucesso: Entrada aceita.");
        }
        else
        {
            Console.WriteLine("Erro: Entrada não consumida completamente.");
        }
    }
}