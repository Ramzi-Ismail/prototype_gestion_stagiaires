using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using App.WinFromLib.FormUC;

namespace App.GestionStagiaires.Filieres
{
    public partial class FiliereFromUC : BaseFormUserControl, IBaseFormUserControl
    {
        public FiliereFromUC(ModelContext context):base(context)
        {
            InitializeComponent();
        }

        public override void Afficher()
        {
            Filiere  obj = (Filiere) this.Entity;
            codeTextBox.Text = obj.Code;
            descriptionTextBox.Text = obj.Description;

        }

        public override BaseFormUserControl CreateInstance(IBaseRepository service)
        {
           return new FiliereFromUC(this.context);
        }

        public override BaseEntity CreateObjetInstance()
        {
            return new Filiere();
        }

        

        void IBaseFormUserControl.Lire()
        {
            Filiere obj = (Filiere)this.Entity;
            obj.Code = codeTextBox.Text;
            obj.Description = descriptionTextBox.Text;
        }
    }
}
