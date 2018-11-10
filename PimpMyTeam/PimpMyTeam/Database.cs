using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace PimpMyTeam
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Member>().Wait();
        }

        public Task<List<Member>> GetMembersAsync()
        {
            return database.Table<Member>().ToListAsync();
        }

        public Task<List<Member>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Member>("SELECT * FROM [Member] WHERE [Done] = 0");
        }

        public Task<Member> GetMemberAsync(int id)
        {
            return database.Table<Member>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveMemberAsync(Member item)
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

        public Task<int> DeleteMemberAsync(Member item)
        {
            return database.DeleteAsync(item);
        }
    }
}
