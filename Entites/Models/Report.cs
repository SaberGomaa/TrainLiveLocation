using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Report
    {
        [Column("ReportId")]
        public int Id { get; set; }
        public string?  Descreption { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Post>? posts { get; set; }


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
