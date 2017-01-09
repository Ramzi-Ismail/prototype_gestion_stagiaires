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


            int y = 35;
            foreach (PropertyInfo item in ls)
            {
                
                string NomAtribute = item.Name;
                Type type = item.PropertyType;

                if(type.Name == "String")
                {

                    // 
                    // label
                    // 
                    Label lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.Location = new System.Drawing.Point(6, y);
                    lbl.Name = "label1";
                    lbl.Size = new System.Drawing.Size(35, 13);
                    lbl.TabIndex = 0;
                    lbl.Text = NomAtribute;
                    // 
                    // textBox1
                    // 
                    TextBox txt = new TextBox();
                    txt.Location = new System.Drawing.Point(66, y-3);
                    txt.Name = NomAtribute;
                    txt.Size = new System.Drawing.Size(100, 20);
                    txt.TabIndex = 1;


                    this.formulaire.Controls.Add(lbl);
                    this.formulaire.Controls.Add(txt);

                    y += 25;

                }

            }
        }


        public  override void Lire()
        {

        }
    }
}
