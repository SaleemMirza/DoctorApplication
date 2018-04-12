using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.DM
{
   public class DoctorRegistration
    {
       public Guid Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }

       public string UserName { get; set; }
       public string Password { get; set; }
       public string EmailAddress { get; set; }

       public int MobileNumber { get; set; }

       public Specialized Specialized { get; set; }
       public Guid SpecializedId { get; set; }
       public int Gender { get; set; }

       public Country Country { get; set; }
       public Guid CountryId { get; set; }

       public Country  State { get; set; }
       public Guid StateId { get; set; }
       public string Address { get; set; }




    }
}
