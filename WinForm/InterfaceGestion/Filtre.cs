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
        /// <summary>
        /// Création et Initialisation de filtre
        /// </summary>
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
                label_champ_filtre.Size = new System.Drawing.Size(145, 13);
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

                    //if (AffichagePropriete.isValeurVide) ls.Insert(0, new BaseEntity() { Id= 0});
                    comboBoxRelationManyToOne.DataSource = ls;

                    if(AffichagePropriete.isValeurFiltreVide) comboBoxRelationManyToOne.SelectedIndex = -1;

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
                if (propertyInfo.PropertyType.Name == "Int32")
                {
                    // 
                    // comboBoxRelationManyToOne
                    // 
                    TextBox textBoxString = new TextBox();
                    textBoxString.Location = new System.Drawing.Point(x, 37);
                    textBoxString.Name = propertyInfo.Name;
                    textBoxString.Size = new System.Drawing.Size(145, 21);
                    textBoxString.TabIndex = TabIndex++;
                    this.groupBoxFiltrage.Controls.Add(textBoxString);

                    //
                    // Evénement Change sur le ComboBox : Actualisation de DataGrid
                    //
                    textBoxString.TextChanged += Filtre_TextBox_SelectedValueChanged;

                }
                if (propertyInfo.PropertyType.Name == "DateTime")
                {
                    // 
                    // comboBoxRelationManyToOne
                    // 
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Location = new System.Drawing.Point(x, 37);
                    dateTimePicker.Name = propertyInfo.Name;
                    dateTimePicker.Size = new System.Drawing.Size(145, 21);
                    dateTimePicker.TabIndex = TabIndex++;
                    this.groupBoxFiltrage.Controls.Add(dateTimePicker);

                    //
                    // Evénement Change sur le ComboBox : Actualisation de DataGrid
                    //
                    dateTimePicker.ValueChanged += Filtre_TextBox_SelectedValueChanged;

                }

                x += 200;
            } // End For
        }

        /// <summary>
        /// Evénement SelectValueChange de ComboBoxs des Propriétés avec Relation :MnayToOne
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

        /// <summary>
        /// Affichage des information dans DataGrid selon le filtre s'il exsiste
        /// </summary> 
        public void Actualiser()
        {
            ObjetBindingSource.Clear();
            var ls = Service.Recherche(this.CritereRechercheFiltre());
            ObjetBindingSource.DataSource = ls;
        }

        protected Dictionary<string, object> CritereRechercheFiltre()
        {
            // Application de filtre
            Dictionary<string, object> RechercheInfos = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in this.ListePropriete)
            {
                // Trouver l'objet AffichagePropriete depuis l'annotation avec Filtre = True
                Attribute getAffichagePropriete = propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                if (getAffichagePropriete == null) continue;
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)getAffichagePropriete;
                if (AffichagePropriete.Filtre == false) continue;


                switch (propertyInfo.PropertyType.Name)
                {
                    case "String":
                        {
                            TextBox textBoxString = (TextBox)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if (textBoxString.Text != String.Empty)
                                RechercheInfos[propertyInfo.Name] = textBoxString.Text;
                        }
                        break;
                    case "Int32":
                        {
                            TextBox textBoxString = (TextBox)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if (textBoxString.Text != String.Empty)
                                RechercheInfos[propertyInfo.Name] = Convert.ToInt32(textBoxString.Text);
                        }
                        break;
                    case "DateTime":
                        {
                            DateTimePicker dateTimePicker = (DateTimePicker)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if (dateTimePicker.Text != String.Empty)
                                RechercheInfos[propertyInfo.Name] = dateTimePicker.Value;
                        }
                        break;
                    default: // Dans le cas d'un objet de type BaseEntity
                        {
                            ComboBox ComboBoxEntity = (ComboBox)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            BaseEntity obj = (BaseEntity)ComboBoxEntity.SelectedItem;


                            if (obj != null && Convert.ToInt32(obj.Id) != 0)
                                RechercheInfos[propertyInfo.Name] = ComboBoxEntity.SelectedValue;
                        }
                        break;
                }



            }

            return RechercheInfos;
        }




    }
}
