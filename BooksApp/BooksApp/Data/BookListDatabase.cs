using BooksApp.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data
{
    public class BookListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public BookListDatabase(string dbPath)
        {

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Book>().Wait();
            
        }
        public Task<List<Book>> GetBookListsAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }
        public Task<Book> GetBookListAsync(int id)
        {
            return _database.Table<Book>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveBookListAsync(Book blist)
        {
            if (blist.ID != 0)
            {
                return _database.UpdateAsync(blist);
            }
            else
            {
                return _database.InsertAsync(blist);
            }
        }
        public Task<int> DeleteBookListAsync(Book blist)
        {
            return _database.DeleteAsync(blist);
        }
    }
}
