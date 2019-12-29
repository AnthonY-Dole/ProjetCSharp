using CM2Projet.Metier;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        pageScores scoreboard = new pageScores();
        string toFind;
        string cityToFind;
        string countryToFind;

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
            scoreboard.UpdateJoueur(J);
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
            scoreboard.UpdateJoueur(J);
            BtnDrapeaux_Click(sender, e);
            questions.DataContext = J.Prenom +"Quelle est la capital?";
        }

        private void choice4_Click(object sender, RoutedEventArgs e)
        {
           
            Reponse(choice4.Content.ToString());
            
        }

        private void choice1_Click(object sender, RoutedEventArgs e)
        {
            Reponse(choice1.Content.ToString());
        }

        private void choice2_Click(object sender, RoutedEventArgs e)
        {
            Reponse(choice2.Content.ToString());
        }

        private void choice3_Click(object sender, RoutedEventArgs e)
        {
            Reponse(choice3.Content.ToString());
        }
        public string EuropeRandom()
        {
            List<string> ListeEurope = new List<String>() { "France:Paris", "Allemagne:Berlin", "Italie:Rome", "Espagne:Madrid", "Royaume-Unis:Londres", "Irlande:Dublin", "Portugal:Lisbonne", "Belgique:Bruxelles", "Luxembourg:Luxembourg", "Pays-Bas:Amsterdam", "Suisse:Berne", "Danemark:Copenhague", "Norvège:Oslo", "Suède:Stockholm", "Finlande:Helsinki", "Estonie:Tallinn", "Lettonie:Riga", "Lituanie:Vilnius", "Pologne:Varsovie", "RépubliqueTchèque:Prague", "Liechtenstein/", "Autriche:Vienne", "Slovaquie:Bratislava", "Hongrie:Budapest", "Slovénie:Ljubljana", "Andorre/", "Monaco/", "Saint-Marin/", "Turquie:Ankara", "Vatican/", "Croatie:Zagreb", "Bosnie-Herzégovine:Sarajevo", "Malte/", "Roumanie:Bucarest", "Yougoslavie:Belgrade", "Bulgarie:Sofia", "Albanie:Tijana", "Macédoine:Skopje", "Grèce:Athène", "Moldavie:Chisinau", "Ukraine:Kiev", "Biélorussie:Minsk", "Russie:Moscou", "Géorgie:Tbilissi", "Azerbaïdjan:Bakou", "Arménie:Erevan", "Serbie/", "Islande:Reykjavik", "Monténégro/" };
            Random PaysRandom = new Random();
            int lavaleur = PaysRandom.Next(0, ListeEurope.Count);
            string PaysVilleAleatoire = ListeEurope[lavaleur];
            Debug.WriteLine(ListeEurope[lavaleur]);
            return PaysVilleAleatoire;
        }
        public string onlyCity(string random)
        {

            string[] stringRandom = { random };
            int compteur = 0;
            string villePays = "";
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

            Debug.WriteLine("city:"+villePays);
            return villePays;
        }

        public string onlyCountry(string random)
        {

            string[] stringRandom = { random };
            int compteur = 0;
            string Pays = "";

            if (stringRandom.Contains("/"))
            {
                Pays = random.Substring(0, random.Length - 1);
               
            }
          else
            {
                foreach (string chaine in stringRandom)
                {

                    compteur = chaine.IndexOf(":");
                    Pays = chaine.Substring(0, compteur);
                }
              
            }

            Debug.WriteLine("country:"+Pays);
            return Pays;
        }


        private void Drapeaux(string drapeaux)
        {
            ImageOk.Source = new SvgImageSource(new Uri("ms-appx:///img/Drapeaux/" + drapeaux + ".svg", UriKind.Absolute));

        }

        private void BtnDrapeaux_Click(object sender, RoutedEventArgs e)
        {
             toFind = EuropeRandom();
             cityToFind = onlyCity(toFind);
             countryToFind = onlyCountry(toFind);
            nomPays.DataContext = countryToFind;
            Drapeaux(countryToFind);
            RandomButton();
            
        }

        private void RandomButton()
        { 
            choice1.Content = countryToFind;
          
            List<string> ListeVille = new List<String>() {cityToFind,onlyCity(EuropeRandom()), onlyCity(EuropeRandom()), onlyCity(EuropeRandom()) };
            Random villeRandom = new Random();
            int lavaleur = villeRandom.Next(0, ListeVille.Count);
            int lavaleur1 = villeRandom.Next(0, ListeVille.Count);
            int lavaleur2 = villeRandom.Next(0, ListeVille.Count);
            int lavaleur3 = villeRandom.Next(0, ListeVille.Count);
            choice1.Content = ListeVille[lavaleur];
            choice2.Content = ListeVille[lavaleur1];
            choice3.Content = ListeVille[lavaleur2];
            choice4.Content = ListeVille[lavaleur3];

        }

        private bool Reponse(string laville)
        {
            bool laReponse = false;

            if (laville ==cityToFind)
            {
                winGame();
                laReponse = true;
                J.ScoreGEO = J.ScoreGEO + 7;
            }
            else
            {
                loseGame();
                laReponse = false;
                J.ScoreGEO = J.ScoreGEO-4;
                
            }
            ScoreJoueurGeo.DataContext = "Score: "+J.ScoreGEO;
            return laReponse;
        }
        private async void winGame()
        {
            var msgAlerte = new MessageDialog("Bravo");
            
            await msgAlerte.ShowAsync();
            
        }
        private async void loseGame()
        {
            var msgAlerte = new MessageDialog("Ah dommage la bonne reponse était: "+cityToFind);
            await msgAlerte.ShowAsync();

        }
    }
}
