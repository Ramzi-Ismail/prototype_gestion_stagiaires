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
                default: break;
            }
        }

    }
}
