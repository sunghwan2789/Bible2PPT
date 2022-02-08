using Bible2PPT.Services.BibleIndexService;

internal class CsvBibleIndexSeedBuilder
{
    private readonly string _languageCode;
    private readonly string _version;

    public CsvBibleIndexSeedBuilder(string languageCode, string version)
    {
        _languageCode = languageCode;
        _version = version;
    }

    public IEnumerable<BookInfo> Build(string data)
    {
        var meta = new BookInfo { LanguageCode = _languageCode, Version = _version };

        using var reader = new StringReader(data);
        while (reader.ReadLine() is string line)
        {
            if (!(
                line.Split(',') is [var key, var name, var abbreviation]
                && Enum.Parse<BookKey>(key) is var bookKey))
            {
                throw new InvalidOperationException();
            }

            yield return meta with { Key = bookKey, Kind = BookInfoKind.Name, Value = name };
            yield return meta with { Key = bookKey, Kind = BookInfoKind.Abbreviation, Value = abbreviation };
        }
    }
}
