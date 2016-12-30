using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites
{
    public class Utilisateur: BaseEntity
    {
        public static string ROLE_STAGIAIRE = "STAGIAIRE";
        public static string ROLE_ADMIN = "ADMIN";

        // Authentification
        [Index("LoginIndex", IsUnique = true)]
        [StringLength(450)]
        public string Login { set; get; }
        public string Password { set; get; }
        public string role { set; get; }
        

        public Utilisateur() : base()
        {
            
        }
    }
}
