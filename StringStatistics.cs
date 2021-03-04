using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_cv4
{
    class StringStatistics
    {
        private string data;
        
        private static char[] wordSeparators = { ' ', ',', '\n' };
        private static char[] punctuation = { '.', ',', ':', ';', '?', '!', '(', ')' };
        private static char[] sentenceEndings = { '.', '?', '!' };
        private static string[] infectedWords = { "covid", "covid-19", "sars-cov-2" };

        public StringStatistics(string dataIn)
        {
            if (dataIn.Length == 0) throw new Exception("Cannot construct string statistics with no input");
            data = dataIn;
        }
        private string removeAny(string dataIn, char[] letters)    //removes specified letters from input string
        {
            string result = dataIn;
            foreach (char letter in letters)
            {
                result = result.Replace(letter.ToString(), String.Empty);
            }
            return result;
        }
        private string[] splitWords()
        {
            return removeAny(data, punctuation).Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
        }
        public int WordCount()
        {
            return splitWords().Length;
        }
        public int LineCount()
        {
            return data.Split('\n').Length;
        }
        public int SentenceCount()
        {
            string[] stringSplit = data.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
            int result = 1;
            for (int wordIndex = 0; wordIndex < stringSplit.Length-1; wordIndex++)
            {
                //new sentence is detected as a sentence ending character followed by an upper case letter
                if (sentenceEndings.Contains(stringSplit[wordIndex].Last()) && Char.IsUpper(stringSplit[wordIndex + 1].First()))
                {
                    result++;
                }
            }
            return result;
        }
        public string[] LongestWords()
        {
            string[] stringSplit = splitWords();
            int maxLength = 0;
            int resultSize = 1;
            foreach (string word in stringSplit)    //find length of longest words and amount of these words
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
            foreach (string word in stringSplit)    //load result array with longest words
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
            string[] stringSplit = splitWords();
            int minLength = stringSplit[0].Length;
            int resultSize = 1;
            foreach (string word in stringSplit)    //find length of shortest words and amount of these words
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
            foreach (string word in stringSplit)    //load result array with shortest words
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
            string[] stringSplit = splitWords();
            string uniqueWordString = " ";
            int uniqueWordsCount = 0;
            foreach (string word in stringSplit)    //convert string array into a string of unique words
            {
                if (!uniqueWordString.Contains(" " + word + " "))
                {
                    uniqueWordsCount++;
                    uniqueWordString += word + " ";
                }
            }
            int[] wordCounts = new int[uniqueWordsCount];
            string[] uniqueWords = uniqueWordString.Substring(1, uniqueWordString.Length-2).Split(' ');
            foreach (string word in stringSplit)    //count the amount of each unique word in the original data
            {
                wordCounts[Array.IndexOf(uniqueWords, word)]++;
            }
            int maxCount = 0;
            int resultSize = 1;
            for (int wordIndex = 0; wordIndex < wordCounts.Length; wordIndex++)     //find the most common words and amount of these words
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
            for (int wordIndex = 0; wordIndex < wordCounts.Length; wordIndex++)     //load result array with shortest words
            {
                if (wordCounts[wordIndex] == maxCount)
                {
                    result[resultIndex] = uniqueWords[wordIndex];
                    resultIndex++;
                }
            }
            return result;
        }
        public string[] AlphabeticalOrder()
        {
            string[] stringSplit = splitWords();
            Array.Sort(stringSplit);
            return stringSplit;
        }
        public bool IsInfected()
        {
            string[] stringSplit = splitWords();
            foreach (string word in stringSplit)
            {
                if (infectedWords.Contains(word.ToLower())) return true;
            }
            return false;
        }
    }
}
