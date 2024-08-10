using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Uso: LL1Parser <caminho_tabela_csv> <caminho_entrada> <simbolo_inicial>");
            return;
        }

        ParseTable parseTable = new ParseTable(args[0]);
        InputReader inputReader = new InputReader(args[1]);
        LL1Parser parser = new LL1Parser(parseTable, inputReader, args[2]);
        parser.Parse();
    }
}