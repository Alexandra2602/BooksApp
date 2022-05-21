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
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Review>().Wait();
            _database.CreateTableAsync<ListReview>().Wait();
            _database.CreateTableAsync<RatingModel>().Wait();
            _database.CreateTableAsync<ListRating>().Wait();
            _database.CreateTableAsync<Finished>().Wait();
            _database.CreateTableAsync<ListFinished>().Wait();

        }
        public Task<List<Book>> GetBookListsAsync()
        {
            return _database.Table<Book>().ToListAsync();
        }
        public Task<List<Book>> GetBookByRating()
        {
            return _database.Table<Book>().OrderByDescending(x => x.Average_Rating).ToListAsync();
        }
        public Task<Book> GetBookListAsync(int id)
        {
            return _database.Table<Book>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<Book> GetBookListByRating(float rating)
        {
            return _database.Table<Book>()
            .Where(i => i.Average_Rating == rating)
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
        public  Task <List<Book>>GetBooksByTitle(string title)
        {
            return _database.Table<Book>().Where(c=>c.Title.ToLower().Contains(title.ToLower()) || c.Author.ToLower().Contains(title.ToLower())).ToListAsync();
        }


        public Task<List<User>> GetUserListsAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
        public Task<User> GetUserListAsync(int id)
        {
            return _database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserListAsync(User ulist)
        {
            if (ulist.Id != 0)
            {
                return _database.UpdateAsync(ulist);
            }
            else
            {
                return _database.InsertAsync(ulist);
            }
        }
        public Task<int> DeleteUserListAsync(User ulist)
        {
            return _database.DeleteAsync(ulist);
        }

        public Task<int> SaveReviewAsync(Review review)
        {
            if (review.ID != 0)
            {
                return _database.UpdateAsync(review);
            }
            else
            {
                return _database.InsertAsync(review);
            }
        }
        public Task<int> DeleteReviewAsync(Review review)
        {
            return _database.DeleteAsync(review);
        }
        public Task<List<Review>> GetReviewsAsync()
        {
            return _database.Table<Review>().ToListAsync();
        }
        public Task<int> SaveListReviewAsync(ListReview listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Review>> GetListReviewsAsync(int reviewid)
        {
            return _database.QueryAsync<Review>(
            "select R.ID, R.Description, R.UserName from Review R"
            + " inner join ListReview LR"
            + " on R.ID = LR.ReviewID where  LR.BookID = ?",
            reviewid);
        }
        public Task<int> SaveRatingAsync(RatingModel rating)
        {
            if (rating.ID != 0)
            {
                return _database.UpdateAsync(rating);
            }
            else
            {
                return _database.InsertAsync(rating);
            }
        }
        public Task<int> DeleteRatingAsync(RatingModel rating)
        {
            return _database.DeleteAsync(rating);
        }
        public Task<List<RatingModel>> GetRatingsAsync()
        {
            return _database.Table<RatingModel>().ToListAsync();
        }
        public Task<int> SaveListRatingAsync(ListRating listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<RatingModel>> GetListRatingsAsync(int ratingid)
        {
            return _database.QueryAsync<RatingModel>(
            "select M.ID, M.Description, M.UserName from RatingModel M"
            + " inner join ListRating LM"
            + " on M.ID = LM.RatingID where LM.BookID = ?",
            ratingid);
        }

        public Task<int> SaveFinishedAsync(Finished finished)
        {
            if (finished.ID != 0)
            {
                return _database.UpdateAsync(finished);
            }
            else
            {
                return _database.InsertAsync(finished);
            }
        }
        public Task<int> DeleteFinishedAsync(Finished finished)
        {
            return _database.DeleteAsync(finished);
        }
        public Task<List<Finished>> GetFinishedAsync()
        {
            return _database.Table<Finished>().ToListAsync();
        }
        public Task<int> SaveListFinishedAsync(ListFinished listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Finished>> GetListFinishedsAsync(int finishedid)
        {
            return _database.QueryAsync<Finished>(
            "select M.ID, M.Name, M.Author, M.Title, M.ImagePath from Finished M"
            + " inner join ListFinished LM"
            + " on M.ID = LM.FinishedID where LM.UserID = ?",
            finishedid);
        }


    }
}

