using App.Formations;
using App.WinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.GestionFormations
{
   public class SeancesService : BaseRepository<Seance>, IService
    {
        public SeancesService():base()
        {
        }

        public SeancesService(ModelContext context) : base(context)
        {
        }

        public override void ValueChanged(object sender, BaseEntity entity)
        {
            Control control = (Control)sender;
            Seance seance = (Seance)entity;

            switch (control.Name)
            {
                case "contenuPrecision":
                    {
                       
                        
                    }
                    break;
                case "dateFinDateTimePicker":
                    {
                        

                    }
                    break;
                default: break;
            }
        }

        public override int Save(Seance item)
        {
            // Calcule de l'ordre dans le cas d'insertoin
            if (item.Ordre == 0)
            {
                int ordre = this.DbSet.Where(p => p.Formation.Id == item.Formation.Id).Count();
                item.Ordre = ++ordre;
            }
            return base.Save(item);
        }
    }
}
