using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Diagnostics;

namespace CM2Projet
{
    class DicoApi
    {
        public string mot { get; set; }
        public string definition { get; set; }
        public string listemot { get; set; }
        string _apiKey = "_AjY_O0PDQfz7TlaeZV5rJrOzjngiqk3";
       
        string def = string.Empty;

        bool imp = false;
        public DicoApi()
        {

        }
        public DicoApi Get(int limite, string categorie, string unmot)
        {
            int cpt = 0;
            int cpt2 = 0;
            var restClient = new RestClient("https://api.dicolink.com/v1/mot");
            var request = new RestRequest(unmot + "/" + categorie, Method.GET);
            request.AddParameter("limite", limite, ParameterType.QueryString);
            request.AddParameter("api_key", _apiKey);

            var reponse2 = restClient.Execute<List<DicoApi>>(request);


            if (categorie == "definitions")
            {
                if (imp == false)
                {


                    foreach (DicoApi items in reponse2.Data)
                    {
                        Debug.WriteLine(items.mot, "----2----");

                        if (cpt2 == 1)
                        {
                            Data.MotDico.Add(items.definition);
                            break;
                        }
                        cpt2 += 1;

                    }


                    foreach (DicoApi items in reponse2.Data)
                    {
                        if (cpt == 2)
                        {
                            Data.ListeMot.Add(items.mot);
                            break;
                        }

                        cpt += 1;
                    }

                    imp = true;
                }

            }
            else
            {
                foreach (DicoApi items in reponse2.Data)
                {
                    Debug.WriteLine(items.mot, "----2----");
                    Data.ListeMot.Add(items.mot);

                }
            }

            return reponse2.Data[0];

        }
        public string MotsAleatoire()
        {
            List<string> MotsFind = new List<String>() { "acheter", "aider", "aimer", "aller", "apporter", "apprendre", "arrêter", "arriver", "attendre", "boire", "changer", "choisir", "commencer", "comprendre", "continuer", "coucher", "couper", "coûter", "croire", "connaître", "courir", "décider", "décrire", "demander", "dépêcher", "descendre", "devenir", "devoir", "dire", "donner", "dormir", "écouter", "écrire", "effacer", "entendre", "entrer", "envoyer", "essayer", "faire", "fermer", "finir", "gagner", "inquiéter", "inviter", "jouer", "laver", "lever", "lire", "manger", "mettre", "monter", "mourir", "nager", "naître", "neiger", "nettoyer", "obéir", "obtenir", "oublier", "ouvrir", "pardonner", "parler", "partir", "passer", "payer", "penser", "perdre", "pleurer", "porter", "pouvoir", "préférer", "prendre", "préparer", "sepromener", "quitter", "raconter", "réfléchir", "regarder", "remplacer", "remplir", "répéter", "répondre", "reposer", "rester", "retourner", "réussir", "réveiller", "savoir", "sortir", "suivre", "terminer", "tomber", "travailler", "trouver", "utiliser", "vendre", "venir", "visiter", "voir", "vouloir" };
            Random randomWord = new Random();
            int valeur = randomWord.Next(0, MotsFind.Count);
            Debug.WriteLine("-----------------------");
            string MotAleatoire = MotsFind[valeur];
            Debug.WriteLine(MotsFind[valeur]);
            Debug.WriteLine("-----------------------");

            return MotAleatoire;
        }

        public string dico()
        {
            string motrandom = MotsAleatoire();
            Get(1000, "definitions", motrandom);
            foreach (string s in Data.MotDico)
            {
                def = s;
            }
            return def;
        }
        public bool DicoAleatoire(string joueurRep)
        {
            bool DicoResultleatoire = false;

            string motrandom = MotsAleatoire();
            DicoResultleatoire = motCompare("definitions", joueurRep, motrandom);


            return DicoResultleatoire;
        }

        public bool motCompare(string categorie, string motuser, string motAlea)
        {
            
            bool result = false;
            if (imp == true)
            {
                List<string> MotFind = new List<string>();
                foreach (string l in Data.ListeMot)
                {
                    MotFind.Add(l);

                    int i = 0;
                    Debug.WriteLine(MotFind[i]);
                    i++;
                }
                Data.ListeMot.Clear();
                
                foreach (string s in MotFind)
                {

                    if (s == motuser)
                    {
                        result = true;
                        Debug.WriteLine(result);
                    }
                    else
                    {
                        Debug.WriteLine(result);

                    }

                }
                MotFind.Clear();
                imp = false;
            }
            return result;
        }

    }
}
