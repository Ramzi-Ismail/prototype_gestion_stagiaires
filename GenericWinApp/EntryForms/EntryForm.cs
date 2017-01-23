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
using System.ComponentModel.DataAnnotations;
using App.WinForm.Annotation;
using System.Collections;
using App.WinFrom.Fileds;

namespace App.WinForm
{

    /// <summary>
    /// Formulaire de saisie générique
    /// </summary>
    public partial class EntryForm : BaseEntryForm
    {

        #region Constructeurs
        public EntryForm(IBaseRepository service, BaseEntity entity, Dictionary<string, object> critereRechercheFiltre) 
            : base(service, entity, critereRechercheFiltre)
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructeur principale
        /// </summary>
        /// <param name="service">Instance de ServerManager qui gérer l'entity en cours gestion</param>
        /// 
        public EntryForm(IBaseRepository service) : base(service)
        {
            InitializeComponent();
 
        }
       
        #endregion

    

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            // même si nous avons définit l'événement Clikc sur le button ajouter 
            // l'événement de btEnregistrer_Click est toujour exécuter
        }
    }
}
