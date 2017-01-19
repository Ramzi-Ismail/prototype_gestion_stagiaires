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
        private Control CreateManyToOneField(PropertyInfo item, int x, int y, int index)
        {
            

            // Lecture de l'annotation 
            AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


            if (AffichagePropriete.FilterSelection)
            {
                InputComboBox InputComboBox = new InputComboBox(item.PropertyType,
                    this.Entity,
                    InputComboBox.MainContainers.Panel,
                    InputComboBox.Directions.Vertical);

                InputComboBox.Location = new System.Drawing.Point(x, y);
                InputComboBox.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "ComboBox";
                InputComboBox.Size = new System.Drawing.Size(200, 100); y += 80;
                InputComboBox.TabIndex = index;
                InputComboBox.ValueChanged += ControlPropriete_ValueChanged;

                this.formulaire.Controls.Add(InputComboBox);

                if (AffichagePropriete.isOblegatoir)
                    InputComboBox.Validating += ComboBox_Validating;

                return InputComboBox;
            }
            else
            {


                Type ServicesEntityType = typeof(BaseRepository<>).MakeGenericType(item.PropertyType);
                IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityType);
                List<object> ls = ServicesEntity.GetAllDetached();

                ComboBox comboBox = new ComboBox();

                comboBox.Location = new System.Drawing.Point(x, y);
                comboBox.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "ComboBox";
                comboBox.Size = new System.Drawing.Size(200, 20);
                comboBox.TabIndex = index;
                comboBox.SelectedIndexChanged += ControlPropriete_ValueChanged;
                comboBox.ValueMember = "Id";
                comboBox.DisplayMember = AffichagePropriete.DisplayMember;
                comboBox.DataSource = ls;
                this.formulaire.Controls.Add(comboBox);

                if (AffichagePropriete.isOblegatoir)
                    comboBox.Validating += ComboBox_Validating;

                return comboBox;

            }
        }
    }
}
