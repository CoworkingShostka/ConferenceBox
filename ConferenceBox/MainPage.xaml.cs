using ConferenceBox.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ConferenceBox
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static MainPage Current;

        public MainPage()
        {
            this.InitializeComponent();

            Current = this;


            this.conferences = new ConferenceList();

            
            //this.connection = new Connection();

        }

        public ConferenceList conferences { get; set; }
        //public Connection connection { get; set; }

        //public List<Scenario> Scenarios
        //{
        //    get { return this.scenarios; }
        //}

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    // Populate the scenario list from the SampleConfiguration.cs file
        //    ScenarioControl.ItemsSource = conferences.scenarios;
        //    //if (Window.Current.Bounds.Width < 640)
        //    //{
        //    //    ScenarioControl.SelectedIndex = -1;
        //    //}
        //    //else
        //    //{
        //    //    ScenarioControl.SelectedIndex = 0;
        //    //}
        //}


    }


}
