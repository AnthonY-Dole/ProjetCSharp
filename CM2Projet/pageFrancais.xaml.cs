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
using Windows.UI.Popups;



// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    /// 
    public sealed partial class pageFrancais : Page
    {

        Joueur J = null;
        DicoApi apidico = new DicoApi();
        public pageFrancais()
        {
            this.InitializeComponent();
        }
        string test;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            prenomContext.DataContext = J.Prenom +" trouve le synonyme du mot :";
            motAlea.DataContext = apidico.MotsAleatoire();

           Context.DataContext = "Trouve maintenant l'Antonyme du mot :";
            motAlea2.DataContext = apidico.MotsAleatoire();

            Dico.DataContext = "Trouve le mots de la définitions suivante:";

            test = apidico.MotsAleatoire();
            apidico.motCompare("definitions", textBoxReponseAntonyme.Text, test);
          //  motAlea3.DataContext = ANTHO.MotDico[0];
            ANTHO.MotDico.Clear();
            test = apidico.MotsAleatoire();

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
        int compteur = 0;
        private  async void  valider_Click(object sender, RoutedEventArgs e)
        {
            
            compteur++;
            var msgAlerte = new MessageDialog("Le jeux Synonyme et finis vous avez jouer" + compteur.ToString() + " fois");
            if (compteur <= 10)
            {
                string motAfficher = motAlea.DataContext.ToString();
                if (valider.IsEnabled == false)
                {
                    AfficherDialogRessayer();
                }
                else
                {


                    if (apidico.motCompare("synonymes", textBoxReponseSynonyme.Text, motAfficher) == true)
                    {

                        AfficherDialogBravo();
                        J.ScoreFR = J.ScoreFR + 7;
                        ScoreSynonyme.DataContext = "+ 14 points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";
                        ScoreSynonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);

                    }
                    else
                    {
                        ScoreSynonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                        AfficherDialogRessayer();
                        J.ScoreFR = J.ScoreFR - 4;
                        ScoreSynonyme.DataContext = "- 4 points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";
                    }
                    motAlea.DataContext = apidico.MotsAleatoire();

                }
            }
            else
            {

                valider.IsEnabled = false;
                await  msgAlerte.ShowAsync();
                
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
                    Title = "Exercice",
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
                Title = "Exercice ",
                Content = "AH,tu a eu faux",
                PrimaryButtonText = "SUIVANT",
                DefaultButton = ContentDialogButton.Primary
            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

            }
        }
        private async void AfficherDialogFinJeux()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Exercice ",
                Content = "Fin du jeux jouer passer au suivant",
                PrimaryButtonText = "D'accord",
                DefaultButton = ContentDialogButton.Primary
            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

            }
        }

        private void validerAntonyme_Click(object sender, RoutedEventArgs e)
        {
            if (compteur <= 10)
            {
                string motAfficher2 = motAlea2.DataContext.ToString();
            if (validerAntonyme.IsEnabled == false)
            {
                AfficherDialogRessayer();
            }
            else
            {

               
                if (apidico.motCompare("antonymes",textBoxReponseAntonyme.Text, motAfficher2) == true)
                {

                    AfficherDialogBravo();
                    J.ScoreFR = J.ScoreFR + 7;
                    ScoreAntonyme.DataContext = "+ 14 points";
                    ScoreJoueur.DataContext = J.ScoreFR + " points";
                        ScoreAntonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    }
                else
                {
                        ScoreAntonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                        AfficherDialogRessayer();
                    J.ScoreFR = J.ScoreFR - 4;
                    ScoreAntonyme.DataContext = "- 4 points";
                    ScoreJoueur.DataContext = J.ScoreFR + " points";
                }
                motAlea2.DataContext = apidico.MotsAleatoire();
                }
            }
            else
            {
                var msgAlerte = new MessageDialog("Le jeux Synonyme et finis vous avez jouer" + compteur.ToString());
                validerAntonyme.IsEnabled = false;
            }
        }

        private void textBoxReponseAntonyme_TextChanged(object sender, TextChangedEventArgs e)
        {
            String antonymeJoueur = textBoxReponseAntonyme.Text;

            if (antonymeJoueur != "")
            {
                validerAntonyme.IsEnabled = true;
            }
            else
            {
                validerAntonyme.IsEnabled = false;
            }
        }
        //Definitions
        private void textBoxReponseDefinitions_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            String definitionsJoueur = textBoxReponseDefinitions.Text;

            if (definitionsJoueur != "")
            {
                validerDefinitions.IsEnabled = true;
            }
            else
            {
                validerDefinitions.IsEnabled = false;
            }
        }

        private void validerDefinitions_Click(object sender, RoutedEventArgs e)
        {

            string MotdefinitionsAfficher = test;
            //motAlea3.DataContext.ToString();
            if (validerDefinitions.IsEnabled == false)
            {
                AfficherDialogRessayer();
            }
            else
            {
              
                if (apidico.motCompare("definitions", textBoxReponseDefinitions.Text, MotdefinitionsAfficher) == true)
                {

                    AfficherDialogBravo();
                    J.ScoreFR = J.ScoreFR + 7;
                    ScoreDictionnaire.DataContext = "+ 30 points";
                    ScoreJoueur.DataContext = J.ScoreFR + " points";
                    ScoreDictionnaire.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                }
                else
                {
                    ScoreDictionnaire.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AfficherDialogRessayer();
                    J.ScoreFR = J.ScoreFR - 4;
                    ScoreDictionnaire.DataContext = "- 7 points";
                    ScoreJoueur.DataContext = J.ScoreFR + " points";
                   
                }
             
                motAlea3.DataContext = ANTHO.MotDico[0];
                ANTHO.MotDico.Clear();
                test = apidico.MotsAleatoire();

            }
        }
    }


}
