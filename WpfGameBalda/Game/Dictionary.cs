using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGameBalda.Game
{
    internal class Dictionary
    {
        List<string> words = new List<string>();
        public Dictionary()
        {

            if (File.Exists(@"./LibRus.xml"))
                LoadFromFile();
            else
            {
                AddWord("АБЗАЦ");
                AddWord("АВТОР");
                SaveToFile();
            }
      
        }
        public Dictionary AddWord(string word)
        {
            if (words.All(x => x != word))
                words.Add(word);
            SaveToFile();
            return this;
        }
        public string GetWord(int wordLength)
        {
            return words
                .Where(x => x.Length == wordLength)
                .Skip(new Random().Next(0, words.Count(x => x.Length == wordLength) - 1))
                .FirstOrDefault();
        }
        public bool CheckWord(string word)
        {
            return words.Any(x => x == word);
        }
        void LoadFromFile()
        {
            var reader = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
            var file = new StreamReader(@"./LibRus.xml");
            words = new List<string>();
            words = (List<string>)reader.Deserialize(file);
        }
        void SaveToFile()
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<string>));
            
            System.IO.StreamWriter file = new StreamWriter(@"./LibRus.xml");
            writer.Serialize(file, words);
            file.Close();
        }
    }
}
