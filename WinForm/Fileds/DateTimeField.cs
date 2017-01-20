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
    public partial class DateTimeField : App.WinFrom.Fileds.BaseField
    {
        #region Propriété
        /// <summary>
        /// Obient la valeur de DateTimePicker
        /// </summary>
        public DateTime Value
        {
            get
            {
                return dateTimeControl.Value;
            }
        }
        #endregion 
         

        public DateTimeField(PropertyInfo PropertyInfo, Orientation OrientationFiled,int WidhtField):base(PropertyInfo,OrientationFiled, WidhtField)
        {
            InitializeComponent();
        }
        public DateTimeField() : this(null,Orientation.Horizontal,0)
        {

        }

        private void dateTimeControl_ValueChanged(object sender, EventArgs e)
        {
            onFieldChanged(sender, e);
        }
    }
}
