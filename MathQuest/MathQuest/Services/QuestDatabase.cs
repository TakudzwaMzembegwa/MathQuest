using MathQ.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MathQuest.Services
{
    public class QuestDatabase
    {
        readonly SQLiteAsyncConnection database;

        public QuestDatabase(String dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Quest>().Wait();
        }
        public Task<List<Quest>> GetQuestsAsync()
        {

            return database.Table<Quest>().ToListAsync();
        }
        public Task<Quest> GetQuestAsync(int id)
        {

            return database.Table<Quest>()
                            .Where(i => i.id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveQuestAsync(Quest Quest)
        {
            if (Quest.id != 0)
            {

                return database.UpdateAsync(Quest);
            }
            else
            {

                return database.InsertAsync(Quest);
            }
        }
    }
}
