using System;
using System.Collections.Generic;
using System.Linq;
using OnlineClient.Models;
using SQLite;

namespace People
{
    public class PersonRepository
    {
        SQLiteConnection clientdata;
        public string StatusMessage { get; set; }

        public PersonRepository(string dbPath)
        {
            clientdata = new SQLiteConnection(dbPath);
            clientdata.CreateTable<online_Client>();
        }

        public void AddNewPerson(string name , string gender , string Tshirt_Size , string Tshirt_color , string Shipping_address , string newPost_address)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = clientdata.Insert(new OnlineClient { Name = name , Gender = gender , TShirt_Size = Tshirt_Size , TShirt_Color = Tshirt_color , Shipping_address = Shipping_address , Date_of_Order = newPost_address }) ;

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public List<OnlineClient> GetAllPeople()
        {
            try
            {
                return clientdata.Table<OnlineClient>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<OnlineClient>();
        }
    }
}