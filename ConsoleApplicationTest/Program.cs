using App.Modules;
using LinqExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.GestionStagiaires;
using System.Data.Entity;

namespace App.AutoFormation
{
    class Program
    {
        static void Main(string[] args)
        {

           


            //new DynamiqueLinq();
            // new RechercheModuleParFiliere();
            var sets = from p in typeof(ModelContext).GetProperties() where p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) let entityType = p.PropertyType.GetGenericArguments().First() select p.Name;



        }
    }
}
