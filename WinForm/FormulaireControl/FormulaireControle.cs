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

namespace App.WinForm
{
    public partial class FormulaireControle : BaseFormulaire
    {
        public FormulaireControle():base()
        {
            InitializeComponent();
        }
        public FormulaireControle(IBaseRepository service) : base(service)
        {
            InitializeComponent();
            CreationFormulaire();
          
        }

        private void CreationFormulaire()
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
                 
                  
                    // label
                    Label lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.Location = new System.Drawing.Point(x_label, y);
                    lbl.Name = "label1";
                    lbl.Size = new System.Drawing.Size(100, 13);
                    lbl.TabIndex = index++;
                    lbl.Text = AffichagePropriete.Titre;
                    if (item.PropertyType.Name == "String")
                    {
                        // textBox1
                        TextBox txt = new TextBox();
                        txt.Location = new System.Drawing.Point(x_control, y-3);
                        txt.Name = item.Name;
                        
                        txt.TabIndex = index++;
                        if (AffichagePropriete.MultiLine)
                        {
                            txt.Multiline = true;
                            txt.Size = new System.Drawing.Size(400, 100);
                            y += 80;
                    }
                        else
                        {
                            txt.Size = new System.Drawing.Size(200, 20);
                        }
                       
                    this.formulaire.Controls.Add(txt);
                    }
                if (item.PropertyType.Name == "Int32")
                {
                    // textBox1
                    TextBox txt = new TextBox();
                    txt.Location = new System.Drawing.Point(x_control, y - 3);
                    txt.Name = item.Name;
                    txt.Size = new System.Drawing.Size(200, 20);
                    txt.TabIndex = index++;

                    this.formulaire.Controls.Add(txt);
                }
                if (item.PropertyType.Name == "DateTime")
                    {
                        DateTimePicker dateTimePocker = new DateTimePicker();
                        dateTimePocker.Location = new System.Drawing.Point(x_control, y - 3);
                        dateTimePocker.Name = item.Name;
                        dateTimePocker.Size = new System.Drawing.Size(200, 20);
                        dateTimePocker.TabIndex = index++;
                        this.formulaire.Controls.Add(dateTimePocker);
                    }
                    if (AffichagePropriete.Relation == "ManyToOne")
                    {
                        Type ServicesEntityType = typeof(BaseRepository<>).MakeGenericType(item.PropertyType);
                        IBaseRepository ServicesEntity = (IBaseRepository) Activator.CreateInstance(ServicesEntityType);

                        List<object> ls = ServicesEntity.GetAllDetached();

                        ComboBox comboBox = new ComboBox();
                        comboBox.Location = new System.Drawing.Point(x_control, y - 3);
                        comboBox.Name = item.Name;
                        comboBox.Size = new System.Drawing.Size(200, 20);
                        comboBox.TabIndex = index++;
                        comboBox.ValueMember = "Id";
                        comboBox.DisplayMember = AffichagePropriete.DisplayMember;
                        comboBox.DataSource = ls;
                        this.formulaire.Controls.Add(comboBox);

                    }

                    this.formulaire.Controls.Add(lbl);
               
                y += 25;

            }
        }


        protected  override void Lire()
        {
            BaseEntity entity = this.Entity;
            Type typeEntity = this.Service.TypeEntity;

            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));

              

                    Type typePropriete = item.PropertyType;
                    string NomPropriete = item.Name;
             
                    if (typePropriete.Name == "String")
                    {
                        TextBox txtBox = (TextBox)this.formulaire.Controls.Find(NomPropriete, true).First();
                        typeEntity.GetProperty(NomPropriete).SetValue(entity, txtBox.Text);
                    }
                    if (item.PropertyType.Name == "Int32")
                    {
                        TextBox txtBox = (TextBox)this.formulaire.Controls.Find(NomPropriete, true).First();
                        int Nombre;
                        if (int.TryParse(txtBox.Text, out Nombre))
                            typeEntity.GetProperty(NomPropriete).SetValue(entity, Nombre);
                        else
                            MessageBox.Show("Impossible de lire un nombre");

                    }
                    if (typePropriete.Name == "DateTime")
                    {
                        DateTimePicker dateTimePicker = (DateTimePicker)this.formulaire.Controls.Find(NomPropriete, true).First();
                        typeEntity.GetProperty(NomPropriete).SetValue(entity, dateTimePicker.Value);
                    }
                    if (AffichagePropriete.Relation == "ManyToOne")
                    {
                        ComboBox comboBox = (ComboBox)this.formulaire.Controls.Find(NomPropriete, true).First();

                        Type ServicesEntityType = typeof(BaseRepository<>).MakeGenericType(item.PropertyType);
                        IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityType,this.Service.Context());
                        BaseEntity  ManyToOneEntity = ServicesEntity.GetBaseEntityByID(Convert.ToInt32(comboBox.SelectedValue));
                       

                        typeEntity.GetProperty(NomPropriete).SetValue(entity, ManyToOneEntity);
                    }
                }

          

        }
        public override void Afficher()
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
                    if (typePropriete.Name == "String")
                    {
                        string valeur = (string)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                        TextBox txtBox = (TextBox)this.formulaire.Controls.Find(NomPropriete, true).First();
                        txtBox.Text = valeur;
                    }
                    if (typePropriete.Name == "DateTime")
                    {
                        DateTime valeur = (DateTime)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                        DateTimePicker dateTimePicker = (DateTimePicker)this.formulaire.Controls.Find(NomPropriete, true).First();
                        dateTimePicker.Value = valeur;
                    }
                    if (AffichagePropriete.Relation == "ManyToOne")
                    {
                        BaseEntity valeur = (BaseEntity)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                        ComboBox comboBox = (ComboBox)this.formulaire.Controls.Find(NomPropriete, true).First();
                        if(valeur != null)
                        comboBox.SelectedValue = valeur.Id;
 
                    }
                

            }
        }

        /// <summary>
        /// Obient la liste des Propriété à utliser dans la formulaire
        /// </summary>
        /// <returns></returns>
        private List<PropertyInfo> ListeChampsFormulaire()
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
