using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm.Annotation
{
    public class AffichageFromAttribute : Attribute
    {
        

        public string Titre { set; get; }
        public string Description { set; get; }
        public int Ordre { set; get; }

        public string Relation { set; get; }
        public string DisplayMember { get; set; }
        public bool isFormulaire { get; set; }
        public bool isGridView { set; get; }
        public int WidthColonne { get; set; }
        public bool MultiLine { get; set; }
    }
}
