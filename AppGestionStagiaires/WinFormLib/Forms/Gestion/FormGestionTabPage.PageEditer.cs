using App.WinFromLib.FormUC;
using EFlib.Entites;
using System;
using System.Windows.Forms;

namespace App.WinFormLib.Forms.Gestion
{
    partial class FormGestionTabPage
    {
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
               // tabControl.SelectedTab = tabEditer;

                // Insertion du formulaire 
                BaseFormUserControl form = Formulaire.CreateInstance(this.Service);
                form.Name = "EntityForm";
                form.Entity = entity;
                form.Afficher();
                this.tabControl.TabPages[tabEditerName].Controls.Add(form);
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
            BaseFormUserControl form = (BaseFormUserControl)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            // Suppression de la page Editer
            this.tabControl.TabPages.Remove(tabEditer);
            this.Actualiser();
        }

        private void Form_AnnulerEditerClick(object sender, EventArgs e)
        {
            BaseFormUserControl form = (BaseFormUserControl)sender;
            BaseEntity entity = form.Entity;
            string tabEditerName = "TabEditer-" + entity.Id;
            TabPage tabEditer = this.tabControl.TabPages[tabEditerName];
            tabControl.TabPages.Remove(tabEditer);
        }
    }
}
