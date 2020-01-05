using CM2Projet.Metier;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
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
        pageScores scoreboard = new pageScores();
        Rectangle mySquare = new Rectangle();
        Rectangle myRectangle = new Rectangle();
        Ellipse myCircle = new Ellipse();
        Ellipse myEllipse = new Ellipse();
        Polygon myTriangle = new Polygon();
        Polygon myPentagon = new Polygon();
        Polygon myHexagon = new Polygon();
        Polygon myHeptagon = new Polygon();
        List<Shape> shapes = new List<Shape>();

        public pageMath()
        {
            this.InitializeComponent();
            initQuestions();
            listShape();
            LayoutRootForFigure.Children.Add(randomShape());
            animate();
        }

        public void initQuestions()
        {

            mySquare.Width = 200;
            mySquare.Height = 200;
            mySquare.Name = "carre";
            Color SquareColor = Color.FromArgb(255, 92, 119, 214);
            SolidColorBrush SquareBrush = new SolidColorBrush();
            SquareBrush.Color = SquareColor;
            mySquare.Fill = SquareBrush;

            myRectangle.Width = 400;
            myRectangle.Height = 200;
            myRectangle.Name = "rectangle";
            Color RectangleColor = Color.FromArgb(255, 144, 158, 209);
            SolidColorBrush RectangleBrush = new SolidColorBrush();
            RectangleBrush.Color = RectangleColor;
            myRectangle.Fill = RectangleBrush;

            myCircle.Width = 200;
            myCircle.Height = 200;
            myCircle.Name = "cercle";
            Color CircleColor = Color.FromArgb(255, 118, 173, 120);
            SolidColorBrush CircleBrush = new SolidColorBrush();
            CircleBrush.Color = CircleColor;
            myCircle.Fill = CircleBrush;

            myEllipse.Width = 400;
            myEllipse.Height = 200;
            myEllipse.Name = "ellipse";
            Color EllipseColor = Color.FromArgb(255, 194, 153, 175);
            SolidColorBrush EllipseBrush = new SolidColorBrush();
            EllipseBrush.Color = EllipseColor;
            myEllipse.Fill = EllipseBrush;

            Point pointTriangle1 = new Point(0, 0);
            Point pointTriangle2 = new Point(0, 300);
            Point pointTriangle3 = new Point(300, 0);
            PointCollection trianglePoints = new PointCollection();
            trianglePoints.Add(pointTriangle1);
            trianglePoints.Add(pointTriangle2);
            trianglePoints.Add(pointTriangle3);
            myTriangle.Points = trianglePoints;
            Color TriangleColor = Color.FromArgb(255, 0, 0, 0);
            SolidColorBrush TriangleBrush = new SolidColorBrush();
            TriangleBrush.Color = TriangleColor;
            myTriangle.Fill = TriangleBrush;
            myTriangle.Name = "triangle";

            Point pointPentagon1 = new Point(125, 250);
            Point pointPentagon2 = new Point(250, 150);
            Point pointPentagon3 = new Point(200, 0);
            Point pointPentagon4 = new Point(50, 0);
            Point pointPentagon5 = new Point(0, 150);
            PointCollection pentagonPoints = new PointCollection();
            pentagonPoints.Add(pointPentagon1);
            pentagonPoints.Add(pointPentagon2);
            pentagonPoints.Add(pointPentagon3);
            pentagonPoints.Add(pointPentagon4);
            pentagonPoints.Add(pointPentagon5);
            myPentagon.Points = pentagonPoints;
            Color PentagonColor = Color.FromArgb(255, 255, 255, 255);
            SolidColorBrush PentagonBrush = new SolidColorBrush();
            PentagonBrush.Color = PentagonColor;
            myPentagon.Fill = PentagonBrush;
            myPentagon.Name = "pentagone";

            Point pointHexagon1 = new Point(75, 300);
            Point pointHexagon2 = new Point(225, 300);
            Point pointHexagon3 = new Point(300, 150);
            Point pointHexagon4 = new Point(225, 0);
            Point pointHexagon5 = new Point(75, 0);
            Point pointHexagon6 = new Point(0, 150);
            PointCollection HexagonPoints = new PointCollection();
            HexagonPoints.Add(pointHexagon1);
            HexagonPoints.Add(pointHexagon2);
            HexagonPoints.Add(pointHexagon3);
            HexagonPoints.Add(pointHexagon4);
            HexagonPoints.Add(pointHexagon5);
            HexagonPoints.Add(pointHexagon6);
            myHexagon.Points = HexagonPoints;
            Color HexagonColor = Color.FromArgb(255, 255, 100, 70);
            SolidColorBrush HexagonBrush = new SolidColorBrush();
            HexagonBrush.Color = HexagonColor;
            myHexagon.Fill = HexagonBrush;
            myHexagon.Name = "hexagone";

            Point pointHeptagon1 = new Point(150, 300);
            Point pointHeptagon2 = new Point(250, 250);
            Point pointHeptagon3 = new Point(300, 150);
            Point pointHeptagon4 = new Point(225, 0);
            Point pointHeptagon5 = new Point(75, 0);
            Point pointHeptagon6 = new Point(0, 150);
            Point pointHeptagon7 = new Point(50, 250);
            PointCollection HeptagonPoints = new PointCollection();
            HeptagonPoints.Add(pointHeptagon1);
            HeptagonPoints.Add(pointHeptagon2);
            HeptagonPoints.Add(pointHeptagon3);
            HeptagonPoints.Add(pointHeptagon4);
            HeptagonPoints.Add(pointHeptagon5);
            HeptagonPoints.Add(pointHeptagon6);
            HeptagonPoints.Add(pointHeptagon7);
            myHeptagon.Points = HeptagonPoints;
            Color HeptagonColor = Color.FromArgb(255, 255, 255, 13);
            SolidColorBrush HeptagonBrush = new SolidColorBrush();
            HeptagonBrush.Color = HeptagonColor;
            myHeptagon.Fill = HeptagonBrush;
            myHeptagon.Name = "heptagone";
        }

        private void listShape()
        {
            shapes.Add(mySquare);
            shapes.Add(myRectangle);
            shapes.Add(myCircle);
            shapes.Add(myEllipse);
            shapes.Add(myTriangle);
            shapes.Add(myPentagon);
            shapes.Add(myHexagon);
            shapes.Add(myHeptagon);
        }

        private Shape randomShape()
        {
            Random rng = new Random();
            int valeur = rng.Next(0, shapes.Count);
            Shape displayed = shapes[valeur];
            Debug.WriteLine(shapes[valeur].Name);
            shapes.Remove(shapes[valeur]);
            return displayed;
        }

        private void animate()
        {
            TranslateTransform translateTransform = new TranslateTransform();
            translateTransform.X = 200;
            translateTransform.Y = 0;
            LayoutRootForFigure.Children.OfType<Shape>().FirstOrDefault().RenderTransform = translateTransform;
            Duration duration = new Duration(TimeSpan.FromMilliseconds(500));
            DoubleAnimation doubleAnimationX = new DoubleAnimation();
            DoubleAnimation doubleAnimationY = new DoubleAnimation();
            doubleAnimationX.Duration = duration;
            doubleAnimationY.Duration = duration;
            Storyboard storyboard = new Storyboard();
            storyboard.Duration = duration;
            storyboard.Children.Add(doubleAnimationX);
            storyboard.Children.Add(doubleAnimationY);
            Storyboard.SetTarget(doubleAnimationX, translateTransform);
            Storyboard.SetTarget(doubleAnimationY, translateTransform);
            Storyboard.SetTargetProperty(doubleAnimationX, "X");
            Storyboard.SetTargetProperty(doubleAnimationY, "Y");
            doubleAnimationX.To = 0;
            doubleAnimationY.To = 0;
            LayoutRootForFigure.Resources.Add("storyboard", storyboard);
            storyboard.Begin();
            LayoutRootForFigure.Resources.Clear();
        }

        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            prenomContext.DataContext = J.Prenom + ", voici une figure géométrique:";
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
            //scoreboard.UpdateJoueur(J);
        }

        private bool On_BackRequested()
        {
            //if (J.ScoreMATH < 0)
            //{
            //    J.ScoreMATH = 0;
            //}
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                return true;
            }
            return false;
        }

        int compteur = 0;

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            compteur++;
            Debug.WriteLine("Question " + compteur + " en cours de validation :");
            if (compteur <= 8)
            {
                Debug.WriteLine("Je verifie la question");
                switch (LayoutRootForFigure.Children.OfType<Shape>().FirstOrDefault().Name)
                {
                    case "carre":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == mySquare.Name && coteTextBox.Text == "4")
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                    case "rectangle":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == myRectangle.Name && coteTextBox.Text == "4")
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                    case "cercle":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == myCircle.Name && (coteTextBox.Text.ToLower() == "infini" || coteTextBox.Text == "0"))
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                    case "ellipse":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == myEllipse.Name && (coteTextBox.Text.ToLower() == "infini" || coteTextBox.Text == "0"))
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                    case "triangle":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == myTriangle.Name && (coteTextBox.Text == "3"))
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                    case "pentagone":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == myPentagon.Name && (coteTextBox.Text == "5"))
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                    case "hexagone":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == myHexagon.Name && (coteTextBox.Text == "6"))
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                    case "heptagone":
                        if (RemoveDiacritics(nomTextBox.Text).ToLower() == myHeptagon.Name && (coteTextBox.Text == "7"))
                        {
                            J.ScoreMATH = J.ScoreMATH + 7;
                            AfficherDialogBravo();
                        }
                        else
                        {
                            J.ScoreMATH = J.ScoreMATH - 4;
                            AfficherDialogRessayer();
                        }
                        break;
                }
            }
            if (compteur == 8)
            {
                finishGame();
            }
            if (shapes.Count != 0)
            {
                LayoutRootForFigure.Children.Clear();
                Debug.WriteLine("J'ajoute une figure");
                LayoutRootForFigure.Children.Add(randomShape());
                animate();
                Debug.WriteLine("Je clear les champs");
                nomTextBox.Text = String.Empty;
                coteTextBox.Text = String.Empty;
            } else
            {
                Debug.WriteLine("Je n'ajoute plus de figures");
            }
            Debug.WriteLine("----------");
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
                Content = "Bravo, bonne réponse.",
                PrimaryButtonText = "Question suivante",
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
                Content = "Faux!",
                PrimaryButtonText = "Question suivante",
                DefaultButton = ContentDialogButton.Primary
            };
            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
            }
        }

        private async void finishGame()
        {
            if (J.ScoreMATH < 0)
            {
                J.ScoreMATH = 0;
            }
            scoreboard.UpdateJoueur(J);
            var msgAlerte = new MessageDialog("Le jeu est terminé, vous avez joué 8 fois et obtenu " + J.ScoreMATH.ToString() + "/56 !");
            await msgAlerte.ShowAsync();
        }
    }
}
