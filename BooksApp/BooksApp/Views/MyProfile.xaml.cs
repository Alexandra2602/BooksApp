﻿using BooksApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class MyProfile : ContentPage
    {
        private ObservableCollection<Book> myrootobject;
        public MyProfile()
        {
            InitializeComponent();
            BindingContext = this;

            var assembly = typeof(BooksPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("BooksApp.books.json");

            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<Book> mylist = JsonConvert.DeserializeObject<List<Book>>(json);
                myrootobject = new ObservableCollection<Book>(mylist);
                MyList.ItemsSource = myrootobject;

            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            popupView.IsVisible = true;

        }
        private void TapGestureRecognizer2_Tapped(object sender, EventArgs e)
        {
            popupView.IsVisible = true;

        }
        private void TapGestureRecognizer3_Tapped(object sender, EventArgs e)
        {
            popupView.IsVisible = true;

        }

        private void Creion(object sender, EventArgs e)
        {

        }
        private void Bifa(object sender, EventArgs e)
        {
      
        }
        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
        }
        void OnEditorCompleted(object sender, EventArgs e)
        {
            string text = ((Editor)sender).Text;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            MainLabel.Text = Slider.Value.ToString();
        }
        async void Image_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please pick a photo"
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
            }
            
        }
      

    }

}