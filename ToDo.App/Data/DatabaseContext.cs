using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDo.App.Models;

namespace ToDo.App.Data
{
    public class DatabaseContext
    {
        public SQLiteAsyncConnection Conn { get; set; }
        public DatabaseContext(string path)
        {
            Conn = new SQLiteAsyncConnection(path);
            Conn.CreateTableAsync<ToDoItem>().Wait();
        }

        public async Task<int> InsertItemAsyn(ToDoItem item)
        {
            return await Conn.InsertAsync(item);
        }

        public async Task<List<ToDoItem>> GetItemAsyn()
        {
            return await Conn.Table<ToDoItem>().ToListAsync();
        }

        public async Task<int> DeleteItemAsyn(ToDoItem item)
        {
            return await Conn.DeleteAsync(item);
        }
    }
}
