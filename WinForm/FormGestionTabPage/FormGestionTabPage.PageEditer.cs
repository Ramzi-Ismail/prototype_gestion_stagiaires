using App.WinForm;
using System;
using System.Windows.Forms;

namespace App.WinForm
{
    partial class FormGestionTabPage
    {
        /// <summary>
        /// Editer un objet séléctioné du DataGridView
        /// </summary>
        private void EditerObjet()
        {
            BaseEntity entity = (BaseEntity)ObjetBindingSource.Current;
            string tabEditerName = "TabEditer-" + entity.Id;

            if (tabControl.TabPages.IndexOfKey(tabEditerName) == -1)
            {
                // Création de Tab
                TabPage tabEditer = new TabPage();
                tabEditer.Text = entity.ToString();
                tabEditer.Name = tabEditerName;
                tabControl.TabPages.Add(tabEditer);
                tabControl.SelectedTab = tabEditer;
             

                // Insertion du formulaire 
                FormUserControl form = Formulaire.CreateInstance(this.Service);
                form.Name = "EntityForm";
                form.Entity = entity;
                form.Dock = DockStyle.Fill;
                this.tabControl.TabPages[tabEditerName].Controls.Add(form);
                form.Afficher();
                form.EnregistrerClick += Form_EditerClick;
                form.AnnulerClick += Form_AnnulerEditerClick;
            }else
            {
                TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
                tabControl.SelectedTab = tabEditer;
            }
          

        }
        private void Form_EditerClick(object sender, EventArgs e)
        {
            FormUserControl form = (FormUserControl)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            // Suppression de la page Editer
            this.tabControl.TabPages.Remove(tabEditer);
            this.Actualiser();
        }

        private void Form_AnnulerEditerClick(object sender, EventArgs e)
        {
            FormUserControl form = (FormUserControl)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            tabControl.TabPages.Remove(tabEditer);
        }
    }
}
