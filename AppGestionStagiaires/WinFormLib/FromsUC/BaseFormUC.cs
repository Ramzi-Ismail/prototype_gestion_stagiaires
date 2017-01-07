using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using App.WinFromLib.FromsUC;
using App.WinFromLib.FormUC;

namespace App.Gestion
{
    public  class BaseFormUC : UserControl, IBaseFormUC
    {
        private Button button1;
        private Button button2;

        public BaseFormUC()
        {

        }
        #region Evenements
        public event EventHandler EnregistrerClick;
        public event EventHandler AnnulerClick;

        protected void onEnregistrerClick(Object sender,EventArgs e)
        {
            if (EnregistrerClick != null) EnregistrerClick(sender, e);
        }
        protected void onAnnulerClick(Object sender, EventArgs e)
        {
            if (AnnulerClick != null) AnnulerClick(sender, e);
        }
        #endregion

        /// <summary>
        /// Obtient ou définire l'entité qui représente 
        /// </summary>
        public BaseEntity Entity { get; set; }

        public virtual void Afficher() { }


        #region validation
        protected void ValiderTextBox(object sender, CancelEventArgs e, ErrorProvider errorProvider, String message=""  )
        {

            TextBox controle = (TextBox)sender;
            if (message == "") message = "La saisie de ce champs est oblégatoir";
            if (controle.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(controle, message);
                e.Cancel = true;
            }
            else
                errorProvider.SetError(controle, "");
        }

        /// <summary>
        /// Creation d'une instance de l'objet en cours
        /// </summary>
        /// <returns></returns>
        public virtual BaseFormUC CreateInstance()
        {
            return new BaseFormUC();
        }
        #endregion

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(62, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(174, 210);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BaseFormUC
            // 
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "BaseFormUC";
            this.Size = new System.Drawing.Size(399, 251);
            this.ResumeLayout(false);

        }

        

        public BaseFormUserControl CreateInstance(IBaseRepository service)
        {
            throw new NotImplementedException();
        }
    }

   
}
