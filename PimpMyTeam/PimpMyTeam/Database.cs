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
            database.CreateTableAsync<Team>().Wait();
        }

        // MEMBERS

        public Task<List<Member>> GetMembersAsync()
        {
            return database.Table<Member>().ToListAsync();
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

        // TEAMS

        public Task<List<Team>> GetTeamsAsync()
        {
            return database.Table<Team>().ToListAsync();
        }

        public Task<Team> GetTeamAsync(int id)
        {
            return database.Table<Team>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveTeamAsync(Team item)
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

        public Task<int> DeleteTeamAsync(Team item)
        {
            return database.DeleteAsync(item);
        }
    }
}
