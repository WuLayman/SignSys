using DataManager.ChangeBackgroundColor.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ChangeBackgroundColor.Views
{
    public interface IChangedBackgroundColorView
    {
        IChangedBackgroundColorViewModel ViewModel { get; set; }
    }
}
