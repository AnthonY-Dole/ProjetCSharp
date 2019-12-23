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
using CM2Projet.Metier;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CM2Projet
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Joueur J = null;
        Frame rootFrame = Window.Current.Content as Frame;
        public string leJoueur { get; set; }
        private MainPage pseudoJoueur;

        public MainPage()
        {
            this.InitializeComponent();
           
        }

        public void init()
        {
           
        }

        private void btnjoueurvalid_Click(object sender, RoutedEventArgs e)
        {
            pseudoJoueur = new MainPage
            {
                leJoueur = "Bonjour " + textBoxPrenom.Text
            };
            DataContext = pseudoJoueur;
          /*  Joueur currentJoueur = (Joueur);
            Application.Current.Resources["monJoueur"] = currentJoueur; 
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(pageFrancais));*/
        }

        private void btnScience_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            Frame.Navigate(typeof(pageScience));
        }

        private void btnFrancais_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            Frame.Navigate(typeof(pageFrancais));
        }

        private void btnMath_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            Frame.Navigate(typeof(pageMath));
        }

        private void btnGeographie_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            Frame.Navigate(typeof(pageGeographie));
        }

        private void btnScore_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            Frame.Navigate(typeof(pageScores));
        }

        private void textBoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxNom.Text != "" && textBoxPrenom.Text != "")
            {
                btnScience.IsEnabled = true;
                btnFrancais.IsEnabled = true;
                btnMath.IsEnabled = true;
                btnGeographie.IsEnabled = true;
                //btnScore.IsEnabled = true;
                btnjoueurvalid.IsEnabled = true;
            }
            else
            {
                btnScience.IsEnabled = false;
                btnFrancais.IsEnabled = false;
                btnMath.IsEnabled = false;
                btnGeographie.IsEnabled = false;
                //btnScore.IsEnabled = false;
                btnjoueurvalid.IsEnabled = false;
            }
        }

        private void textBoxPrenom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxNom.Text != "" && textBoxPrenom.Text != "")
            {
                btnScience.IsEnabled = true;
                btnFrancais.IsEnabled = true;
                btnMath.IsEnabled = true;
                btnGeographie.IsEnabled = true;
                //  btnScore.IsEnabled = true;
                btnjoueurvalid.IsEnabled = true;
            }
            else
            {
                btnScience.IsEnabled = false;
                btnFrancais.IsEnabled = false;
                btnMath.IsEnabled = false;
                btnGeographie.IsEnabled = false;
                //btnScore.IsEnabled = false;
                btnjoueurvalid.IsEnabled = false;
            }
        }
        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }



    
}
