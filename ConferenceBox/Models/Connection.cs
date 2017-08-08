using MySql.Data.MySqlClient;
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
        //public Connection(int _id)
        //{
        //    System.Text.EncodingProvider provider;
        //    provider = System.Text.CodePagesEncodingProvider.Instance;
        //    Encoding.RegisterProvider(provider);
        //    People.Clear();

        //    //ConnectAsync(_id.ToString());
        //    test();
        //}

        public Connection()
        {
            System.Text.EncodingProvider provider;
            provider = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);
            People.Clear();
        }

        private static ObservableCollection<Person> _People = new ObservableCollection<Person>();
        public ObservableCollection<Person> People
        {
            get { return _People; }
            set { SetProperty(ref _People, value); }
        }



        public async Task ConnectAsync(string _id)
        {
            People.Clear();

            string connStr = "server=shostka.mysql.ukraine.com.ua;user=shostka_conf;database=shostka_conf;port=3306;password=Cpu1234Pro;SslMode=None;";


            //string connStr = "server=shostka.mysql.ukraine.com.ua;user=shostka_test;database=shostka_test;port=3306;password=12345678;SslMode=None;";
            //"server=shostka.mysql.ukraine.com.ua;user=shostka_test;database=shostka_test;port=3306;password=12345678;SslMode=None;";

            try
            {

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    Debug.WriteLine("Connecting to MySQL conference...");
                    conn.Open();

                    string sql = "SELECT users.*, conference_" +_id+ ".is_visited FROM conference_" +_id+ " LEFT JOIN users ON conference_" +_id+ ".user_id = users.id";
                    
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    //cmd.Parameters.AddWithValue("@id",_id);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        //await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                        //{
                            while (rdr.Read())
                            {
                                People.Add(new Person
                                {
                                    id = rdr.GetInt32("id"),
                                    firstname = rdr.GetString("firstname"),
                                    lastname = rdr.GetString("lastname"),
                                    email = rdr.GetString("email"),
                                    barcode = rdr.GetString("barcode"),
                                    notes = rdr.GetString("notes"),
                                    isVisited = rdr.GetInt32("is_visited")

                                    //surname = rdr.GetString("surname"),
                                    //id = rdr.GetInt32("id"),
                                    //name = rdr.GetString("name"),
                                    //email = rdr.GetString("email"),
                                    //note = rdr.GetString("note"),
                                    //patronymic = rdr.GetString("patronymic")
                                });
                            }
                        //});


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
            try
            {
                var person = (Person)args.ClickedItem;

                var item = People.FirstOrDefault(i => i.id == person.id);
                if (item != null)
                {
                    item.isVisited = 1;
                }

                //using (MySqlConnection conn = new MySqlConnection(connStr))
                //{
                //    Debug.WriteLine("Connecting to MySQL...");
                //    conn.Open();

                //    string sql = "UPDATE participant SET note='Check' WHERE id=" + item.id;
                //    MySqlCommand cmd = new MySqlCommand(sql, conn);

                //    cmd.ExecuteNonQuery(); 

                //    conn.Close();
                //    Debug.WriteLine("Done.");
                //}



                var dialog = new MessageDialog(item.isVisited + "\n" + item.firstname + "\n" + item.lastname);
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                var dialogEx = new MessageDialog(ex.ToString());
                await dialogEx.ShowAsync();

                //Debug.WriteLine(ex.ToString());
            }

        }

        public void test()
        {
            
                People.Add(new Person
                {
                    id = 1,
                    firstname = "firstname1",
                    lastname = "lastname1",
                    email = "email1",
                    barcode = "barcode1",
                    notes = "notes1",
                    isVisited = 0
                });

                People.Add(new Person
                {
                    id = 2,
                    firstname = "firstname2",
                    lastname = "lastname2",
                    email = "email2",
                    barcode = "barcode2",
                    notes = "notes2",
                    isVisited = 0
                });

                People.Add(new Person
                {
                    id = 3,
                    firstname = "firstname3",
                    lastname = "lastname3",
                    email = "email3",
                    barcode = "barcode3",
                    notes = "notes3",
                    isVisited = 0
                });
            
            
        }
    }
}
