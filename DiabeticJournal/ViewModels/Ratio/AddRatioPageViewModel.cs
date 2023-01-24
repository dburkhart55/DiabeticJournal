using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticJournal.ViewModels.Ratio
{

    public class AddRatioPageViewModel : BaseViewModel
    {
        Database db;

        public AddRatioPageViewModel(Database database)
        {
            db = database;
            Title = "Add Carb Ratio";
            
        }
    }
}
