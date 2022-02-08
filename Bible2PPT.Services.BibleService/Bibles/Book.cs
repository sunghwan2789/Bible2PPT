using System.ComponentModel.DataAnnotations.Schema;
using Bible2PPT.Services.BibleIndexService;

namespace Bible2PPT.Bibles;

public record Book : BibleBase
{
    public int BibleId { get; set; }
    public Bible Bible { get; set; } = null!;

    public string OnlineId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Abbreviation { get; set; }

    public BookKey Key { get; set; }

    /// <summary>
    /// Key와 Bible.LanguageCode의 조합으로 매칭한 대표 책 이름 정보
    /// </summary>
    /// <remarks>
    /// PPT 제작 중에 언어별 대표 책 정보를 변경하더라도
    /// 제작 시작 시점의 정보로 PPT를 만들 수 있도록 보관한다.
    /// </remarks>
    [NotMapped]
    public string NameInfo { get; set; } = null!;

    /// <summary>
    /// Key와 Bible.LanguageCode의 조합으로 매칭한 대표 책 이름 약자 정보
    /// </summary>
    /// <remarks>
    /// PPT 제작 중에 언어별 대표 책 정보를 변경하더라도
    /// 제작 시작 시점의 정보로 PPT를 만들 수 있도록 보관한다.
    /// </remarks>
    [NotMapped]
    public string AbbreviationInfo { get; set; } = null!;

    public int ChapterCount { get; set; }

    //public List<Chapter> Chapters => Source.GetChapters(this);
}
