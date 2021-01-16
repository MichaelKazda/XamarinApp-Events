using EventsApp.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppRemastered.Database {
    class EventDB {
        readonly SQLiteAsyncConnection _DB;

        public EventDB(string dbPath) {
            _DB = new SQLiteAsyncConnection(dbPath);
            _DB.CreateTableAsync<Event>().Wait();
        }

        public async Task<List<Event>> GetNotesAsync() {
            return await _DB.Table<Event>().ToListAsync();
        }

        public Task<Event> GetNoteAsync(int id) {
            return _DB.Table<Event>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<int> SaveNoteAsync(Event note) {
            int insertedRows = await _DB.InsertAsync(note);
            return insertedRows;
        }

        public async Task EditNoteAsync(int id, string label, string text) {
            Event note = await GetNoteAsync(id);

        }

        public async void DeleteNoteAsync(Event note) {
            int deletedRows = await _DB.DeleteAsync(note);
        }
    }
}

