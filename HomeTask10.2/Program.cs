using System.Text;

string line;
using (StreamReader sr = new StreamReader(@"forbidden_words.txt"))
    line = sr.ReadLine();
Dictionary<string, int> dictionary = new Dictionary<string, int>();
foreach (var word in line.Split(' '))
{
    dictionary.Add(word, 1);
}

string text;
using (StreamReader str = new StreamReader(@"text.txt"))
    text = str.ReadToEnd().ToLower();
foreach (var word in dictionary.Keys)
{
    if (text.Contains(word))
    {
        string censored = new StringBuilder().Insert(0, "*", word.Length).ToString();
        text = text.Replace(word, censored);

    }
}
Console.WriteLine(text);


