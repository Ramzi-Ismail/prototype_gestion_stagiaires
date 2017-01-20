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
        private TextBox CreateStringField(PropertyInfo item, int x,ref int y, int index)
        {
            // Lecture de l'annotation 
            AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


            TextBox textBoxString = new TextBox();
            textBoxString.Location = new System.Drawing.Point(x, y);
            textBoxString.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "TextBox";
            textBoxString.TabIndex = index;
            textBoxString.TextChanged += ControlPropriete_ValueChanged;

            if (AffichagePropriete.isOblegatoir)
                textBoxString.Validating += textBoxString_Validating;
            if (AffichagePropriete.MultiLine)
            {
                textBoxString.Multiline = true;
                textBoxString.Size = new System.Drawing.Size(400, 100);
                y += 80;
            }
            else
            {
                textBoxString.Size = new System.Drawing.Size(200, 20);
            }

            this.formulaire.Controls.Add(textBoxString);

            return textBoxString;
        }
    }
}
