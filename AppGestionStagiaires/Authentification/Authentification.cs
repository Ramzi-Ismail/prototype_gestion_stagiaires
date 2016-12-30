using AppGestionStagiaires.GestionFormateurs;
using AppGestionStagiaires.GestionStagiaires;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionStagiaires.Authentification
{
    public class Authentification
    {
        public static Utilisateur user;
        public Utilisateur Connexion(string login, string password)
        {
            Utilisateur user = new StagiairesService().GetAll(0, 0, (s => s.Login == login && s.Password == password)).SingleOrDefault();
            if(user == null)
                 user = new FormateursService().GetAll(0, 0, (s => s.Login == login && s.Password == password)).SingleOrDefault();
            return user;
                 
        }

       
    }
}
