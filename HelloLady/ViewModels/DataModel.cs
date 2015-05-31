using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloLady.ViewModels
{
    public class DataModel : INotifyPropertyChanged
    {
        public ObservableCollection<Item> myItems;
        public ObservableCollection<Item> MyItems 
        {
            get { return myItems; }
            set { NotifyPropertyChanged(ref myItems, value); } 
        }

        public DataModel()
        {
           
           
        }

        public bool IsDataLoaded { get; set; }
        public void LoadData(String currentSite)
        {
            MyItems = new ObservableCollection<Item>();
            RSSReader MyReader = new RSSReader(this, currentSite);
            try
            {
               this.IsDataLoaded = true;
            }
            catch (Exception)
            {
                this.IsDataLoaded = false;
              
            }
           
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool NotifyPropertyChanged<T>(ref T variable, T valeur, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(variable, valeur)) return false;

            variable = valeur;
            NotifyPropertyChanged(propertyName);
            return true;
        }

    }
}
