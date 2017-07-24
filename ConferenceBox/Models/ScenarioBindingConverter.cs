using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ConferenceBox.Models
{
    public class ScenarioBindingConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Scenario s = value as Scenario;
            return s.id + ") " + s.Name;
           // return (MainPage.Current.Scenarios.IndexOf(s) + 1) + ") " + s.Title;
        }

        public object ConvertBack(object value, Type targetType, object parametr, string language)
        {
            return true;
        }
    }
}
