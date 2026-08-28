using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary;

namespace clsBussinseLibrary
{
    static public class clsDatabaseInitializer
    {
        static public void DatabaseInitializer()
        {
            clsDDatabaseInitializer.Initialize();
        }
    }
}
