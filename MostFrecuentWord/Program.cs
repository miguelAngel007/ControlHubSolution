class Program
{
    static void Main()
    {
        //book is a fragment from a bojack serie in netflix
        string book = @"Horsin' Around is filmed
                        before a live studio audience.
                        Mondays.
                        Well, good morning to you too.
                        Oh, hey.
                        Where? I'd love hay.
                        In 1987, the situation
                        comedy Horsin' Around
                        premiered on ABC.
                        The show, in which a young, bachelor horse
                        is forced to reevaluate his priorities
                        when he agrees to raise
                        three human children,
                        was initially dismissed by critics
                        as broad and saccharine and not good,
                        but the family comedy
                        struck a chord with America
                        and went on to air for nine seasons.
                        The star of Horsin'
                        Around, BoJack Horseman,
                        is our guest tonight.
                        Welcome, BoJack.";

        // Tokenize the text by splitting it into words
        string[] excludes = { "\n","\r", "\r\n", "\n\r" };//remove new line
        string[] words = book.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Where(x=> !excludes.Contains(x)).ToArray();

        // Create a dictionary to store word frequencies
        Dictionary<string, int> wordFreq = new Dictionary<string, int>();

        // Count the frequency of each word
        foreach (string word in words)
        {
            string cleanedWord = word.ToLower(); // Convert to lowercase for case-insensitive counting
            if (wordFreq.ContainsKey(cleanedWord))
                wordFreq[cleanedWord]++;
            else
                wordFreq[cleanedWord] = 1;
        }

        // Find the most frequent word
        KeyValuePair<string, int> mostFrequentWord = wordFreq.OrderByDescending(pair => pair.Value).First();
        string output = $"The most frequent word is '{mostFrequentWord.Key}' with a frequency of {mostFrequentWord.Value} times.";
        Console.WriteLine(output);
    }
}
