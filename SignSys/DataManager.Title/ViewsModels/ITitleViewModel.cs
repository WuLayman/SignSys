using Client.Infrastructure;
using DataManager.Title.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Title.ViewsModels
{
    public interface ITitleViewModel
    {
        ITitleView View { get; set; }
    }
}
