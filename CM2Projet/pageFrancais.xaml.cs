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
using RestSharp;
using RestSharp.Authenticators;
using System.Diagnostics;


// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class pageFrancais : Page
    {
        public class Mots
        {
            public string Valeur { get; set; }
     

        }
       

        private Mots motSynonyme;

      
        const string BaseUrl = "https://api.dicolink.com";

        readonly IRestClient _client;

        string _version = "v1";
        string _mot = "mot";
        public pageFrancais()
        {
            this.InitializeComponent();

          
            _client = new RestClient(BaseUrl);

        }

        public T Execute<T>(RestRequest request) where T : new()
        {

            request.AddParameter("version", _version, ParameterType.UrlSegment);
            request.AddParameter("mot", _mot, ParameterType.UrlSegment);

            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Erreur de requete veuillez ressayer.";
                var dicoExeption = new Exception(message, response.ErrorException);
                throw dicoExeption;
            }
            return response.Data;
        }
        public pageFrancais GetSynonyme(string unMot)
        {
            var categorie = "synonymes";
            var request = new RestRequest("/{mot}/{categorie}{other}{key}");
            request.AddUrlSegment("mot", unMot);
            request.AddUrlSegment("categorie", categorie);
            request.AddParameter("other", "?limite=5&api_key=", ParameterType.UrlSegment);
            request.AddParameter("key", "_AjY_O0PDQfz7TlaeZV5rJrOzjngiqk3", ParameterType.UrlSegment);
            return Execute<pageFrancais>(request);
        }
        public pageFrancais GetMotHasard()
        {
            var request = new RestRequest("/motauhasard?avecdef=true&minlong=5&maxlong=-1&verbeconjugue=false&api_key=");
            request.AddParameter("key", "_AjY_O0PDQfz7TlaeZV5rJrOzjngiqk3", ParameterType.UrlSegment);
            return Execute<pageFrancais>(request);
        }
   
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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
        private void valider_Click(object sender, RoutedEventArgs e)
        {
            if (valider.IsEnabled == false)
            {
                AfficherDialogRessayer();
                TextBlock motSynonyme = new TextBlock();
                motSynonyme.Text = "ssvsvd";
            }
            else
            {
                AfficherDialogBravo();
                TextBlock motSynonyme = new TextBlock();
                motSynonyme.Text = "ssvsvd";
            }
        }
       

        private void textBoxReponseSynonyme_TextChanged(object sender, TextChangedEventArgs e)
        {
            String synonymeJoueur = textBoxReponseSynonyme.Text;

            if (synonymeJoueur !="")
            {
               

                valider.IsEnabled = true;
               
            }
            else{
               
                valider.IsEnabled = false;
            }
        }

        

            private async void AfficherDialogBravo()
            {
                ContentDialog dialog = new ContentDialog
                {
                    Title = "Exercice Synonyme",
                    Content = "Bravo,Bonne réponse",
                    PrimaryButtonText = "CONTINUER",
                    DefaultButton = ContentDialogButton.Primary


                };
                ContentDialogResult result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {

                }
            }
        private async void AfficherDialogRessayer()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Exercice Synonyme",
                Content = "AH,tu a eu faux",
                PrimaryButtonText = "RETENTER?",
                DefaultButton = ContentDialogButton.Primary


            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

            }
        }
        
        private void motsATrouver()
        {
            motSynonyme = new Mots
            {
                Valeur = GetMotHasard().ToString()
            };
            DataContext = motSynonyme;
            
        }
      
    }
}