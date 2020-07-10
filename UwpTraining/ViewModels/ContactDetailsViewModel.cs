using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpTraining.ViewModels.Base;

namespace UwpTraining.ViewModels
{
    public class ContactDetailsViewModel : BindableBase
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.SetProperty(ref this.firstName, value);
                this.OnPropertyChanged(string.Empty);
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.SetProperty(ref this.lastName, value);
                this.OnPropertyChanged(string.Empty);
            }
        }

        public IList<string> FavouriteColors { get; set; }

        public string Summary => $"{FirstName} {LastName}";
    }
}
