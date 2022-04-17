using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class HistoryViewModel:BaseViewModel
    {
        private ObservableCollection<History> _ListHistory;
        public ObservableCollection<History> ListHistory { get => _ListHistory; set { _ListHistory = value; OnPropertyChanged(); } }
        public ICommand LoadCommand { get; set; }
        public HistoryViewModel()
        {
            ListHistory = new ObservableCollection<History>(DataProvider.Ins.DB.Histories);
            LoadCommand = new RelayCommand<HistoryPage>((p) => { return true; }, (p) => { Load(p); });
        }

        private void Load(HistoryPage p)
        {
            ListHistory = new ObservableCollection<History>(DataProvider.Ins.DB.Histories);
        }
    }
}
