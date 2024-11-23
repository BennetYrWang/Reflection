namespace Bennet.Util.IO
{
    public abstract class CsvData
    {
        public abstract object Data { get; protected set; }
        public abstract bool IsValidInput(string[] line);
        public abstract void ParseInput(string[] line);
        public abstract string FormatCsvString();
    }
}