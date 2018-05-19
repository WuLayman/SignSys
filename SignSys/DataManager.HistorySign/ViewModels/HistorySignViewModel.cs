﻿using Client.Infrastructure;
using PublicBaseClassProj;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.HistorySign.ViewModels
{
    public class HistorySignViewModel : NotifyPropertyChangedBase, IHistorySignViewModel
    {

        AllHistroySign _sign;
        ObservableCollection<AllHistroySign> _obAllSign;
        ObservableCollection<PersonSignInfo> _obHistorySign;
        public ObservableCollection<PersonSignInfo> ObHistorySign { get => _obHistorySign; set { _obHistorySign = value; OnPropertyChanged("ObHistorySign"); } }

        public ObservableCollection<AllHistroySign> ObAllSign { get => _obAllSign; set { _obAllSign = value; OnPropertyChanged("ObAllSign"); } }

        public AllHistroySign Sign { get => _sign; set { _sign = value; OnPropertyChanged("Sign"); } }

        public HistorySignViewModel()
        {
            //ObHistorySign = InterfaceClass.ClientInterface.ReceiveAllSignInfoFromServer();


            ObAllSign = new ObservableCollection<AllHistroySign>();
            foreach (var item in ObHistorySign)
            {
                DateTime dt = item.SignTime.Value;
                Sign = new AllHistroySign
                {
                    Data = dt.ToLongDateString(),
                    IsSign = item.IsSign,
                    ExactData = item.SignTime.ToString()
                };
                ObAllSign.Add(Sign);
            }
        }


    }


    public class AllHistroySign : NotifyPropertyChangedBase
    {

        string _data;
        bool _isSign;
        string _exactData;
        public string Data { get => _data; set { _data = value; OnPropertyChanged("ShortData"); } }
        public string ExactData { get => _exactData; set { _exactData = value; OnPropertyChanged("LongData"); } }
        public bool IsSign { get => _isSign; set { _isSign = value; OnPropertyChanged("IsSign"); } }

    }
}