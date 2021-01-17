using EventsApp.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppRemastered.Database {
    public class EventDB {
        readonly SQLiteAsyncConnection _DB;

        public EventDB(string dbPath) {
            _DB = new SQLiteAsyncConnection(dbPath);
            _DB.CreateTableAsync<Event>().Wait();
        }

        public async Task<List<Event>> GetEventsAsync() {
            return await _DB.Table<Event>()
                .Where(u => u.UserName == App._UserName)
                .ToListAsync();
        }

        public Task<Event> GetEventAsync(int id) {
            return _DB.Table<Event>()
                            .Where(i => i.ID == id)
                            .Where(u => u.UserName == App._UserName)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveEventAsync(Event note) {
            int insertedRows = await _DB.InsertAsync(note);
            return insertedRows;
        }

        public async void DeleteEventAsync(Event note) {
            int deletedRows = await _DB.DeleteAsync(note);
        }

        public async void DeleteEventByID(int ID) {
            Event evn = await GetEventAsync(ID);
            DeleteEventAsync(evn);
        }

        public async void DeleteEventsAsync() {
            int deletedRows = await _DB.DeleteAllAsync<Event>();
        }
    }
}

