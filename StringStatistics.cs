using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv4
{
    class StringStatistics
    {
        private string data = "";
        
        private static char[] wordSeparators = { ' ', '\n' };
        private static char[] punctuation = { '.', ',', ':', ';', '?', '!', '(', ')' };
        private static char[] sentenceEndings = { '.', '?', '!' };

        public StringStatistics(string dataIn)
        {
            data = dataIn;
        }
        private static string removeDuplicate(string dataIn, char[] letters)
        {
            string result = "";
            char prevLetter = dataIn[0];
            foreach (char letter in dataIn)
            {
                if (!(letters.Contains(letter) && letters.Contains(prevLetter)))
                {
                    result += letter;
                }
                prevLetter = letter;
            }
            return result;
        }
        private static string removeAny(string dataIn, char[] letters)
        {
            string result = dataIn;
            foreach (char letter in letters)
            {
                result = result.Replace(letter.ToString(), String.Empty);
            }
            return result;
        }
        public int WordCount()
        {
            return data.Split(wordSeparators).Length;
        }
        public int LineCount()
        {
            return data.Split('\n').Length;
        }
        public int SentenceCount()
        {
            string[] stringSplit = removeDuplicate(data, wordSeparators).Split(wordSeparators);
            int result = 1;
            for (int wordIndex = 0; wordIndex < stringSplit.Length-1; wordIndex++)
            {
                if (sentenceEndings.Contains(stringSplit[wordIndex][stringSplit[wordIndex].Length - 1]) && Char.IsUpper(stringSplit[wordIndex + 1][0]))
                {
                    result++;
                }
            }
            return result;
        }
        public string[] LongestWords()
        {
            string[] stringSplit = removeAny(removeDuplicate(data, wordSeparators), punctuation).Split(wordSeparators);
            int maxLength = 0;
            int resultSize = 1;
            foreach (string word in stringSplit)
            {
                if (word.Length > maxLength)
                {
                    maxLength = word.Length;
                    resultSize = 1;
                }
                else if (word.Length == maxLength) resultSize++;
            }
            string[] result = new string[resultSize];
            int resultIndex = 0;
            foreach (string word in stringSplit)
            {
                if (word.Length == maxLength)
                {
                    result[resultIndex] = word;
                    resultIndex++;
                }
            }
            return result;
        }
        public string[] ShortestWords()
        {
            string[] stringSplit = removeAny(removeDuplicate(data, wordSeparators), punctuation).Split(wordSeparators);
            int minLength = stringSplit[0].Length;
            int resultSize = 1;
            foreach (string word in stringSplit)
            {
                if (word.Length < minLength)
                {
                    minLength = word.Length;
                    resultSize = 1;
                }
                else if (word.Length == minLength) resultSize++;
            }
            string[] result = new string[resultSize];
            int resultIndex = 0;
            foreach (string word in stringSplit)
            {
                if (word.Length == minLength)
                {
                    result[resultIndex] = word;
                    resultIndex++;
                }
            }
            return result;
        }
        public string[] MostCommonWords()
        {
            string[] stringSplit = removeAny(removeDuplicate(data, wordSeparators), punctuation).Split(wordSeparators);
            string uniqueWords = " ";
            int uniqueWordsCount = 0;
            foreach (string word in stringSplit)
            {
                if (!uniqueWords.Contains(" " + word + " "))
                {
                    uniqueWordsCount++;
                    uniqueWords += word + " ";
                }
            }
            int[] wordCounts = new int[uniqueWordsCount];
            string[] words = uniqueWords.Substring(1,uniqueWords.Length-2).Split(' ');
            foreach (string word in stringSplit)
            {
                wordCounts[Array.IndexOf(words, word)]++;
            }
            int maxCount = 0;
            int resultSize = 1;
            for (int wordIndex = 0; wordIndex < wordCounts.Length; wordIndex++)
            {
                if (wordCounts[wordIndex] > maxCount)
                {
                    maxCount = wordCounts[wordIndex];
                    resultSize = 1;
                }
                else if (wordCounts[wordIndex] == maxCount) resultSize++;
            }
            string[] result = new string[resultSize];
            int resultIndex = 0;
            for (int countsIndex = 0; countsIndex < wordCounts.Length; countsIndex++)
            {
                if (wordCounts[countsIndex] == maxCount)
                {
                    result[resultIndex] = words[countsIndex];
                    resultIndex++;
                }
            }
            return result;
        }
    }
}
