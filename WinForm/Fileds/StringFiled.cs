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
        public string Value
        {
            get
            {
                return textBoxField.Text;
            }
        }
        #endregion 

        public StringFiled(PropertyInfo propertyInfo,Orientation OrientationFiled, int WidhtField) :base(propertyInfo,OrientationFiled, WidhtField)
        {
            InitializeComponent();
        }
        public StringFiled() : this(null,Orientation.Horizontal,0)
        {
       
        }

        private void textBoxField_TextChanged(object sender, EventArgs e)
        {
            onFieldChanged(sender, e);
        }
    }
}
