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

namespace App.WinForm {  

    /// <summary>
    /// Formulaire générique, il générer automatiquement les champs,
    /// selon l'annotation des Propriétés de l'Entity de la formulaire.
    /// </summary>
    public partial class FormulaireControle : BaseFormulaire
    {

        #region Constructeurs et Initalisation
        public FormulaireControle():base()
        {
            InitializeComponent();
      
        }
        public FormulaireControle(IBaseRepository service) : base(service)
        {
            InitializeComponent();
            ConteneurFormulaire = this.formulaire;
            InitFormulaire();
        }

        /// <summary>
        /// Création des contrôle du formulaire à partire de son annotation
        /// </summary>
        private void InitFormulaire()
        {
            
            // La position Y
            int y = 35;
            int x_label = 16;
            int x_control = 200;
            // L'index de la touche Entrer
            int index = 0;
            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute) item.GetCustomAttribute(typeof(AffichageProprieteAttribute));


                //
                // label
                // 
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(x_label, y);
                lbl.Name = "label1";
                lbl.Size = new System.Drawing.Size(100, 13);
                lbl.TabIndex = index++;
                lbl.Text = AffichagePropriete.Titre;

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
                    if (AffichagePropriete.Relation == "ManyToOne")
                    {
                        Type ServicesEntityType = typeof(BaseRepository<>).MakeGenericType(item.PropertyType);
                        IBaseRepository ServicesEntity = (IBaseRepository) Activator.CreateInstance(ServicesEntityType);
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
