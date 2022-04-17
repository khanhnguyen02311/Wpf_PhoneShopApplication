using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp2.Model;
using WpfApp2.View;
namespace WpfApp2.ViewModel
{
    public class AddEventVM : BaseViewModel
    {

        private DateTime _day;
        public DateTime day { get => _day; set { _day = value; OnPropertyChanged(); } }
        private DateTime _DayBegin;
        public DateTime DayBegin { get => _DayBegin; set { _DayBegin = value; OnPropertyChanged(); } }
        private DateTime _DayEnd;
        public DateTime DayEnd { get => _DayEnd; set { _DayEnd = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private int _Discount;
        public int Discount { get => _Discount; set { _Discount = value; OnPropertyChanged(); } }
        private string _ID;
        public string ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }

        private Event_sale _Cus;
        public Event_sale Cus { get => _Cus; set { _Cus = value; OnPropertyChanged(); } }


        private List<Event_sale> _ListEventSale;
        public List<Event_sale> ListEventSale { get => _ListEventSale; set { _ListEventSale = value; OnPropertyChanged(); } }

        private Event_sale _SelectedItem;
        public Event_sale SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        public ICommand SaveEvent { get; set; }
        public ICommand ResetEvent { get; set; }


        public AddEventVM()
        {
            DayEnd = DateTime.Today;
            DayBegin = DateTime.Today;
            ListEventSale = new List<Event_sale>(DataProvider.Ins.DB.Event_sale);
            ResetEvent = new RelayCommand<AddEventSale>((p) => { return true; }, (p) => { Reset(p); });
            SaveEvent = new RelayCommand<AddEventSale>((p) => { return true; }, (p) => { SaveData(p); });

        }

        private void Reset(AddEventSale p)
        {
            DayEnd = DateTime.Today;
            DayBegin = DateTime.Today;
            Name = "";
            ID = "";
            Discount = 0;
            SelectedItem = null;
        }
        private void SaveData(AddEventSale p)
        {
            if (DayBegin == null
                    || DayEnd == null || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(ID)

              )
            {
                OkDialog dialog = new OkDialog();
                string mess = "Vui lòng nhập đầy đủ các thông tin!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (Discount > 70)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Tỉ lệ giảm giá quá cao!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (Discount < 0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Giảm giá nhỏ hơn 0%";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (DataProvider.Ins.DB.Event_sale.Where(x => x.Id == ID).Count() > 0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Trùng mã sự kiện!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (DayBegin.Year < DateTime.Now.Year)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Thời gian không hợp lệ!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else
            {
                Dialog dialog = new Dialog();
                string mess = "Thêm sự kiện?";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                {

                    var temptypeproduct = new Event_sale();
                    temptypeproduct.Name = Name;
                    temptypeproduct.Id = ID;
                    temptypeproduct.Datebegin = DayBegin;

                    temptypeproduct.Datefinish = DayEnd;
                    temptypeproduct.Percent_sale = Discount;
                    DataProvider.Ins.DB.Event_sale.Add(temptypeproduct);


                    DataProvider.Ins.DB.SaveChanges();


                    Name = "";
                    ID = "";
                    DayBegin = DateTime.Now;
                    DayEnd = DateTime.Now;
                    ListEventSale = new List<Event_sale>(DataProvider.Ins.DB.Event_sale);
                    Dialog dialog1 = new Dialog();
                    string mess1 = "Lưu thành công!";
                    var x1 = dialog1.DataContext as DialogViewModel;
                    x1.Announcement = mess1;
                    dialog1.ShowDialog();
                    if (x1.Ok == true)
                        return;
                }
                else return;
            }
        }
    }
}
