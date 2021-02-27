using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NMS.Entities;

namespace NMS.Data
{
   public class Context: DbContext
    {
        public Context(): base("Context")
        {

        }

    

        //Testing
        public DbSet<Test> Tests { get; set; }
    }
}
