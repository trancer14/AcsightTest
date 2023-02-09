using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcSight.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime? EditedDate { get; set; }

    }
}
