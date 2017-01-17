using App.Modules;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace App.AutoFormation
{
    internal class DynamiqueLinq
    {
        public DynamiqueLinq()
        {
            //RechercheParId();
            RechercheGeniric("Filiere", 1);
        }


        public void RechercheGeniric(String NomObjetEnRelation, Int64 valeur)
        {

            BaseRepository<Module> context = new BaseRepository<Module>();

            ParameterExpression m = Expression.Parameter(typeof(Module), "m");
            MemberExpression m_filiere = Expression.PropertyOrField(m, "Filiere");
            MemberExpression m_filiere_id = Expression.PropertyOrField(m_filiere, "Id");


            ConstantExpression id = Expression.Constant(valeur, typeof(Int64));



            BinaryExpression EqualId = Expression.Equal(m_filiere_id, id);
            var lambda1 =
                Expression.Lambda<Func<Module, bool>>(
                    EqualId,
                    new ParameterExpression[] { m });


            List<Module> ls = context.GetAll(0, 0, lambda1);
        }

        public void RechercheIdFiliere()
        {

            String NomObjetEnRelation = "Filiere";
            Int64 valeur = 1;

            BaseRepository<Module> context = new BaseRepository<Module>();


            ParameterExpression m = Expression.Parameter(typeof(Module), "m");
            MemberExpression m_filiere = Expression.PropertyOrField(m, "Filiere");
            MemberExpression m_filiere_id = Expression.PropertyOrField(m_filiere, "Id");

           
            ConstantExpression id = Expression.Constant(valeur, typeof(Int64));



            BinaryExpression EqualId = Expression.Equal(m_filiere_id, id);
            var lambda1 =
                Expression.Lambda<Func<Module, bool>>(
                    EqualId,
                    new ParameterExpression[] { m });


            List<Module> ls = context.GetAll(0, 0, lambda1);
        }

        public void RechercheParId()
        {
            BaseRepository<Module> context = new BaseRepository<Module>();


            ParameterExpression m = Expression.Parameter(typeof(Module), "m");
            MemberExpression m_id = Expression.PropertyOrField(m, "Id");

            Int64 valeur = 100;
            ConstantExpression id = Expression.Constant(valeur, typeof(Int64));



            BinaryExpression MLessTehnId = Expression.LessThan(m_id, id);
            var lambda1 =
                Expression.Lambda<Func<Module, bool>>(
                    MLessTehnId,
                    new ParameterExpression[] { m });


            List<Module> ls = context.GetAll(0, 0, lambda1);
        }
    }
}