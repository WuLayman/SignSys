using DataManager.Title.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Title.Views
{
    public interface IHomePageView
    {
        IHomePageViewModel ViewModel { get; set; }
    }
}
