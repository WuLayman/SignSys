using Client.Infrastructure;
using DataManager.Land.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Land.Views
{
    public interface ILandView
    {
        ILandViewModel ViewModel { get; set; }
    }
}
