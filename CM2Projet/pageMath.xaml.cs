using CM2Projet.Metier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;


// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class pageMath : Page
    {
        Joueur J = null;

        public pageMath()
        {
            this.InitializeComponent();
            initQuestions();
        }

        private void initQuestions()
        {
            // First Question is a Square.
            Rectangle mySquare = new Rectangle();
            mySquare.Width = 200;
            mySquare.Height = 200;
            Color SquareColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush SquareBrush = new SolidColorBrush();
            SquareBrush.Color = SquareColor;
            mySquare.Fill = SquareBrush;
            // Second Question is a Rectangle.
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 200;
            myRectangle.Height = 200;
            Color RectangleColor = Color.FromArgb(255, 255, 100, 20);
            SolidColorBrush RectangleBrush = new SolidColorBrush();
            RectangleBrush.Color = RectangleColor;
            myRectangle.Fill = RectangleBrush;
            // Third Question is a Circle.
            Ellipse myCircle = new Ellipse();
            myCircle.Width = 200;
            myCircle.Height = 200;
            Color CircleColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush CircleBrush = new SolidColorBrush();
            CircleBrush.Color = CircleColor;
            myCircle.Fill = CircleBrush;
            // Fourth Question is a Ellipse.
            Ellipse myEllipse = new Ellipse();
            myEllipse.Width = 200;
            myEllipse.Height = 200;
            Color EllipseColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush EllipseBrush = new SolidColorBrush();
            EllipseBrush.Color = EllipseColor;
            myEllipse.Fill = EllipseBrush;
            // Fifth Question is a Triangle.


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            prenomContext.DataContext = J.Prenom + ", voici une figure géométrique:";
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
            if (valider.IsEnabled == false)
            {
            }
            else
            {
            }
        }

        private void MultipleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String nomFigureJoueur = nomTextBox.Text;
            String coteFigureJoueur = coteTextBox.Text;
            if (nomFigureJoueur != "" && coteFigureJoueur != "")
            {
                valider.IsEnabled = true;
            }
            else
            {
                valider.IsEnabled = false;
            }
        }

        private async void AfficherDialogBravo()
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "Exercice Figures",
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
                Title = "Exercice Figures",
                Content = "AH,tu a eu faux",
                PrimaryButtonText = "RETENTER?",
                DefaultButton = ContentDialogButton.Primary
            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
            }
        }
    }
}
