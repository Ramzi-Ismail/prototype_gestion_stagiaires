using App.Modules;
using LinqExtension;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.AutoFormation
{
    internal class RechercheModuleParFiliere
    {
        public RechercheModuleParFiliere()
        {
            using (var context = new ModelContext())
            {

                var u = Type.GetType("App.GestionStagiaires.Filiere, Entites");

                Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
                //dictionary["Duree"] = new List<string> {
                //    "=1"
                //};

                dictionary["Filiere"] = new List<string> {
                    "=1"
                };

                var data = context.Modules.CollectionToQuery(dictionary).ToList();

                List<Module> ls = data.ToList<Module>();
            }
        }
    }
}