using DataManager.HistorySign.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.HistorySign.Views
{
    public interface IHistoryView
    {
        IHistorySignViewModel ViewModel { get; set; }
    }
}
