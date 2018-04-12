
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace DoctorApp.DM
{
   public class Specialized
    {
       public Guid Id { get; set; }
       [Required]
       [MaxLength(150)]
       public string SpecializedField { get; set; }

       public DateTime DataEntry { get; set; }
       public string Username { get; set; }
    }
}
