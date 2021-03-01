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
        private static char[] sentenceEndings = { '.', '?', '!' };
        private static char[] wordSeparators = { ' ', '\n' };
        //private static string[] abbreviations = { "zkr." };

        public StringStatistics(string initString)
        {
            data = initString;
        }
        public int WordCount()
        {
            /*
            if (data.Length == 0) return 0;
            int result = 1;
            char prevLetter = data[0];
            foreach (char letter in data)
            {
                if (wordSeparators.Contains(letter) && !wordSeparators.Contains(prevLetter))    //don't increment on duplicate separators
                {
                    result++;
                }
                prevLetter = letter;
            }
            return result;
            */
            return data.Split(wordSeparators).Length;
        }
        public int LineCount()
        {
            /*
            if (data.Length == 0) return 0;
            int result = 1;
            foreach (char letter in data)
            {
                if (letter == '\n')
                {
                    result++;
                }
            }
            return result;
            */
            return data.Split('\n').Length;
        }
        public int SentenceCount()
        {
            /*
            if (data.Length == 0) return 0;
            int result = 0;
            char prevLetter = data[0];
            int lastSpaceIndex = 0;
            for (int letterIndex = 0; letterIndex < data.Length; letterIndex++)
            {
                if (data[letterIndex] == ' ') lastSpaceIndex = letterIndex;
                if (sentenceSeparators.Contains(data[letterIndex]) && !sentenceSeparators.Contains(prevLetter)      //don't increment on duplicate separators
                    && !abbreviations.Contains(data.Substring(lastSpaceIndex + 1, letterIndex - lastSpaceIndex)))   //don't increment on abbreviations
                {
                    result++;
                }
                prevLetter = data[letterIndex];
            }
            return result;
            */
            string[] dataSplit = data.Split(wordSeparators);
            int result = 1;
            for (int wordIndex = 0; wordIndex < dataSplit.Length-1; wordIndex++)
            {
                if (sentenceEndings.Contains(dataSplit[wordIndex][dataSplit[wordIndex].Length - 1]) && Char.IsUpper(dataSplit[wordIndex + 1][0]))
                {
                    result++;
                }
            }
            return result;
        }
        public string[] LongestWords()
        {
            string[] dataSplit = data.Split(wordSeparators);
            int maxLength = 0;
            int resultSize = 1;
            foreach (string word in dataSplit)
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
            foreach (string word in dataSplit)
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
            string[] dataSplit = data.Split(wordSeparators);
            int minLength = dataSplit[0].Length;
            int resultSize = 1;
            foreach (string word in dataSplit)
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
            foreach (string word in dataSplit)
            {
                if (word.Length == minLength)
                {
                    result[resultIndex] = word;
                    resultIndex++;
                }
            }
            return result;
        }
    }
}
