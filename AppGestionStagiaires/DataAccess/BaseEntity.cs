using System;

namespace Entites
{
   public abstract class BaseEntity
    {
        public Int64 Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateModification { get; set; }
    }
}
