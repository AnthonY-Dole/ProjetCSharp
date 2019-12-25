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
        public string listemot { get; set; }
        string _apiKey = "_AjY_O0PDQfz7TlaeZV5rJrOzjngiqk3";


        public DicoApi()
        {

        }
        public DicoApi Get(string categorie, string unmot)
        {
            var restClient = new RestClient("https://api.dicolink.com/v1/mot");
            var request = new RestRequest(unmot + "/" + categorie, Method.GET);
            request.AddParameter("limite", "5", ParameterType.QueryString);
            request.AddParameter("api_key", _apiKey);

            var reponse2 = restClient.Execute<List<DicoApi>>(request);


            foreach (DicoApi items in reponse2.Data)
            {
                Console.WriteLine(items.mot);
                Debug.WriteLine(items.mot);
                ANTHO.ListeMot.Add(items.mot);

            }
            return reponse2.Data[0];
            // return listemot;
        }
        public DicoApi GetAleaWord()
        {
            var restClient = new RestClient("https://api.dicolink.com/v1/mots");
            var request = new RestRequest("motsauhasard?avecdef=false&minlong=5&maxlong=5&verbeconjugue=true&limite=1", Method.GET);

            request.AddParameter("api_key", _apiKey);

            var reponse = restClient.Execute<List<DicoApi>>(request);


            foreach (DicoApi item in reponse.Data)
            {
                Console.WriteLine(item.mot);
                Debug.WriteLine(item.mot);
                listemot = item.mot;
                ANTHO.MotAlea.Add(item.mot);
            }

            return reponse.Data[0];
        }
    }
}
