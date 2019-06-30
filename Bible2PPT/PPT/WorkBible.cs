using Bible2PPT.Bibles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Bible2PPT.PPT
{
    class WorkBible
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Work Work { get; set; }

        public virtual Bible Bible { get; set; }
    }
}
