﻿using System;
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
        pageScores scoreboard = new pageScores();
        public pageFrancais()
        {
            this.InitializeComponent();

        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //lancement Synonyme
            prenomContext.DataContext = J.Prenom +" trouve le synonyme du mot :";
            motAlea.DataContext = apidico.MotsAleatoire();
            //lancement Antonyme
            Context.DataContext = "Trouve maintenant l'Antonyme du mot :";
            motAlea2.DataContext = apidico.MotsAleatoire();
            //lancement Definition
            Dico.DataContext = "Trouve le mots de la définitions suivante:";
            motAlea3.DataContext = apidico.dico();
           
            scoreboard.UpdateJoueur(J);
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            J = (Joueur)e.Parameter;
            BackButton.IsEnabled = this.Frame.CanGoBack;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            On_BackRequested();
           // J.ScoreTOT = J.ScoreTOT + J.ScoreFR;
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
        int compteur = 0;
        int compteurAnto = 0;
        int compteurDef = 0;
        private void  valider_Click(object sender, RoutedEventArgs e)
        {
            compteur++;

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
                       
                        ScoreSynonyme.DataContext = "+ 7 points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";
                        ScoreSynonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);

                    }
                    else
                    {
                        ScoreSynonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                        AfficherDialogRessayer();
                        J.ScoreFR = J.ScoreFR - 4;
                        scoreboard.UpdateJoueur(J);
                        ScoreSynonyme.DataContext = "- 4 points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";
                    }
                    motAlea.DataContext = apidico.MotsAleatoire();
                    scoreboard.UpdateJoueur(J);
                }
            }
            else
            {
                finishGame();
                valider.IsEnabled = false;
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
            compteurAnto++;
            if (compteurAnto <= 10)
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
                            scoreboard.UpdateJoueur(J);
                            ScoreAntonyme.DataContext = "+ 7points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";
                            ScoreAntonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                        }
                    else
                    {
                            ScoreAntonyme.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                            AfficherDialogRessayer();
                        J.ScoreFR = J.ScoreFR - 4;
                            scoreboard.UpdateJoueur(J);
                            ScoreAntonyme.DataContext = "- 4 points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";
                    }
                    motAlea2.DataContext = apidico.MotsAleatoire();
                    }
                scoreboard.UpdateJoueur(J);
            }
            else
            {
                validerAntonyme.IsEnabled = false;
                finishGame();

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
        private async void finishGame()
        {
            var msgAlerte = new MessageDialog("Le jeux  et finis vous avez jouer 10 fois");
            await msgAlerte.ShowAsync();
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
            compteurDef++;
            if (compteurDef <= 10)
            {

                Debug.WriteLine(Data.MotDico);
                if (validerDefinitions.IsEnabled == false)
                {
                    AfficherDialogRessayer();
                }
                else
                {
                    Data.MotDico.Clear();
                    if (apidico.DicoAleatoire(textBoxReponseDefinitions.Text) == true)
                    {

                        AfficherDialogBravo();
                        J.ScoreFR = J.ScoreFR + 15;
                        scoreboard.UpdateJoueur(J);
                        ScoreDictionnaire.DataContext = "+ 15 points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";
                        ScoreDictionnaire.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);

                    }
                    else
                    {
                        ScoreDictionnaire.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                        AfficherDialogRessayer();
                        J.ScoreFR = J.ScoreFR - 7;
                        scoreboard.UpdateJoueur(J);
                        ScoreDictionnaire.DataContext = "- 7 points";
                        ScoreJoueur.DataContext = J.ScoreFR + " points";

                    }
                    Debug.WriteLine("Affichage  apres click du mot");
                    motAlea3.DataContext = apidico.dico();

                }
                scoreboard.UpdateJoueur(J);
            }
            else
            {
                validerDefinitions.IsEnabled = false;
                finishGame();
            }
        }
    }


}
