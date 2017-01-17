using App.WinForm.Annotation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace App.WinForm.EntityManagement
{
    public partial class FiltreControl : App.WinForm.EntityManagement.BaseFilterControl
    {
        public FiltreControl():base()
        {
            InitializeComponent();
        }

        public FiltreControl(IBaseRepository service) : base(service)
        {
            InitializeComponent();
        }
        public FiltreControl(IBaseRepository Service, Dictionary<string, object> ValeursFiltre) : base(Service, ValeursFiltre)
        {
            InitializeComponent();
        }
       


        private void FiltreControl_Load(object sender, EventArgs e)
        {
            this.initFiltre();
        }
 
    }
}
