using OnlineClient.Models;
using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;

namespace People
{
  
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnNewButtonClicked(object sender, EventArgs args)
        {
            string status = statusMessage.Text = "";
            DisplayAlert("You have added a new Order", status, "Ok");
            App.PersonRepo.AddNewPerson(newPerson.Text , newGender.Text , newTShirtSize.Text , newTShirt_Color.Text , newShipping_Address.Text , newDate_of_Order.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
           
            List<OnlineClient> people = App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }
    }
}
