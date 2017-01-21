using App.WinForm.Annotation;
using App.WinForm.Fileds;
using App.WinFrom.Fileds;
using System;
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
        #region Création du formulaire
        /// <summary>
        /// Création et Initalisation des contrôles du formulaire
        /// </summary>
        private void GenerateForm()
        {
            // La position X et Y
            int y_field = 0;
            int x_field = 0;
            int width_label = 80;
            int height_label = 20;
            int width_control = 100;
            int height_control = 20;

            // L'index de la touche Entrer
            int index = 0;

            // Boucle sur les champs de la classe qui doive s'afficher
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                // l'annotation 
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));

                switch (item.PropertyType.Name)
                {
                    case "String":

                        StringFiled stringFiled = new StringFiled(
                            item,
                            Orientation.Vertical,
                            new Size(width_label, height_label),
                            new Size(width_control, height_control));
                        stringFiled.Location = new System.Drawing.Point(x_field, y_field);
                        stringFiled.Name = item.Name;
                        stringFiled.TabIndex = index;
                        stringFiled.FieldChanged += ControlPropriete_ValueChanged;
                        if (AffichagePropriete.isOblegatoir)
                            stringFiled.ValidatingFiled += textBoxString_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(stringFiled);
                        break;
                    case "Int32":

                        Int32Filed int32Filed = new Int32Filed(
                           item,
                           Orientation.Vertical,
                           new Size(width_label, height_label),
                           new Size(width_control, height_control));
                        int32Filed.Location = new System.Drawing.Point(x_field, y_field);
                        int32Filed.Name = item.Name;
                        int32Filed.TabIndex = index;
                        int32Filed.FieldChanged += ControlPropriete_ValueChanged;
                        if (AffichagePropriete.isOblegatoir)
                            int32Filed.ValidatingFiled += TextBoxInt32_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(int32Filed);

                        break;
                    case "DateTime":

                        DateTimeField dateTimeField = new DateTimeField(
                         item,
                         Orientation.Vertical,
                         new Size(width_label, height_label),
                         new Size(width_control, height_control));
                        dateTimeField.Location = new System.Drawing.Point(x_field, y_field);
                        dateTimeField.Name = item.Name;
                        dateTimeField.TabIndex = index;
                        dateTimeField.FieldChanged += ControlPropriete_ValueChanged;
                        if (AffichagePropriete.isOblegatoir)
                            dateTimeField.ValidatingFiled += DateTimePicker_Validating;
                        // Insertion à l'interface
                        this.ConteneurFormulaire.Controls.Add(dateTimeField);

                        break;

                    default:
                        {
                            if (AffichagePropriete.Relation == "ManyToOne")
                            {

                                ManyToOneField manyToOneField = new ManyToOneField(item,
                                    this.ConteneurFormulaire, Orientation.Vertical,
                                    new Size(width_label, height_label),
                                   new Size(width_control, height_control)
                                    );
                                manyToOneField.Location = new System.Drawing.Point(x_field, y_field);
                                manyToOneField.Name = item.Name;
                                manyToOneField.BackColor = System.Drawing.Color.Green;
                                manyToOneField.TabIndex = index;

                                manyToOneField.Size = new System.Drawing.Size(500, 50);

                                
                                manyToOneField.FieldChanged += ControlPropriete_ValueChanged;

                               

                                if (AffichagePropriete.isOblegatoir)
                                    manyToOneField.Validating += ComboBox_Validating;

                                this.ConteneurFormulaire.Controls.Add(manyToOneField);
                            }
                            if (AffichagePropriete.Relation == "ManyToMany")
                            {
                                //  this.CreateManyToManyField(item, x_control, ref y, index++);
                            }
                        }
                        break;
                }

            }
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
