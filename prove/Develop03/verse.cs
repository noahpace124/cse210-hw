using System;
using verse_word;

namespace verse
{
    public class Verse
    {
        private List<Verse_Word> verseWords { get; set; } = new List<Verse_Word>();

        public Verse(List<Verse_Word> words)
        {
            verseWords = words;
        }

        public string GetVerse()
        {
            string verseText = "";
            foreach (var verseWord in verseWords)
            {
                verseText += verseWord.GetWord() + " ";
            }
            return verseText.TrimEnd();
        }

        public bool HideWord()
        {
            var random = new Random();
            var visibleWords = verseWords.Where(word => !word.Hidden).ToList();

            if (visibleWords.Count == 0)
            {
                return false;
            }

            var wordToHide = visibleWords[random.Next(visibleWords.Count)];
            wordToHide.Hidden = true;
            return true;
        }
    }
}