using verse;
using verse_word;

namespace scripture 
{
    public class Scripture
    {
        private string Book { get; set; }
        private int Chapter { get; set; }
        private int Verse { get; set; }
        private int Count { get; set; }
        private List<Verse> Verses { get; set; } = new List<Verse>();

        public Scripture(string book, int chapter, int verse, int count, List<List<Verse_Word>> verses)
        {
            Book = book;
            Chapter = chapter;
            Verse = verse;
            Count = count;

            foreach (var words in verses)
            {
                Verses.Add(new Verse(words));
            }
        }

        public string GetScripture()
        {
            string verses;

            if (Count == 1)
            {
            verses = Verse.ToString();
            }
            else
            {
            verses = $"{Verse}-{Verse + Count - 1}";
            }

            string verseTexts = "";
            foreach (Verse verse in Verses)
            {
                verseTexts += verse.GetVerse() + "\n";
            }
            return $"{Book} {Chapter}:{verses}\n{verseTexts}";
        }

        public bool HideWords()
        {
            Random random = new Random();
            List<int> availableIndexes = Enumerable.Range(0, Verses.Count).ToList();
            bool wordHidden = false;

            for (int i = 0; i < 3; i++)
            {
                if (availableIndexes.Count == 0)
                {
                    return wordHidden;
                }

                int randomIndex = random.Next(availableIndexes.Count);
                int verseIndex = availableIndexes[randomIndex];

                if (Verses[verseIndex].HideWord())
                {
                    wordHidden = true;
                    continue;
                }
                else
                {
                    availableIndexes.RemoveAt(randomIndex);
                    i--;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string verses = Count == 1 ? Verse.ToString() : $"{Verse}-{Verse + Count - 1}";
            string verseTexts = string.Join("\n", Verses.Select(v => v.GetVerse()));
            return $"Book: {Book}, Chapter: {Chapter}, Verses: {verses}, Count: {Count}\n{verseTexts}";
        }
    }
}