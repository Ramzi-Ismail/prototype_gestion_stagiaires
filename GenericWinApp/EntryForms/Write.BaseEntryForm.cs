using App.WinForm.Annotation;
using App.WinForm.Fileds;
using App.WinFrom.Fileds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{
    /// <summary>
    /// Lire 
    /// </summary>
    public partial class BaseEntryForm
    {
                            
        public virtual void WriteEntityToField()
        {
            this.WriteEntityToField(null);
        }
 
        /// <summary>
        /// Affiher l'objet dans le formulaire avec la valeurs initial de l'objet
        /// avec l'affichage  des valeurs initiaux de filtre
        /// </summary>
        public virtual void WriteEntityToField(Dictionary<string, object> CritereRechercheFiltre)
        {
            // début de la phase d'initialisation, pour ne pas lancer les evénement 
            // de changement des valeurs des contôle
            isStepInitializingValues = true;

            BaseEntity entity = this.Entity;
            Type typeEntity = this.Service.TypeEntity;

            foreach (PropertyInfo item in ListeChampsFormulaire())
            {
                AffichageProprieteAttribute AffichagePropriete = (AffichageProprieteAttribute)item.GetCustomAttribute(typeof(AffichageProprieteAttribute));
                Type typePropriete = item.PropertyType;
                string NomPropriete = item.Name;

                switch (typePropriete.Name)
                {
                    case "String":
                        {
                            string valeur = (string)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur = CritereRechercheFiltre[item.Name].ToString();
                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur;
                            }
                            else
                            {
                                TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                                txtBox.Text = valeur;
                            }
                        }
                        break;
                    case "Int32":
                        {
                            int valeur = (int)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur = Convert.ToInt32( CritereRechercheFiltre[item.Name]);

                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur;
                            }
                            else
                            {
                                TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                                txtBox.Text = valeur.ToString();
                            }

                        }
                        break;
                    case "DateTime":
                        {
                            DateTime valeur = (DateTime)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur = Convert.ToDateTime(CritereRechercheFiltre[item.Name]);


                            
                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur;
                            }
                            else
                            {
                                DateTimePicker dateTimePicker = (DateTimePicker)this.FindPersonelField(item.Name, "DateTimePicker");
                                dateTimePicker.Value = valeur;
                            }

                        }
                        break;
                    default:
                        if (AffichagePropriete.Relation == "ManyToOne")
                        {
                            BaseEntity valeur = (BaseEntity)typeEntity.GetProperty(NomPropriete).GetValue(entity);
                            if (valeur == null) continue;
                            Int64 valeur_id = valeur.Id;
                            // La valeur Iniale de filtre
                            if (CritereRechercheFiltre != null && CritereRechercheFiltre.ContainsKey(item.Name))
                                valeur_id = Convert.ToInt64(CritereRechercheFiltre[item.Name]);

                            if (this.AutoGenerateField)
                            {
                                BaseField baseField = this.FindGenerateField(item.Name);
                                baseField.Value = valeur_id;
                            }
                            else
                            {
                                ComboBox comboBox =(ComboBox) this.FindPersonelField(item.Name, "ComboBox");
                                comboBox.CreateControl();
                                if (valeur.Id != 0)
                                comboBox.SelectedValue = valeur.Id;
                            }
                        }
                        break;
                }
 
            }

            // Fin de la phase d'initialisaiton
            this.isStepInitializingValues = false;
        }
        private Control FindPersonelField(string name, String TypeControl)
        {
            String PossibiliteNomControle1 = char.ToLower(name[0]) + name.Substring(1) + TypeControl;
            Control[] recherche1 = this.ConteneurFormulaire.Controls.Find(PossibiliteNomControle1, true);
            if (recherche1.Count() > 0) return recherche1.First();
            throw new FieldNotExistInFormException();
        }
        /// <summary>
        /// Trouver un controle dans l'interface du formlaire 
        /// </summary>
        /// <param name="name">Le nom de la propriété</param>
        /// <param name="TypeControl">Le type de control qui est en relation avec le type de la propriété</param>
        /// <returns></returns>
        private BaseField FindGenerateField(string name)
        {
            Control[] recherche = this.ConteneurFormulaire.Controls.Find(name, true);
            if (recherche.Count() > 0) return (BaseField)recherche.First();
            throw new FieldNotExistInFormException();
        }




    }
}
