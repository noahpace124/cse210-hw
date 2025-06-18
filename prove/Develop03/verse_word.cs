using System;

namespace verse_word
{
    public class Verse_Word
    {
        private string Word { get; set; }
        private string Punctuation {get; set;}
        public bool Hidden { get; set; } = false;

        public Verse_Word(string word, string punctuation = "")
        {
            Word = word;
            Punctuation = punctuation;
        }

        public string GetWord()
        {
            if (Hidden)
            {
                return new string('_', Word.Length) + Punctuation;
            }
            else {
                return Word + Punctuation;
            }
        }
    }
}