using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Formations
{
    public class FeriesService : BaseRepository<Ferier>, IService
    {

        public FeriesService():base()
        {

        }
        public override void ValueChanged(object sender,BaseEntity entity)
        {
            Control control =(Control) sender;
            Ferier ferier = (Ferier)entity;

            switch (control.Name)
            {
                case "dateDebutDateTimePicker":
                    {
                            ferier.DateFin = ferier.DateDebut;
                    }
                    break;
                case "dateFinDateTimePicker":
                    {
                        if(ferier.DateFin < ferier.DateDebut)
                        {
                            ferier.DateFin = ferier.DateDebut;
                            MessageToUser.AddMessage(MessageToUser.Category.BusinessRule, 
                                "La date de fin ne peut pas être ingférieur de la date de début");

                        }

                    }
                    break;
                default: break;
            }
        }

    }
}
