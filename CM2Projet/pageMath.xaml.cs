using CM2Projet.Metier;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Rectangle mySquare = new Rectangle();
        Rectangle myRectangle = new Rectangle();
        Ellipse myCircle = new Ellipse();
        Ellipse myEllipse = new Ellipse();
        List<Shape> shapes = new List<Shape>();

        public pageMath()
        {
            this.InitializeComponent();
            initQuestions();
            listShape();
            randomShape();
        }

        public void initQuestions()
        {
            // First Question is a Square.
            mySquare.Width = 200;
            mySquare.Height = 200;
            mySquare.Name = "Carré";
            int sideSquare = 4;
            Color SquareColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush SquareBrush = new SolidColorBrush();
            SquareBrush.Color = SquareColor;
            mySquare.Fill = SquareBrush;
            // Second Question is a Rectangle.
            myRectangle.Width = 400;
            myRectangle.Height = 200;
            myRectangle.Name = "Rectangle";
            int sideRectangle = 4;
            Color RectangleColor = Color.FromArgb(255, 255, 100, 20);
            SolidColorBrush RectangleBrush = new SolidColorBrush();
            RectangleBrush.Color = RectangleColor;
            myRectangle.Fill = RectangleBrush;
            // Third Question is a Circle.
            myCircle.Width = 200;
            myCircle.Height = 200;
            myCircle.Name = "Cercle";
            int sideCircle = 0;
            Color CircleColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush CircleBrush = new SolidColorBrush();
            CircleBrush.Color = CircleColor;
            myCircle.Fill = CircleBrush;
            // Fourth Question is a Ellipse.
            myEllipse.Width = 400;
            myEllipse.Height = 200;
            myEllipse.Name = "Ellipse";
            int sideEllipse = 0;
            Color EllipseColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush EllipseBrush = new SolidColorBrush();
            EllipseBrush.Color = EllipseColor;
            myEllipse.Fill = EllipseBrush;
        }

        // Creates a list of shapes.
        private void listShape()
        {
            shapes.Add(mySquare);
            shapes.Add(myRectangle);
            shapes.Add(myCircle);
            shapes.Add(myEllipse);
        }

        private void randomShape()
        {
            Random rng = new Random();
            int valeur = rng.Next(0, shapes.Count);
            LayoutRootForFigure.Children.Add(shapes[valeur]);
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
