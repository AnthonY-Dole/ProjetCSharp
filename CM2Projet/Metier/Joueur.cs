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
        private int scoreTOT;
        private int scoreFR;
        private int scoreSC;
        private int scoreMATH;
        private int scoreGEO;

        public Joueur(string Pnom, string Pprenom)
        {
            nom = Pnom;
            prenom = Pprenom;
            scoreTOT = 0;
            scoreFR = 0;
            scoreSC = 0;
            scoreMATH = 0;
            scoreGEO = 0;
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
        public int ScoreTOT
        {
            get { return scoreTOT; }
            set { scoreTOT = value; }
        }

        public int ScoreFR
        {
            get { return scoreFR; }
            set { scoreFR = value; }
        }

        public int ScoreSC
        {
            get { return scoreSC; }
            set { scoreSC = value; }
        }

        public int ScoreMATH
        {
            get { return scoreMATH; }
            set { scoreMATH = value; }
        }

        public int ScoreGEO
        {
            get { return scoreGEO; }
            set { scoreGEO = value; }
        }
    }
}
