﻿using App.WinForm;
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
    public partial class Int32Filed : App.WinFrom.Fileds.BaseField
    {
        #region Propriété
        /// <summary>
        /// Obient la valeur du champs
        /// </summary>
        public override object Value
        {
            get
            {
                if (textBoxFiled.Text == string.Empty) return 0;
                else
                {
                    int value = 0;
                    if (int.TryParse(textBoxFiled.Text, out value))
                    {
                        return value;
                    }
                    else
                    {
                        MessageToUser.AddMessage(MessageToUser.Category.Convert, "Impossible de lire la valeur Entier :" + textBoxFiled.Text);
                        return 0;
                    }
                }

            }
            set
            {
                textBoxFiled.Text = value.ToString();

            }
        }
        #endregion

        public Int32Filed(PropertyInfo PropertyInfo, Orientation OrientationField, Size SizeLabel, Size SizeControl) : base(PropertyInfo,OrientationField, SizeLabel, SizeControl)
        {
            InitializeComponent();
        }

        public Int32Filed() : this(null, Orientation.Horizontal, new Size(50, 20), new Size(50, 20))
        {

        }

        private void textBoxFiled_TextChanged(object sender, EventArgs e)
        {
            onFieldChanged(this, e);
        }
    }
}
