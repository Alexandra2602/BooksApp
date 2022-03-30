using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace BooksApp.ViewModels
{
    public class PickerViewModel :INotifyPropertyChanged
    {
        public List<Genre> GenresList{get;set;}

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private Genre _selectedGenre { get; set; }
        public Genre SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                if (_selectedGenre != value)
                {
                    _selectedGenre = value;
                    MyGenre = _selectedGenre.Value;
                }
            }
        }
        private Genre _selectedGenre2 { get; set; }
        public Genre SelectedGenre2
        {
            get { return _selectedGenre2; }
            set
            {
                if (_selectedGenre2 != value)
                {
                    _selectedGenre2 = value;
                    MyGenre2 =  _selectedGenre2.Value;
                }
            }
        }
        private Genre _selectedGenre3 { get; set; }
        public Genre SelectedGenre3
        {
            get { return _selectedGenre3; }
            set
            {
                if (_selectedGenre3 != value)
                {
                    _selectedGenre3 = value;
                    MyGenre3 =_selectedGenre3.Value;
                }
            }
        }
        public string _myGenre;
        public string MyGenre
        {
            get { return _myGenre; }
            set
            {
                if (_myGenre !=value)
                {
                    _myGenre = value;
                    OnPropertyChanged();
                }
            }
        }
        public string _myGenre2;
        public string MyGenre2
        {
            get { return _myGenre2; }
            set
            {
                if (_myGenre2 != value)
                {
                    _myGenre2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public string _myGenre3;
        public string MyGenre3
        {
            get { return _myGenre3; }
            set
            {
                if (_myGenre3 != value)
                {
                    _myGenre3 = value;
                    OnPropertyChanged();
                }
            }
        }

        public PickerViewModel()
        {
            GenresList = GetGenres().OrderBy(t => t.Value).ToList();
        }

        public List<Genre> GetGenres()
        {
            var genres = new List<Genre>()
            {
                new Genre(){Key=1, Value="Biography"},
                new Genre(){Key=2, Value="Business"},
                new Genre(){Key=3, Value="Classics"},
                new Genre(){Key=4, Value="Fantasy"},
                new Genre(){Key=5, Value="Fiction"},
                new Genre(){Key=6, Value="Financial Education"},
                new Genre(){Key=7, Value="History"},
                new Genre(){Key=8, Value="Horror"},
                new Genre(){Key=9, Value="Humor"},
                new Genre(){Key=10, Value="Mystery"},
                new Genre(){Key=11, Value="Philosophy"},
                new Genre(){Key=12, Value="Psychology"},
                new Genre(){Key=13, Value="Romance"},
                new Genre(){Key=14, Value="Science Fiction"},
                new Genre(){Key=15, Value="Self-Development"},
                new Genre(){Key=16, Value="Spirituality"},
                new Genre(){Key=17, Value="Thriller"},
                new Genre(){Key=18, Value="Young Adult"}
            };
            return genres;
        }


    }

    public class Genre
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
