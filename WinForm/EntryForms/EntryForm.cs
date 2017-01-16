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

namespace App.WinForm {  

    /// <summary>
    /// Générer automatiquement le formulaire de saisie
    ///  les champs sont générés selon son annotation
    /// </summary>
    public partial class EntryForm : BaseEntryForm
    {
        #region Variables


        #endregion

        #region Constructeurs
        public EntryForm():base()
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
            ConteneurFormulaire = this.formulaire;
            InitFormulaire();
        }


        public EntryForm(IBaseRepository service,BaseEntity entity,Dictionary<string,object> critereRechercheFiltre) : base(service, entity, critereRechercheFiltre)
        {
            InitializeComponent();

       

            ConteneurFormulaire = this.formulaire;
            InitFormulaire();
        }

        #endregion

        #region Création du formulaire

        /// <summary>
        /// Création et Initalisation des contrôles du formulaire
        /// </summary>
        private void InitFormulaire()
        {
            
            // La position X et Y
            int y = 35;
            int x_label = 16;
            int x_control = 200;
            // L'index de la touche Entrer
            int index = 0;

            // Boucle sur les champs de la classe qui contient l'annotation : AffichageProprieteAttribute
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                // Lecture de l'annotation 
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute) item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


                //
                // Cration de label
                // 
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(x_label, y);
                lbl.Name = "label1";
                lbl.Size = new System.Drawing.Size(100, 13);
                lbl.TabIndex = index++;
                lbl.Text = AffichagePropriete.Titre;

                //
                // Création des champs de type String
                //
                if (item.PropertyType.Name == "String")
                {
                    // 
                    // textBoxString
                    // 
                    TextBox textBoxString = new TextBox();
                    textBoxString.Location = new System.Drawing.Point(x_control, y-3);
                    textBoxString.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1)   + "TextBox";
                    textBoxString.TabIndex = index++;
                    if(AffichagePropriete.isOblegatoir)
                        textBoxString.Validating += textBoxString_Validating;
                    if (AffichagePropriete.MultiLine)
                    {
                        textBoxString.Multiline = true;
                        textBoxString.Size = new System.Drawing.Size(400, 100);
                         y += 80;
                    }
                        else
                        {
                        textBoxString.Size = new System.Drawing.Size(200, 20);
                        }
                       
                    this.formulaire.Controls.Add(textBoxString);
                    }

                //
                // Création des champs de type Int32
                //
                if (item.PropertyType.Name == "Int32")
                {
                    // textBoxInt32
                    TextBox textBoxInt32 = new TextBox();
                    textBoxInt32.Location = new System.Drawing.Point(x_control, y - 3);
                    textBoxInt32.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "TextBox";
                    textBoxInt32.Size = new System.Drawing.Size(200, 20);
                    textBoxInt32.TabIndex = index++;
                    if (AffichagePropriete.isOblegatoir)
                        textBoxInt32.Validating += TextBoxInt32_Validating;

                    this.formulaire.Controls.Add(textBoxInt32);
                }

                //
                // Création des champs de type DateTime
                //
                if (item.PropertyType.Name == "DateTime")
                    {
                        DateTimePicker dateTimePicker = new DateTimePicker();
                    dateTimePicker.Location = new System.Drawing.Point(x_control, y - 3);
                    dateTimePicker.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "DateTimePicker";
                 
                    dateTimePicker.Size = new System.Drawing.Size(200, 20);
                    dateTimePicker.TabIndex = index++;
                    if (AffichagePropriete.isOblegatoir)
                        dateTimePicker.Validating += DateTimePicker_Validating;

                        this.formulaire.Controls.Add(dateTimePicker);
                    }

                //
                // Création des champs de type BaseEntity : ManyToOne
                //
                if (AffichagePropriete.Relation == "ManyToOne")
                    {

                    if (AffichagePropriete.FilterSelection)
                    {
                        InputComboBox InputComboBox = new InputComboBox(item.PropertyType,
                            this.Entity, 
                            InputComboBox.MainContainers.Panel, 
                            InputComboBox.Directions.Vertical);
                        
                        InputComboBox.Location = new System.Drawing.Point(x_control, y - 3);
                        InputComboBox.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "ComboBox";
                        InputComboBox.Size = new System.Drawing.Size(200, 100); y += 80;
                        InputComboBox.TabIndex = index++;

                       
                        this.formulaire.Controls.Add(InputComboBox);

                        if (AffichagePropriete.isOblegatoir)
                            InputComboBox.Validating += ComboBox_Validating;

                    }
                    else {


                        Type ServicesEntityType = typeof(BaseRepository<>).MakeGenericType(item.PropertyType);
                        IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityType);
                        List<object> ls = ServicesEntity.GetAllDetached();

                        ComboBox comboBox = new ComboBox();

                        comboBox.Location = new System.Drawing.Point(x_control, y - 3);
                        comboBox.Name = char.ToLower(item.Name[0]) + item.Name.Substring(1) + "ComboBox";
                        comboBox.Size = new System.Drawing.Size(200, 20);
                        comboBox.TabIndex = index++;
                        comboBox.ValueMember = "Id";
                        comboBox.DisplayMember = AffichagePropriete.DisplayMember;
                        comboBox.DataSource = ls;
                        this.formulaire.Controls.Add(comboBox);

                        if (AffichagePropriete.isOblegatoir)
                            comboBox.Validating += ComboBox_Validating;

                    }

                }

                //
                // Création des champs de type BaseEntity : ManyToOne
                //
                if (AffichagePropriete.Relation == "ManyToMany")
                {
                    // Création de TabPage
                    TabPage tabPage = new TabPage();
                    tabPage.Text = item.Name;
                    this.tabControlManytoMany.TabPages.Add(tabPage);

                    //Valeur par défaut
                    List<BaseEntity> ls_default_value = null;
                    if (this.Entity != null) {
                        IList ls_obj = item.GetValue(this.Entity) as IList;

                        if(ls_obj != null)  ls_default_value = ls_obj.Cast<BaseEntity>().ToList();
                    }

                    
             
                    InputCollectionControle InputCollectionControle = new InputCollectionControle(item,ls_default_value, this.Entity);

                    InputCollectionControle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));


                    tabPage.Controls.Add(InputCollectionControle);
              



                }

                this.formulaire.Controls.Add(lbl);
               
                y += 25;

            }
        }

        private void ComboBox_Validating(object sender, CancelEventArgs e)
        {
            // déja le combobox propose le premiere élément séléctioné
        }

        private void DateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.DateTimePicker(sender, e);
        }

        private void TextBoxInt32_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxInt32(sender, e);
        }

        private void textBoxString_Validating(object sender, CancelEventArgs e)
        {
            this.MessageValidation.TextBoxString(sender, e);
        }
        #endregion



        /// <summary>
        /// Initialisation des valeurs depuis le fitre
        /// </summary>
        /// <param name="dictionary"></param>
        public override void InitValeurFromFiltre(Dictionary<string, object> dictionary)
        {
            foreach (var item in dictionary)
            {

            }
        }


    }
}
