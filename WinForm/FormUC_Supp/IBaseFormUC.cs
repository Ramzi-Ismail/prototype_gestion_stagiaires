using App.Gestion;
using App.WinFromLib.FormUC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.WinFromLib.FromsUC
{
    internal interface IBaseFormUC
    {
        // Creation d'une instance
          BaseFormUserControl CreateInstance(IBaseRepository service);
    }
}
