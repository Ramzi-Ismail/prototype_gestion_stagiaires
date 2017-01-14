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

namespace App.WinForm
{
    /// <summary>
    /// Permet la saisie d'une collection d'entity dans une relation ManyToMany
    /// 
    /// </summary>
    public partial class InputManyToManyControle : UserControl
    {
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




        public InputManyToManyControle(PropertyInfo propertyInfo, List<BaseEntity> DefaultValueList, BaseEntity Entity)
        {
            InitializeComponent();
            this.DefaultValueList = DefaultValueList;
            this.PropertyInfo_ManyToMany = propertyInfo;

           // if (Entity == null) throw new ArgumentException("L'objet Entity dans InputManyToManu ne doit pas être null");
            this.Entity = Entity;

            this.TypeEntity = PropertyInfo_ManyToMany.PropertyType.GetGenericArguments()[0];
            this.SelectionCriteria =(SelectionCriteriaAttribute) PropertyInfo_ManyToMany.GetCustomAttribute(typeof(SelectionCriteriaAttribute));
            this.Init_Show();
        }
        private void Init_Show()
        {
            this.Show_Filter();
            this.Show_List_Of_Choices();
            this.Show_Display_Selected_Entity();
        }

        /// <summary>
        /// Afficher le filtre dans l'interface
        /// </summary>
        private void Show_Filter()
        {
            if (this.SelectionCriteria == null) { 
                groupBoxFilter.Visible = false;
                groupBoxListChoices.Location = new Point(12, 0);
                groupBoxDisplaySelected.Location = new Point(12, groupBoxListChoices.Location.Y + groupBoxListChoices.Size.Height + 10);
            }
            else
            {
                int index = 0;
                int y =12;
                foreach (Type item in SelectionCriteria.Criteria)
                {

                    //
                    // Si le type de  la critère de selection exite dans la classe DeclarynType
                    // Nous choisisson la sa valeur pour trouver les valeurs désendante dans 
                    // les critère de séléction
                    //
                    // DeclarynType : qui declare cette propriété désigné par l'objet  
                    // PropertyInfo_ManyToMany 
                    //


                    // Obiten l'objet PropertyInfo qui conteint la vlaeur
                    Type DeclaringType = PropertyInfo_ManyToMany.DeclaringType;
                    PropertyInfo PropertyInfo_value = DeclaringType.GetProperties().Where(p => p.PropertyType.Name == item.Name).SingleOrDefault();

                    if (PropertyInfo_value != null)
                    {
                        if(Entity != null) { 
                        BaseEntity value =(BaseEntity) PropertyInfo_value.GetValue(Entity);
                        }

                        continue;
                    }
                    // 
                    // label1
                    // 
                    Label label_comboBox = new Label();
                    label_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
                    comboBox.Location = new System.Drawing.Point(6, y +30);
                    comboBox.Name = "comboBoxFilter_" + item.Name; ;
                    comboBox.Size = new System.Drawing.Size(188, 21);
                    comboBox.TabIndex = ++index; ;

                    //
                    // DataSource ComboBox
                    //
                    IBaseRepository service = new BaseRepository<BaseEntity>()
                        .CreateInstance_Of_Service_From_TypeEntity(item);
                    comboBox.DataSource = service.GetAll();

                    this.groupBoxFilter.Controls.Add(label_comboBox);
                    this.groupBoxFilter.Controls.Add(comboBox);

                    y += 50;
                }

                //
                // Redimention de l'interface
                //
                groupBoxFilter.Location = new Point(12, 5);
                groupBoxFilter.Size = new System.Drawing.Size(188, y +20);
                groupBoxListChoices.Location = new Point(12, groupBoxFilter.Location.Y + groupBoxFilter.Size.Height + 10);
                groupBoxDisplaySelected.Location = new Point(12, groupBoxListChoices.Location.Y + groupBoxListChoices.Size.Height + 10);
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
                BaseEntity item =(BaseEntity) this.listBoxChoices.Items[i];
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
