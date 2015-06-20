using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSEntities
{
    [Table("BSPost")]
    public class BSPost:BSInput
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual BSUser User { get; set; }
        public virtual List<BSComment> Comments { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
