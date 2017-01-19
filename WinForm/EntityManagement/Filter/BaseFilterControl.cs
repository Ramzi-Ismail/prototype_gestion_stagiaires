using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using App.WinForm.Annotation;

namespace App.WinForm.EntityManagement
{
    public partial class BaseFilterControl : UserControl
    {
        #region Propriétés
        /// <summary>
        /// Le Service de gestion  
        /// </summary>
        protected IBaseRepository Service { set; get; }

        /// <summary>
        /// définir les valeurs initiaux du filtre
        /// </summary>
        protected Dictionary<string, object> ValeursFiltre { set; get; }


        /// <summary>
        /// Le contenuer de l'interface
        /// </summary>
        protected Control MainContainer { set; get; }

        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            RefreshEvent(sender, e);
        }
        #endregion

        #region Constructeurs
        [Obsolete("N'utiliserz pas le constructeur pardéfaut, il est ajouter au programme pour supporter le mode designe de VisualStudio")]
        public BaseFilterControl()
        {
            InitializeComponent();
        }

        public BaseFilterControl(IBaseRepository Service, Dictionary<string, object> ValeursFiltre) 
        {
            InitializeComponent();
            this.MainContainer = this.flowLayoutPanel1;
            this.Service = Service;
            this.ValeursFiltre = ValeursFiltre;
            initFiltre();

        }

        public BaseFilterControl(IBaseRepository Service) : this(Service,null)
        {
        }
    
        #endregion

        #region InitializeFilter

        protected List<PropertyInfo> PropertyListFilter()
        {
            // [Bug]
            // Ajoutez la condition filtre 
            var requete = from i in Service.TypeEntity.GetProperties()
                          where i.GetCustomAttribute(typeof(AffichageProprieteAttribute)) != null &&
                          ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).isGridView
                          orderby ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).Ordre
                          select i;
            return requete.ToList<PropertyInfo>();
        }

        /// <summary>
        /// Création et Initialisation de filtre en utilisation de la liste des propriété de la classe
        /// et l'annotation 
        /// </summary>
        protected void initFiltre()
        {

            int height_panel = 60;
            int width_panel = 100;

            int height_controle = 20;
            int width_controle = 80;


            int height_main_contrainner = 100;

            int y = 30;
            int TabIndex = 0;
            foreach (PropertyInfo propertyInfo in PropertyListFilter())
            {
                // Trouver l'objet AffichagePropriete depuis l'annotation
                Attribute getAffichagePropriete = propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                if (getAffichagePropriete == null) continue;
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)getAffichagePropriete;
                if (AffichagePropriete.Filtre == false) continue;

                // Chaque panel représente un seul critère
                Panel panel = new Panel();



                // 
                // label_relation_many_to_one
                // 
                Label label_champ_filtre = new Label();
                label_champ_filtre.Location = new System.Drawing.Point(5, 5);
                label_champ_filtre.Name = "label_" + propertyInfo.Name;
                label_champ_filtre.Size = new System.Drawing.Size(width_controle, height_controle);
                label_champ_filtre.TabIndex = TabIndex++;
                label_champ_filtre.Text = AffichagePropriete.Titre;
               

                //
                // Relation ManyToOne
                //
                if (AffichagePropriete.Relation != String.Empty &&
                 AffichagePropriete.Relation == AffichageProprieteAttribute.RELATION_MANYTOONE)
                {

                    // si le combo a des filtre personnelle
                    if (AffichagePropriete.FilterSelection)
                    {
                        InputComboBox comboBoxRelationManyToOne = new InputComboBox(
                            propertyInfo.PropertyType,
                            null,
                            InputComboBox.MainContainers.Panel,
                            InputComboBox.Directions.Horizontal);
                        comboBoxRelationManyToOne.Dock = DockStyle.Fill;
                        comboBoxRelationManyToOne.Name = propertyInfo.Name;
                        comboBoxRelationManyToOne.TabIndex = TabIndex++;
                     
                        panel.Controls.Add(comboBoxRelationManyToOne);
                        height_panel = comboBoxRelationManyToOne.height + 10;


                    }
                    else
                    {
                        // 
                        // comboBoxRelationManyToOne
                        // 
                        ComboBox comboBoxRelationManyToOne = new ComboBox();
                        comboBoxRelationManyToOne.FormattingEnabled = true;
                        comboBoxRelationManyToOne.Name = propertyInfo.Name;
                        comboBoxRelationManyToOne.Location = new System.Drawing.Point(5, y);
                        comboBoxRelationManyToOne.Size = new System.Drawing.Size(width_controle, height_controle);
                        comboBoxRelationManyToOne.TabIndex = TabIndex++;
                        panel.Controls.Add(comboBoxRelationManyToOne);

                        //
                        // Remplissage de ComboBox
                        //
                        Type ServicesEntityEnRelationType = typeof(BaseRepository<>).MakeGenericType(propertyInfo.PropertyType);
                        IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityEnRelationType);
                        List<object> ls = ServicesEntity.GetAllDetached();
                        comboBoxRelationManyToOne.ValueMember = "Id";
                        comboBoxRelationManyToOne.DisplayMember = AffichagePropriete.DisplayMember;
                        comboBoxRelationManyToOne.DataSource = ls;
                        if (AffichagePropriete.isValeurFiltreVide) comboBoxRelationManyToOne.SelectedIndex = -1;
                        // Affectation de valeur initial
                        if (this.ValeursFiltre != null && this.ValeursFiltre.ContainsKey(propertyInfo.Name))
                        {
                            comboBoxRelationManyToOne.CreateControl();
                            comboBoxRelationManyToOne.SelectedValue = Convert.ToInt64(this.ValeursFiltre[propertyInfo.Name]);
                        }
                        // Recalcule le widht de comboBox
                        if (ls.Count > 0)
                        {
                            int width = ls.Max(o => ((BaseEntity)o).ToString().Count()) * 5 + 20;
                            comboBoxRelationManyToOne.Size = new System.Drawing.Size(width, height_controle);
                           // if (width > 200) x += (200 - width);
                        }

                        //
                        // Evénement Change sur le ComboBox : Actualisation de DataGrid
                        //
                        comboBoxRelationManyToOne.SelectedValueChanged += Filtre_ComboBox_SelectedValueChanged;

                    }


                }
                if (propertyInfo.PropertyType.Name == "String")
                {
                    // 
                    // comboBox
                    // 
                    TextBox textBoxString = new TextBox();
                    textBoxString.Location = new System.Drawing.Point(5, y);
                    textBoxString.Name = propertyInfo.Name;
                    textBoxString.Size = new System.Drawing.Size(width_controle, height_controle);
                    textBoxString.TabIndex = TabIndex++;
                    panel.Controls.Add(textBoxString);

                    //
                    // Evénement Change sur le ComboBox : Actualisation de DataGrid
                    //
                    textBoxString.TextChanged += Filtre_TextBox_SelectedValueChanged;
                    panel.Controls.Add(label_champ_filtre);

                }
                if (propertyInfo.PropertyType.Name == "Int32")
                {
                    // 
                    // comboBoxRelation
                    // 
                    TextBox textBoxString = new TextBox();
                    textBoxString.Location = new System.Drawing.Point(5, y);
                    textBoxString.Name = propertyInfo.Name;
                    textBoxString.Size = new System.Drawing.Size(width_controle, height_controle);
                    textBoxString.TabIndex = TabIndex++;
                    panel.Controls.Add(textBoxString);

                    //
                    // Evénement Change sur le ComboBox : Actualisation de DataGrid
                    //
                    textBoxString.TextChanged += Filtre_TextBox_SelectedValueChanged;
                    panel.Controls.Add(label_champ_filtre);

                }
                if (propertyInfo.PropertyType.Name == "DateTime")
                {
                    // 
                    // comboBoxRelation
                    // 
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Location = new System.Drawing.Point(5, y);
                    dateTimePicker.Name = propertyInfo.Name;
                    dateTimePicker.Size = new System.Drawing.Size(width_controle, height_controle);
                    dateTimePicker.TabIndex = TabIndex++;
                    panel.Controls.Add(dateTimePicker);

                    //
                    // Evénement Change sur le ComboBox : Actualisation de DataGrid
                    //
                    dateTimePicker.ValueChanged += Filtre_TextBox_SelectedValueChanged;
                    panel.Controls.Add(label_champ_filtre);

                }


                panel.Size = new System.Drawing.Size(width_panel, height_panel);
                panel.BackColor = Color.Gray;
                this.MainContainer.Controls.Add(panel);

                int max_h = this.MainContainer.Controls.Cast<Control>().Max(c => c.Size.Height);
                this.MainContainer.Size = new Size(this.MainContainer.Size.Width, max_h);

            } // End For
        }

        /// <summary>
        /// Evénement SelectValueChange de ComboBoxs des Propriétés avec Relation :MnayToOne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filtre_TextBox_SelectedValueChanged(object sender, EventArgs e)
        {
            onRefreshEvent(sender, e);
        }
        private void Filtre_ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var item in this.groupBoxFiltrage.Controls.OfType<TextBox>())
            {
                item.Text = "";
            }
            onRefreshEvent(sender, e);
        }


        #endregion


        #region Read & Write
        /// <summary>
        /// Obtient les valeurs du filtre
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> CritereRechercheFiltre()
        {
            // Application de filtre
            Dictionary<string, object> RechercheInfos = new Dictionary<string, object>();
            foreach (PropertyInfo propertyInfo in PropertyListFilter())
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
                            if (AffichagePropriete.FilterSelection)
                            {
                                InputComboBox ComboBoxEntity = (InputComboBox)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                                BaseEntity obj = (BaseEntity)ComboBoxEntity.SelectedItem;
                                if (obj != null && Convert.ToInt32(obj.Id) != 0)
                                    RechercheInfos[propertyInfo.Name] = ComboBoxEntity.SelectedValue;
                            }
                            else
                            {
                                ComboBox ComboBoxEntity = (ComboBox)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                                
                                BaseEntity obj = (BaseEntity)ComboBoxEntity.SelectedItem;
                                if (obj != null && Convert.ToInt32(obj.Id) != 0)
                                    RechercheInfos[propertyInfo.Name] = ComboBoxEntity.SelectedValue;

                            }




                        }
                        break;
                }



            }

            return RechercheInfos;
        }

        #endregion

        private void groupBoxFiltrage_Enter(object sender, EventArgs e)
        {

        }
    }
}
