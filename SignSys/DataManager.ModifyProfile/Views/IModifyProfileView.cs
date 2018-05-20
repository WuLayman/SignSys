using DataManager.ModifyProfile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.ModifyProfile.Views
{
    public interface IModifyProfileView
    {
        IModifyProfileViewModel ViewModel { get; set; }
    }
}
