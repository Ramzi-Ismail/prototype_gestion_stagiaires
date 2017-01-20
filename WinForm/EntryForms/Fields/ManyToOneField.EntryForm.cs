using App.WinForm.Annotation;
using App.WinForm.Fileds;
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
        /// Création et Affichage de champs ManytoOne
        /// </summary>
        /// <param name="item"></param>
        /// <param name="x">La postion X du controle</param>
        /// <param name="y">La position T du control</param>
        /// <param name="index">L'index du contôle</param>
        /// <returns></returns>
        private Control CreateManyToOneField(PropertyInfo item, int x,int x_label, ref int y, int index)
        {
            

            // Lecture de l'annotation 
            AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


            if (AffichagePropriete.FilterSelection)
            {

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();

                flowLayoutPanel.Location = new System.Drawing.Point(x_label, y);
                flowLayoutPanel.Size = new System.Drawing.Size(500, 100);
                flowLayoutPanel.BackColor = System.Drawing.Color.Gray;
                y += 200;
                this.formulaire.Controls.Add(flowLayoutPanel);

                ManyToOneField manyToOneField = new ManyToOneField(item, flowLayoutPanel, 350,Orientation.Vertical);
                manyToOneField.Location = new System.Drawing.Point(x, y);
                manyToOneField.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "ComboBox";
                manyToOneField.BackColor = System.Drawing.Color.Green;

                // !!
                manyToOneField.Size = new System.Drawing.Size(500, 50);

                manyToOneField.TabIndex = index;
                manyToOneField.FieldChanged += ControlPropriete_ValueChanged;

                flowLayoutPanel.Controls.Add(manyToOneField);

                if (AffichagePropriete.isOblegatoir)
                    manyToOneField.Validating += ComboBox_Validating;

                return manyToOneField;
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
