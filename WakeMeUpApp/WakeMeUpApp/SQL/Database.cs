using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using WakeMeUpApp.API;

namespace WakeMeUpApp.SQL
{
    class Database
    {
        private SQLiteAsyncConnection database;
        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Time>().Wait();
        }

        public Task<List<Time>> GetItemsAsync()
        {
            return database.Table<Time>().ToListAsync();
        }

        public Task<Time> GetItemAsync(int id)
        {
            return database.Table<Time>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Time item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Time item)
        {
            return database.DeleteAsync(item);
        }
    }
}
