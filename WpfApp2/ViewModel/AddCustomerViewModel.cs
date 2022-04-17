using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    class AddCustomerViewModel : BaseViewModel
    {

        private string _ID;
        public string ID { get => _ID; set { _ID = value; OnPropertyChanged(); } }
        private string _NameCustomer;
        public string NameCustomer { get => _NameCustomer; set { _NameCustomer = value; OnPropertyChanged(); } }
        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private string _Address;
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(); } }
        public ICommand SaveNewProductCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public AddCustomerViewModel()
        {
            NameCustomer = "";
            ID = "";
            Phone = "";
            Address = "";
            SaveNewProductCommand = new RelayCommand<AddCustomerPage>((p) => { return true; }, (p) => { SaveData(p); });
            RefreshCommand = new RelayCommand<AddCustomerPage>((p) => { return true; }, (p) => { Refresh(p); });
        }

        private void Refresh(AddCustomerPage p)
        {
            NameCustomer = "";
            ID = "";
            Phone = "";
            Address = "";
        }

        private void SaveData(AddCustomerPage p)
        {
            if (string.IsNullOrEmpty(NameCustomer)
                || string.IsNullOrEmpty(Phone)
                || string.IsNullOrEmpty(Address)
                    || string.IsNullOrEmpty(ID)
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
            else if (DataProvider.Ins.DB.Products.Where(x => x.Id == ID).Count() > 0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Mã khách hàng trùng!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }

            else
            {
                Dialog dialog = new Dialog();
                string mess = "Thêm khách hàng?";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                {

                    var temptypeproduct = new Customer();
                    temptypeproduct.Name = NameCustomer;
                    temptypeproduct.Id = ID;
                    temptypeproduct.Phone = Phone;
                    temptypeproduct.Address = Address;
                    DataProvider.Ins.DB.Customers.Add(temptypeproduct);

                    DataProvider.Ins.DB.SaveChanges();
                    Refresh(p);
                    OkDialog dialog1 = new OkDialog();
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