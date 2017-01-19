using App.WinForm.Annotation;
using System;
using System.Collections;
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
        private Control CreateManyToManyField(PropertyInfo item, int x, int y, int index)
        {


            // Lecture de l'annotation 
            AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));

            // Création de TabPage
            TabPage tabPage = new TabPage();
            tabPage.Text = item.Name;
            this.tabControlManytoMany.TabPages.Add(tabPage);

            //Valeur par défaut
            List<BaseEntity> ls_default_value = null;
            if (this.Entity != null)
            {
                IList ls_obj = item.GetValue(this.Entity) as IList;

                if (ls_obj != null) ls_default_value = ls_obj.Cast<BaseEntity>().ToList();
            }



            InputCollectionControle InputCollectionControle = new InputCollectionControle(item, ls_default_value, this.Entity);

            InputCollectionControle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
   | System.Windows.Forms.AnchorStyles.Left)
   | System.Windows.Forms.AnchorStyles.Right)));


            tabPage.Controls.Add(InputCollectionControle);

            InputCollectionControle.ValueChanged += ControlPropriete_ValueChanged;

            return InputCollectionControle;

        }
    }
}
