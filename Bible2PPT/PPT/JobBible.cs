using System.ComponentModel.DataAnnotations.Schema;
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
