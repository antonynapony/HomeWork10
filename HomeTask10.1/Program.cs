string line;
using (StreamReader text = new StreamReader(@"text.txt"))
    while ((line = text.ReadLine()) != null)
    {
        var array = line.ToLower().Split(new char[] { ' ', ',', '.', '?', '!', ':' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        for (int i = 0; i < array.Length; i++)
        {
            if (dictionary.ContainsKey(array[i]))
            {
                dictionary[array[i]]++;
            }
            else
            {
                dictionary.Add(array[i], 1);
            }
        }
        var frequent = dictionary.OrderBy(s => s.Value).Last().Key;
        File.AppendAllText(@"newText.txt", $"{frequent} {dictionary[frequent]}\n");
        continue;
    }
