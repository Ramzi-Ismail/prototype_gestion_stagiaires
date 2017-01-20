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

namespace App.WinFrom.Fileds
{
    public partial class BaseField : UserControl
    {
        #region Constance
        protected int Default_Width_Label = 50;
        protected int Default_Heifht_Label = 20;
        #endregion

        #region Enumération
        #endregion

        #region Evénement
        public event EventHandler FieldChanged;
        protected void onFieldChanged(object sender,EventArgs e)
        {
            FieldChanged(sender, e);
        }
        #endregion

        #region Propriété

        /// <summary>
        /// Le type de l'objet à entrer par ce contôle
        /// </summary>
        protected Type TypeOfObject { set; get; }

        /// <summary>
        /// La propriété Info de du champs
        /// </summary>
        protected PropertyInfo propertyInfo;


        /// <summary>
        /// La direction d'affichage, il est soit vertical soit horizontale
        /// </summary>
        protected Orientation orientationFiled;
        protected Orientation OrientationFiled
        {
            set
            {
                orientationFiled = value;
                this.splitContainer.Orientation = orientationFiled;

            }
            get
            {
                return orientationFiled;
            }
        }

        /// <summary>
        /// Définire le texte du label 
        /// </summary>
        public string Text_Label
        {
            set
            {
                this.labelField.Text = value;
            }
        }

        /// <summary>
        /// Définire le largeur du label, par défaut il a la valeur 50 px
        /// </summary>
        public int WidthLabel { set; get; }
        public int HeightLabel { set; get; }
        /// <summary>
        /// Obtient la vlaeur largeur du du controle qui contient la valeur
        /// </summary>
        public int WidthControleValue {
            protected set;
              get; }

        protected int widthField;

        /// <summary>
        /// Obient et Lire le largeur du champs
        /// </summary>
        public int WidthField {
            set
            {
                widthField = value;
                this.splitContainer.Width = widthField;
                InitBaseField();
            }
            get
            {
                return widthField;
            }
        }
        public int HeightField { set; get; }

        #endregion

        #region Constructeurs
        public BaseField(Type TypeObjet, PropertyInfo PropertyInfo, Orientation OrientationFiled, int WidthField)
        {
            InitializeComponent();
            this.TypeOfObject = TypeObjet;
            this.propertyInfo = PropertyInfo;
            this.OrientationFiled = OrientationFiled;
            // Default Label size
            this.WidthLabel = Default_Width_Label;
            this.HeightLabel = Default_Heifht_Label;
            // Default Filed size

            this.HeightField = 100; // doit être initialiser avant WidhtField

            // Widht et Initialisation 
            this.WidthField = WidthField;


        }
        public BaseField(Type TypeObjet, Orientation OrientationFiled, int WidthField)
            : this(TypeObjet,null, OrientationFiled, WidthField) { }

        public BaseField(PropertyInfo PropertyInfo, Orientation OrientationFiled, int WidthField)
           : this(null, PropertyInfo, OrientationFiled, WidthField) { }

        public BaseField():this(null,null, Orientation.Horizontal,150)  {}

       
        #endregion

        private void InitBaseField()
        {

            //
            // Label
            //
            labelField.Width = this.WidthLabel;
            labelField.Height = this.HeightLabel;

            //
            // Containner
            // 
            this.splitContainer.Orientation = this.OrientationFiled;
            
            this.splitContainer.Width = this.WidthField;
            this.splitContainer.Height = this.HeightField;
            if (OrientationFiled == Orientation.Vertical)
            {
                this.Size = new Size(this.WidthField, 25);
                this.WidthControleValue = this.WidthField - this.WidthLabel;
                this.splitContainer.SplitterDistance = this.WidthLabel;
            }
            else
            {
                this.Size = new Size(this.WidthField, 70);
                this.WidthControleValue = widthField;
                this.splitContainer.SplitterDistance = this.HeightLabel ;  
            }


        }
    }
}
