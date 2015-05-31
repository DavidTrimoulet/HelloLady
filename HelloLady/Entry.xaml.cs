using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Linq;
using HelloLady.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HelloLady
{
    public partial class Entry : PhoneApplicationPage
    {

        public ObservableCollection<SiteData> SiteCollection { get; set; }
        public XDocument Mysites { get; set; }

        public Entry()
        {
            SiteCollection = new ObservableCollection<SiteData>();
            InitializeComponent();
            Mysites = XDocument.Load("Resources/Site.xml");
            foreach (XElement c in Mysites.Element("root").Elements("site"))
            {
                SiteCollection.Add(
                    new SiteData(){
                        Name = c.Attribute("name").Value,
                        URL = c.Attribute("URL").Value
                });
            }
            DataContext = SiteCollection;
        }

        private void Button_AddSiteClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SiteLLS.SelectedItem == null)
                return;

            LongListSelector selected = sender as LongListSelector;


            // Naviguer vers la nouvelle page
            NavigationService.Navigate(new Uri("/MainPage.xaml?selectedItem=" + (SiteLLS.SelectedItem as SiteData).URL, UriKind.Relative));

            // Réinitialiser l'élément sélectionné sur Null (pas de sélection)
            SiteLLS.SelectedItem = null;
        }


    }
}