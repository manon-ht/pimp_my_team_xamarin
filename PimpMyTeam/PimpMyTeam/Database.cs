using System.Collections.Generic;
using System.Threading.Tasks;
using SQLiteNetExtensionsAsync.Extensions;

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
            database.CreateTableAsync<MemberTeam>().Wait();
        }

        // MEMBERS

        public Task<List<Member>> GetMembersAsync()
        {
            return database.Table<Member>().ToListAsync();
        }

        public Task<Member> GetMemberAsync(int id)
        {
            return database.GetWithChildrenAsync<Member>(id);
        }

        public void SaveMemberAsync(Member item)
        {
            if (item.ID != 0)
            {
                database.UpdateWithChildrenAsync(item);
            }
            else
            {
                database.InsertWithChildrenAsync(item);
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
            return database.GetWithChildrenAsync<Team>(id);
        }

        public void SaveTeamAsync(Team item)
        {
            if (item.ID != 0)
            {
                database.UpdateWithChildrenAsync(item);
            }
            else
            {
                database.InsertWithChildrenAsync(item);
            }
        }

        public Task<int> DeleteTeamAsync(Team item)
        {
            return database.DeleteAsync(item);
        }
    }
}
