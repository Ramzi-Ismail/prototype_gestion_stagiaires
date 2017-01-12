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
    /// <summary>
    /// Configuration de filtre de l'interface de gestion
    /// </summary>
    partial class InterfaceGestion
    {
        protected void initFiltre()
        {
            int x = 27;
            int TabIndex = 0;
            foreach (PropertyInfo propertyInfo in this.ListePropriete)
            {
                // Trouver l'objet AffichagePropriete depuis l'annotation
                Attribute getAffichagePropriete = propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                if (getAffichagePropriete == null) continue;
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)getAffichagePropriete;
                if (AffichagePropriete.Filtre == false) continue;

                // 
                // label_relation_many_to_one
                // 
                Label label_champ_filtre = new Label();
                label_champ_filtre.Location = new System.Drawing.Point(x, 20);
                label_champ_filtre.Name = "label_" + propertyInfo.Name;
                label_champ_filtre.Size = new System.Drawing.Size(32, 13);
                label_champ_filtre.TabIndex = TabIndex++;
                label_champ_filtre.Text = AffichagePropriete.Titre;
                this.groupBoxFiltrage.Controls.Add(label_champ_filtre);

                if (AffichagePropriete.Relation != String.Empty &&
                 AffichagePropriete.Relation == AffichageProprieteAttribute.RELATION_MANYTOONE)
                {
                    // 
                    // comboBoxRelationManyToOne
                    // 
                    ComboBox comboBoxRelationManyToOne = new ComboBox();
                    comboBoxRelationManyToOne.FormattingEnabled = true;
                    comboBoxRelationManyToOne.Location = new System.Drawing.Point(x, 37);
                    comboBoxRelationManyToOne.Name =  propertyInfo.Name;
                    comboBoxRelationManyToOne.Size = new System.Drawing.Size(145, 21);
                    comboBoxRelationManyToOne.TabIndex = TabIndex++;
                    this.groupBoxFiltrage.Controls.Add(comboBoxRelationManyToOne);
                    //
                    // Remplissage de ComboBox
                    //
                    Type ServicesEntityEnRelationType = typeof(BaseRepository<>).MakeGenericType(propertyInfo.PropertyType);
                    IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityEnRelationType);
                    List<object> ls = ServicesEntity.GetAllDetached();
                    comboBoxRelationManyToOne.ValueMember = "Id";
                    comboBoxRelationManyToOne.DisplayMember = AffichagePropriete.DisplayMember;

                    if (AffichagePropriete.isValeurVide) ls.Insert(0, new { Id = 0 });
                    comboBoxRelationManyToOne.DataSource = ls;
                    //
                    // Evénement Change sur le ComboBox : Actualisation de DataGrid
                    //
                    comboBoxRelationManyToOne.SelectedValueChanged += Filtre_ComboBox_SelectedValueChanged;

                }
                if (propertyInfo.PropertyType.Name == "String")
                {
                    // 
                    // comboBoxRelationManyToOne
                    // 
                    TextBox textBoxString = new TextBox();
                    textBoxString.Location = new System.Drawing.Point(x, 37);
                    textBoxString.Name =  propertyInfo.Name;
                    textBoxString.Size = new System.Drawing.Size(145, 21);
                    textBoxString.TabIndex = TabIndex++;
                    this.groupBoxFiltrage.Controls.Add(textBoxString);

                    //
                    // Evénement Change sur le ComboBox : Actualisation de DataGrid
                    //
                    textBoxString.TextChanged += Filtre_TextBox_SelectedValueChanged;

                }

                x += 200;
            } // End For
        }

        /// <summary>
        /// événement SelectValueChange de ComboBoxs des Propriétés avec Relation :MnayToOne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtre_TextBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Actualiser();
        }
        private void Filtre_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var item in this.groupBoxFiltrage.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            this.Actualiser();
        }
    }
}
