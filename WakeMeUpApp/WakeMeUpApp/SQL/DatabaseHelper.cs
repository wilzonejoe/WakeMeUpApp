using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WakeMeUpApp.SQL
{
    class DatabaseHelper
    {
        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("TimeSQLite.db3"));
                }
                return database;
            }
        }

    }
}
