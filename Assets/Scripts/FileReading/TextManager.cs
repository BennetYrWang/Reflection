using System;
using UnityEngine;

namespace FileReading
{
    public class TextManager : MonoBehaviour, ICsvLineParser<TextContent>
    {
        public TextAsset TextCsvFile;
        private void Awake()
        {
            CsvReader reader = new CsvReader() { skipLines = 0, };
            reader.ReadCsv(TextCsvFile);
            
        }

        public TextContent ParseLine(ref string line)
        {
            
        }
    }
}