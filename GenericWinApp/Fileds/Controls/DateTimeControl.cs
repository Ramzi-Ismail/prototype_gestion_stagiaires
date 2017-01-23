using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace App.WinFrom.Fileds.Controls
{
 
    /// <summary>
    /// Représente un champs de type DateTime dans une Entity
    /// </summary>
    public partial class DateTimeControl : UserControl
    {

        #region Evénement
        public event EventHandler ValueChanged;
        protected void onValueChanged(object sender, EventArgs e)
        {
            ValueChanged(sender, e);
        }

        #endregion

        #region Propriété 
        public DateTime Value
        {
            get
            {
                if(this.dateTimePicker.Text == string.Empty) return DateTime.MinValue;
                else return this.dateTimePicker.Value;
            }
            set
            {
                this.dateTimePicker.Value = Value;
            }
        }
        #endregion





        List<CultureInfo> ListCultureInfo { get; set; }

        /// <summary>
        /// Format de la date 
        /// dddd/MMMM/yyyy h:m:s
        /// </summary>
        String Formet { get; set; }

        public DateTimeControl()
        {
            InitializeComponent();
        }
        public DateTimeControl(List<CultureInfo> ListCultureInfo)
        {
            InitializeComponent();
            this.ListCultureInfo = ListCultureInfo;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            onValueChanged(sender, e);
        }
    }
}
