
namespace App.GestionFormations
{
    public class FormateursService : BaseRepository<Formateur>
    {
        public FormateursService(ModelContext context) : base(context)
        {
        }
    }
}