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
    public class TypeProductViewModel: BaseViewModel
    {
        private ObservableCollection<ProductType> _ListProductType;
        public ObservableCollection<ProductType> ListProductType { get => _ListProductType; set { _ListProductType = value; OnPropertyChanged(); } }
        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private string _Id;
        public string Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private string _Description;
        public string Description { get => _Description; set { _Description = value; OnPropertyChanged(); } }
        private int _NumOfProduct;
        public int NumOfProduct { get => _NumOfProduct; set { _NumOfProduct = value; OnPropertyChanged(); } }
        private DateTime _Date;
        public DateTime Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }

        private ProductType _SelectedItem;
        public ProductType SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    Name = SelectedItem.Name;
                    Id= SelectedItem.Id;
                    Description = SelectedItem.Description;   
                }
            }
        }
        private List<string> _ListArrange = new List<string>();
        public List<string> ListArrange { get => _ListArrange; set { _ListArrange = value; OnPropertyChanged(); } }

        private int _SelectedIndexCBX;
        public int SelectedIndexCBX { get => _SelectedIndexCBX; set { _SelectedIndexCBX = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand RefreshCommand { set; get; }
        public ICommand SelectionChangedCommand { get; set; }
        public TypeProductViewModel()
        {
            ListProductType = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
            ListArrange.Add("Ngày tăng dần");
            ListArrange.Add("Ngày giảm dần");
            ListArrange.Add("Số lượng sản phẩm tăng dần");
            ListArrange.Add("Số lượng sản phẩm giảm dần");
            SelectedIndexCBX = -1;

            AddCommand = new RelayCommand<object>((p) =>
            {
                var displayList = DataProvider.Ins.DB.ProductTypes.Where(x => x.Id == Id).Count();
                if (displayList > 0)
                    return false;
                return true;

            }, (p) =>
            {
                var item = new ProductType()
                {
                    Name = Name,
                    Id = Id,
                    Description = Description,
                    Date = DateTime.Now,
                    NumOfProduct = 0
                };

                DataProvider.Ins.DB.ProductTypes.Add(item);
                DataProvider.Ins.DB.SaveChanges();

                ListProductType.Add(item);
                Description = Name = Id = "";
                OkDialog dialog = new OkDialog();
                string mess = "Thêm thành công!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            });
            EditCommand = new RelayCommand<TypeProductPage>((p) =>
            {
                if (SelectedItem == null || Account.user.IdRole == 2)
                    return false;
                if (p != null)
                    p.editProductTypeId.IsReadOnly = true;

                var displayList = DataProvider.Ins.DB.ProductTypes.Where(x => x.Id == SelectedItem.Id);
                if (displayList != null && displayList.Count() != 0)
                    return true;

                return false;

            }, (p) =>
            {

                var item = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == SelectedItem.Id).SingleOrDefault();
                item.Name = Name;
                item.Description = Description;
                item.Date = DateTime.Now;
                DataProvider.Ins.DB.SaveChanges();               
                ListProductType = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
                OkDialog dialog = new OkDialog();
                string mess = "Sửa thành công!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;

            });

            DeleteCommand = new RelayCommand<TypeProductPage>((p) =>
             {
                 if (SelectedItem == null || Account.user.IdRole == 2)
                     return false;
                 if (p != null)
                     p.editProductTypeId.IsReadOnly = true;
                 return true;

             }, (p) =>
             {
                 Dialog dialog = new Dialog();
                 string mess = "Bạn muốn xóa loại SP này ?";
                 var x = dialog.DataContext as DialogViewModel;
                 x.Announcement = mess;
                 dialog.ShowDialog();
                 if (x.Ok == true)
                 {
                     try
                     {
                         int count = DataProvider.Ins.DB.Products.Where(y => y.IdProductType == SelectedItem.Id).Count();
                         while (count > 0)
                         {
                             var product = DataProvider.Ins.DB.Products.Where(y => y.IdProductType == SelectedItem.Id).First();
                             DataProvider.Ins.DB.Products.Remove(product);
                             count--;
                         }
                         var item = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == SelectedItem.Id).First();
                         DataProvider.Ins.DB.ProductTypes.Remove(item);
                         DataProvider.Ins.DB.SaveChanges();
                         ListProductType = new ObservableCollection<ProductType>(DataProvider.Ins.DB.ProductTypes);
                         Description = Name = Id = "";
                         OkDialog dialog1 = new OkDialog();
                         string mess1 = "Xóa thành công";
                         var x1 = dialog1.DataContext as DialogViewModel;
                         x1.Announcement = mess1;
                         dialog1.ShowDialog();
                         if (x1.Ok == true)
                             return;
                     }
                     catch
                     {
                         OkDialog dialog1 = new OkDialog();
                         string mess1 = "Không tồn tại dữ liệu cần xóa";
                         var x1 = dialog1.DataContext as DialogViewModel;
                         x1.Announcement = mess1;
                         dialog1.ShowDialog();
                         if (x1.Ok == true)
                             return;
                     }
                 }
             });
            SelectionChangedCommand = new RelayCommand<TypeProductPage>((p) =>
            {
                if (SelectedIndexCBX < 0)
                    return false;
                SelectedItem = null;
                Description = Name = Id = "";
                if (p != null)
                    p.editProductTypeId.IsReadOnly = false;
                return true;

            }, (p) =>
            {
                for (int i = 0; i < ListProductType.Count - 1; i++)
                {
                    for (int j = i; j < ListProductType.Count; j++)
                        if (Compare(ListProductType[i], ListProductType[j]))
                        {
                            ProductType temp = ListProductType[i];
                            ListProductType[i] = ListProductType[j];
                            ListProductType[j] = temp;
                        }
                }


            });

            RefreshCommand = new RelayCommand<TypeProductPage>((p) => { return true; }, (p) =>
            {
                SelectedItem = null;
                Description = Name = Id = "";
                if (p != null)
                    p.editProductTypeId.IsReadOnly = false;
            });
        }
        public bool Compare(ProductType a, ProductType b) // so sánh sp
        {
            switch (SelectedIndexCBX)
            {
                case 0:
                    if (a.Date == b.Date && a.Name.CompareTo(b.Name) > 0)
                        return true;
                    return a.Date > b.Date; // Tăng dần thời gian nhập kho
                case 1:
                    if (a.Date == b.Date && a.Name.CompareTo(b.Name) < 0)
                        return true;
                    return a.Date < b.Date; // Giảm dần thời gian nhập kho
                case 2: return a.NumOfProduct > b.NumOfProduct; // Tăng dần sp
                case 3: return a.NumOfProduct < b.NumOfProduct; // Giảm dần sp
           
                default:
                    return false;
            }
        }
    }
}
