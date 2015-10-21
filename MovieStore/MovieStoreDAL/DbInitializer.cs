using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace MovieStoreDAL
{
   public class DbInitializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MovieStoreDbInitializer());
        }

    }
}
