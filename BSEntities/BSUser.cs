using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSEntities
{
    [Table("BSUser")]
    public class BSUser:BSInput
    {
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Avatar { get; set; }
        public BSUserRole Role { get; set; }
        public virtual List<BSPost> Posts { get; set; }

        public override string ToString()
        {
            return this.Role.ToString() + " " + this.Account;
        }

    }
}
