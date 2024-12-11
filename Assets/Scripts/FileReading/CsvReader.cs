using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace FileReading
{
    public class CsvReader
    {
        public List<string> lines;
        public int skipLines;
        public int skipColumns;

        public CsvReader ReadCsv(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
            using (var reader = new StreamReader(filePath))
            {
                int lineIndex = 0;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineIndex ++ < skipLines)
                        continue;
                    lines.Add(line);
                }
                    
            }
            
            return this;
        }

        public CsvReader ReadCsv(TextAsset csvFile)
        {
            lines = csvFile.text.Split(Environment.NewLine).ToList();
            return this;
        }
    }
}