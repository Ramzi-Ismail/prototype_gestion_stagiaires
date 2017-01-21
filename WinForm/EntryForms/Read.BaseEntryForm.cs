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
    public partial class BaseEntryForm
    {
        /// <summary>
        /// Lire les informations du formulaire vers l'Entity
        /// </summary>
        protected virtual void ReadFormToEntity()
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
                    string value = "";
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        value = baseField.Value.ToString() ;
                    }
                    else
                    {
                        TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                        value = txtBox.Text;
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, value);
                }
                if (item.PropertyType.Name == "Int32")
                {
                    int Nombre = 0;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        Nombre = Convert.ToInt32(baseField.Value)  ;
                    }
                    else
                    {
                        TextBox txtBox = (TextBox)this.FindPersonelField(item.Name, "TextBox");
                        if (!int.TryParse(txtBox.Text, out Nombre))
                            MessageBox.Show("Impossible de lire un nombre :" + txtBox.Text);
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, Nombre);

                }
                if (typePropriete.Name == "DateTime")
                {
                    DateTime date = DateTime.MinValue;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        date = Convert.ToDateTime(baseField.Value);
                    }
                    else
                    {
                        DateTimePicker dateTimePicker = (DateTimePicker)this.FindPersonelField(item.Name, "TextBox");
                        date = dateTimePicker.Value;
                    }
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, date);
                }
                if (AffichagePropriete.Relation == "ManyToOne")
                {
                    Int64 id;
                    if (this.AutoGenerateField)
                    {
                        BaseField baseField = this.FindGenerateField(item.Name);
                        id =Convert.ToInt64( baseField.Value);
                    }
                    else
                    {
                        ComboBox comboBox = (ComboBox)this.FindPersonelField(item.Name, "ComboBox");
                        id = Convert.ToInt64(comboBox.SelectedValue);

                    }
                    Type ServicesEntityType = typeof(BaseRepository<>).MakeGenericType(item.PropertyType);
                    IBaseRepository ServicesEntity = (IBaseRepository)Activator.CreateInstance(ServicesEntityType, this.Service.Context());
                    BaseEntity ManyToOneEntity = ServicesEntity.GetBaseEntityByID(Convert.ToInt32(id));
                    typeEntity.GetProperty(NomPropriete).SetValue(entity, ManyToOneEntity);
                }
            }
        }
    }
}
