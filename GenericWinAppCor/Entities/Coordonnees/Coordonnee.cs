using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Coordonnees
{
    public class Coordonnee : BaseEntity
    {
        public string Adresse { set; get; }

        public Ville Ville { set; get; }

        public string Email { set; get; }

        public string TelephoneFixe { set; get; }

        public string TelephonePortable { set; get; }

        public string FaceBook { set; get; }

        public string SiteWeb { set; get; }
    }
}
