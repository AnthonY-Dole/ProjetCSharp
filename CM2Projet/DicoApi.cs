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
        string _apiKey = "_AjY_O0PDQfz7TlaeZV5rJrOzjngiqk3";
        public DicoApi Get(string categorie, string unmot)
        {

            var restClient = new RestClient("https://api.dicolink.com/v1/mot");
            var request = new RestRequest(unmot + "/" + categorie, Method.GET);
            request.AddParameter("limite", "5", ParameterType.QueryString);
            request.AddParameter("api_key", _apiKey);
    
            var reponse2 = restClient.Execute<List<DicoApi>>(request);


            foreach (DicoApi item in reponse2.Data)
            {
                Console.WriteLine(item.mot);
               
            }
            return reponse2.Data[1];
        }

    }
}
