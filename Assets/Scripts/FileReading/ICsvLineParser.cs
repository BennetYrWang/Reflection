namespace FileReading
{
    public interface ICsvLineParser<T>
    {
        T ParseLine(ref string line);
    }
}