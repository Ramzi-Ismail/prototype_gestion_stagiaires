using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinForm
{
    /// <summary>
    /// Classe Utiliser comme paramétrage des colonnes du DataGridView
    /// </summary>
    public class ColonneDataGridView
    {
        public static string TYPE_STRING = "STRING";
        public static string TYPE_DATATIME = "DATETIME";

        public ColonneDataGridView(string code, string type, string titre)
        {
            this.Code = code;
            this.Type = type;
            this.Titre = titre;
        }

        public string Code { set; get; }
        public string Titre { set; get; }
        public string Type { set; get; }
    }
}
