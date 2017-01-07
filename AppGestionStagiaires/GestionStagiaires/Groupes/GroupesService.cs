using App.Entites;
using EFlib;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.GestionGroupes
{
    public class GroupesService : BaseRepository<Groupe>
    {
        public override int Save(Groupe g)
        {

            //this.Context.Entry(g.Filiere).State = System.Data.Entity.EntityState.Unchanged;
            
            return base.Save(g);


        }

        protected override int Update(Groupe item)
        {
            this.Context.Entry(item).State = EntityState.Modified;
            string state_filiere = this.Context.Entry(item.Filiere).State.ToString();


            this.Context.Filieres.Attach(item.Filiere);
             state_filiere = this.Context.Entry(item.Filiere).State.ToString();

            return this.Context.SaveChanges();
        }
    }
}
