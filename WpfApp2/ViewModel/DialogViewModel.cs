using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class DialogViewModel : BaseViewModel
    {
        private Dialog dialog;
        private string announcement;
        private bool ok;
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public string Announcement { get => announcement; set { announcement = value; OnPropertyChanged(); } }
        public Dialog Dialog { get => dialog; set => dialog = value; }
        public bool Ok { get => ok; set => ok = value; }

        public DialogViewModel()
        {
            Ok = false;
            MouseMoveWindowCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    w.DragMove();
                }
            });
            OkCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
              {
                  FrameworkElement window = GetWindowParent(p);
                  var w = window as Window;
                  if (w != null) 
                  {
                      Ok = true;
                      w.Close();
                  }

              });
            CancelCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                FrameworkElement window = GetWindowParent(p);
                var w = window as Window;
                if (w != null)
                {
                    Ok = false;
                    w.Close();
                }
            });
            FrameworkElement GetWindowParent(Window p)
            {
                FrameworkElement parent = p;
                while (parent.Parent != null)
                    parent = parent.Parent as FrameworkElement;
                return parent;
            }
        }
    }
}
