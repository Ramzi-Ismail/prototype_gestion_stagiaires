using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace App.WinFrom.Fileds
{
    public partial class StringFiled : App.WinFrom.Fileds.BaseField
    {
        #region Propriété
        /// <summary>
        /// Obient la valeur de TexteBox du champs String
        /// </summary>
        public override object Value
        {
            get
            {
                return textBoxField.Text;
            }
            set
            {
                if(value != null)
                textBoxField.Text = value.ToString();
            }
        }

        /// <summary>
        /// Obtien si la Zone de Texte est multi_ligne
        /// </summary>
        public bool MultiLinge { get; private set; }
        public AffichageProprieteAttribute AffichagePropriete { get; private set; }
    
        #endregion

        public StringFiled(PropertyInfo propertyInfo,Orientation OrientationFiled, Size SizeLabel, Size SizeControl) :base(propertyInfo,OrientationFiled, SizeLabel, SizeControl)
        {
            InitializeComponent();

            AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
            this.AffichagePropriete = AffichagePropriete;
           
            InitSizeStringFiled();
        }

     

        public StringFiled() : this(null,Orientation.Horizontal, new Size(50, 20), new Size(50, 20))
        {
       
        }
        private void textBoxField_TextChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
        /// <summary>
        /// Initialisation spécifique à zone de texte
        /// Exécuter aprés l'initialisation de du Size Field
        /// </summary>
        private void InitSizeStringFiled()
        {
            if (this.AffichagePropriete.MultiLine)
            {
                this.textBoxField.Multiline = true;
                this.textBoxField.Size = new Size(this.SizeControl.Width, 10 * this.AffichagePropriete.NombreLigne);
                // Modification de Size de Field
                // [Bug] est ce que il faut augmenter aussi la taille Layout ?
                this.Size = new Size(this.Size.Width, this.Size.Height + 10 * (this.AffichagePropriete.NombreLigne));
            }
        }
    }
}
