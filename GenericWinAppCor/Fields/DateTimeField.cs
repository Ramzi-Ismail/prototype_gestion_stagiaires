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
        public override object Value
        {
            get
            {
                return dateTimeControl.Value;
            }
            set
            {
                dateTimeControl.Value = Convert.ToDateTime(value);
            }
        }
        #endregion 
         

        public DateTimeField(PropertyInfo PropertyInfo, Orientation OrientationFiled, Size SizeLabel, Size SizeControl) : base(PropertyInfo, OrientationFiled, SizeLabel, SizeControl)
        {
            InitializeComponent();
            dateTimeControl.Size = SizeControl;
        }
        public DateTimeField() : this(null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20))
        {

        }

        private void dateTimeControl_ValueChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
    }
}
