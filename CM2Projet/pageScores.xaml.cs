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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>

  

    public class Person
    {
      
        public string Nom { get; set; }
        public string TotalScore { get; set; }
        public string ScoreFrancais { get; set; }
        public string ScoreMath { get; set; }
        public string ScoreGeographie { get; set; }
        public string ScoreScience { get; set; }
    }
    public sealed partial class pageScores : Page
    {
        public List<Person> Persons { get; set; }

        public pageScores()
        {
            this.InitializeComponent();

            AfficherDialogErreur();

            Persons = new List<Person>
        {
            new Person
            {
               Nom = "Jean Eud", TotalScore = "12457",
                ScoreFrancais = "54" ,ScoreMath ="125",ScoreGeographie="314",ScoreScience="456"
            },
            new Person
            {
                 Nom = "Rene isssou", TotalScore = "2457",
                ScoreFrancais = "5544" ,ScoreMath ="125425",ScoreGeographie="31214",ScoreScience="497856"
            },
            new Person
            {
                 Nom = "Faze Arouf", TotalScore = "54457",
                ScoreFrancais = "4561" ,ScoreMath ="781",ScoreGeographie="0546",ScoreScience="678"
            }
        };
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
