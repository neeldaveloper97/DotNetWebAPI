using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaltedsoft_Model.Entities
{
    public class BaseModel
    {
        [Key]
        public Guid? Id { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public Guid CreatedByUserId { get; set; }
        //public DateTime? UpdatedDate { get; set; }
        //public Guid? UpdatedByUserId { get; set; }
        //public DateTime? DeletedDate { get; set; }
        //public Guid? DeletedByUserId { get; set; }
        //public bool IsDeleted { get; set; }
    }
}
