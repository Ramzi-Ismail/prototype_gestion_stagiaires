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
using App.WinForm.Annotation;
using System.Collections;

namespace App.WinForm
{
    /// <summary>
    /// Permet la saisie d'une collection d'entity dans une relation ManyToMany
    /// 
    /// </summary>
    public partial class InputManyToManyControle : UserControl
    {
        #region Variables
        /// <summary>
        /// Critères de filtre
        /// Le filtre permet de filtre la liste de collection de choix
        /// </summary>
        List<Type> Criteria { set; get; }

        /// <summary>
        /// Lire et obient la liste de choix
        /// </summary>
        List<BaseEntity> SelectionList { set; get; }

        /// <summary>
        /// Les valeurs pardéfaut
        /// </summary>
        List<BaseEntity> DefaultValueList { set; get; }

        /// <summary>
        /// Type de l'entity en cours
        /// </summary>
        Type TypeEntity { set; get; }

        /// <summary>
        /// L'objet ProtpertyInfo de la classe "ManyToMany"
        /// </summary>
        PropertyInfo PropertyInfo_ManyToMany { set; get; }

        SelectionCriteriaAttribute SelectionCriteria { set; get; }

        BaseEntity Entity { set; get; }

        /// <summary>
        /// Lite des ComboBox 
        /// </summary>
        Dictionary<string, ComboBox> ListeComboBox = new Dictionary<string, ComboBox>();

        /// <summary>
        /// Lite des Valeur de critère Initial de comboBox
        /// </summary>
        Dictionary<string, Int64> ListeValeursCritere = new Dictionary<string, long>();

        /// <summary>
        /// Liste des Types de critère 
        /// </summary>
        Dictionary<string, Type> LsiteTypeObjetCritere = new Dictionary<string, Type>();


        #endregion

        #region Constructeur
        public InputManyToManyControle(PropertyInfo propertyInfo, List<BaseEntity> DefaultValueList, BaseEntity Entity)
        {
            InitializeComponent();
            this.DefaultValueList = DefaultValueList;
            this.PropertyInfo_ManyToMany = propertyInfo;

            // if (Entity == null) throw new ArgumentException("L'objet Entity dans InputManyToManu ne doit pas être null");
            this.Entity = Entity;

            this.TypeEntity = PropertyInfo_ManyToMany.PropertyType.GetGenericArguments()[0];
            this.SelectionCriteria = (SelectionCriteriaAttribute)PropertyInfo_ManyToMany.GetCustomAttribute(typeof(SelectionCriteriaAttribute));
            this.Init_Show();
        }
        private void Init_Show()
        {
            this.Show_Filter();
            this.Show_List_Of_Choices();
            this.Show_Display_Selected_Entity();
        }
        #endregion

        /// <summary>
        /// Afficher le filtre dans l'interface
        /// </summary>
        private void Show_Filter()
        {
            // Suppresion de la zone de filtre si les critères de filtrage 
            // n'existe pas  
            if (this.SelectionCriteria == null)
            {
                groupBoxFilter.Visible = false;
                groupBoxListChoices.Location = new Point(12, 0);
                groupBoxDisplaySelected.Location = new Point(12, groupBoxListChoices.Location.Y + groupBoxListChoices.Size.Height + 10);
                return;
            }

            // Positions
            int index = 0;
            int y = 20;

            // Initation de comboBox pour chaque Critère de filtrage
            //
            // Si un objet du critère de selection exite dans la classe 
            // Nous cherchons sa valeur pour l'utiliser
            //
            foreach (Type item in SelectionCriteria.Criteria)
            {
                // Configuration de la classe de Critère
                AffichageClasseAttribute AffichageClasse = (AffichageClasseAttribute) item.GetCustomAttribute(typeof(AffichageClasseAttribute));

                // Trouver la valeur du critère dans l'objet Entity
                Int64 ValeurCritere = 0;
                Type DeclaringType = PropertyInfo_ManyToMany.DeclaringType;
                PropertyInfo PropertyInfo_value = DeclaringType.GetProperties().Where(p => p.PropertyType.Name == item.Name).SingleOrDefault();
                if (PropertyInfo_value != null && Entity != null)
                {
                        BaseEntity value = (BaseEntity)PropertyInfo_value.GetValue(Entity);
                        if(value != null)  ValeurCritere = value.Id;
                }

                //
                // Initialisation de l'interface
                //

                // 
                // label1
                // 
                Label label_comboBox = new Label();
                label_comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
          | System.Windows.Forms.AnchorStyles.Left)
          | System.Windows.Forms.AnchorStyles.Right)));
                label_comboBox.AutoSize = true;
                label_comboBox.Location = new System.Drawing.Point(6, y);
                label_comboBox.Name = "label_" + item.Name;
                label_comboBox.Size = new System.Drawing.Size(35, 13);
                label_comboBox.TabIndex = ++index;
                label_comboBox.Text = item.Name;
                //
                // ComBobox
                //
                ComboBox comboBox = new ComboBox();

                comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
                comboBox.FormattingEnabled = true;
                comboBox.Location = new System.Drawing.Point(6, y +20);
                comboBox.Name = "comboBoxFilter_" + item.Name; ;
                comboBox.Size = new System.Drawing.Size(250, 21);
                comboBox.ValueMember = "Id";
                comboBox.DisplayMember = AffichageClasse.DisplayMember;
                comboBox.TabIndex = ++index; ;

                this.groupBoxFilter.Controls.Add(label_comboBox);
                this.groupBoxFilter.Controls.Add(comboBox);

                ListeComboBox.Add(item.Name, comboBox);
                ListeValeursCritere.Add(item.Name, ValeurCritere);
                LsiteTypeObjetCritere.Add(item.Name, item);
                y += 40;
            }

            //
            // Redimention de l'interface
            //
            groupBoxFilter.Location = new Point(12, 5);
            groupBoxFilter.Size = new System.Drawing.Size(188, y );
            groupBoxListChoices.Location = new Point(12, groupBoxFilter.Location.Y + groupBoxFilter.Size.Height + 10);
            groupBoxDisplaySelected.Location = new Point(12, groupBoxListChoices.Location.Y + groupBoxListChoices.Size.Height + 10);


            // 
            // Affectation des sources de données
            //
            for(int i = 0; i < ListeComboBox.Count; i++ )
            {
                ComboBox comboBox = ListeComboBox.Values.ElementAt(i) ;
                string key = ListeComboBox.Keys.ElementAt(i);
                IBaseRepository service = new BaseRepository<BaseEntity>()
                    .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);
                comboBox.DataSource = service.GetAll();
            }

            // 
            // Affectation des Valeurs par défaut
            //
            for (int i = 0; i < ListeComboBox.Count; i++)
            {
                ComboBox comboBox = ListeComboBox.Values.ElementAt(i);
                string key = ListeComboBox.Keys.ElementAt(i);
                IBaseRepository service = new BaseRepository<BaseEntity>()
                    .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);
                
                // Valeur par défaut
                if (ListeValeursCritere[key] != 0)
                {
                    comboBox.CreateControl();
                    comboBox.SelectedValue = ListeValeursCritere[key];
                    // Actualisation de ComboBox suivant
                    ComboBox comboBox_suivant = ListeComboBox.Values.ElementAt(i+1);
                    string key_suivant = ListeComboBox.Keys.ElementAt(i+1);

                    BaseEntity EntityPere = service.GetBaseEntityByID(ListeValeursCritere[key]);
                    PropertyInfo PropertyChild = EntityPere.GetType()
                                                    .GetProperties()
                                                    .Where(p => p.Name == key_suivant + "s")
                                                    .SingleOrDefault();
                    comboBox_suivant.DataSource = PropertyChild.GetValue(EntityPere) ;
                }
            }



            // Création des relation de chargement entre les critères
            foreach (var item in ListeComboBox)
            {
                item.Value.SelectedIndexChanged += Value_SelectedIndexChanged;
            }

        }

        
        /// <summary>
        /// Actualisation de tous les comboBox et ListBox
        /// </summary>
        private void Value_SelectedIndexChanged(object sender, EventArgs e)
        {
            // à chaque changement d'un combo 
            // on charge les donnée de comboBox suivant
            ComboBox comboBox = (ComboBox)sender;
            int index_comboBox =  ListeComboBox.Values.ToList<ComboBox>().IndexOf(comboBox);

           
            string key = ListeComboBox.Keys.ElementAt(index_comboBox);
            IBaseRepository service = new BaseRepository<BaseEntity>()
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);

            // Actualisation de ComboBox suivant
            if ((ListeComboBox.Values.Count()-1) >= (index_comboBox + 1))
            {
                //
                // Actualisation de combobBox suivant
                //
                ComboBox comboBox_suivant = ListeComboBox.Values.ElementAt(index_comboBox + 1);
                string key_suivant = ListeComboBox.Keys.ElementAt(index_comboBox + 1);

                BaseEntity EntityPere = service.GetBaseEntityByID(Convert.ToInt64(comboBox.SelectedValue));
                PropertyInfo PropertyChild = EntityPere.GetType()
                                                .GetProperties()
                                                .Where(p => p.Name == key_suivant + "s")
                                                .SingleOrDefault();

                IList ls_source = PropertyChild.GetValue(EntityPere) as IList;
                comboBox_suivant.DataSource = ls_source;

                // Si ce Combo n'a pas d'information 
                // alors vider les combBobx suivant 
                if (ls_source == null || ls_source.Count == 0)
                    for (int i = (index_comboBox + 1); i < ListeComboBox.Values.Count(); i++)
                    {
                        ComboBox comboBox_suivant2 = ListeComboBox.Values.ElementAt(i);
                        comboBox_suivant2.DataSource = null;
                        comboBox_suivant2.Text = "";

                    }
            }
            else
            {
                //
                // aprés l'actualisation de tous les comboBox on  actualise  de ListBox
                //
                if(comboBox.SelectedValue != null) { 
                BaseEntity EntityPere = service.GetBaseEntityByID(Convert.ToInt64(comboBox.SelectedValue));
                PropertyInfo PropertyChild = EntityPere.GetType()
                                                .GetProperties()
                                                .Where(p => p.Name == PropertyInfo_ManyToMany.PropertyType.GetGenericArguments()[0].Name + "s")
                                                .SingleOrDefault();
                    listBoxChoices.DataSource = PropertyChild.GetValue(EntityPere);
                }
                else
                {
                    listBoxChoices.DataSource = null;
                }
                
            }





        }

        /// <summary>
        /// Afficher la liste de choix
        /// </summary>
        private void Show_List_Of_Choices()
        {

            IBaseRepository service = new BaseRepository<BaseEntity>().CreateInstance_Of_Service_From_TypeEntity(this.TypeEntity);
            this.listBoxChoices.DataSource = service.GetAll();

            if (DefaultValueList == null) return;
            for (int i = 0; i < this.listBoxChoices.Items.Count; i++)

            {
                BaseEntity item = (BaseEntity)this.listBoxChoices.Items[i];
                if (this.DefaultValueList.Contains(item))
                    this.listBoxChoices.SelectedItems.Add(item);
            }


        }

        /// <summary>
        /// Affichage du détaille de l'entity selectionné
        /// </summary>
        private void Show_Display_Selected_Entity()
        {

        }
    }
}
