using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSEntities
{
    [Table("BSComment")]
    public class BSComment
    {
        [Required]
        public string CommenterName { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual BSPost Post { get; set; }

        public override string ToString()
        {
            return this.CommenterName + "'s comment on " + this.Post.Title;
        }

    }
}
