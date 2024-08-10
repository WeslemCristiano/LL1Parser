using System.IO;

class InputReader
{
    public string Input { get; private set; }

    public InputReader(string filePath)
    {
        Input = File.ReadAllText(filePath).Trim() + "$";
    }
}