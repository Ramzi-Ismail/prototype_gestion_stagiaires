using App.WinForm.Annotation;
using App.WinForm.EntityManagement;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm.Fileds
{
    /// <summary>
    /// Filtrer du champs ManyToOne
    /// Ce filtre est ajouter avant le champs dans le même conteneur, 
    /// </summary>
    public partial class ManyToOneField
    {
        #region Variables


        /// <summary>
        /// Filtre
        /// </summary>
        public Control MainContainner { set; get; }
       
        #endregion

        #region Les critère de filtrage
        /// <summary>
        /// Lite des ComboBox 
        /// </summary>
        Dictionary<string, ManyToOneField> ListeComboBox = new Dictionary<string, ManyToOneField>();

        /// <summary>
        /// Lite des Valeur de critère Initial de comboBox
        /// </summary>
        Dictionary<string, BaseEntity> ListeValeursCritere = new Dictionary<string, BaseEntity>();

        /// <summary>
        /// Liste des Types de critère 
        /// </summary>
        Dictionary<string, Type> LsiteTypeObjetCritere = new Dictionary<string, Type>();

        #endregion

        #region Degault Value
        /// <summary>
        /// Trouver les valeurs par défaut de chaque critère de filtre, 
        /// depuis l'objet qui déclare la collection
        /// </summary> 
        protected void CalculatesDefaultValues()
        {
            //if (MetaSelectionCriteria == null) return;
            //foreach (Type item in MetaSelectionCriteria.Criteria)
            //{
            //    // Trouver si la classe de critère de filtre existe déja comme Membre 
            //    // de la classe qui déclare la collection
            //    Type DeclaringType = PropertyInfoOfCollection.DeclaringType;
            //    PropertyInfo PropertyInfo_value = DeclaringType.GetProperties().Where(p => p.PropertyType.Name == item.Name).SingleOrDefault();
            //    if (PropertyInfo_value != null && Entity != null)
            //    {
            //        BaseEntity BaseEntityValue = (BaseEntity)PropertyInfo_value.GetValue(Entity);
            //        if (BaseEntityValue != null)
            //        {
            //            ListeValeursCritere[item.Name] = BaseEntityValue;

            //            // si la critère a une valeur par défaut
            //            // on cherche les valeurs par défaut des critère précédent 
            //            int index = MetaSelectionCriteria.Criteria.ToList().IndexOf(item);
            //            ValeurParen(index, BaseEntityValue);

            //        }



            //    }
            //}
        }
        #endregion


        #region InitInterface
        /// <summary>
        /// Affichage du filtre dans l'interface
        /// Remplissage de ListeComboBox
        /// </summary>
        private void InitAndLoadData()
        {

           
            this.DisplayMember = "";
            this.ValueMember = "Id";
            

            if (this.propertyInfo != null)
            {

                // DisplayMember de combobox actuel
                // Annotation : Affichage de l'objet
                AffichageClasseAttribute MetaAffichageClasse = (AffichageClasseAttribute)this.propertyInfo.PropertyType
                    .GetCustomAttribute(typeof(AffichageClasseAttribute));


                this.DisplayMember = MetaAffichageClasse.DisplayMember;
                this.Text_Label = MetaAffichageClasse.Minuscule;

                Attribute getAffichagePropriete = propertyInfo.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)getAffichagePropriete;
                if (AffichagePropriete.FilterSelection)
                {
                    #region Annotatin
                    // Annotation : Critère de filtre
                    SelectionCriteriaAttribute MetaSelectionCriteria =
                        (SelectionCriteriaAttribute)this.propertyInfo.PropertyType
                        .GetCustomAttribute(typeof(SelectionCriteriaAttribute));



                  
                    #endregion


                    int index = 10;

                    // Si un objet du critère de selection exite dans la classe 
                    // Nous cherchons sa valeur pour l'utiliser
                    foreach (Type item in MetaSelectionCriteria.Criteria)
                    {
                        // Meta information d'affichage du de Critère
                        AffichageClasseAttribute MetaAffichageClasseCritere = (AffichageClasseAttribute)item.GetCustomAttribute(typeof(AffichageClasseAttribute));


                        ManyToOneField manyToOneFilter = new ManyToOneField(item, null, null,this.HeightField,this.orientationFiled);
                        manyToOneFilter.Name = item.Name;


                        manyToOneFilter.Size = new System.Drawing.Size(this.widthField, this.HeightField);


                        manyToOneFilter.TabIndex = ++index;
                        manyToOneFilter.Text_Label = item.Name;
                        manyToOneFilter.BackColor = System.Drawing.Color.Beige;


                        manyToOneFilter.ValueMember = "Id";
                        manyToOneFilter.DisplayMember = MetaAffichageClasseCritere.DisplayMember;
                        manyToOneFilter.FieldChanged += Value_SelectedIndexChanged;



                      
                        

                        manyToOneFilter.Visible = true;

                        // [bug] Le contôle ne s'affiche pas dans le formilaire ??
                        //Form f = new Form();
                        //f.Controls.Add(manyToOneFilter);
                        //f.Show();

                        this.MainContainner.Controls.Add(manyToOneFilter);
                        
                        ListeComboBox.Add(item.Name, manyToOneFilter);
                        LsiteTypeObjetCritere.Add(item.Name, item);
                    }




                }

                // Insertion du ComBox Actuel pour qu'il sera remplit par les données
                ListeComboBox.Add(this.propertyInfo.PropertyType.Name, this);
                LsiteTypeObjetCritere.Add(this.propertyInfo.PropertyType.Name, this.propertyInfo.PropertyType);

            }
            else
            {
                // Cas des sous ComBobox de filtre

                // Insertion du ComBox Actuel pour qu'il sera remplit par les données
                ListeComboBox.Add(this.TypeOfObject.Name, this);
                LsiteTypeObjetCritere.Add(this.TypeOfObject.Name, this.TypeOfObject);
               
            }
            this.FieldChanged += Value_SelectedIndexChanged;
            ViewingData();


        }


        /// <summary>
        /// SelectedIndexChanged qui Actualise de tous les comboBoxs déscendantes
        /// </summary>
        private void Value_SelectedIndexChanged(object sender, EventArgs e)
        {
            // à chaque changement d'un combo on charge les donnée de comboBox suivant
            ManyToOneField comboBox = (ManyToOneField)sender;
            comboBox.CreateControl();
            int index_comboBox = ListeComboBox.Values.ToList<ManyToOneField>().IndexOf(comboBox);

            // Le Service de l'objet de ComboBox
            string key = ListeComboBox.Keys.ElementAt(index_comboBox);
            IBaseRepository service = new BaseRepository<BaseEntity>()
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);

            // Actualisation de ComboBox suivant s'il existe, et le comboBox actual a une valeur
            if (comboBox.SelectedValue != null && (ListeComboBox.Values.Count() - 1) >= (index_comboBox + 1))
            {
                //
                // Actualisation de combobBox suivant
                //
                ManyToOneField comboBox_suivant = ListeComboBox.Values.ElementAt(index_comboBox + 1);
                string key_suivant = ListeComboBox.Keys.ElementAt(index_comboBox + 1);

                BaseEntity EntityPere = service.GetBaseEntityByID(Convert.ToInt64(comboBox.SelectedValue));
                PropertyInfo PropertyChild = EntityPere.GetType()
                                                .GetProperties()
                                                .Where(p => p.Name == key_suivant + "s")

                                                .SingleOrDefault();
                IList ls_source = null;
                if (PropertyChild != null)
                {
                    ls_source = PropertyChild.GetValue(EntityPere) as IList;
                    comboBox_suivant.DataSource = ls_source;
                }
                // Si ce Combo n'a pas d'information 
                // alors vider les combBobx suivant 
                if (ls_source == null || ls_source.Count == 0)
                    for (int i = (index_comboBox + 1); i < ListeComboBox.Values.Count(); i++)
                    {
                        ManyToOneField comboBox_suivant2 = ListeComboBox.Values.ElementAt(i);
                        comboBox_suivant2.DataSource = null;
                        comboBox_suivant2.TextCombobox = "";
                    }
            }
        }
        #endregion

        #region Affichage des données dans les comboBox
        /// <summary>
        /// Affichage des données dans les ComboBox
        /// </summary>
        protected void ViewingData()
        {
            // Affichage des données du premiere comboBox
            // les autres comboBox sont afficher par l'événement ValueChange du ComboBox
            if (ListeComboBox.Values.Count() <= 0) return;
            ManyToOneField comboBox = ListeComboBox.Values.ElementAt(0);
            string key = ListeComboBox.Keys.ElementAt(0);
            IBaseRepository service = new BaseRepository<BaseEntity>()
                .CreateInstance_Of_Service_From_TypeEntity(LsiteTypeObjetCritere[key]);
            comboBox.DataSource = service.GetAll();
        }
        #endregion

    }
}
