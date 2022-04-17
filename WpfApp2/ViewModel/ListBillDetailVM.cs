using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Words.NET;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApp2.Model;
using WpfApp2.View;
using Xceed.Document.NET;
using System.Diagnostics;
using Aspose.Cells;


namespace WpfApp2.ViewModel
{
    class ListBillDetailVM : BaseViewModel
    {
        private DateTime _Day;
        public DateTime Day { get => _Day; set { _Day = value; OnPropertyChanged(); } }
        private string _IdBill;
        public string IdBill { get => _IdBill; set { _IdBill = value; OnPropertyChanged(); } }
        private long _Sum;
        public long Sum { get => _Sum; set { _Sum = value; OnPropertyChanged(); } }
        private string _IdProDuct;
        public string IdProDuct { get => _IdProDuct; set { _IdProDuct = value; OnPropertyChanged(); } }

        private string _IdCustomer;
        public string IdCustomer { get => _IdCustomer; set { _IdCustomer = value; OnPropertyChanged(); } }

        private Customer _tempCus;
        public Customer tempCus { get => _tempCus; set { _tempCus = value; OnPropertyChanged(); } }

        private Product _tempProduct;
        public Product tempProduct { get => _tempProduct; set { _tempProduct = value; OnPropertyChanged(); } }
        private Detail_Bill _tempDetailBill;
        public Detail_Bill tempDetailBill { get => _tempDetailBill; set { _tempDetailBill = value; OnPropertyChanged(); } }
        private Bill _tempBild;
        public Bill tempBild { get => _tempBild; set { _tempBild = value; OnPropertyChanged(); } }
        private ObservableCollection<Customer> _ListCustomer;
        public ObservableCollection<Customer> ListCustomer
        {
            get => _ListCustomer; set
            {
                _ListCustomer = value;
                OnPropertyChanged();
            }
        }
        private Detail_Bill _BillDetail;
        public Detail_Bill BillDetail
        {
            get => _BillDetail; set
            {
                _BillDetail = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Bill> _ListBill;
        public ObservableCollection<Bill> ListBill { get => _ListBill; set { _ListBill = value; OnPropertyChanged(); } }
        private Bill _SelectedItem;
        public Bill SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        public ICommand DeleteChecked { get; set; }
        public ICommand BillChecked { get; set; }


        public ICommand ExportExcelCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand back { get; set; }
        public ICommand LoadWindowCommand { get; set; }
        public ICommand SeeProductCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DaySort { get; set; }
        public ICommand ListChangeCommand { get; set; }
        public ICommand ExportCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ListBillDetailVM()
        {
            Day = DateTime.Now;

            ExportCommand = new RelayCommand<ListBillDetail>((p) => {
                if (ListBill == null || ListBill.Count <= 0 || SelectedItem == null)
                    return false;
                return true;
            }, (p) => { export(p); });
            ExportExcelCommand = new RelayCommand<ListBillDetail>((p) => {
                if (ListBill == null || ListBill.Count <= 0)
                    return false;
                return true;
            }, (p) => { ExportToExcel(p); });
            DaySort = new RelayCommand<ListBillDetail>((p) => { return true; }, (p) => { DayedView(p); });
            ListChangeCommand = new RelayCommand<ListBillDetail>((p) => { return true; }, (p) => { ChangeListView(p); });
            LoadWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { LoadWindow(p); });
            ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills); ;
            CancelCommand = new RelayCommand<ListBillDetail>((p) => {
                if (SelectedItem == null)
                    return false;
                if (SelectedItem.Status == "Đang giao hàng")
                    return true;
                return false;
            }, (p) => { CancelBill(p); });
            DeleteChecked = new RelayCommand<ListBillDetail>((p) => {
                if (Account.user.IdRole == 2)
                    return false;
                if (SelectedItem == null)
                    return false;
                if (SelectedItem.Status != "Đang giao hàng")
                    return true;
                return false;
            }, (p) => { DeteteBill(p); });
            SelectionChangedCommand = new RelayCommand<ListBillDetail>((p) => { return true; }, (p) => { SelectionChanged(p); });
            BillChecked = new RelayCommand<ListBillDetail>((p) => {
                if (SelectedItem == null)
                    return false;
                if (SelectedItem.Status == "Đang giao hàng")
                    return true;
                return false;
            }, (p) => { BillCheck(p); });
            SeeProductCommand = new RelayCommand<ListBillDetail>((p) => {
                if (SelectedItem == null)
                    return false;
                return true;
            }, (p) => { SeeProduct(p); });
            RefreshCommand = new RelayCommand<ListBillDetail>((p) => { return true; }, (p) => { Refresh(p); });

        }
        private void ExportToExcel(ListBillDetail p)
        {
            Dialog dialog = new Dialog();
            string mess = "Xuất dữ liệu ra Excel?";
            var anc = dialog.DataContext as DialogViewModel;
            anc.Announcement = mess;
            dialog.ShowDialog();
            if (anc.Ok == true)
            {
                // Mở hộp thoại lưu tập tin
                Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                saveFileDialog.DefaultExt = ".xlsx";
                saveFileDialog.Filter = "Excel Workbook (.xlsx)|*.xlsx";
                List<Detail_Bill> tempBillDetail = new List<Detail_Bill>(DataProvider.Ins.DB.Detail_Bill);

                if (false == saveFileDialog.ShowDialog()) return;
                string filename = saveFileDialog.FileName;

                Workbook workbook = new Workbook();
                Worksheet worksheet = workbook.Worksheets[0];
                worksheet.Name = "Danh sách hóa đơn";

                worksheet.Cells["A1"].PutValue("TÊN SẢN PHẨM");
                worksheet.Cells["B1"].PutValue("TÊN KHÁCH HÀNG");
                worksheet.Cells["C1"].PutValue("NGÀY BÁN");
                worksheet.Cells["D1"].PutValue("GIÁ BÁN");


                int idexcel = 0;
                foreach (Detail_Bill delwyn in tempBillDetail)
                {
                    var tempBill = DataProvider.Ins.DB.Bills.Where(x => x.Id == delwyn.IdBill).FirstOrDefault();
                    var tempCustomer = DataProvider.Ins.DB.Customers.Where(x => x.Id == tempBill.IdCustomer).SingleOrDefault();

                    var tempProduct = DataProvider.Ins.DB.Products.Where(x => x.Id == delwyn.IdProduct).SingleOrDefault();
                    var tempEvent = DataProvider.Ins.DB.Event_sale.Where(x => x.Id == delwyn.Id_Event_sale).SingleOrDefault();
                    worksheet.Cells[$"A{idexcel + 2}"].PutValue(tempProduct.Name);
                    worksheet.Cells[$"B{idexcel + 2}"].PutValue(tempCustomer.Name);
                    worksheet.Cells[$"C{idexcel + 2}"].PutValue(tempBill.Date_output_bill.Date.ToString("dd-MM-yyyy"));
                    worksheet.Cells[$"D{idexcel + 2}"].PutValue(delwyn.FinalPrice.ToString("N0"));

                    idexcel++;
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

        private void Refresh(ListBillDetail p)
        {
            SelectedItem = null;
            p.txtnameproduct.Text = "";
            p.txtid.Text = "";
            p.txtnamecus.Text = "";
            p.sum.Text = "";
            p.txtamount.Text = "";
            p.txtgiven.Text = "";
        }

        private void ChangeListView(ListBillDetail p)
        {

            switch (p.selecttype.SelectedIndex)
            {
                case 0:
                    ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills.Where(x => x.Status == "Đang giao hàng" && x.Date_output_bill.Day == Day.Day && x.Date_output_bill.Month == Day.Month && x.Date_output_bill.Year == Day.Year));

                    break;

                case 1:
                    ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills);
                    break;
                case 2:
                    ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills.Where(x => x.Status == "Đã hủy" && x.Date_output_bill.Day == Day.Day && x.Date_output_bill.Month == Day.Month && x.Date_output_bill.Year == Day.Year));
                    break;
                case 3:
                    ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills.Where(x => x.Status == "Đã hoàn thành" && x.Date_output_bill.Day == Day.Day && x.Date_output_bill.Month == Day.Month && x.Date_output_bill.Year == Day.Year));
                    break;
                case 4:
                    ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills.OrderByDescending(x => x.Date_output_bill));
                    break;
            }

        }
        private void DayedView(ListBillDetail p)
        {

            ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills.Where(x => x.Date_output_bill.Day == Day.Day && x.Date_output_bill.Month == Day.Month && x.Date_output_bill.Year == Day.Year));

        }
        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }
        private void export(ListBillDetail p)
        {

            string fileName = "HoaDon.docx";
            var doc = DocX.Create(fileName);
            string storeName = "Tài Long Khánh Store";

            string title = "Hóa Đơn Điện Thoại";
            string address = "Khu phố 6," +
                " Thủ Đức, Thành phố Hồ Chí Minh" + Environment.NewLine;

            Formatting titleFormat = new Formatting();
            titleFormat.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
            titleFormat.Bold = true;
            Formatting nameformatting = new Formatting();
            nameformatting.FontFamily = new Xceed.Document.NET.Font("Times New Roman");


            nameformatting.Size = 16;
            nameformatting.Position = 30;
            titleFormat.Size = 20D;
            titleFormat.Position = 40;
            var tempBillDetail = DataProvider.Ins.DB.Detail_Bill.Where(x => x.IdBill == SelectedItem.Id).First();
            var tempCustomer = DataProvider.Ins.DB.Customers.Where(x => x.Id == SelectedItem.IdCustomer).First();
            var tempUser = DataProvider.Ins.DB.Users.Where(x => x.Id == SelectedItem.IdUsers).First();
            var tempProduct = DataProvider.Ins.DB.Products.Where(x => x.Id == tempDetailBill.IdProduct).First();
            var tempEvent = DataProvider.Ins.DB.Event_sale.Where(x => x.Id == tempBillDetail.Id_Event_sale).FirstOrDefault();
            titleFormat.Italic = true;
            //Text  
            string textParagraph = "Tên khách hàng: " + tempCustomer.Name + ".             " + "Mã hóa đơn: " + tempDetailBill.IdBill + Environment.NewLine +
                "Địa chỉ: " + tempCustomer.Address + Environment.NewLine;

            Formatting detaiformatting = new Formatting();
            detaiformatting.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
            detaiformatting.Spacing = 0;
            detaiformatting.Size = 14D;


            //Formatting Text Paragraph  
            Formatting textParagraphFormat = new Formatting();
            //font family  
            textParagraphFormat.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
            //font size  
            textParagraphFormat.Size = 12D;
            //Spaces between characters  
            textParagraphFormat.Spacing = 1;
            //Insert title  
            Paragraph paragraphstoreName = doc.InsertParagraph(address + "                " + storeName, false, nameformatting);
            paragraphstoreName.Alignment = Alignment.left;
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
            paragraphTitle.Alignment = Alignment.center;
            //Insert text  
            doc.InsertParagraph(textParagraph, false, detaiformatting);
            string user = "Người lập: " + tempUser.DisplayName + ".";
            doc.InsertParagraph(user, false, detaiformatting);
            if (tempEvent != null)
            {
                string eventName = "Sự kiện giảm giá: " + tempEvent.Name + ".";
                doc.InsertParagraph(eventName, false, detaiformatting);
            }
            else
            {
                string eventName = "sự giện giảm giá: {Trống}" + ".";
                doc.InsertParagraph(eventName, false, detaiformatting);
            }

            string shipName = "Tiền vận chuyển: " + tempBillDetail.Ship + ".";
            doc.InsertParagraph(shipName, false, detaiformatting);
            string depositName = "Tiền đặt trước: " + tempBillDetail.Deposit + "." + Environment.NewLine;
            doc.InsertParagraph(depositName, false, detaiformatting);
            Table t = doc.AddTable(3, 6);
            t.Alignment = Alignment.center;
            t.Design = TableDesign.LightShadingAccent1;
            t.TableCaption = "chi tiết";
            t.Rows[0].Cells[0].Paragraphs.First().Append("Tên sản phẩm");
            t.Rows[0].Cells[1].Paragraphs.First().Append("Số lượng");
            t.Rows[0].Cells[2].Paragraphs.First().Append("Tặng");
            t.Rows[0].Cells[3].Paragraphs.First().Append("Ngày tạo");
            t.Rows[0].Cells[4].Paragraphs.First().Append("Đơn giá");
            t.Rows[0].Cells[5].Paragraphs.First().Append("Thành tiền");





            t.Rows[1].Cells[0].Paragraphs.First().Append(tempProduct.Name);
            t.Rows[1].Cells[1].Paragraphs.First().Append(tempDetailBill.Amount_Buy.ToString());
            t.Rows[1].Cells[2].Paragraphs.First().Append(tempDetailBill.Amount_Given.ToString());
            t.Rows[1].Cells[3].Paragraphs.First().Append(SelectedItem.Date_output_bill.ToString());
            t.Rows[1].Cells[4].Paragraphs.First().Append(ConvertLongToMoney(Convert.ToInt64(tempDetailBill.OriginPrice)));
            t.Rows[1].Cells[5].Paragraphs.First().Append(ConvertLongToMoney(Convert.ToInt64(tempDetailBill.FinalPrice)));

            doc.InsertTable(t);
            string textMoney = Environment.NewLine + "Số tiền viết bằng chữ : " + NumberToText(Decimal.ToDouble(tempDetailBill.FinalPrice)) + ".";
            doc.InsertParagraph(textMoney, false, detaiformatting);
            DateTime dayy = DateTime.Now;
            string dayfooter = "Hồ Chí Minh , ngày " + dayy.Day.ToString() + " , tháng " + dayy.Month.ToString() + " , năm " + dayy.Year.ToString();
            Paragraph dayyy = doc.InsertParagraph(dayfooter, false, nameformatting);
            string sign = Environment.NewLine + "Bên bán" + "                            " + "  Bên mua";
            Paragraph S = doc.InsertParagraph(sign, false, detaiformatting);
            S.Alignment = Alignment.center;

            dayyy.Alignment = Alignment.right;
            doc.Save();
            Process.Start("WINWORD.EXE", fileName);
        }
        private void SeeProduct(ListBillDetail p)
        {
            try
            {

                var temp = DataProvider.Ins.DB.Detail_Bill.Where(x => x.IdBill == SelectedItem.Id).First();
                var item = DataProvider.Ins.DB.Products.Where(x => x.Id == temp.IdProduct).First();
                if (item != null)
                {
                    var x = new DetailProductPage(item);
                    var y = x.DataContext as DetailProductPageViewModel;
                    y.Item = item;
                    p.NavigationService.Navigate(x);

                }
            }
            catch { }
        }
        private void CancelBill(ListBillDetail p)
        {
            Dialog dialog = new Dialog();
            string mess = "Bạn muốn huỷ đơn hàng?";
            var x = dialog.DataContext as DialogViewModel;
            x.Announcement = mess;
            dialog.ShowDialog();
            if (x.Ok == true)
            {
                tempBild.Status = "Đã hủy";
                DataProvider.Ins.DB.SaveChanges();
                ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills); ;
                p.selecttype.SelectedIndex = 1;
                OkDialog dialog1 = new OkDialog();
                string mess1 = "Đã huỷ đơn hàng";
                var x1 = dialog1.DataContext as DialogViewModel;
                x1.Announcement = mess1;
                dialog1.ShowDialog();
                if (x1.Ok == true)
                    return;
            }
        }
        private void SelectionChanged(ListBillDetail p)
        {
            Bill newCus = new Bill();
            newCus = p.akanaka.SelectedItem as Bill;
            if (newCus != null)
            {
                IdBill = newCus.Id;
                IdCustomer = newCus.IdCustomer;
                tempBild = DataProvider.Ins.DB.Bills.Where(x => x.Id == IdBill).SingleOrDefault();
                tempDetailBill = DataProvider.Ins.DB.Detail_Bill.Where(x => x.IdBill == IdBill).SingleOrDefault();
                tempCus = DataProvider.Ins.DB.Customers.Where(x => x.Id == IdCustomer).SingleOrDefault();
                tempProduct = DataProvider.Ins.DB.Products.Where(x => x.Id == tempDetailBill.IdProduct).SingleOrDefault();
                Sum = Convert.ToInt64(tempDetailBill.FinalPrice);
                p.sum.Text = ConvertLongToMoney(Sum);
                if (newCus.Status == "Đã Hoàn Thành")
                {
                    p.Payment.IsEnabled = false;
                }
                else
                {
                    p.Payment.IsEnabled = true;
                }
            }


        }
        private void DeteteBill(ListBillDetail p)
        {

            Dialog dialog = new Dialog();
            string mess = "Bạn thực sự muốn xóa đơn hàng này ?!!!";
            var an = dialog.DataContext as DialogViewModel;
            an.Announcement = mess;
            dialog.ShowDialog();
            if (an.Ok == true)
            {
                if (IdBill != "")
                {
                    tempBild = DataProvider.Ins.DB.Bills.Where(x => x.Id == IdBill).SingleOrDefault();
                    tempDetailBill = DataProvider.Ins.DB.Detail_Bill.Where(x => x.IdBill == IdBill).SingleOrDefault();

                    DataProvider.Ins.DB.Detail_Bill.Remove(tempDetailBill);
                    DataProvider.Ins.DB.SaveChanges();
                    DataProvider.Ins.DB.Bills.Remove(tempBild);
                    DataProvider.Ins.DB.SaveChanges();
                    IdBill = "";
                    tempBild = null;
                    tempCus = null;
                    tempDetailBill = null;
                    tempProduct = null;
                    ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills); ;
                    p.selecttype.SelectedIndex = 1;
                }
                ChangeListView(p);
            }

        }
        private void BillCheck(ListBillDetail p)
        {
            tempBild.Status = "Đã hoàn thành";

            tempProduct.CurrentAmount = tempProduct.CurrentAmount - tempDetailBill.Amount_Given - tempDetailBill.Amount_Buy;
            var tempproducttype = DataProvider.Ins.DB.ProductTypes.Where(y => y.Id == tempProduct.IdProductType).SingleOrDefault();
            tempproducttype.NumOfProduct = tempproducttype.NumOfProduct - (tempDetailBill.Amount_Buy + tempDetailBill.Amount_Given);

            DataProvider.Ins.DB.SaveChanges();

            ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills); ;
            p.selecttype.SelectedIndex = 1;
            OkDialog dialog = new OkDialog();
            string mess = "Đã hoàn thành";
            var x = dialog.DataContext as DialogViewModel;
            x.Announcement = mess;
            dialog.ShowDialog();
            if (x.Ok == true)
                return;

        }
        private string ConvertLongToMoney(long money)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return money.ToString("#,###", cul.NumberFormat) + "vnd";


        }
        private void LoadWindow(Window p)
        {
            ListBill = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills);
        }
    }
}
