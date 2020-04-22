using AssistApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssistApp.Data
{
    public class AssistDB
    {
        readonly SQLiteAsyncConnection _database;

        public AssistDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PhoneNos>().Wait();
        }

        public Task<List<PhoneNos>> GetPhoneNosAsync()
        {
            return _database.Table<PhoneNos>().ToListAsync();
        }

        public Task<PhoneNos> GetPhoneNosAsync(int id)
        {
            return _database.Table<PhoneNos>()
                            .Where(i => i.pk == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SavePhoneNosAsync(PhoneNos _PhoneNos)
        {
            if (_PhoneNos.pk != 0)
            {
                return _database.UpdateAsync(_PhoneNos);
            }
            else
            {
                return _database.InsertAsync(_PhoneNos);
            }
        }

        public Task<int> DeletePhoneNosAsync(PhoneNos _PhoneNos)
        {
            return _database.DeleteAsync(_PhoneNos);
        }
    }
}
