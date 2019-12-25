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
using CM2Projet.Metier;
using System.ComponentModel;



// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class pageFrancais : Page
    {
        Joueur J = null;
        DicoApi apidico = new DicoApi();

        const string BaseUrl = "https://api.dicolink.com";

      

        
        public pageFrancais()
        {
            this.InitializeComponent();

          

            

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            prenomContext.DataContext = J.Prenom +" trouve le synonyme du mot :";
            motsATrouver();

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
        private void valider_Click(object sender, RoutedEventArgs e)
        {
            motsATrouver();
            if (valider.IsEnabled == false)
            {
                AfficherDialogRessayer();

            }
            else
            {
                bool test = true;
              if (test == motCompare(textBoxReponseSynonyme.Text))
                {
                   
                    AfficherDialogBravo();
                    J.ScoreFR = J.ScoreFR +5;
                }
                else
                {
                    AfficherDialogRessayer();
                   
                }

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
                PrimaryButtonText = "SUIVANT",
                DefaultButton = ContentDialogButton.Primary


            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

            }
        }

        private void motsATrouver()
        {

            apidico.GetAleaWord().ToString();
            BindingList<string> MotAlea = new BindingList<string>();
            foreach (string l in ANTHO.MotAlea)
            {
                MotAlea.Add(l);
            }
            for (int i = 0; i < MotAlea.Count; i++)
            {
                motAlea.DataContext = MotAlea[i];
            }
            
            // Debug.WriteLine(motAlea.DataContext);
           


        }
        private  bool motCompare(string motuser)
        {

            apidico.Get("synonymes", ANTHO.MotAlea[0].ToString());
            BindingList<string> ListeMot = new BindingList<string>();
            foreach (string l in ANTHO.ListeMot)
            {
                ListeMot.Add(l);
                Debug.WriteLine(ListeMot[0]);
            }
            bool result =false;
            //List<string> chaines = new List<string>(); 
            //chaines.Add(motuser);
            // bool result = ListeMot.All(s => chaines.Contains(s)) && chaines.All(s => ListeMot.Contains(s));
            foreach (string s in ListeMot)
            {
               
                if (s == motuser)
                {
                 result = true;
                    Debug.WriteLine(result);
                }
                else
                {
                    Debug.WriteLine("false");
                   
                }
                Debug.WriteLine(ListeMot[0]);
            }
            return result;
            /* Debug.WriteLine(result);
             if (result ==true)
             {

             }*/
        }

    }


}
