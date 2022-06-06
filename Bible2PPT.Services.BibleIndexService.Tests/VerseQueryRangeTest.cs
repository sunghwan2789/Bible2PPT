using System.Globalization;

namespace Bible2PPT.Services.BibleIndexService.Tests;

public class VerseQueryRangeTest
{
    [Theory]
    [InlineData("4", 4, 1, 4, null)]
    [InlineData("4-9", 4, 1, 9, null)]
    [InlineData("4-9:8", 4, 1, 9, 8)]
    [InlineData("4:3", 4, 3, 4, 3)]
    [InlineData("4:3-8", 4, 3, 4, 8)]
    [InlineData("4:3-9:8", 4, 3, 9, 8)]
    public void Parse_Success(string s, int startChapter, int startVerse, int? endChapter, int? endVerse)
    {
        VerseQueryRange.TryParse(s, CultureInfo.InvariantCulture, out var result).ShouldBeTrue();

        result.StartChapterNumber.ShouldBe(startChapter);
        result.StartVerseNumber.ShouldBe(startVerse);
        result.EndChapterNumber.ShouldBe(endChapter);
        result.EndVerseNumber.ShouldBe(endVerse);
    }

    [Theory]
    [InlineData("")]
    [InlineData("GEN")]
    [InlineData("1SAM")]
    public void Parse_BookAbbr_Fail(string s)
    {
        VerseQueryRange.TryParse(s, CultureInfo.InvariantCulture, out _).ShouldBeFalse();
    }
}
