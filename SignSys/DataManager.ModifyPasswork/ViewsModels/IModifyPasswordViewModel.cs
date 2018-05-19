using Client.Infrastructure;
using DataManager.ModifyPasswork.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ModifyPasswork.ViewsModels
{
    public interface IModifyPasswordViewModel
    {
        IModifyPasswordView View { get; set; }

    }
}
