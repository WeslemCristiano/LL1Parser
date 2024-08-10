using System;
using System.Collections.Generic;
using System.IO;

class ParseTable
{
    private Dictionary<string, Dictionary<string, string>> table;

    public ParseTable(string filePath)
    {
        table = new Dictionary<string, Dictionary<string, string>>();
        LoadTable(filePath);
    }

    private void LoadTable(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var headers = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            var cells = lines[i].Split(',');
            var nonTerminal = cells[0].Trim();
            table[nonTerminal] = new Dictionary<string, string>();

            for (int j = 1; j < cells.Length; j++)
            {
                if (!string.IsNullOrEmpty(cells[j].Trim()))
                {
                    table[nonTerminal][headers[j].Trim()] = cells[j].Trim();
                    Console.WriteLine($"Adicionando produção: {nonTerminal} -> {headers[j].Trim()} : {cells[j].Trim()}");
                }
            }
        }
    }

    public string GetProduction(string nonTerminal, string terminal)
    {
        if (table.ContainsKey(nonTerminal) && table[nonTerminal].ContainsKey(terminal))
        {
            return table[nonTerminal][terminal];
        }
        return string.Empty;
    }
}