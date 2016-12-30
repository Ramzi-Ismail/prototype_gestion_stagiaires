using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public abstract class AbstractEntity
    {
        [Key]
        public int Id { set; get; }
        public DateTime DateCreation { set; get; }
        public DateTime DateModification { set; get; }
 
    }
}
