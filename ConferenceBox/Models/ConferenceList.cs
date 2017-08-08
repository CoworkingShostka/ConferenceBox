
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
    public class ConferenceList : NotificationBase
    {
        public ConferenceList()
        {
            System.Text.EncodingProvider provider;
            provider = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(provider);
            
            ConnectAsync();
        }

        private string _TitleText = "ConferenceBox";
        public string TitleText
        {
            get { return _TitleText; }
            set { SetProperty(ref _TitleText, value); }
        }
        //public const string FEATURE_NAME = "Список конференцій";
        private bool _IsPaneOpen = true;
        public bool IsPaneOpen
        {
            get { return _IsPaneOpen; }
            set { SetProperty(ref _IsPaneOpen, value); }
        }

        private ObservableCollection<Scenario> _scenarios = new ObservableCollection<Scenario>();
        public ObservableCollection<Scenario> scenarios
        {
            get { return _scenarios; }
            set { SetProperty(ref _scenarios, value); }
        }

        string connStr = "server=shostka.mysql.ukraine.com.ua;user=shostka_conf;database=shostka_conf;port=3306;password=Cpu1234Pro;SslMode=None;";

        public async Task ConnectAsync()
        {

            //string connStr = "server=shostka.mysql.ukraine.com.ua;user=shostka_test;database=shostka_test;port=3306;password=12345678;SslMode=None;";
            //"server=shostka.mysql.ukraine.com.ua;user=shostka_test;database=shostka_test;port=3306;password=12345678;SslMode=None;";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    Debug.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql = "SELECT * FROM conferences ORDER BY id DESC";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);


                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            scenarios.Add(new Scenario
                            {
                                id = rdr.GetInt32("id"),
                                Name = rdr.GetString("name")
                            });
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

        //List<Scenario> scenarios = new List<Scenario>
        //{
        //    new Scenario() { Title = "Connect to Facebook Services" },
        //    new Scenario() { Title = "Connect to Twitter Services"},
        //    new Scenario() { Title = "Connect to Flickr Services" },
        //    new Scenario() { Title = "Connect to Google Services" }
        //};

        public async void OnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {

            ListBox scenarioListBox = sender as ListBox;
            Scenario s = scenarioListBox.SelectedItem as Scenario;
            if (s != null)
            {
                await MainPage.Current.connection.ConnectAsync(s.id.ToString());
                //UserList.Current.connection = new Connection(s.id);
                //MainPage.Current.connection = new Connection(s.id);
                IsPaneOpen = false;
                TitleText = s.Name;
            }

        }
    }

    public class Scenario : NotificationBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        //public Type ClassType { get; set; }
    }


}
