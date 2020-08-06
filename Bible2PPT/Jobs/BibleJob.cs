using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Bible2PPT.Bibles;

namespace Bible2PPT.Jobs
{
    internal class BibleJob
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<BibleJobBible> JobBibles { get; set; }

        [NotMapped]
        public List<Bible> Bibles
        {
            get => JobBibles.Select(i => i.Bible).ToList();
            set => JobBibles = value.Select(i => new BibleJobBible { Bible = i, }).ToList();
        }

        public TemplateTextOptions TemplateBookNameOption { get; set; }
        public TemplateTextOptions TemplateBookAbbrOption { get; set; }
        public TemplateTextOptions TemplateChapterNumberOption { get; set; }
        public int NumberOfVerseLinesPerSlide { get; set; }
        public string QueryString { get; set; }
        public bool SplitChaptersIntoFiles { get; set; }
        public string OutputDestination { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    class BibleJobBible
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual BibleJob Job { get; set; }

        public virtual Bible Bible { get; set; }
    }
}
