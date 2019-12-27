using CM2Projet.Metier;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class pageGeographie : Page
    {
        Joueur J = null;
        
        public pageGeographie()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            J = (Joueur)e.Parameter;
            BackButton.IsEnabled = this.Frame.CanGoBack;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
        }

        private bool On_BackRequested()
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           // EuropeRandom();
            onlyCity(EuropeRandom());
            Drapeaux();
        }

        private void choice4_Click(object sender, RoutedEventArgs e)
        {
            choice4.Content = "zefzef";
        }

        private void choice1_Click(object sender, RoutedEventArgs e)
        {
            onlyCity(EuropeRandom());
        }

        private void choice2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void choice3_Click(object sender, RoutedEventArgs e)
        {

        }
        public string EuropeRandom()
        {
            List<string> ListeEurope = new List<String>() { "France:Paris", "Allemagne:Berlin", "Italie:Rome", "Espagne:Madrid", "Royaume-Unis:Londres", "Irlande:Dublin", "Portugal:Lisbonne", "Belgique:Bruxelles", "Luxembourg:Luxembourg", "Pays-Bas:Amsterdam", "Suisse:Berne", "Danemark:Copenhague", "Norvège:Oslo", "Suède:Stockholm", "Finlande:Helsinki", "Estonie:Tallinn", "Lettonie:Riga", "Lituanie:Vilnius", "Pologne:Varsovie", "RépubliqueTchèque:Prague", "Liechtenstein/", "Autriche:Vienne", "Slovaquie:Bratislava", "Hongrie:Budapest", "Slovénie:Ljubljana", "Andorre/", "Monaco/", "Saint-Marin/", "Turquie:Ankara", "Vatican/", "Croatie:Zagreb", "Bosnie-Herzégovine:Sarajevo", "Malte/", "Roumanie:Bucarest", "Yougoslavie:Belgrade", "Bulgarie:Sofia", "Albanie:Tijana", "Macédoine:Skopje", "Grèce:Athène", "Moldavie:Chisinau", "Ukraine:Kiev", "Biélorussie:Minsk", "Russie:Moscou", "Géorgie:Tbilissi", "Azerbaïdjan:Bakou", "Arménie:Erevan", "Serbie/", "Islande:Reykjavik", "Monténégro" };
            Random PaysRandom = new Random();
            int lavaleur = PaysRandom.Next(0, ListeEurope.Count);
            string PaysVilleAleatoire = ListeEurope[lavaleur];
            Debug.WriteLine("--------------------------------------");
            Debug.WriteLine(ListeEurope[lavaleur]);
            return PaysVilleAleatoire;
        }
        public string onlyCity(string random)
        {

            string[] stringRandom = { random};
            int compteur = 0;
            string villePays ="";
            if (random.Contains("/"))
            {
                villePays = random.Substring(0, random.Length - 1);
            }
            else
            {
                foreach (string chaine in stringRandom)
                {
                    compteur = chaine.IndexOf(":");
                    villePays = chaine.Substring(compteur + 1);
                }
            }
            
            Debug.WriteLine(villePays);
            return villePays;
        }

        

        private void Drapeaux()
        {
            ImageOk.Source = new BitmapImage(new Uri("ms-appx:///img/FR.svg"));
        }

        private void BtnDrapeaux_Click(object sender, RoutedEventArgs e)
        {
           Drapeaux();
        }
    }
}
