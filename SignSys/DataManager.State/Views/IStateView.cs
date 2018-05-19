using DataManager.State.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.State.Views
{
    public interface IStateView
    {
        IStateViewModel ViewModel { get; set; }
    }
}
