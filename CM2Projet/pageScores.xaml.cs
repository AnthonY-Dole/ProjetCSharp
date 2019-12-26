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
        Joueur J = null;
        public List<Joueur> LesJoueur { get; set; }
        public pageScores()
        {
            this.InitializeComponent();

            LesJoueur = new List<Joueur>
             {
               new Joueur("michel","eud")
               {
                  Nom="ervev" ,Prenom="rvrv", ScoreFR = 35,ScoreMATH = 60,ScoreGEO= 120,ScoreSC= 20,ScoreTOT =5454//J.getTotal(J.ScoreGEO,J.ScoreMATH,J.ScoreFR,J.ScoreSC)
               },
                 new Joueur("erfef","efef")
               {
                   Nom="EUD" ,Prenom="AROUF", ScoreFR =322585,ScoreMATH =6827820,ScoreGEO=127220,ScoreSC=7222220,ScoreTOT =454//J.getTotal(J.ScoreGEO,J.ScoreMATH,J.ScoreFR,J.ScoreSC)
               },
            };
          /*  if (LesJoueur.Contains() =null)
            {
                AfficherDialogErreur();
            }*/
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
     
         

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
