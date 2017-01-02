using System;

namespace EFlib.Entites
{
   public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.DateCreation = DateTime.Now;
            this.DateModification = DateTime.Now;
        }

        public Int64 Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
    }
}
