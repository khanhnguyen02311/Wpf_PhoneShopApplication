using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class BillOfProduct
    {
        private string nameCus;
        private DateTime date;
        private decimal money;

        public string NameCus { get => nameCus; set => nameCus = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Money { get => money; set => money = value; }

        public BillOfProduct()
        {

        }
    }
    public class DetailProductPageViewModel:BaseViewModel
    {
        private  Product item;
        private string imagePath;
        private string textPrice;
        private string textNameProduct;
        private string textIdProduct;
        private string textTypeProduct;
        private string textCapital;
        private string textDateInput;
        private string textDecription;
        private string textAmountProduct;
        private ObservableCollection<BillOfProduct> listBill;
        public  Product Item { get => item; set { item = value;OnPropertyChanged();  }}
        public string ImagePath { get => imagePath; set { imagePath = value; OnPropertyChanged(); } }
        public string TextPrice { get => textPrice; set { textPrice = value; OnPropertyChanged(); } }
        public string TextIdProduct { get => textIdProduct; set { textIdProduct = value; OnPropertyChanged(); } }
        public string TextTypeProduct { get => textTypeProduct; set { textTypeProduct = value; OnPropertyChanged(); } }
        public string TextCapital { get => textCapital; set { textCapital = value; OnPropertyChanged(); } }
        public string TextDateInput { get => textDateInput; set { textDateInput = value; OnPropertyChanged(); } }
        public string TextDecription { get => textDecription; set { textDecription = value; OnPropertyChanged(); } }
        public string TextAmountProduct { get => textAmountProduct; set { textAmountProduct = value; OnPropertyChanged(); } }
        public string TextNameProduct { get => textNameProduct; set { textNameProduct = value; OnPropertyChanged(); } }
        public ICommand LoadedCommand { set; get; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand AddBillCommand { get; set; }

        public ICommand RefreshCommand { get; set; }
        public ObservableCollection<BillOfProduct> ListBill { get => listBill; set { listBill = value; OnPropertyChanged(); } }

        public DetailProductPageViewModel(Product item = null)
        {
            Item = item;
            TextNameProduct = Item.Name;
            ImagePath = Item.ImagePath;
            TextPrice = Item.Price.ToString("N0");
            TextIdProduct = Item.Id;
            TextTypeProduct = Item.IdProductType;
            TextCapital = Item.Capital.ToString("N0");

            TextDateInput = Item.Date.ToString("dd/MM/yyyy hh:mm:ss tt");
            var TempDate = TextDateInput;
            TextDecription = Item.Description;
            TextAmountProduct = Item.CurrentAmount.ToString() + "/" + Item.InitialAmount.ToString();
            LoadListBill();
            LoadedCommand = new RelayCommand<Page>((p) => { return true; }, 
                (p) => { 
                    Loaded();
                });
            DeleteCommand  = new RelayCommand<Page>((p) => {
                if (Account.user.IdRole == 2)
                    return false;
                var typeproduct = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == TextTypeProduct).Count();
                if (typeproduct > 0)
                    return true;
                return false; 
            }, (p) => { Delete(p); });
            EditCommand = new RelayCommand<Page>((p) => {
                if (Account.user.IdRole == 2)
                    return false;
                if (TextNameProduct != Item.Name
              || ImagePath != Item.ImagePath
              || TextPrice != Item.Price.ToString("N0")
              || TextCapital != Item.Capital.ToString("N0")
              || TextDateInput!= TempDate
              || TextDecription != Item.Description
              || TextAmountProduct != Item.CurrentAmount.ToString() + "/" + Item.InitialAmount.ToString())
                    return true;
                return false;
            }, (p) => { Edit(); });
            AddBillCommand = new RelayCommand<Page>((p) => 
            { 
                if(Item == null)
                    return false;
                return true;
            }, 
                (p) => {
                    AddBill x = new AddBill();
                    var y = x.DataContext as AddBillViewModel;
                    y.Product = Item;
                    p.NavigationService.Navigate(x);
                });
            RefreshCommand = new RelayCommand<Page>((p) => { return true; }, (p) => {  Loaded(); });
        }

        private void LoadListBill()
        {
            ListBill = new ObservableCollection<BillOfProduct>();
            var ter = DataProvider.Ins.DB.Bills.Join(DataProvider.Ins.DB.Detail_Bill, x => x.Id, y => y.IdBill, (x, y) => new {x,y }).Where(x=>x.y.IdProduct==Item.Id);
            var temp = ter.Join(DataProvider.Ins.DB.Customers, x => x.x.IdCustomer, y => y.Id, (x, y) => new { x, y }).ToList();
            for(int i = 0; i < temp.Count; i++)
            {
                BillOfProduct x = new BillOfProduct()
                {
                    NameCus = temp[i].y.Name,
                    Date = temp[i].x.x.Date_output_bill,
                    Money = temp[i].x.y.Moneywillget,
                };
                ListBill.Add(x);
            }
            
        }

        private void Edit()
        {
            try
            {
                Product temp = DataProvider.Ins.DB.Products.Where(y => y.Id == TextIdProduct).First();
                var typeproduct = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == TextTypeProduct).First();
                temp.Name = TextNameProduct;
                temp.Date = DateTime.Parse(TextDateInput);
                temp.Price = decimal.Parse(TextPrice);
                temp.Description = TextDecription;
                temp.Capital = decimal.Parse(TextCapital);
                string[] arr = TextAmountProduct.Split('/');
                temp.CurrentAmount = int.Parse(arr[0]);
                typeproduct.NumOfProduct -= temp.InitialAmount;
                temp.InitialAmount = int.Parse(arr[1]);
                typeproduct.NumOfProduct += temp.InitialAmount;
                DataProvider.Ins.DB.SaveChanges();
                Item = temp;
                Loaded();
                OkDialog dialog = new OkDialog();
                string mess = "Sửa thành công!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            catch
            {
                OkDialog dialog = new OkDialog();
                string mess = "Dữ liệu sửa đổi không hợp lệ!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            } 


        }

        private void Delete(Page p)
        {
            Dialog dialog = new Dialog();
            string mess = "Bạn muốn xóa sản phẩm này?";
            var x = dialog.DataContext as DialogViewModel;
            x.Announcement = mess;
            dialog.ShowDialog();
            if (x.Ok == true)
            {
                try
                {
                    var typeproduct = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == TextTypeProduct).First();
                    typeproduct.NumOfProduct -= Item.InitialAmount;
                    Product temp = DataProvider.Ins.DB.Products.Where(y => y.Id == TextIdProduct).First();
                    DataProvider.Ins.DB.Products.Remove(temp);
                    DataProvider.Ins.DB.SaveChanges();
                    Item = new Product();
                    ImagePath = "/Resources/Images/Image.png";
                    TextNameProduct = TextPrice = TextIdProduct = TextTypeProduct = TextCapital = TextDateInput = TextDecription = TextAmountProduct = "";
                    OkDialog dialog1 = new OkDialog();
                    string mess1 = "Xóa thành công!";
                    var x1 = dialog1.DataContext as DialogViewModel;
                    x1.Announcement = mess1;
                    dialog1.ShowDialog();
                    if (x1.Ok == true)
                        return;
                   
                }
                catch
                {
                    
                }
               

            }
        }

        private void Loaded()
        {
            TextNameProduct = Item.Name;
            ImagePath = Item.ImagePath;
            TextPrice = Item.Price.ToString("N0");
            TextIdProduct = Item.Id;
            TextTypeProduct = Item.IdProductType;
            TextCapital = Item.Capital.ToString("N0");
            TextDateInput = Item.Date.ToString("dd/MM/yyyy hh:mm:ss tt");
            TextDecription = Item.Description;
            TextAmountProduct = Item.CurrentAmount.ToString() + "/" + Item.InitialAmount.ToString();
        }
    }
}
