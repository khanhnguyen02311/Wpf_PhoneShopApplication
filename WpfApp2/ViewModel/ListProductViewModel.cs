using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Aspose.Cells;
using WpfApp2.Model;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class ListProductViewModel : BaseViewModel
    {
        #region Proprerties
        private string textSearchProduct;
        private ObservableCollection<Product> _ListProduct;
        private List<string> arrangePrice;
        private List<string> listPage;
        private int selectedItem;
        private int numPages;
        private List<ObservableCollection<Product>> listTempProduct;
        private string textPriceFrom;
        private string textPriceTo;
        private ObservableCollection<Product> Products_after_search;

        public string TextSearchProduct { get => textSearchProduct; set { textSearchProduct = value; OnPropertyChanged(); } }
        public ObservableCollection<Product> ListProduct { get => _ListProduct; set { _ListProduct = value; OnPropertyChanged(); } }
        public List<string> ArrangePrice { get => arrangePrice; set => arrangePrice = value; }
        public List<string> ListPage { get => listPage; set { listPage = value; OnPropertyChanged(); } }
        public int SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(); } }
        public int NumPages { get => numPages; set { numPages = value; OnPropertyChanged(); } }
        private int selectedItemProduct;
        public int SelectedItemProduct { get => selectedItemProduct; set { selectedItemProduct = value; OnPropertyChanged(); } }
        public List<ObservableCollection<Product>> ListTempProduct { get => listTempProduct; set { listTempProduct = value; OnPropertyChanged(); } }
        public string TextPriceFrom { get => textPriceFrom; set {textPriceFrom = value; OnPropertyChanged(); } }
        public string TextPriceTo { get => textPriceTo; set { textPriceTo = value; OnPropertyChanged(); } }

        #endregion
        #region Các Command
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand SelectionPageCommand { get; set; }
        public ICommand NextPageCommmand { get; set; }
        public ICommand PreviousPageCommmand { get; set; }
        public ICommand AddProductCommand { get; set; }
        public ICommand LoadWindowCommand { get; set; }
        public ICommand SearchProductCommand { get; set; }
        public ICommand FindPriceCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SelectProductCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand ImportCommand { get; set; }

        #endregion

        public ListProductViewModel()
        {
            ArrangePrice = new List<string>();
            ListPage = new List<string>();
            SelectedItem = 0;
            SelectedItemProduct = 0;
            TextPriceTo = TextPriceFrom = "";
            ListProduct = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);
            LoadListPage(ListProduct);
            ListTempProduct = LoadListProduct_Page(new ObservableCollection<Product>(DataProvider.Ins.DB.Products));
            Products_after_search = ListProductAfterSearch();
            LoadWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { LoadWindow(p); });
            AddProductCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { OpenAddProductPage(p); });
            SearchProductCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { SearchProduct(Products_after_search); });
            LoadArrangePrice();
            SelectionChangedCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) => { SelectionChanged(Products_after_search); });
            SelectionPageCommand = new RelayCommand<ComboBox>((p) => { return true; }, (p) => { SelectionPage(Products_after_search); });
            NextPageCommmand = new RelayCommand<ListProductPage>((p) => {
                if (NumPages + 1 < listPage.Count)
                    return true;
                return false;
            
            }, (p) => { NextPage(p); });
            PreviousPageCommmand = new RelayCommand<ListProductPage>((p) => {
                if (NumPages + 1 > 1)
                    return true;
                return false;

            }, (p) => { PreviousPage(p); });
            FindPriceCommand = new RelayCommand<Button>((p) => { return true; }, (p) => { FindPrice(Products_after_search); });
            RefreshCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { Refresh(new ObservableCollection<Product>(DataProvider.Ins.DB.Products)); });
            SelectProductCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { SelectProduct(p); });
            ExportCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { ExportToExcel(p); });
            ImportCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { ImportFromExcel(p); });
        }

        private void ImportFromExcel(Page p)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.DefaultExt = ".xlsx";
            openFileDialog.Filter = "Excel Workbook (.xlsx)|*.xlsx";



            if (false == openFileDialog.ShowDialog()) return;
            string filename = openFileDialog.FileName;

            Workbook workbook = new Workbook(filename);
            Worksheet worksheet = workbook.Worksheets[0];
            ObservableCollection<Product> listproducts = new ObservableCollection<Product>();
            if (worksheet.Name.Equals("Product"))
            {
                
                int i = 2;
                while (worksheet.Cells[$"B{i}"].Value != null)
                {
                    if (DataProvider.Ins.DB.Products.Find(worksheet.Cells[$"B{i}"].Value.ToString()) != null)
                    {
                        i++;
                        continue;
                    }

                    if (DataProvider.Ins.DB.ProductTypes.Find(worksheet.Cells[$"H{i}"].Value.ToString()) == null)
                    {
                        i++;
                        continue;
                    }
                    if (worksheet.Cells[$"A{i}"].Value == null
                           || worksheet.Cells[$"C{i}"].Value == null
                           || worksheet.Cells[$"D{i}"].Value == null
                           || worksheet.Cells[$"E{i}"].Value == null
                           || worksheet.Cells[$"F{i}"].Value == null
                           || worksheet.Cells[$"H{i}"].Value == null
                           || worksheet.Cells[$"I{i}"].Value == null
                           || worksheet.Cells[$"J{i}"].Value == null
                           )
                    {
                        i++;
                        continue;
                    }

                    string date = worksheet.Cells[$"C{i}"].Value.ToString();
                    DateTime dateTime = new DateTime();
                    try
                    {
                        dateTime = DateTime.Parse(date);
                    }
                    catch (Exception ex)
                    {
                        i++;
                        continue;
                    }
                    string path = worksheet.Cells[$"I{i}"].Value.ToString();
                    if (!path.Contains(".jpg") && !path.Contains(".png") && !path.Contains(".webp"))
                    {
                        i++;
                        continue;
                    }

                    try
                    {
                        Product product = new Product()
                        {
                            Name = worksheet.Cells[$"A{i}"].Value.ToString(),
                            Id = worksheet.Cells[$"B{i}"].Value.ToString(),
                            Date = dateTime,
                            Price = long.Parse(worksheet.Cells[$"D{i}"].Value.ToString()),
                            InitialAmount = int.Parse(worksheet.Cells[$"E{i}"].Value.ToString()),
                            CurrentAmount = int.Parse(worksheet.Cells[$"F{i}"].Value.ToString()),
                            Description = worksheet.Cells[$"G{i}"].Value == null ? null : worksheet.Cells[$"G{i}"].Value.ToString(),
                            IdProductType = worksheet.Cells[$"H{i}"].Value.ToString(),
                            ImagePath = worksheet.Cells[$"I{i}"].Value.ToString(),
                            Capital = long.Parse(worksheet.Cells[$"J{i}"].Value.ToString()),
                        };
                        listproducts.Add(product);
                    }
                    catch (Exception) { }
                    i++;
                    continue;
                }
                if (listproducts.Count() > 0)
                {
                    DataFromExcelWindow data = new DataFromExcelWindow();
                    string anouncement = "Bạn muốn thêm dữ liệu này vào?";
                    var x = data.DataContext as DataFromExcelViewModel;
                    x.Announcement = anouncement;
                    x.ListFromExcel = listproducts;
                    data.ShowDialog();
                    if (x.Ok == true)
                    {
                        foreach (var product in listproducts)
                        {
                            var typeproduct = DataProvider.Ins.DB.ProductTypes.Where(k => k.Id == product.IdProductType).First();
                            typeproduct.NumOfProduct += product.InitialAmount;
                            DataProvider.Ins.DB.Products.Add(product);
                        }
                        DataProvider.Ins.DB.SaveChanges();
                        Refresh(new ObservableCollection<Product>(DataProvider.Ins.DB.Products));
                        OkDialog dialog = new OkDialog();
                        string mess = "Thêm thành công!";
                        var y = dialog.DataContext as DialogViewModel;
                        y.Announcement = mess;
                        dialog.ShowDialog();
                        if (y.Ok == true)
                            return;
                    }
                }
                else
                {
                    OkDialog dialog = new OkDialog();
                    string mess = "Dữ liệu đã tồn tại hoặc lỗi!";
                    var x = dialog.DataContext as DialogViewModel;
                    x.Announcement = mess;
                    dialog.ShowDialog();
                    if (x.Ok == true)
                        return;
                }
                
            }
        }

        private void ExportToExcel(Page p)
        {
            Dialog dialog = new Dialog();
            string mess = "Xuất dữ liệu ra Excel?";
            var x = dialog.DataContext as DialogViewModel;
            x.Announcement = mess;
            dialog.ShowDialog();
            if (x.Ok == true)
            {
                // Mở hộp thoại lưu tập tin
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.DefaultExt = ".xlsx";
                saveFileDialog.Filter = "Excel Workbook (.xlsx)|*.xlsx";

                if (false == saveFileDialog.ShowDialog()) return;
                string filename = saveFileDialog.FileName;

                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                worksheet.Name = "Product";

                worksheet.Cells["A1"].PutValue("TÊN SẢN PHẨM");
                worksheet.Cells["B1"].PutValue("MÃ SẢN PHẨM");
                worksheet.Cells["C1"].PutValue("NGÀY NHẬP");
                worksheet.Cells["D1"].PutValue("GIÁ BÁN");
                worksheet.Cells["E1"].PutValue("TỒN KHO BAN ĐẦU");
                worksheet.Cells["F1"].PutValue("TỒN KHO HIỆN TẠI");
                worksheet.Cells["G1"].PutValue("MÔ TẢ");
                worksheet.Cells["H1"].PutValue("MÃ LOẠI SẢN PHẨM");
                worksheet.Cells["I1"].PutValue("ẢNH SẢN PHẨM");
                worksheet.Cells["J1"].PutValue("VỐN BỎ RA");
                var tempProduct = new ObservableCollection<Product>(DataProvider.Ins.DB.Products);
                for (int i = 0; i < tempProduct.Count(); i++)
                {
                    worksheet.Cells[$"A{i + 2}"].PutValue(tempProduct[i].Name);
                    worksheet.Cells[$"B{i + 2}"].PutValue(tempProduct[i].Id);
                    worksheet.Cells[$"C{i + 2}"].PutValue(tempProduct[i].Date.ToString("dd-MM-yyyy hh:mm:ss tt"));
                    worksheet.Cells[$"D{i + 2}"].PutValue(tempProduct[i].Price.ToString("N0"));
                    worksheet.Cells[$"E{i + 2}"].PutValue(tempProduct[i].InitialAmount);
                    worksheet.Cells[$"F{i + 2}"].PutValue(tempProduct[i].CurrentAmount);
                    worksheet.Cells[$"G{i + 2}"].PutValue(tempProduct[i].Description);
                    worksheet.Cells[$"H{i + 2}"].PutValue(tempProduct[i].IdProductType);
                    worksheet.Cells[$"I{i + 2}"].PutValue(tempProduct[i].ImagePath);
                    worksheet.Cells[$"J{i + 2}"].PutValue(tempProduct[i].Capital.ToString("N0"));
                }

                worksheet.AutoFitColumns();
                workbook.Save(filename);
                OkDialog dialog1 = new OkDialog();
                string mess1 = "Lưu thành công!";
                var x1 = dialog1.DataContext as DialogViewModel;
                x1.Announcement = mess1;
                dialog1.ShowDialog();
                if (x1.Ok == true)
                    return;
            }
        }

        private void SelectProduct(Page p)
        {
            try
            {
                var item = ListProduct[SelectedItemProduct];
                if (item != null)
                {
                    var x = new DetailProductPage(item);
                    var y = x.DataContext as DetailProductPageViewModel;
                    y.Item = item;
                    p.NavigationService.Navigate(x);     
                }
            }
            catch
            {

            }
            
        }

        private void Refresh(ObservableCollection<Product> list) //Làm mới danh sách
        {
            SelectedItem = 0;
            TextSearchProduct=TextPriceTo = TextPriceFrom = "";
            SelectionChanged(list);
        }

        private void FindPrice(ObservableCollection<Product> List) // Tìm theo giá (Button Find)
        {
            if (string.IsNullOrEmpty(TextPriceTo) || string.IsNullOrEmpty(TextPriceFrom))
                return;
            decimal priceMin = 0;
            decimal priceMax = 0;
            decimal.TryParse(textPriceFrom, out priceMin);
            decimal.TryParse(textPriceTo, out priceMax);
            ObservableCollection<Product> list = new ObservableCollection<Product>(List);
            list = new ObservableCollection<Product>(list.
                            Where(x => x.Price >= priceMin && x.Price <= priceMax));
            SelectionChanged(list);

            
        }

        private void PreviousPage(ListProductPage p) // Trang ds sản phẩm trước
        {
            ListProduct = ListTempProduct[--NumPages];
            
        }

        private void NextPage(ListProductPage p) // Trang ds sản phẩm sau
        {
            ListProduct = ListTempProduct[++NumPages];
        }

        private void LoadArrangePrice() //Set Item cho combobox 
        {
            ArrangePrice.Add("Nhập kho lâu nhất");
            ArrangePrice.Add("Nhập kho gần đây nhất");
            ArrangePrice.Add("Giá tăng dần");
            ArrangePrice.Add("Giá giảm dần");
            ArrangePrice.Add("Tồn kho nhiều nhất");
            ArrangePrice.Add("Tồn kho ít nhất");
            ArrangePrice.Add("Bán chạy nhất");
            ArrangePrice.Add("Bán ế nhất");
            SelectionChanged(new ObservableCollection<Product>(DataProvider.Ins.DB.Products));
        }

        private void LoadListPage(ObservableCollection<Product> list) // lấy danh sách các trang sp
        {
            NumPages = -1;
            ListPage.Clear();
            int num = (int)Math.Ceiling(list.Count / 12.0);
            for (int i = 1; i <= num; i++)
            {
                ListPage.Add(i + "/" + num);
            }
            NumPages = 0;
        }
        private List<ObservableCollection<Product>> LoadListProduct_Page(ObservableCollection<Product> list) // hàm trả về ds sp theo từng trang
        {
            int temp = 0;
            List<ObservableCollection<Product>> Listtemp = new List<ObservableCollection<Product>>();
            
            while (temp + 1 < ListPage.Count)
            {
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                for (int i = 12 * temp; i < 12 * (temp + 1); i++)
                    products.Add(list[i]);
                Listtemp.Add(products);
                temp++;
            }
            ObservableCollection<Product> products1 = new ObservableCollection<Product>();
            for (int i = 12 * temp; i < list.Count; i++)
                products1.Add(list[i]);
            Listtemp.Add(products1);
            return Listtemp;
        }
        private void SelectionPage(ObservableCollection<Product> list)//Chọn trang 
        {
            try
            {
                ListTempProduct = LoadListProduct_Page(ListArranged(list));
                ListProduct = ListTempProduct[NumPages];
            }
            catch
            {
                
            }


        }
        private ObservableCollection<Product> ListArranged(ObservableCollection<Product> list) // sx ds sp
        {
            ListProduct = list;
            for (int i = 0; i < ListProduct.Count - 1; i++)
            {
                for (int j = i; j < ListProduct.Count; j++)
                    if (Compare(ListProduct[i], ListProduct[j]))
                    {
                        Product temp = ListProduct[i];
                        ListProduct[i] = ListProduct[j];
                        ListProduct[j] = temp;
                    }
            }
            return ListProduct;
        }
        private void SelectionChanged(ObservableCollection<Product> list)//Mỗi lần chọn cách sx -> load lại trang
        {
            if (list.Count > 0)
            {

                LoadListPage(ListArranged(list));
                ListTempProduct = LoadListProduct_Page(ListArranged(list));
                ListProduct = ListTempProduct[NumPages];
                Products_after_search = ListProductAfterSearch();

            }
            else
            {
                OkDialog dialog = new OkDialog();
                string mess = "Không tồn tại sản phẩm!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            TextSearchProduct = TextPriceFrom = TextPriceTo = "";

        }
        public bool Compare(Product a, Product b) // so sánh sp
        {
            switch (SelectedItem)
            {
                case 0:
                    if (a.Date == b.Date && a.Name.CompareTo(b.Name)>0)
                        return true;
                    return a.Date >b.Date ; // Tăng dần thời gian nhập kho
                case 1:
                    if (a.Date == b.Date && a.Name.CompareTo(b.Name) < 0)
                        return true;
                    return a.Date < b.Date; // Giảm dần thời gian nhập kho
                case 2: return a.Price > b.Price; // Tăng dần giá cả
                case 3: return a.Price < b.Price; // Giảm dần giá cả
                case 4: return a.CurrentAmount < b.CurrentAmount; // Tăng dần số lượng tồn kho
                case 5: return a.CurrentAmount > b.CurrentAmount; // Giảm dần số lượng tồn kho
                case 6: return (a.InitialAmount - a.CurrentAmount) < (b.InitialAmount - b.CurrentAmount); // Tăng dần bán chạy nhất
                case 7: return (a.InitialAmount - a.CurrentAmount) > (b.InitialAmount - b.CurrentAmount); // Giảm dần bán ế nhất
                default:
                    return false;
            }
        }
        private ObservableCollection<Product> ListProductAfterSearch() //hàm trả về ds sản phẩm sau khi search
        {
            try
            {
                int n = 0;
                ObservableCollection<Product> products = new ObservableCollection<Product>();
                while (n < ListPage.Count)
                {
                    foreach (var i in ListTempProduct[n])
                    {
                        if (i.Name.Contains(textSearchProduct))
                            products.Add(i);
                    }
                    n++;
                }
                return products;
            }
            catch
            {
                return new ObservableCollection<Product>(DataProvider.Ins.DB.Products);
            }
        }
        private void SearchProduct(ObservableCollection<Product> list)// sự kiện tìm kiếm sp
        {
            
            Products_after_search = ListProductAfterSearch();
            SelectionChanged(Products_after_search);
        }

        private void OpenAddProductPage(Page p) // điều hướng qua trang mới
        {
            p.NavigationService.Navigate(new AddProductPage());
        }

        private void LoadWindow(Window p)// load lại ListProductPage mỗi khi đc gọi
        {
            Refresh(new ObservableCollection<Product>(DataProvider.Ins.DB.Products));
        }
    }
}
