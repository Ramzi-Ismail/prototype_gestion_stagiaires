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
using System.ComponentModel.DataAnnotations;
using App.WinForm.Annotation;
using System.Collections;

namespace App.WinForm
{

    /// <summary>
    /// Générer automatiquement le formulaire de saisie
    ///  les champs sont générés selon son annotation
    /// </summary>
    public partial class EntryForm : BaseEntryForm
    {

        #region Constructeurs
        //private EntryForm() : base()
        //{
        //    InitializeComponent();

        //}
   
        /// <summary>
        /// Constructeur principale
        /// </summary>
        /// <param name="service">Instance de ServerManager qui gérer l'entity en cours gestion</param>
        /// 
        public EntryForm(IBaseRepository service) : base(service)
        {
            InitializeComponent();
            this.Entity =(BaseEntity) service.CreateInstanceObjet();
            isStepInitializingValues = false;
            ConteneurFormulaire = this.formulaire;
            InitFormulaire();
        }
        public EntryForm(IBaseRepository service, BaseEntity entity, Dictionary<string, object> critereRechercheFiltre) : base(service, entity, critereRechercheFiltre)
        {
            InitializeComponent();
            ConteneurFormulaire = this.formulaire;
            InitFormulaire();
        }
        #endregion

        #region Création du formulaire
        /// <summary>
        /// Création et Initalisation des contrôles du formulaire
        /// </summary>
        private void InitFormulaire()
        {
            // La position X et Y
            int y = 35;
            int x_label = 16;
            int x_control = 200;
            // L'index de la touche Entrer
            int index = 0;

            // Boucle sur les champs de la classe qui contient l'annotation : AffichageProprieteAttribute
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                // Lecture de l'annotation 
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                //
                // Cration de label
                // 
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(x_label, y);
                lbl.Name = "label1";
                lbl.Size = new System.Drawing.Size(100, 13);
                lbl.TabIndex = index++;
                lbl.Text = AffichagePropriete.Titre;
                this.formulaire.Controls.Add(lbl);

                // Le contrôle qui représente la propriété
                Control controlPropriete = null;
                switch (item.PropertyType.Name)
                {
                    case "String":
                        controlPropriete = this.CreateStringField(item, x_control, y - 3, index++);
                        break;
                    case "Int32":
                        controlPropriete = this.CreateInt32Field(item, x_control, y - 3, index++);
                        break;
                    case "DateTime":
                        controlPropriete = this.CreateDateTimeField(item, x_control, y - 3, index++);
                        break;

                    default:
                        {
                            if (AffichagePropriete.Relation == "ManyToOne")
                            {
                                controlPropriete = this.CreateManyToOneField(item, x_control, y - 3, index++);
                            }
                            if (AffichagePropriete.Relation == "ManyToMany")
                            {
                                controlPropriete = this.CreateManyToManyField(item, x_control, y - 3, index++);
                            }
                        }
                        break;
                }
                y += 25;
            }
        }

        /// <summary>
        /// Exécuter aprés le changement de chaque propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlPropriete_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isStepInitializingValues)
            {
                // Lecture informations
                this.Lire();
                this.Service.ValueChanged(sender,this.Entity);
                this.isStepInitializingValues = true;
                this.Afficher();
                this.isStepInitializingValues = false;
                // Re-Initialisation des valeurs
            }
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            // déja le combobox propose le premiere élément séléctioné
        }

        private void DateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.DateTimePicker(sender, e);
        }

        private void TextBoxInt32_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxInt32(sender, e);
        }

        private void textBoxString_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxString(sender, e);
        }
        #endregion

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            // même si nous avons définit l'événement Clikc sur le button ajouter 
            // l'événement de btEnregistrer_Click est toujour exécuter


        }
    }
}
