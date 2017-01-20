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
        private   TextBox CreateInt32Field(PropertyInfo item, int x, ref int y, int index)
        {
            // Lecture de l'annotation 
            AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


            // textBoxInt32
            TextBox textBoxInt32 = new TextBox();
            textBoxInt32.Location = new System.Drawing.Point(x,y);
            textBoxInt32.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "TextBox";
            textBoxInt32.Size = new System.Drawing.Size(200, 20);
            textBoxInt32.TabIndex = index;
            textBoxInt32.TextChanged += ControlPropriete_ValueChanged;
            if (AffichagePropriete.isOblegatoir)
                textBoxInt32.Validating += TextBoxInt32_Validating;

            this.formulaire.Controls.Add(textBoxInt32);

            return textBoxInt32;
        }

    }
}
