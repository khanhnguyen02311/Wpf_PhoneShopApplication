using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class DataFromExcelViewModel : BaseViewModel
    {
        private string announcement;
        private bool ok;
        private ObservableCollection<Product> _ListFromExcel;
        public ObservableCollection<Product> ListFromExcel { get => _ListFromExcel; set { _ListFromExcel = value; OnPropertyChanged(); } }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public string Announcement { get => announcement; set { announcement = value; OnPropertyChanged(); } }
        public bool Ok { get => ok; set => ok = value; }

        public DataFromExcelViewModel()
        {
            Ok = false;

            MouseMoveWindowCommand = new RelayCommand<DataFromExcelWindow>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.DragMove();
                }
            });
            OkCommand = new RelayCommand<DataFromExcelWindow>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    Ok = true;
                    w.Close();
                }

            });
            CancelCommand = new RelayCommand<DataFromExcelWindow>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    Ok = false;
                    w.Close();
                }
            });
            FrameworkElement GetWindowParent(DataFromExcelWindow p)
            {
                FrameworkElement parent = p;
                while (parent.Parent != null)
                    parent = parent.Parent as FrameworkElement;
                return parent;
            }
        }
    }
}
