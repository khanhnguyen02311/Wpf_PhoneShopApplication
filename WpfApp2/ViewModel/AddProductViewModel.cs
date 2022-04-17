using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class AddProductViewModel:BaseViewModel
    {
        #region Properties
        private string _NameProduct;
        public string NameProduct { get => _NameProduct; set { _NameProduct = value; OnPropertyChanged(); } }
        private string _ImageProduct;
        public string ImageProduct { get => _ImageProduct; set { _ImageProduct = value; OnPropertyChanged(); } }
        private string _NameTypeProduct;
        public string NameTypeProduct { get => _NameTypeProduct; set { _NameTypeProduct = value; OnPropertyChanged(); } }

        private long _PriceProduct;
        public long PriceProduct { get => _PriceProduct; set { _PriceProduct = value; OnPropertyChanged(); } }

        private long _Capital;
        public long Capital { get => _Capital; set { _Capital = value; OnPropertyChanged(); } }
        private string _IdProduct;
        public string IdProduct { get => _IdProduct; set { _IdProduct = value; OnPropertyChanged(); } }
        private string _DescriptionProduct;
        public string DescriptionProduct { get => _DescriptionProduct; set { _DescriptionProduct = value; OnPropertyChanged(); } }
        private long _AmountProduct;
        public long AmountProduct { get => _AmountProduct; set { _AmountProduct = value; OnPropertyChanged(); } }
        private string dateText;
        public string DateText { get => dateText; set { dateText = value; OnPropertyChanged(); } }
        public ProductType _SelectedItem;
        public ProductType SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        
        private ObservableCollection<ProductType> listItem;
        public ObservableCollection<ProductType> ListItem { get => listItem; set { listItem = value; OnPropertyChanged(); } }
        private ObservableCollection<ProductType> listTypeItem;
        public ObservableCollection<ProductType> ListTypeItem { get => listTypeItem; set { listTypeItem = value; OnPropertyChanged(); } }
#endregion
        #region Các Command
        public ICommand LoadImageCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SaveNewProductCommand { get; set; }
        public ICommand OpenTypeProductCommand { set; get; }
        public ICommand SelectionCommand { set; get; }
        public ICommand LoadedCommand { set; get; }
        #endregion

        public AddProductViewModel()
        {
            NameProduct = "";
            PriceProduct = 0;
            IdProduct = "";
            NameTypeProduct = "";
            DescriptionProduct = "";
            ImageProduct = "/Resources/Images/Image.png";
            AmountProduct = 0;
            DateText = "";
            Capital = 0;
            RefreshCommand = new RelayCommand<AddProductPage>((p) => { return true; }, (p) => { Refresh(p); });
            SaveNewProductCommand = new RelayCommand<AddProductPage>((p) => { return true; }, (p) => { SaveData(p); });
            LoadImageCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { LoadImage(p); });
            
            OpenTypeProductCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { OpenTypeProduct(p); });
   
            LoadedCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
            ListTypeItem = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
               
            });
        } // Constructor

        private void OpenTypeProduct(Page p)
        {
            if (p != null)
            {
                p.NavigationService.Navigate(new TypeProductPage());
            }
        }  // Mở trang Loại SP
        private void Refresh(AddProductPage p)
        {
            NameProduct = "";
            PriceProduct = 0;
            IdProduct = "";
            ImageProduct = "/Resources/Images/Image.png";
            AmountProduct = 0;
            Capital = 0;
            p.DateInput.SelectedDate = null;
            SelectedItem = null;
        } // Làm mới
        private void SaveData(AddProductPage p)
        {
            if (string.IsNullOrEmpty(NameProduct)
                || string.IsNullOrEmpty(NameTypeProduct)
                || string.IsNullOrEmpty(IdProduct)
                ||string.IsNullOrEmpty(DateText)
                || ImageProduct == "/Resources/Images/Image.png"
                || AmountProduct <= 0
                ||  Capital <=0
                || PriceProduct <= 0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Vui lòng nhập đầy đủ các thông tin!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if(x.Ok==true)
                    return;
            }
            else if (DataProvider.Ins.DB.Products.Where(x => x.Id == IdProduct).Count() > 0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Mã sản phẩm đã trùng!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else
            {
                Dialog dialog = new Dialog();
                string mess = "Bạn muốn thêm sản phẩm này?";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                {
                    var typeproduct = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == SelectedItem.Id).First();
                    typeproduct.NumOfProduct += (int)AmountProduct;
                    DateTime dt = p.DateInput.SelectedDate.Value;
                    DescriptionProduct = string.IsNullOrEmpty(DescriptionProduct) ? null : DescriptionProduct;
                    DateText = dt.Year+"/"+dt.Month+"/"+dt.Day+ " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
                    var tempProduct = new Product()
                    {
                        Name = NameProduct,
                        Id = IdProduct,
                        Description = DescriptionProduct,
                        ImagePath = ImageProduct,
                        Date = DateTime.Parse(DateText),
                        CurrentAmount = (int)AmountProduct,
                        InitialAmount = (int)AmountProduct,
                        IdProductType = SelectedItem.Id,
                        Price = PriceProduct,
                        Capital = Capital
                    };

                    DataProvider.Ins.DB.Products.Add(tempProduct);
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

        } // Lưu SP

        private void LoadImage(Window p)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            if (true == openFileDialog.ShowDialog())
            {
                string filename = openFileDialog.FileName;
                try
                {
                    BitmapImage source = new BitmapImage(new Uri(filename));
                    ImageProduct = filename;
                }
                catch
                {
                    OkDialog dialog = new OkDialog();
                    string mess = "Định dạng ảnh không hợp lệ!";
                    var x = dialog.DataContext as DialogViewModel;
                    x.Announcement = mess;
                    dialog.ShowDialog();
                    if (x.Ok == true)
                        return;
                }
            }
        } // Tải ảnh từ PC
    }
}
