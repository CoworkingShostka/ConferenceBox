﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace ConferenceBox.Models
{
    public class Connection : NotificationBase
    {
        public Connection()
        {
            System.Text.EncodingProvider provider;
            provider = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);

            ConnectAsync();
        }

        private static ObservableCollection<Person> _People = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get { return _People; }
            set { SetProperty(ref _People, value); }
        }
       
        public async Task ConnectAsync()
        {

            string connStr = "server=shostka.mysql.ukraine.com.ua;user=shostka_test;database=shostka_test;port=3306;password=12345678;SslMode=None;";
                //"server=shostka.mysql.ukraine.com.ua;user=shostka_test;database=shostka_test;port=3306;password=12345678;SslMode=None;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    Debug.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql = "SELECT * FROM participant";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);


                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            People.Add(new Person { surname = rdr.GetString("surname"), id = rdr.GetInt32("id"), name = rdr.GetString("name"),
                                email = rdr.GetString("email"), note = rdr.GetString("note"), patronymic = rdr.GetString("patronymic") });
                        }

                        rdr.Close();
                    }

                    
                    conn.Close();
                }

                //while (rdr.Read())
                //{
                //    Debug.WriteLine(rdr[0] + " -- " + rdr[1]);
                //}
                //
                
            }
                catch (Exception ex)
                {
                    var dialog = new MessageDialog(ex.ToString());
                    await dialog.ShowAsync();

                    //Debug.WriteLine(ex.ToString());
                }

            
            Debug.WriteLine("Done.");
        }

        public async void OnSelectionChanged(object sender, ItemClickEventArgs args)
        {
            var person = (Person)args.ClickedItem;

            var dialog = new MessageDialog(person.name + "\n" + person.surname);
            await dialog.ShowAsync();
        }
    }
}
