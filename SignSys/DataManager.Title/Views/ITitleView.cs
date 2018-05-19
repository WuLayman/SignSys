using Client.Infrastructure;
using DataManager.Title.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Title.Views
{
    public interface ITitleView
    {
        ITitleViewModel ViewModel { get; set; }
    }
}
