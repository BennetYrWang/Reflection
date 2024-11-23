using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Bennet.Util.IO
{
    public class CsvLoader
    {
        public int skipColumn, skipRow;

        public string[][] ParseStringContent(string csvContent)
        {
            var lines = csvContent.Split(Environment.NewLine).Skip(skipRow);
            return ParseLines(lines);
        }

        private string[][] ParseLines(IEnumerable<string> lines)
        {
            var parsedContent = lines.Select(
                    line => line.Split(',')
                        .Skip(skipColumn)
                        .ToArray())
                .ToArray();
            return parsedContent;
        } 

        public string[][] ParseFileContent(TextAsset csvFile)
        {
            if (csvFile == null)
                throw new ArgumentException("CsvFile not assigned");
            return ParseStringContent(csvFile.text);
        }

        public string[][] ParseFileContent(string path)
        {
            if (!File.Exists(path))
                throw new IOException("Invalid Path");
            return ParseLines(File.ReadAllLines(path).Skip(skipRow));
        }
    }
}
