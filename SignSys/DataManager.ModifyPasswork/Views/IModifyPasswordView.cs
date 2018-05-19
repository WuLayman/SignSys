using Client.Infrastructure;
using DataManager.ModifyPasswork.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ModifyPasswork.Views
{
    public interface IModifyPasswordView
    {
        IModifyPasswordViewModel ViewModel { get; set; }
    }
}
