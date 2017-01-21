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
using App.WinFrom.Fileds;
using App.WinForm.Fileds;

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
        public Control MainContainer { set; get; }

        #endregion

        #region Evénement
        public event EventHandler RefreshEvent;
        protected void onRefreshEvent(object sender, EventArgs e)
        {
            if (RefreshEvent != null)
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

        public BaseFilterControl(IBaseRepository Service) : this(Service, null)
        {
        }

        #endregion

        #region InitializeFilter

        /// <summary>
        /// Recherche des propriété qui doivent être utiliser dans le filtre
        /// </summary>
        /// <returns></returns>
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
            int width_label = 50;
            int height_label = 20;
            int width_control = 50;
            int height_control = 20;

            int TabIndex = 0;
            foreach (PropertyInfo propertyInfo in PropertyListFilter())
            {
                // Trouver l'objet AffichagePropriete depuis l'annotation
                Attribute getAffichagePropriete = propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                if (getAffichagePropriete == null) continue;
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)getAffichagePropriete;
                if (AffichagePropriete.Filtre == false) continue;



                if (propertyInfo.PropertyType.Name == "String")
                {
                    StringFiled stringFiled = new StringFiled(propertyInfo,
                        Orientation.Horizontal,
                        new Size(width_label, height_label),
                            new Size(width_control, height_control));
                    stringFiled.Name = propertyInfo.Name;
                    stringFiled.TabIndex = TabIndex++;
                    stringFiled.Text_Label = AffichagePropriete.Titre;
                   

                    stringFiled.FieldChanged += Filtre_TextBox_SelectedValueChanged;
            
                    MainContainer.Controls.Add(stringFiled);


                }
                if (propertyInfo.PropertyType.Name == "Int32")
                {
                    Int32Filed int32Filed = new Int32Filed(propertyInfo,
                        Orientation.Vertical,
                       new Size(width_label, height_label),
                            new Size(width_control, height_control)
                        );
                    int32Filed.Name = propertyInfo.Name;
                    int32Filed.TabIndex = TabIndex++;
                    int32Filed.Text_Label = AffichagePropriete.Titre;
                  

                    int32Filed.FieldChanged += Filtre_TextBox_SelectedValueChanged;
                    MainContainer.Controls.Add(int32Filed);



                }
                if (propertyInfo.PropertyType.Name == "DateTime")
                {
                    DateTimeField dateTimeField = new DateTimeField(propertyInfo,Orientation.Vertical,
                         new Size(width_label, height_label),
                            new Size(width_control, height_control)
                        );
                    dateTimeField.Name = propertyInfo.Name;
                    dateTimeField.TabIndex = TabIndex++;
                    dateTimeField.Text_Label = AffichagePropriete.Titre;
           

                    dateTimeField.FieldChanged += Filtre_TextBox_SelectedValueChanged;
                    MainContainer.Controls.Add(dateTimeField);

                }

                //
                // Relation ManyToOne
                //
                if (AffichagePropriete.Relation != String.Empty &&
                 AffichagePropriete.Relation == AffichageProprieteAttribute.RELATION_MANYTOONE)
                {

                    ManyToOneField manyToOneField = new ManyToOneField(propertyInfo,
                        this.MainContainer,
                        Orientation.Horizontal,
                         new Size(width_label, height_label),
                         new Size(width_control, height_control)
                        );
                    manyToOneField.Name = propertyInfo.Name;
                    manyToOneField.TabIndex = TabIndex++;
                    manyToOneField.Text_Label = AffichagePropriete.Titre;
                    manyToOneField.FieldChanged += Filtre_ComboBox_SelectedValueChanged;

                    MainContainer.Controls.Add(manyToOneField);
             

                    //
                    // Remplissage de ComboBox
                    //
                    //Type ServicesEntityEnRelationType = typeof(BaseRepository<>).MakeGenericType(propertyInfo.PropertyType);
                    //IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityEnRelationType);
                    //List<object> ls = ServicesEntity.GetAllDetached();
                    //manyToOneField.ValueMember = "Id";
                    //manyToOneField.DisplayMember = AffichagePropriete.DisplayMember;
                    //manyToOneField.DataSource = ls;
                    //if (AffichagePropriete.isValeurFiltreVide) manyToOneField.SelectedIndex = -1;

                    // Affectation de valeur initial
                    //if (this.ValeursFiltre != null && this.ValeursFiltre.ContainsKey(propertyInfo.Name))
                    //{
                    //    manyToOneField.CreateControl();
                    //    manyToOneField.SelectedValue = Convert.ToInt64(this.ValeursFiltre[propertyInfo.Name]);
                    //}



                }




                //if (MainContainer.Controls.Count > 0)
                //{
                //    int max_h = this.MainContainer.Controls.Cast<Control>().Max(c => c.Size.Height);
                //    this.MainContainer.Size = new Size(this.MainContainer.Size.Width, max_h);
                //}

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
                            StringFiled stringFiled = (StringFiled)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if (stringFiled.Value != String.Empty)
                                RechercheInfos[propertyInfo.Name] = stringFiled.Value;
                        }
                        break;
                    case "Int32":
                        {
                            Int32Filed int32Filed = (Int32Filed)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if ((int) int32Filed.Value != 0)
                                RechercheInfos[propertyInfo.Name] = int32Filed.Value;
                        }
                        break;
                    case "DateTime":
                        {
                            DateTimeField dateTimeField = (DateTimeField)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                            if ((DateTime)dateTimeField.Value != DateTime.MinValue)
                                RechercheInfos[propertyInfo.Name] = dateTimeField.Value;
                        }
                        break;
                    default: // Dans le cas d'un objet de type BaseEntity
                        {
                            // [bug] groupBoxFiltrage doit être MainContainner
                            ManyToOneField ComboBoxEntity = (ManyToOneField)this.groupBoxFiltrage.Controls.Find(propertyInfo.Name, true).First();
                                BaseEntity obj = (BaseEntity)ComboBoxEntity.SelectedItem;
                                if (obj != null && Convert.ToInt32(obj.Id) != 0)
                                    RechercheInfos[propertyInfo.Name] = obj.Id;
 




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
