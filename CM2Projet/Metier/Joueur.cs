using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Projet.Metier
{
    public class Joueur
    {
        private string nom;
        private string prenom;
        private int score;

        public Joueur(string Pnom, string Pprenom)
        {
            nom = Pnom;
            prenom = Pprenom;
            score = 0;
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
