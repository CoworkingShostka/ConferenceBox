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
        private string _firstname;
        private string _lastname;
        private string _email;
        private string _barcode;
        private string _notes;
        private int _isVisited;

        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        public string firstname
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }
        public string lastname
        {
            get { return _lastname; }
            set { SetProperty(ref _lastname, value); }
        }
        public string barcode
        {
            get { return _barcode; }
            set { SetProperty(ref _barcode, value); }
        }
        public string email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }
        public int isVisited
        {
            get { return _isVisited; }
            set { SetProperty(ref _isVisited, value); }
        }
    }
}
