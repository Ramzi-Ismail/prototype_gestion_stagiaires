using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    public partial class EntryForm
    {
        /// <summary>
        /// Création du champ de type DateTime dans la formilaire de saisie
        /// </summary>
        /// <param name="item">PropertyInfo du champs</param>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        /// <param name="index">L'index de contrôle dans l'interface</param>
        /// <returns>Le contôle ajouté à l'interface</returns>
        private Control CreateDateTimeField(PropertyInfo item, int x, int y, int index)
        {
            // Lecture de l'annotation 
            AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Location = new System.Drawing.Point(x, y);
            dateTimePicker.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "DateTimePicker";

            dateTimePicker.Size = new System.Drawing.Size(200, 20);
            dateTimePicker.TabIndex = index++;
            dateTimePicker.ValueChanged += ControlPropriete_ValueChanged;
            if (AffichagePropriete.isOblegatoir)
                dateTimePicker.Validating += DateTimePicker_Validating;

            this.formulaire.Controls.Add(dateTimePicker);


            return dateTimePicker;

        }
    }
}
