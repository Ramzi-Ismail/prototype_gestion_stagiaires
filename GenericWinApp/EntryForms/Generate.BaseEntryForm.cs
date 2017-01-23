using App.WinForm.Annotation;
using App.WinForm.Fileds;
using App.WinFrom.Fileds;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class BaseEntryForm
    {
 
        /// <summary>
        /// Création et Initalisation des contrôles du formulaire
        /// </summary>
        private void GenerateForm()
        {
            #region Taille par défaut
            // Positions et Tailles par défaut
            int y_field = 0;
            int x_field = 0;
            int width_label = 100;
            int height_label = 10;
            int width_control = 250;
            int height_control = 25;
            int width_groueBox = 100;
            int height_groueBox = 200; // il ne sera pas utilisé 

            // Orientation par défaut
            Orientation orientation = Orientation.Vertical;
            #endregion

            #region Préparation de l'interface par Panel et GroupeBox
            // Initalisation de l'interface avec TabControl 
            this.InitTabPageInterface();
                 
            // Création des groupBox s'il existe
            Dictionary<string, Control> GroupesBoxMainContainers = new Dictionary<string, Control>();
            this.CreateGroupesBoxes(GroupesBoxMainContainers, width_groueBox, height_groueBox);
            #endregion

            // L'index de la touche Entrer
            int TabIndex = 0;

            // Boucle sur les champs de la classe qui doive s'afficher
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                #region Recalcule des valeurs pardéfaut selon l'annotation de chauqe champs
                // l'annotation 
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));

                // Taile du Field
                int width_control_config = width_control;
                if (AffichagePropriete.WidthControl != 0)
                    width_control_config = AffichagePropriete.WidthControl;

                // Orientation
                Orientation orientation_config = orientation;
                if (AffichagePropriete.UseOrientationField )
                    orientation_config = AffichagePropriete.OrientationField;
                #endregion

                Control field_control = null;
                switch (item.PropertyType.Name)
                {
                    #region Champs String
                    case "String":
                       

                        StringFiled stringFiled = new StringFiled(
                            item,
                            orientation_config,
                            new Size(width_label, height_label),
                            new Size(width_control_config, height_control));
                        stringFiled.Location = new System.Drawing.Point(x_field, y_field);
                        stringFiled.Name = item.Name;
                        stringFiled.TabIndex = ++TabIndex;
                        stringFiled.Text_Label = AffichagePropriete.Titre;
                        stringFiled.FieldChanged += ControlPropriete_ValueChanged;
                        if (AffichagePropriete.isOblegatoir)
                            stringFiled.ValidatingFiled += textBoxString_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(stringFiled);
                        field_control = stringFiled;
                        break;
                    #endregion

                    #region Champs Int32
                    case "Int32":

                        Int32Filed int32Filed = new Int32Filed(
                           item,
                           orientation_config,
                           new Size(width_label, height_label),
                           new Size(width_control_config, height_control));
                        int32Filed.Location = new System.Drawing.Point(x_field, y_field);
                        int32Filed.Name = item.Name;
                        int32Filed.TabIndex = ++TabIndex;
                        int32Filed.Text_Label = AffichagePropriete.Titre;
                        int32Filed.FieldChanged += ControlPropriete_ValueChanged;
                        if (AffichagePropriete.isOblegatoir)
                            int32Filed.ValidatingFiled += TextBoxInt32_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(int32Filed);
                        field_control = int32Filed;
                        break;
                    #endregion

                    #region Champs DateTime
                    case "DateTime":

                        DateTimeField dateTimeField = new DateTimeField(
                         item,
                         orientation_config,
                         new Size(width_label, height_label),
                         new Size(width_control_config, height_control));
                        dateTimeField.Location = new System.Drawing.Point(x_field, y_field);
                        dateTimeField.Name = item.Name;
                        dateTimeField.TabIndex = ++TabIndex;
                        dateTimeField.Text_Label = AffichagePropriete.Titre;
                        dateTimeField.FieldChanged += ControlPropriete_ValueChanged;
                        if (AffichagePropriete.isOblegatoir)
                            dateTimeField.ValidatingFiled += DateTimePicker_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(dateTimeField);
                        field_control = dateTimeField;
                        break;
                    #endregion

                    default:
                        {
                            #region Champs : ManyToOne
                            if (AffichagePropriete.Relation == "ManyToOne")
                            {

                                // Déterminer le contenue de Field ManyToOne
                                Control ConteneurManyToMany = this.ConteneurFormulaire;
                                if (AffichagePropriete.GroupeBox != null && AffichagePropriete.GroupeBox != string.Empty)
                                    ConteneurManyToMany = GroupesBoxMainContainers[AffichagePropriete.GroupeBox];

                                ManyToOneField manyToOneField = new ManyToOneField(item,
                                   ConteneurManyToMany, orientation_config,
                                    new Size(width_label, height_label),
                                   new Size(width_control_config, height_control), null
                                    );
                                manyToOneField.Location = new System.Drawing.Point(x_field, y_field);
                                manyToOneField.Name = item.Name;

                                manyToOneField.TabIndex = ++TabIndex;
                                manyToOneField.Text_Label = AffichagePropriete.Titre;
                                

                                
                                manyToOneField.FieldChanged += ControlPropriete_ValueChanged;

                               

                                if (AffichagePropriete.isOblegatoir)
                                    manyToOneField.Validating += ComboBox_Validating;

                                this.ConteneurFormulaire.Controls.Add(manyToOneField);
                                field_control = manyToOneField;
                            }
                            #endregion

                            #region Champs ManyToMany
                            if (AffichagePropriete.Relation == "ManyToMany")
                            {

                                //Trouver les Valeurs par défaut
                                List<BaseEntity> ls_default_value = null;
                                if (this.Entity != null)
                                {
                                    IList ls_obj = item.GetValue(this.Entity) as IList;

                                    if (ls_obj != null) ls_default_value = ls_obj.Cast<BaseEntity>().ToList();
                                }

                                InputCollectionControle InputCollectionControle = new InputCollectionControle(item, ls_default_value, this.Entity);
                                InputCollectionControle.Name = item.Name;
                                InputCollectionControle.ValueChanged += ControlPropriete_ValueChanged;

                                if (AffichagePropriete.TabPage)
                                {
                                    InputCollectionControle.Dock = DockStyle.Fill;
                                    TabPage tabPage = new TabPage();
                                    tabPage.Name = "tabPage" + item.Name;
                                    tabPage.Text = AffichagePropriete.Titre;
                                    tabPage.Controls.Add(InputCollectionControle);
                                    tabControlForm.TabPages.Add(tabPage);
                                }else
                                {
                                    this.ConteneurFormulaire.Controls.Add(InputCollectionControle);
                                    field_control = InputCollectionControle;
                                }
                               
                                

                               
                            }
                            #endregion
                        }
                        break;
                } // Fin de suitch

                // Insertion du Champs dans sa GroupeBox si il existe
                // [Bug] il n'est pas supprimé de l'inrface, car il est déja ajouté
                if (field_control != null && AffichagePropriete.GroupeBox!=null && AffichagePropriete.GroupeBox != string.Empty)
                    GroupesBoxMainContainers[AffichagePropriete.GroupeBox].Controls.Add(field_control);
            }// Fin de for

            // TabControl sur Enregistrer et Annuler
            this.btEnregistrer.TabIndex = ++TabIndex;
            this.btAnnuler.TabIndex = ++TabIndex;
        }

    
        /// <summary>
        /// Création des groupes Box
        /// </summary>
        /// <param name="groupesBoxMainContainers"></param>
        private void CreateGroupesBoxes(Dictionary<string, Control> groupesBoxMainContainers,int width,int height)
        {
            var listeProprite = from i in this.Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(AffichageProprieteAttribute)) != null
                                && ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).GroupeBox != string.Empty
                                 && ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).GroupeBox != null

                                select  ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).GroupeBox    ;

            foreach (var item in listeProprite.Distinct())
            {
                //
                // CombBox
                //
                GroupBox groupeBox = new GroupBox();
                groupeBox.Text = item;
                groupeBox.AutoSize = true;
                groupeBox.Size = new Size(width, height);
                this.ConteneurFormulaire.Controls.Add(groupeBox);


                // FlowLayout
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Dock = DockStyle.Fill;
                flowLayoutPanel.AutoSize = true;
                flowLayoutPanel.FlowDirection = FlowDirection.TopDown;

                groupeBox.Controls.Add(flowLayoutPanel);
                groupesBoxMainContainers[item] = flowLayoutPanel;


            } 
        }

        /// <summary>
        /// Préparation de conteneurs pour une interface qui contient une relation 
        /// ManytoMany
        /// </summary>
        private void InitTabPageInterface()
        {
            var listeProprite = from i in this.Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(AffichageProprieteAttribute)) != null
                                && ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).TabPage
                                select i;

            // Si l'interface contient des Relation ManyToMany
            if (listeProprite.Count() > 0)
            {

                flowLayoutPanelForm.Parent.Controls.Remove(flowLayoutPanelForm);
                flowLayoutPanelForm.Dock = DockStyle.Fill;
                tabControlForm.TabPages["TabPageForm"].Controls.Add(flowLayoutPanelForm);
                tabControlForm.Dock = DockStyle.Fill;
                tabControlForm.TabPages["TabPageForm"].Text = this.Entity.GetAffichageClasseAttribute().Minuscule;

            }
            // Si l'interface ne contient pas des relation ManyToMany
            else
            {
                tabControlForm.Parent.Controls.Remove(tabControlForm);
            }

            flowLayoutPanelForm.Dock = DockStyle.Fill;
            flowLayoutPanelForm.Padding = new Padding(10);

        }

        /// <summary>
        /// Exécuter aprés le changement de chaque propriété 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ControlPropriete_ValueChanged(object sender, EventArgs e)
        {
            if (!this.isStepInitializingValues)
            {
                // Lecture informations
                this.ReadFormToEntity();
                this.Service.ValueChanged(sender, this.Entity);
                this.isStepInitializingValues = true;
                this.WriteEntityToField();
                this.isStepInitializingValues = false;
                // Re-Initialisation des valeurs
            }
        }

        #region Validation
        protected void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            // déja le combobox propose le premiere élément séléctioné
        }

        protected void DateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.DateTimePicker(sender, e);
        }

        protected void TextBoxInt32_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxInt32(sender, e);
        }

        protected void textBoxString_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxString(sender, e);
        }
        #endregion
 
    }
}
