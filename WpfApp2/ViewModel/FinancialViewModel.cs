using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.View;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Media;

namespace WpfApp2.ViewModel
{
    public class FinancialViewModel : BaseViewModel
    {
        public ICommand LoadFinancialCommand { get; set; }

        private SeriesCollection _AmountTonKhoChart;
        public SeriesCollection AmountTonKhoChart { get => _AmountTonKhoChart; set { _AmountTonKhoChart = value; OnPropertyChanged(); } }

        private SeriesCollection _ProportionLoiNhuanChart;
        public SeriesCollection ProportionLoiNhuanChart { get => _ProportionLoiNhuanChart; set { _ProportionLoiNhuanChart = value; OnPropertyChanged(); } }

        private SeriesCollection _DifferenceNhapXuatChart;
        public SeriesCollection DifferenceNhapXuatChart { get => _DifferenceNhapXuatChart; set { _DifferenceNhapXuatChart = value; OnPropertyChanged(); } }

        private string[] _DifferenceNhapXuatLabels;
        public string[] DifferenceNhapXuatLabels { get => _DifferenceNhapXuatLabels; set { _DifferenceNhapXuatLabels = value; OnPropertyChanged(); } }

        private string[] _AmountTonKhoLabels;
        public string[] AmountTonKhoLabels { get => _AmountTonKhoLabels; set { _AmountTonKhoLabels = value; OnPropertyChanged(); } }


        public List<string> listType = new List<string>();

        public void AmountChart()
        {
            var productType = DataProvider.Ins.DB.ProductTypes;

            foreach (var pt in productType)
            {
                if (!listType.Contains(pt.Name)) listType.Add(pt.Name);
            }

            List<IQueryable<ProductType>> listValid = new List<IQueryable<ProductType>>();
            foreach (string str in listType)
            {
                var temp = productType.Where(p => p.Name == str);
                listValid.Add(temp);
            }

            List<int> sumProduct = new List<int>();
            foreach (var product in listValid)
            {
                if (product != null)
                    sumProduct.Add((int)product.Sum(p => p.NumOfProduct));
                else sumProduct.Add(0);
            }

            AmountTonKhoChart = new SeriesCollection { };
            ColumnSeries series = new ColumnSeries
            {
                Title = "Số lượng",
                Values = new ChartValues<int> { },
                Foreground = Brushes.White,
                DataLabels = true
            };
            foreach (int temp in sumProduct)
            {
                series.Values.Add(temp);
            }

            AmountTonKhoChart.Add(series);
            AmountTonKhoLabels = listType.ToArray();
        }


        public void ProportionChart()
        {
            var detailBill = DataProvider.Ins.DB.Detail_Bill;

            List<IQueryable<Detail_Bill>> listValid = new List<IQueryable<Detail_Bill>>();
            foreach (string str in listType)
            {
                var temp = detailBill.Where(p => p.Bill.Status == "Đã hoàn thành" && p.Product.ProductType.Name == str);
                listValid.Add(temp);
            }

            List<double> sumProduct = new List<double>();

            foreach (var product in listValid)
            {
                if (product != null)
                {
                    double tempsum = 0;
                    foreach (var item in product)
                    {
                        tempsum += (double)item.Moneywillget;
                    }
                    sumProduct.Add(tempsum);
                }
                else sumProduct.Add(0);
            }

            ProportionLoiNhuanChart = new SeriesCollection { };
            for (int i = 0; i < listType.Count; ++i)
            {
                PieSeries series = new PieSeries
                {
                    Title = listType[i],
                    Values = new ChartValues<double> { sumProduct[i] },
                    DataLabels = true,

                };
                ProportionLoiNhuanChart.Add(series);
            }
        }

        public void DifferenceChart()
        {
            DifferenceNhapXuatChart = new SeriesCollection { };

            var listXuat = DataProvider.Ins.DB.Detail_Bill.OrderBy(p => p.Bill.Date_output_bill);
            var listNhap = DataProvider.Ins.DB.Products.OrderBy(p => p.Date);

            LineSeries seriesNhap = new LineSeries
            {
                Title = "Nhập",
                DataLabels = true,
                Values = new ChartValues<int> { },
                LabelPoint = p => p.Y.ToString(),
                LineSmoothness = 0,
                Foreground = Brushes.White
            };

            LineSeries seriesXuat = new LineSeries
            {
                Title = "Xuất",
                DataLabels = true,
                Values = new ChartValues<int> { },
                LabelPoint = p => p.Y.ToString(),
                LineSmoothness = 0,
                Foreground = Brushes.White
            };

            List<DateTime> listDate = new List<DateTime>();
            foreach (var x in listNhap)
            {
                if (!listDate.Contains(x.Date.Date)) listDate.Add(x.Date.Date);
            }
            foreach (var x in listXuat)
            {
                if (!listDate.Contains(x.Bill.Date_output_bill.Date)) listDate.Add(x.Bill.Date_output_bill.Date);
            }
            listDate.Sort();

            Axis ax = new Axis()
            {
                Separator = new LiveCharts.Wpf.Separator()
                {
                    Step = 1,
                    IsEnabled = false
                }
            };

            ax.Labels = new List<string>();
            foreach (DateTime date in listDate)
                ax.Labels.Add(date.ToString("dd/MM/yy"));

            DateTime tempNhap = listDate.First();
            int sumtemp = 0;

            foreach (var x in listDate)
            {
                var tempList1 = listNhap.Where(p => p.Date.Day == x.Day &&
                                                    p.Date.Month == x.Month &&
                                                    p.Date.Year == x.Year);
                var tempList2 = listXuat.Where(p => p.Bill.Date_output_bill.Day == x.Day &&
                                                    p.Bill.Date_output_bill.Month == x.Month &&
                                                    p.Bill.Date_output_bill.Year == x.Year);

                if (tempList1 != null)
                {
                    foreach (var y in tempList1)
                    {
                        sumtemp += (int)y.Price;
                    }
                    seriesNhap.Values.Add(sumtemp);
                    sumtemp = 0;
                }
                else seriesNhap.Values.Add(0);

                if (tempList2 != null)
                {
                    foreach (var y in tempList2)
                    {
                        sumtemp += (int)y.FinalPrice;
                    }
                    seriesXuat.Values.Add(sumtemp);
                    sumtemp = 0;
                }
                else seriesXuat.Values.Add(0);
            }
            DifferenceNhapXuatChart.Add(seriesNhap);
            DifferenceNhapXuatChart.Add(seriesXuat);
            DifferenceNhapXuatLabels = ax.Labels.ToArray();
        }

        private void ResetChart()
        {
            AmountTonKhoLabels = null;
            AmountTonKhoChart = new SeriesCollection { };
            ProportionLoiNhuanChart = new SeriesCollection { };
            DifferenceNhapXuatLabels = null;
            DifferenceNhapXuatChart = new SeriesCollection { };
            AmountChart();
            ProportionChart();
            DifferenceChart();
        }

        public FinancialViewModel()
        {
            LoadFinancialCommand = new RelayCommand<FinancialPage>((p) => { return true; }, (p) => ResetChart());
        }
    }
}
