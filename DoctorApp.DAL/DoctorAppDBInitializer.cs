using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.DAL
{
    public class DocAppDbInitializer : DropCreateDatabaseIfModelChanges<DocAppContext>

    {
    }
}
