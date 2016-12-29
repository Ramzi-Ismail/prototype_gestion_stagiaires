using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Entites
{ 
   public class Stagiaire {

        private int id;
        private String nom;
        private String prenom;
        private DateTime dateNaissance;
        private bool sexe;
        private String cin;
        private String email;
        private String telephone;
        private String adress;
        private String profilImage;
        private int etat;



        public virtual Groupe Groupe { set; get; }
        public virtual Filiere Filiere { set; get; }

       


        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return dateNaissance;
            }

            set
            {
                dateNaissance = value;
            }
        }

        public bool Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                sexe = value;
            }
        }

        public string Cin
        {
            get
            {
                return cin;
            }

            set
            {
                cin = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Telephone
        {
            get
            {
                return telephone;
            }

            set
            {
                telephone = value;
            }
        }

        public string Adress
        {
            get
            {
                return adress;
            }

            set
            {
                adress = value;
            }
        }

        public string ProfilImage
        {
            get
            {
                return profilImage;
            }

            set
            {
                profilImage = value;
            }
        }

        public int Etat
        {
            get
            {
                return etat;
            }

            set
            {
                etat = value;
            }
        }

     
        public override string ToString()
        {
            return this.Nom + "," + this.Prenom;
        }
    }
}
  
