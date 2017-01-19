using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.WinForm
{

    public class MessageToUser
    {
        /// <summary>
        /// Catégoies des messages
        /// </summary>
        public enum Category { BusinessRule, Convert,
            ForeignKeViolation,
            EntityValidation
        } 
       

        static MessageToUser()
        {
            

        }

        public static void AddMessage(Category category, string msg)
        {
         
                
            switch (category)
            {
                case Category.BusinessRule:
                        MessageBox.Show(msg, "Règle de gestion");
                        break;
                case Category.Convert:
                        MessageBox.Show(msg, "Problème de convertion");
                        break;
                case Category.ForeignKeViolation:
                    if (msg == string.Empty) msg = "Vous ne pauvez pas effacer cette information car il est encours d'utilisation";
                    MessageBox.Show(msg, "Intégrité des données");
                        break;

                case Category.EntityValidation:
                    if (msg == string.Empty) msg = "Vous ne pauvez pas insérer cette information car il n'est pas valide";
                    MessageBox.Show(msg, "Valiation des données");
                    break;
                default:
                    break;
            }

            
        }

    }
}
