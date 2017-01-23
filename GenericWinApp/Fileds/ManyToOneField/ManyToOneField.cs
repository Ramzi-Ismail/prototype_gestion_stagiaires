using App.WinForm.Annotation;
using App.WinForm.EntityManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace App.WinForm.Fileds
{
    public partial class ManyToOneField : App.WinFrom.Fileds.BaseField
    {
       


        #region Propriété
        /// <summary>
        /// Obient la valeur de ComBox du champs ManyToOne
        /// </summary>
        public override Object Value
        {
            get
            {
                return comboBoxManyToOne.SelectedValue;
            }
            set
            {
                comboBoxManyToOne.SelectedValue = Convert.ToInt64(value);
            }
        }

        /// <summary>
        /// Valeur pardéfaut de filtre
        /// </summary>
        Dictionary<string, object> DefaultFiltreValues { set; get; }

        #endregion

        #region Variables


        /// <summary>
        /// Le conteneur de l'interface, our que le Filed ajoute son filtre personnelle à l'interface 
        /// sous Forme des Field avant son Field
        /// </summary>
        public Control MainContainner { set; get; }

        #endregion

        #region Les critère de filtrage
        /// <summary>
        /// Lite des ComboBox 
        /// </summary>
        Dictionary<string, ManyToOneField> ListeComboBox { set; get; }

        /// <summary>
        /// Lite des Valeur de critère Initial de comboBox
        /// </summary>
        Dictionary<string, BaseEntity> ListeValeursCritere { set; get; }

        /// <summary>
        /// Liste des Types de critère 
        /// </summary>
        Dictionary<string, Type> LsiteTypeObjetCritere { set; get; }

        #endregion

        #region Degault Value
        /// <summary>
        /// Trouver les valeurs par défaut de chaque critère de filtre, 
        /// depuis l'objet qui déclare la collection
        /// </summary> 
        //protected void CalculatesDefaultValues()
        //{
        //    if (MetaSelectionCriteria == null) return;
        //    foreach (Type item in MetaSelectionCriteria.Criteria)
        //    {
        //        // Trouver si la classe de critère de filtre existe déja comme Membre 
        //        // de la classe qui déclare la collection
        //        Type DeclaringType = PropertyInfoOfCollection.DeclaringType;
        //        PropertyInfo PropertyInfo_value = DeclaringType.GetProperties().Where(p => p.PropertyType.Name == item.Name).SingleOrDefault();
        //        if (PropertyInfo_value != null && Entity != null)
        //        {
        //            BaseEntity BaseEntityValue = (BaseEntity)PropertyInfo_value.GetValue(Entity);
        //            if (BaseEntityValue != null)
        //            {
        //                ListeValeursCritere[item.Name] = BaseEntityValue;

        //                // si la critère a une valeur par défaut
        //                // on cherche les valeurs par défaut des critère précédent 
        //                int index = MetaSelectionCriteria.Criteria.ToList().IndexOf(item);
        //                ValeurParen(index, BaseEntityValue);

        //            }



        //        }
        //    }
        //}
        #endregion

        #region Propriété : ComboBox

        public string ValueMember {
            get { return this.comboBoxManyToOne.ValueMember; }
            set { this.comboBoxManyToOne.ValueMember = value; }
        }
        public string DisplayMember {
            get { return this.comboBoxManyToOne.DisplayMember; }
            set { this.comboBoxManyToOne.DisplayMember = value; }
        }

        public object DataSource {
            get { return this.comboBoxManyToOne.DataSource; }
            set { this.comboBoxManyToOne.DataSource = value; }
           }

        public int SelectedIndex {
            get { return this.comboBoxManyToOne.SelectedIndex; }
            set { this.comboBoxManyToOne.SelectedIndex = value; }
        }

        public object SelectedValue {
            get { return this.comboBoxManyToOne.SelectedValue; }
            set { this.comboBoxManyToOne.SelectedValue = value; }
        }

        public object SelectedItem {
            get { return this.comboBoxManyToOne.SelectedItem; }
            set { this.comboBoxManyToOne.SelectedItem = value; }
        }


        public string TextCombobox {
            get { return this.comboBoxManyToOne.Text; }
            set { this.comboBoxManyToOne.Text = value; }
        }
        #endregion



        public ManyToOneField(Type TypeObjet,
            PropertyInfo propertyInfo, 
            Control MainContainner, 
            Orientation OrientationFiled, 
            Size SizeLabel, 
            Size SizeControl,
            Dictionary<string, object> DefaultFiltreValues) 
            :base(TypeObjet,propertyInfo, OrientationFiled, SizeLabel, SizeControl)
        {
            InitializeComponent();
            this.MainContainner = MainContainner;


            this.DefaultFiltreValues = DefaultFiltreValues;
            this.ListeValeursCritere = new Dictionary<string, BaseEntity>(); // il n'est pas utilisé

            this.ListeComboBox = new Dictionary<string, ManyToOneField>();
            
            this.LsiteTypeObjetCritere = new Dictionary<string, Type>();


            InitAndLoadData();

            // Initialisation du champs par les valeus par défaut 
            // 
            SetDefaultValue();
        }

        /// <summary>
        /// Initialisation du champs avec les valeurs pardéfaut
        /// </summary>
        private void SetDefaultValue()
        {
            foreach (var item in this.DefaultFiltreValues)
            {
                //foreach (var item in )
                //{

                //}
            }
            
        }

        public ManyToOneField(PropertyInfo propertyInfo, Control MainContainner, Orientation OrientationFiled, Size SizeLabel, Size SizeControl, Dictionary<string, object> DefaultFiltreValues)
          : this(null, propertyInfo, MainContainner, OrientationFiled, SizeLabel, SizeControl, DefaultFiltreValues)
        {

        }

        public ManyToOneField() : this(null, null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20), null)
        {

        }

        private ManyToOneField(Type TypeObjet) : this(TypeObjet,null,null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20),null)
        {
            
        }



        private void comboBoxManyToOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
    }
}
