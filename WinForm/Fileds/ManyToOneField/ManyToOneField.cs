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
        public Object Value
        {
            get
            {
                return comboBoxManyToOne.SelectedValue;
            }
        }

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



        public ManyToOneField(Type TypeObjet,PropertyInfo propertyInfo, Control MainContainner, int WidthField, Orientation OrientationFiled) 
            :base(TypeObjet,propertyInfo, OrientationFiled, WidthField)
        {
            InitializeComponent();
            this.MainContainner = MainContainner;
            InitAndLoadData();
        }
        public ManyToOneField(PropertyInfo propertyInfo, Control MainContainner, int WidthField, Orientation OrientationFiled)
          : this(null, propertyInfo, MainContainner, WidthField, OrientationFiled)
        {

        }

        public ManyToOneField() : this(null, null,0, Orientation.Horizontal)
        {

        }

        private ManyToOneField(Type TypeObjet) : this(TypeObjet,null,null,0, Orientation.Horizontal )
        {
            
        }



        private void comboBoxManyToOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
    }
}
