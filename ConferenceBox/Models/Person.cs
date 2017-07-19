using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceBox.Models
{
    public class Person : NotificationBase
    {
        
        private int _id;
        private string _surname;
        private string _name;
        private string _patronymic;
        private string _email;
        private string _note;

        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public string surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }
        public string name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        public string patronymic
        {
            get { return _patronymic; }
            set { SetProperty(ref _patronymic, value); }
        }
        public string email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string note
        {
            get { return _note; }
            set { SetProperty(ref _note, value); }
        }
    }
}
