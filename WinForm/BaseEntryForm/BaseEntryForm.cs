using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App.WinFrom.Validation;
using System.Reflection;
using App.WinForm.Annotation;
using System.Data.Entity;

namespace App.WinForm
{
    /// <summary>
    /// Formulaire de base pour la réalisation d'une Formulaire Particulier
    /// ou à utimiser dans la formulaire génirique
    /// </summary>
    public partial class BaseEntryForm : UserControl, IBaseEntryForm
    {
        #region Variables
        /// <summary>
        /// à supprimer , utilisez Service
        /// </summary>
        protected ModelContext context;
        /// <summary>
        /// Obtient ou définire l'entité représenté par cette formulaire
        /// </summary>
        public BaseEntity Entity { get; set; }

        /// <summary>
        /// l'instance de service de la gestion en cours
        /// 
        /// </summary> 
        public IBaseRepository Service { get; set; }

        /// <summary>
        /// Message da validation des champs de la formulire
        /// </summary>
        protected MessageValidation MessageValidation;

        /// <summary>
        /// Indique le controle qui contient la formulaire
        /// </summary>
        protected Control ConteneurFormulaire {
            get;
            set; }

        public virtual void InitValeurFromFiltre(Dictionary<string, object> dictionary)
        {
             
        }



        #endregion

        #region Constructeurs
        /// <summary>
        /// Créer du formuliare avec l'instance de service en cours d'utilisation
        /// </summary>
        /// <param name="service"></param>
        public BaseEntryForm(IBaseRepository service)
        {
            InitializeComponent();
            this.Service = service;
            MessageValidation = new MessageValidation(errorProvider);
            ConteneurFormulaire = this.splitContainer1.Panel1;




        }

        ///// <summary>
        /////  
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <param name="context"></param>
        // public BaseEntryForm():this(null) : l'appel de constructeur de base , block la modification
        // des controle protected et public sur la formulaire hérité
        public BaseEntryForm() 
        {
            InitializeComponent();
            if (!DesignMode) {
              
                MessageValidation = new MessageValidation(errorProvider);
                ConteneurFormulaire = this.splitContainer1.Panel1;
            }
        }
        #endregion

        #region Evénement
        public event EventHandler EnregistrerClick;
        public event EventHandler AnnulerClick;
        protected void onEnregistrerClick(Object sender, EventArgs e)
        {
            if (EnregistrerClick != null) EnregistrerClick(sender, e);
        }
        protected void onAnnulerClick(Object sender, EventArgs e)
        {
            if (AnnulerClick != null) AnnulerClick(sender, e);
        }
        #endregion
       
        #region validation
        protected void ValiderTextBox(object sender, CancelEventArgs e, ErrorProvider errorProvider, String message = "")
        {

            TextBox controle = (TextBox)sender;
            if (message == "") message = "La saisie de ce champs est oblégatoir";
            if (controle.Text.Trim() == String.Empty)
            {
                errorProvider.SetError(controle, message);
                e.Cancel = true;
            }
            else
                errorProvider.SetError(controle, "");
        }

        /// <summary>
        /// Creation d'une instance de l'objet en cours
        /// </summary>
        /// <returns></returns>

        #endregion

        #region CreateInsce

        /// <summary>
        /// Création d'une instance comme cette formulaire
        /// </summary>
        /// <returns></returns>
        public virtual BaseEntryForm CreateInstance(IBaseRepository Service) {

            BaseEntryForm formilaire =(BaseEntryForm) Activator.CreateInstance(this.GetType(), Service);
           
            return formilaire;


        }
        public virtual BaseEntryForm CreateInstance(IBaseRepository Service,BaseEntity entity)
        {

            BaseEntryForm formilaire = (BaseEntryForm)Activator.CreateInstance(this.GetType(), Service, entity);

            return formilaire;


        }


        /// <summary>
        /// Créer une instance de l'objet du formulaire
        /// </summary>
        /// <returns></returns>
        public virtual BaseEntity CreateObjetInstance()
        {
            return new BaseEntity();
        }
        #endregion


        #region Lire et Afficher

        public virtual void Afficher()
        {
            this.Afficher(null);
        }

        /// <summary>
        /// Affiher l'objet dans le formulaire
        /// Utilisation de l'annotation de l'objet dans le cas d'un formilaire spécifique à l'objet
        /// </summary>
        public virtual void Afficher(Dictionary<string, object> CritereFiltre)
        {

            BaseEntity entity = this.Entity;
            Type typeEntity = this.Service.TypeEntity;

            // Lecture des valeurs


            int y = 35;
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


                Type typePropriete = item.PropertyType;
                string NomPropriete = item.Name;
                if (typePropriete.Name == "String") {

                    String NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "TextBox";
                    string valeur = (string)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                    TextBox txtBox = (TextBox)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();
                    txtBox.Text = valeur;
                    if (CritereFiltre != null && CritereFiltre.ContainsKey(item.Name))
                    {
                        txtBox.Text = CritereFiltre[item.Name].ToString();
                    }

                }
                if (typePropriete.Name == "Int32")
                {

                    String NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "TextBox";
                    int valeur = (int) typeEntity.GetProperty(NomPropriete).GetValue(entity);
                    TextBox txtBox = (TextBox)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();
                    txtBox.Text = valeur.ToString();
                    if (CritereFiltre != null && CritereFiltre.ContainsKey(item.Name))
                    {
                        txtBox.Text = CritereFiltre[item.Name].ToString(); 
                    }

                }

                if (typePropriete.Name == "DateTime")
                {
                    String NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "DateTimePicker";
                    DateTime valeur = (DateTime)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                    DateTimePicker dateTimePicker = (DateTimePicker)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();
                    dateTimePicker.Value = valeur;
                    if (CritereFiltre != null && CritereFiltre.ContainsKey(item.Name))
                    {
                        dateTimePicker.Value = Convert.ToDateTime( CritereFiltre[item.Name]);
                    }
                }
                if (AffichagePropriete.Relation == "ManyToOne")
                {
                    String NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "ComboBox";
                    BaseEntity valeur = (BaseEntity)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                    ComboBox comboBox = (ComboBox)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();
                    if (valeur != null)
                         comboBox.SelectedValue = valeur.Id;
                    if (CritereFiltre != null && CritereFiltre.ContainsKey(item.Name))
                    {
                        Int64 id = (Int64)CritereFiltre[item.Name];
                        // Select Id dans Combo
                        // comboBox.selectedvalue ne marche pas ici !!
                        int index = 0;
                        comboBox.CreateControl();
                        foreach (object obj in (List<object>) comboBox.DataSource)
                        {
                            BaseEntity o = (BaseEntity)obj;
                            if (o.Id == id)
                                comboBox.SelectedIndex = index;

                            index++;
                        }
                        
                        
                    }
                }


        }
    }
    



        /// <summary>
        /// Lire les information du formulaire vers l'objet
        /// </summary>
        protected virtual void Lire() {

            BaseEntity entity = this.Entity;
            Type typeEntity = this.Service.TypeEntity;

            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));

                Type typePropriete = item.PropertyType;
                string NomPropriete = item.Name;

                if (typePropriete.Name == "String")
                {
                    String  NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "TextBox";
                    TextBox txtBox = (TextBox)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, txtBox.Text);
                }
                if (item.PropertyType.Name == "Int32")
                {
                    String NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "TextBox";
                    TextBox txtBox = (TextBox)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();
                    int Nombre;
                    if (int.TryParse(txtBox.Text, out Nombre))
                        typeEntity.GetProperty(NomPropriete).SetValue(entity, Nombre);
                    else
                        MessageBox.Show("Impossible de lire un nombre");

                }
                if (typePropriete.Name == "DateTime")
                {
                    String NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "DateTimePicker";
                    DateTimePicker dateTimePicker = (DateTimePicker)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, dateTimePicker.Value);
                }
                if (AffichagePropriete.Relation == "ManyToOne")
                {
                    String NomControle = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "ComboBox";
                    ComboBox comboBox = (ComboBox)this.ConteneurFormulaire.Controls.Find(NomControle, true).First();

                    Type ServicesEntityType = typeof(BaseRepository<>).MakeGenericType(item.PropertyType);
                    IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityType, this.Service.Context());
                    BaseEntity ManyToOneEntity = ServicesEntity.GetBaseEntityByID(Convert.ToInt32(comboBox.SelectedValue));


                    typeEntity.GetProperty(NomPropriete).SetValue(entity, ManyToOneEntity);
                }
            }


        }


        #endregion


        #region Enregistrer et Annuler
        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            bool validation = true;
            if (ValidationManager.hasValidationErrors(this.Controls))
                return;
            this.Lire();

            if (validation)
            {
                if (Service.Save(this.Entity) > 0)
                {
                    MessageBox.Show(string.Format("'{0}' a été bien enregistrer", this.Entity.ToString()));
                }
                else
                {
                    MessageBox.Show(string.Format("'{0}' n'est pas enregistrer car il n'y a pas des modifications", this.Entity.ToString()));
                }
                onEnregistrerClick(this, e);
            }
        }

        private void btAnnuler_Click(object sender, EventArgs e)
        {
            
            onAnnulerClick(this, e);
            
        }

        void IBaseEntryForm.Lire()
        {
            throw new NotImplementedException();
        }

        #endregion



    

        /// <summary>
        /// Obient la liste des Propriété à utliser dans la formulaire
        /// </summary>
        /// <returns></returns>
        protected List<PropertyInfo> ListeChampsFormulaire()
        {
            // Obtien la liste des PropertyInfo par ordrer d'affichage
            var listeProprite = from i in this.Service.TypeEntity.GetProperties()
                                where i.GetCustomAttribute(typeof(AffichageProprieteAttribute)) != null
                                && ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).isFormulaire
                                orderby ((AffichageProprieteAttribute)i.GetCustomAttribute(typeof(AffichageProprieteAttribute))).Ordre
                                select i;
            return listeProprite.ToList<PropertyInfo>();
        }


    }
}
