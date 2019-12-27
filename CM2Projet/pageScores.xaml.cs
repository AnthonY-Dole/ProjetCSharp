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
using Microsoft.Toolkit.Uwp.UI.Controls;
using CM2Projet.Metier;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>



   
    public sealed partial class pageScores : Page
    {
        public List<Joueur> LesJoueur { get; set; }
        public pageScores()
        {
            LesJoueur = ANTHO.lesJoueurs;
            this.InitializeComponent();
            ANTHO.lesJoueurs.Count();
            foreach (Joueur j in LesJoueur)
            {
                new Joueur("", "")
                {
                    Nom = j.Nom,
                    Prenom = j.Prenom,
                    ScoreFR = j.ScoreFR,
                    ScoreMATH = j.ScoreMATH,
                    ScoreGEO = j.ScoreGEO,
                    ScoreSC = j.ScoreSC,
                    ScoreTOT = j.ScoreTOT//J.getTotal(J.ScoreGEO,J.ScoreMATH,J.ScoreFR,J.ScoreSC)
                };
            }
        
        
        }


        public void UpdateJoueur(Joueur pJoueur)
        {
         
            foreach (Joueur j in ANTHO.lesJoueurs) 
            {
                if (j == pJoueur)
                {
                    if(pJoueur.ScoreFR != 0)
                    {
                        j.ScoreFR = pJoueur.ScoreFR;
                    }
                    else if(pJoueur.ScoreMATH != 0)
                    {
                        j.ScoreMATH = pJoueur.ScoreMATH;
                    }
                    else if (pJoueur.ScoreSC != 0)
                    {
                        j.ScoreSC = pJoueur.ScoreSC;
                    }
                    else if (pJoueur.ScoreGEO != 0)
                    {
                        j.ScoreGEO = pJoueur.ScoreGEO;
                    }

             
                }
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //LesJoueur = (List<Joueur>)e.Parameter;
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
        private async void AfficherDialogErreur()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Erreur",
                Content = "Aucun jeux n'a été jouer",
                PrimaryButtonText = "retour",
                DefaultButton = ContentDialogButton.Primary


            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {

            }
        }
    }
   
}
