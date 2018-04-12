using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorApp.DM
{
    public class Country
    {
        public Country() { }

        [Required]
        public Guid Id { get; set; }

        public Guid ParentId { get; set; }

        [Required]
       

        public string Area { get; set; }
        [Required]
        public string Type { get; set; }

        public int Code { get; set; }

    }
}
