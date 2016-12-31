using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cplus.Entites
{
    public class Utilisateur: BaseEntity
    {
        public static string ROLE_STAGIAIRE = "STAGIAIRE";
        public static string ROLE_ADMIN = "ADMIN";

        // Authentification
        // La création d'un index dans la classe Utilisateur
        // créer un index pour chaque classe fille comme 
        // la classe Stagiaire et Formateur
        // ce qui générer une exéception lors de la Migration automatique 
        // de la base de donénes 
        // parceque les tous les index des tables prend le même nom
        // comme solution il faut nommer l'index selon le type de la classe
        // [Index("LoginIndex"  , IsUnique = true)]
        [StringLength(450)]
        public string Login { set; get; }
        public string Password { set; get; }
        public string role { set; get; }
        

        public Utilisateur() : base()
        {
            
        }
    }
}
