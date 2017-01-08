using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace App.WinForm
{
    public partial class FormulaireControle : FormUserControl
    {
        public FormulaireControle():base()
        {
            InitializeComponent();
        }
        public FormulaireControle(IBaseRepository service) : base(service)
        {
            InitializeComponent();
            CreationFormulaire();
        }
        private void CreationFormulaire()
        {
           PropertyInfo[] ls =  this.Service.CreateInstanceObjet().GetType().GetProperties();

            int x = 10;
            foreach (PropertyInfo item in ls)
            {
                string NomAtribute = item.Name;
                Type type = item.PropertyType;

                if(type.Name == "String")
                {
                    Label lbl = new Label();
                    lbl.Text = NomAtribute;
                    lbl.Location = new Point(x, 10);
                    TextBox txt = new TextBox();
                    txt.Name = NomAtribute;
                    lbl.Location = new Point(x + 30, 10);

                     this.formulaire.Controls.Add(lbl);
                    this.formulaire.Controls.Add(txt);

                    x += 70;

                }

            }
        }
    }
}
