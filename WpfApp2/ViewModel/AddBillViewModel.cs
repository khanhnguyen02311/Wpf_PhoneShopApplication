using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp2.Model;
using WpfApp2.View;
namespace WpfApp2.ViewModel
{
    public class AddBillViewModel : BaseViewModel
    {
        private User _User;
        public User User { get => _User; set { _User = value; OnPropertyChanged(); } }
        private Customer _Cus;
        public Customer Cus { get => _Cus; set { _Cus = value; OnPropertyChanged(); } }

        private Event_sale _EventSale;
        public Event_sale EventSale { get => _EventSale; set { _EventSale = value; OnPropertyChanged(); } }
        private string _IdBill;



        private Product _Product;
        public Product Product { get => _Product; set { _Product = value; OnPropertyChanged(); } }

        public string IdBill { get => _IdBill; set { _IdBill = value; OnPropertyChanged(); } }
        private int _Count;
        public int Count { get => _Count; set { _Count = value; OnPropertyChanged(); } }


        private int _GiveAway;
        public int GiveAway { get => _GiveAway; set { _GiveAway = value; OnPropertyChanged(); } }


        private long _OriginalPrize;
        public long OriginalPrize { get => _OriginalPrize; set { _OriginalPrize = value; OnPropertyChanged(); } }

        private long _FinalPrize;
        public long FinalPrize { get => _FinalPrize; set { _FinalPrize = value; OnPropertyChanged(); } }

        private bool _Deliver;
        public bool Deliver { get => _Deliver; set { _Deliver = value; OnPropertyChanged(); } }

        private long _MoneyTaken;
        public long MoneyTaken { get => _MoneyTaken; set { _MoneyTaken = value; OnPropertyChanged(); } }

        private long _MoneyGiveBack;
        public long MoneyGiveBack { get => _MoneyGiveBack; set { _MoneyGiveBack = value; OnPropertyChanged(); } }

        private long _Deposit;
        public long Deposit { get => _Deposit; set { _Deposit = value; OnPropertyChanged(); } }

        private long _Ship;
        public long Ship { get => _Ship; set { _Ship = value; OnPropertyChanged(); } }
        private long _Sum;
        public long Sum { get => _Sum; set { _Sum = value; OnPropertyChanged(); } }
        public ICommand SaveBillCommand { get; set; }
        public ICommand AddEventSalePageCommand { get; set; }
        public ICommand AddCustomerCommand { get; set; }


        private List<Event_sale> _ListEventSale;
        public List<Event_sale> ListEventSale { get => _ListEventSale; set { _ListEventSale = value; OnPropertyChanged(); } }
        private List<User> _ListUserRole;
        public List<User> ListUserRole { get => _ListUserRole; set { _ListUserRole = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _ListCustomer;
        public ObservableCollection<Customer> ListCustomer
        {
            get => _ListCustomer; set
            {
                _ListCustomer = value;
                OnPropertyChanged();
            }
        }

        private List<Product> _ListProDuct;
        public List<Product> ListProDuct { get => _ListProDuct; set { _ListProDuct = value; OnPropertyChanged(); } }



        public ICommand ShipOptionCommand { get; set; }
        public ICommand CusChoosenCommand { get; set; }
        public ICommand ProductChoosenCommand { get; set; }
        public ICommand EventSaleChoosenCommand { get; set; }
        public ICommand CountsChoosenCommand { get; set; }
        public ICommand DecreaCountCommand { get; set; }
        public ICommand IncreaCountCommand { get; set; }
        public ICommand DepositChoosenCommand { get; set; }
        public ICommand ShipChoosenCommand { get; set; }
        public ICommand ResetCommand { get; set; }

        public ICommand LoadCommand { get; set; }
        public ICommand PaymentChoosenCommand { get; set; }
        public ICommand InShopOptionCommand { get; set; }
        public ICommand AddSeeBillCommand { get; set; }
        public AddBillViewModel()
        {
            Sum = 0;

            Count = 0;
            Ship = 0;
            Deposit = 0;
            GiveAway = 0;
            MoneyGiveBack = 0;
            MoneyTaken = 0;
            FinalPrize = 0;
            OriginalPrize = 0;
            ResetCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { reset(p); });
            DecreaCountCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { increa(p); });
            IncreaCountCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { decrea(p); });
            ListEventSale = ListEventSale = new List<Event_sale>(DataProvider.Ins.DB.Event_sale.Where(x => (x.Datebegin < DateTime.Now) && (x.Datefinish > DateTime.Now)));
            ListCustomer = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            ListProDuct = new List<Product>(DataProvider.Ins.DB.Products);
            ListUserRole = new List<User>(DataProvider.Ins.DB.Users);
            DepositChoosenCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { DepositChanged(p); });
            AddCustomerCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { OpenAddCustomer(p); });
            ShipChoosenCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { ShipChoosen(p); });
            AddSeeBillCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { OpenSeeBill(p); });
            SaveBillCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { SaveData(p); });
            AddEventSalePageCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { openeventsale(p); });
            ShipOptionCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { ShipOption(p); });
            InShopOptionCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { InShopOption(p); });

            ProductChoosenCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { ProductChoosen(p); });
            EventSaleChoosenCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { EventSaleChoosen(p); });
            PaymentChoosenCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { PaymentChoosen(p); });
            CountsChoosenCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { CountsChoosen(p); });
            LoadCommand = new RelayCommand<AddBill>((p) => { return true; }, (p) => { Load(p); });


        }
        private void increa(AddBill p)
        {
            Count++;
            CountsChoosen(p);
        }
        private void decrea(AddBill p)
        {
            if (Count >= 1)
            {
                Count--;
                CountsChoosen(p);
            }
        }
        private void Load(AddBill p)
        {
            ListEventSale = ListEventSale = new List<Event_sale>(DataProvider.Ins.DB.Event_sale.Where(x => (x.Datebegin < DateTime.Now) && (x.Datefinish > DateTime.Now)));
            ListCustomer = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            ListProDuct = new List<Product>(DataProvider.Ins.DB.Products);

        }
        private string ConvertLongToMoney(long money)
        {
            if (money == 0)
            { return "0 vnđ"; }
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return money.ToString("#,###", cul.NumberFormat) + "vnd";


        }
        private void reset(AddBill p)
        {
            p.eventsalechoosen.SelectedItem = null;
            p.productchoosen.SelectedItem = null;

            p.cuschoosen.SelectedItem = null;



            Sum = 0;
            Count = 0;
            Ship = 0;
            Deposit = 0;
            GiveAway = 0;
            MoneyGiveBack = 0;
            MoneyTaken = 0;
            FinalPrize = 0;
            OriginalPrize = 0;

        }
        private void CountsChoosen(AddBill p)
        {
            if (Regex.IsMatch(p.Count.Text, @"^\d+$"))
            {
                Count = int.Parse(p.Count.Text);
            }

            if (EventSale != null)
            {
                FinalPrize = (OriginalPrize * Count) * (100 - EventSale.Percent_sale) / 100;
            }
            else
            {
                FinalPrize = OriginalPrize * Count;
            }
            if (p.MoneyTK.Text != "" && Regex.IsMatch(p.MoneyTK.Text, @"^\d+$"))
            {
                MoneyTaken = Int64.Parse(p.MoneyTK.Text);
                MoneyGiveBack = MoneyTaken - FinalPrize;


            }
            Sum = Ship + FinalPrize - Deposit;

            p.OriginalPrize.Text = ConvertLongToMoney(OriginalPrize * Count);
            p.MoneyGB.Text = ConvertLongToMoney(MoneyGiveBack);
            p.FinalPrize.Text = ConvertLongToMoney(FinalPrize);
            p.MoneyGB.Text = ConvertLongToMoney(MoneyGiveBack);
            p.Sum.Text = ConvertLongToMoney(Sum);
        }


        private void PaymentChoosen(AddBill p)
        {

            if (p.MoneyTK.Text != "" && Regex.IsMatch(p.MoneyTK.Text, @"^\d+$"))
            {
                MoneyTaken = Int64.Parse(p.MoneyTK.Text);
                MoneyGiveBack = MoneyTaken - FinalPrize;
                p.MoneyGB.Text = ConvertLongToMoney(MoneyGiveBack);
            }
            Sum = Ship + FinalPrize - Deposit;
            p.Sum.Text = ConvertLongToMoney(Sum);

        }


        private void DepositChanged(AddBill p)
        {

            if (p.Deposit.Text != "" && Regex.IsMatch(p.Deposit.Text, @"^\d+$"))
            {
                Deposit = Int64.Parse(p.Deposit.Text);
                Sum = Ship + FinalPrize - Deposit;
                p.Sum.Text = ConvertLongToMoney(Sum);
            }


        }
        private void ShipChoosen(AddBill p)
        {

            if (p.Ship.Text != "" && Regex.IsMatch(p.Ship.Text, @"^\d+$"))
            {
                Ship = Int64.Parse(p.Ship.Text);
                Sum = Ship + FinalPrize - Deposit;
                p.Sum.Text = ConvertLongToMoney(Sum);
            }
        }

        private void EventSaleChoosen(AddBill p)
        {


            if (EventSale != null)
            {
                FinalPrize = (OriginalPrize * Count) * (100 - EventSale.Percent_sale) / 100;
            }
            MoneyGiveBack = MoneyTaken - FinalPrize;

            Sum = Ship + FinalPrize - Deposit;
            p.OriginalPrize.Text = ConvertLongToMoney(OriginalPrize * Count);
            p.MoneyGB.Text = ConvertLongToMoney(MoneyGiveBack);
            p.FinalPrize.Text = ConvertLongToMoney(FinalPrize);
            p.MoneyGB.Text = ConvertLongToMoney(MoneyGiveBack);
            p.Sum.Text = ConvertLongToMoney(Sum);


        }
        private void ProductChoosen(AddBill p)
        {
            Product newProduct = new Product();
            newProduct = p.productchoosen.SelectedItem as Product;


            if (newProduct != null)
            {
                OriginalPrize = decimal.ToInt32(newProduct.Price);

            }
            if (EventSale != null)
            {
                FinalPrize = (OriginalPrize * Count) * (100 - EventSale.Percent_sale) / 100;
            }
            else
            {
                FinalPrize = OriginalPrize * Count;
            }
            MoneyGiveBack = MoneyTaken - FinalPrize;

            Sum = Ship + FinalPrize - Deposit;

            p.OriginalPrize.Text = ConvertLongToMoney(OriginalPrize * Count);
            p.MoneyGB.Text = ConvertLongToMoney(MoneyGiveBack);
            p.FinalPrize.Text = ConvertLongToMoney(FinalPrize);
            p.MoneyGB.Text = ConvertLongToMoney(MoneyGiveBack);
            p.Sum.Text = ConvertLongToMoney(Sum);

        }

        private void ShipOption(AddBill p)
        {
            p.MoneyGB.IsEnabled = false;
            p.MoneyTK.IsEnabled = false;
            p.Deposit.IsEnabled = true;
            p.Ship.IsEnabled = true;
            p.Sum.IsEnabled = false;
            p.Address.IsEnabled = true;
            MoneyTaken = 0;
            MoneyGiveBack = 0;
            Deliver = true;

        }
        private void InShopOption(AddBill p)
        {
            Deliver = false;
            p.MoneyGB.IsEnabled = false;
            p.MoneyTK.IsEnabled = true;
            p.Deposit.IsEnabled = false;
            p.Ship.IsEnabled = false;
            p.Sum.IsEnabled = false;
            p.Address.IsEnabled = false;
            Ship = 0;
            Deposit = 0;


        }

        private void OpenSeeBill(AddBill p)
        {
            p.NavigationService.Navigate(new ListBillDetail());
        }
        private void OpenAddCustomer(AddBill p)
        {
            p.NavigationService.Navigate(new AddCustomerPage());
        }
        private void openeventsale(AddBill p)
        {
            p.NavigationService.Navigate(new AddEventSale());
        }

        private void SaveData(AddBill p)
        {
            if (Cus == null)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Bạn chưa chọn khách hàng!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if(x.Ok==true)
                    return;
            }
            if (Count < 1)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Đơn hàng phải có ít nhất 1 sản phẩm!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (Product == null)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Bạn chưa chọn sản phẩm!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }

            else if (User == null)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Bạn chưa chọn người thực hiện!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (MoneyTaken < Sum && MoneyTaken != 0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Số tiền không hợp lệ!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (p.inship.IsChecked == false && p.inshop.IsChecked == false)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Bạn chưa chọn phương thức thanh toán!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (Product.CurrentAmount < Count + GiveAway)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Sản phẩm này đã hết hàng hoặc không đủ!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }

            else
            {
                Dialog dialog = new Dialog();
                string mess = "Bạn muốn thêm đơn hàng?";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                {
                    int newid = 0;
                    var temp = new Detail_Bill();
                    var tempbill = new Bill();
                    List<Detail_Bill> l = new List<Detail_Bill>(DataProvider.Ins.DB.Detail_Bill);

                    if (l.Count != 0)
                    {
                        foreach (Detail_Bill akanaka in l)
                        {
                            newid = Math.Max(newid, int.Parse(akanaka.IdBill));
                        }

                        newid += 1;

                    }
                    else newid = 1;

                    tempbill.Id = newid.ToString();
                    tempbill.IdUsers = User.Id;
                    tempbill.IdCustomer = Cus.Id;
                    tempbill.Date_output_bill = DateTime.Now;
                    if (Deliver)
                    {
                        tempbill.Status = "Đang giao hàng";
                    }
                    else
                    {
                        tempbill.Status = "Đã hoàn thành";
                        var tempproducttype = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == Product.IdProductType).SingleOrDefault();
                        tempproducttype.NumOfProduct = tempproducttype.NumOfProduct - (Count + GiveAway);
                        var tempproduct = DataProvider.Ins.DB.Products.Where(y => y.Id == Product.Id).SingleOrDefault();
                        tempproduct.CurrentAmount = tempproduct.CurrentAmount - Count - GiveAway;
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    DataProvider.Ins.DB.Bills.Add(tempbill);
                    temp.IdBill = newid.ToString();
                    if (EventSale != null)
                    {
                        temp.Id_Event_sale = EventSale.Id;
                    }
                    else temp.Id_Event_sale = null;
                    temp.IdProduct = Product.Id;
                    temp.OriginPrice = OriginalPrize * Count;
                    temp.FinalPrice = FinalPrize;
                    temp.MoneyTaken = MoneyTaken;
                    temp.MoneyExchange = MoneyGiveBack;
                    temp.Amount_Buy = Count;
                    temp.Amount_Given = GiveAway;
                    temp.Ship = Ship;
                    temp.Moneywillget = Sum;
                    temp.Deposit = Deposit;
                    DataProvider.Ins.DB.Detail_Bill.Add(temp);
                    DataProvider.Ins.DB.SaveChanges();
                    reset(p);
                    OkDialog dialog1 = new OkDialog();
                    string mess1 = "Thêm thành công!";
                    var x1 = dialog1.DataContext as DialogViewModel;
                    x1.Announcement = mess1;
                    dialog1.ShowDialog();
                    if (x1.Ok == true)
                        return;
                }
                return;
            }
        }
    }
}