using App.Entites;
using App.GestionFormateurs;
using App.GestionStagiaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Authentification
{
    public class Authentification
    {
        


        public static Filiere filiere;
        public static Groupe groupe;
        public Utilisateur Connexion(string login, string password)
        {
            Utilisateur user = new StagiairesService().GetAll(0, 0, (s => s.Login == login && s.Password == password)).SingleOrDefault();
            if(user == null)
                 user = new FormateursService().GetAll(0, 0, (s => s.Login == login && s.Password == password)).SingleOrDefault();
            return user;
                 
        }

       
    }
}
