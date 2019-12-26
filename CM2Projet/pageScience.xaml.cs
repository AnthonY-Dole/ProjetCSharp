using CM2Projet.Metier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class pageScience : Page
    {
        Joueur J = null;
        TextBox txBx;
        string txBxText;
        TextBlock txBlck;
        bool b = false;
        public pageScience()
        {
            this.InitializeComponent();
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

        private void StackPanel_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = Windows.ApplicationModel.DataTransfer.DataPackageOperation.Copy;
            e.DragUIOverride.Caption = "Déposer";
            e.DragUIOverride.IsCaptionVisible = true;
            e.DragUIOverride.IsContentVisible = true;
            e.DragUIOverride.IsGlyphVisible = true;
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            txBx = sender as TextBox;
            txBxText = txBx.Text;
            b = true;
        }

        private void sourceRep_DropCompleted(UIElement sender, DropCompletedEventArgs args)
        {
            if (b == true)
            {
                txBlck = sender as TextBlock;
                txBx.Text = txBlck.Text;
                txBlck.Visibility = Visibility.Collapsed;
            }
            b = false;

        }

        private void rep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txBxText != txBlck.Text)
            {
                foreach (TextBlock tb in FindVisualChildren<TextBlock>(this))
                {
                    if (tb.Text == txBxText)
                    {
                        tb.Visibility = Visibility.Visible;
                    }
                }
            }
        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txBx = new TextBox();
            txBxText = string.Empty;
            txBlck = new TextBlock();

            repAlveole.Text = string.Empty;
            repBroncheP.Text = string.Empty;
            repFosses.Text = string.Empty;
            repTrachee.Text = string.Empty;
            repPharynx.Text = string.Empty;
            repLarynx.Text = string.Empty;
            repPoumon.Text = string.Empty;
            repBronchiole.Text = string.Empty;

            repAlveole.Background = new SolidColorBrush(Windows.UI.Colors.White);
            repBroncheP.Background = new SolidColorBrush(Windows.UI.Colors.White);
            repFosses.Background = new SolidColorBrush(Windows.UI.Colors.White);
            repTrachee.Background = new SolidColorBrush(Windows.UI.Colors.White);
            repPharynx.Background = new SolidColorBrush(Windows.UI.Colors.White);
            repLarynx.Background = new SolidColorBrush(Windows.UI.Colors.White);
            repPoumon.Background = new SolidColorBrush(Windows.UI.Colors.White);
            repBronchiole.Background = new SolidColorBrush(Windows.UI.Colors.White);

            sourceRepAlevole.Visibility = Visibility.Visible;
            sourceRepBroncheP.Visibility = Visibility.Visible;
            sourceRepBronchiole.Visibility = Visibility.Visible;
            sourceRepFossesN.Visibility = Visibility.Visible;
            sourceRepLarynx.Visibility = Visibility.Visible;
            sourceRepPharynx.Visibility = Visibility.Visible;
            sourceRepPoumon.Visibility = Visibility.Visible;
            sourceRepTrachee.Visibility = Visibility.Visible;

        }

        private async void btnValider_ClickAsync(object sender, RoutedEventArgs e)
        {
            List<TextBox> LesRepFausses = new List<TextBox>();
            int cptRepFausse = 0;
            bool bNull = true;
            bool bFalseRep = false;
            int score = 0;
            string msgCorrection = string.Empty;
            var msgAlerte = new MessageDialog("Veuillez placer tous les mots.");
            var msgFin = new MessageDialog(""); 
            
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                if (tb.Text == "" || tb.Text == null)
                {
                    bNull = false;
                     
                    
                }
            }

            if (bNull)
            {
                foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                {
                    if (tb.Text == tb.PlaceholderText) 
                    {
                        score += 10;
                    }
                    else
                    {
                        bFalseRep = true;
                        cptRepFausse += 1;
                        LesRepFausses.Add(tb);
                    }
                }

                if (bFalseRep)
                {
                    msgCorrection = "Vous avez fait " + cptRepFausse + " faute(s), regardez maintenant la correction.";

                    foreach (TextBox tb in FindVisualChildren<TextBox>(this))
                    {
                        if (LesRepFausses.Contains(tb))
                        {
                            tb.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                            tb.Text = tb.PlaceholderText;
                        }
                        else
                        {
                            tb.Background = new SolidColorBrush(Windows.UI.Colors.DarkGreen);
                        }


                    }
                }
                else
                {
                    msgCorrection = "Bien joué vous avez eu tout juste !";
                }

                if(score == 80)
                {
                    score = 100;
                }
                msgFin = new MessageDialog("Votre score est de " + score + ". " + msgCorrection);
                await msgFin.ShowAsync();
            }
            else
            {
                await msgAlerte.ShowAsync();
            }

            J.ScoreSC = score;
        }
    }
}
