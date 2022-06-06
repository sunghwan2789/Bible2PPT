using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bible2PPT.Services.BibleIndexService.Tests;

public class VerseQueryParserTest
{
    [Theory]
    [InlineData("", 0)]
    [InlineData(" ", 0)]
    [InlineData("창", 1)]
    [InlineData(" 창", 1)]
    [InlineData(" 창 ", 1)]
    [InlineData("창1", 1)]
    [InlineData("창 1", 1)]
    [InlineData("창 롬", 2)]
    [InlineData("창 롬1", 2)]
    [InlineData("창1 롬", 2)]
    [InlineData("창1 롬1", 2)]
    [InlineData("창 1 2", 2)]
    public void Parse_Counts(string queryString, int count)
    {
        var parser = GetVerseQueryParser();

        parser.ParseVerseQueries(queryString).Count().ShouldBe(count);
    }

    private static VerseQueryParser GetVerseQueryParser()
    {
        var services = new ServiceCollection();
        services.AddBibleIndexService(options => options.UseSqlite("Data Source=file::memory:?cache=shared"));

        var serviceProvider = services.BuildServiceProvider();
        serviceProvider.UseBibleIndexService();

        return serviceProvider.GetRequiredService<VerseQueryParser>();
    }
}
