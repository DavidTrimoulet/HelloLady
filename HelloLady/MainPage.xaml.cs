using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using HelloLady.Resources;
using HelloLady.ViewModels;

namespace HelloLady
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();

            // Affecter l'exemple de données au contexte de données du contrôle LongListSelector
           

            // Exemple de code pour la localisation d'ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Charger les données pour les éléments ViewModel
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedItem = "";
            NavigationContext.QueryString.TryGetValue("selectedItem", out selectedItem);
            DataContext = App.ViewModel;
            App.ViewModel.LoadData(selectedItem);
            
            
        }
                
    }
}