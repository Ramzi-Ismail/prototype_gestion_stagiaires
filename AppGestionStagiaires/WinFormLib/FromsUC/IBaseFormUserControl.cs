
namespace App.WinFromLib.FormUC
{
    internal interface IBaseFormUserControl
    {
        void Afficher();
        void Lire();
        BaseFormUserControl CreateInstance(IBaseRepository service);
        BaseEntity CreateObjetInstance();
    }
}