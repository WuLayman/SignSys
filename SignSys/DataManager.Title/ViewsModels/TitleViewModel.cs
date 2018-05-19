using Client.Infrastructure;
using DataManager.Title.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Title.ViewsModels
{
    public class TitleViewModel : ViewModelBase, ITitleViewModel
    {

        public ITitleView View
        { get; set; }


        private string _titleName;

        public string TitleName
        {
            get => _titleName;
            set { _titleName = value; RaisePropertyChanged(() => TitleName); }
        }

        public TitleViewModel()
        {
            _titleName = "签到系统";
        }
    }
}
