using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagementMicroservice.DB
{
    public class DBInitializer
    {
        public static void Initialize(StaffPermContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
