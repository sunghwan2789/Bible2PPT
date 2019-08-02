using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Bible2PPT.Bibles;

namespace Bible2PPT.PPT
{
    class JobBible
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Job Job { get; set; }

        public virtual Bible Bible { get; set; }
    }
}
