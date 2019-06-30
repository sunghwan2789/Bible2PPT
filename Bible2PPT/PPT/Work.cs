using Bible2PPT.Bibles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Bible2PPT.PPT
{
    class Work
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<WorkBible> WorkBibles { get; set; }

        public List<Bible> Bibles
        {
            get => WorkBibles.Select(i => i.Bible).ToList();
            set => WorkBibles = value.Select(i => new WorkBible { Bible = i, }).ToList();
        }

        public TemplateTextOptions TemplateBookNameOption { get; set; }
        public TemplateTextOptions TemplateBookAbbrOption { get; set; }
        public TemplateTextOptions TemplateChapterNumberOption { get; set; }
        public string QueryString { get; set; }
        public bool SplitChaptersIntoFiles { get; set; }
        public string OutputDestination { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
