using DataManager.Title.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Title
{
    public interface IToolBarView
    {
        IToolbarViewModel ViewModel { get; set; }
    }
}
