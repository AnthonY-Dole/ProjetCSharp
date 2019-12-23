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
      
        const string BaseUrl = "https://api.dicolink.com";

        readonly IRestClient _client;

        string _version = "v1";
        string _mot = "mot";

        public DicoApi()
        {
            _client = new RestClient(BaseUrl);
           
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
           
            request.AddParameter("version", _version, ParameterType.UrlSegment);
            request.AddParameter("mot", _mot, ParameterType.UrlSegment);

            var response = _client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Erreur de requete veuillez ressayer.";
                var dicoExeption = new Exception(message, response.ErrorException);
                throw dicoExeption;
            }
            return response.Data;
        }
        public DicoApi GetSynonyme(string unMot)
        {
            var categorie = "synonymes";
            var request = new RestRequest("/{mot}/{categorie}{other}{key}");
            request.AddUrlSegment("mot", unMot);
            request.AddUrlSegment("categorie", categorie);
            request.AddParameter("other", "?limite=5&api_key=", ParameterType.UrlSegment);
            request.AddParameter("key", "_AjY_O0PDQfz7TlaeZV5rJrOzjngiqk3", ParameterType.UrlSegment);
            return Execute<DicoApi>(request);
        }
        public DicoApi GetMotHasard()
        {
            var request = new RestRequest("/motauhasard?avecdef=true&minlong=5&maxlong=-1&verbeconjugue=false&api_key=");
            request.AddParameter("key", "_AjY_O0PDQfz7TlaeZV5rJrOzjngiqk3", ParameterType.UrlSegment);
            return Execute<DicoApi>(request);
        }
 
    }
}
