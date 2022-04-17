using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfApp2.Model;

using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    public class DashBoardViewModel : BaseViewModel
    {
        private bool isChangeName;
        private bool isChangePassword;
        private bool isPressButton;

        private User _User;
        public User User { get => _User; set { _User = value; OnPropertyChanged(); } }
        private UserRole _UserRole;
        public UserRole UserRole { get => _UserRole; set { _UserRole = value; OnPropertyChanged(); } }


        private Color _ColorMenu;

        public Color ColorMenu { get => _ColorMenu; set { _ColorMenu = value; OnPropertyChanged(); } }
        private Color _ColorSetting;

        public Color ColorSetting { get => _ColorSetting; set { _ColorSetting = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private string _NewPassword;
        public string NewPassword { get => _NewPassword; set { _NewPassword = value; OnPropertyChanged(); } }
        private string _AgainPassword;
        public string AgainPassword { get => _AgainPassword; set { _AgainPassword = value; OnPropertyChanged(); } }

        private string TempName;

        public ICommand AddProductPageCommand { get; set; }

        public ICommand ListProductCommand { get; set; }
        public ICommand AddBillCommand { get; set; }
        public ICommand FinancialPageCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand LoadFrameCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand ChangeNameCommand { get; set; }
        public ICommand ShowPasswordCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand PasswordConfirmChangedCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand SaveNameCommand { get; set; }
        public ICommand MenuCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public DashBoardViewModel()
        {
            //Nut Them san pham
            AddProductPageCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { AddProduct(p); });
            //Nut Danh sach san pham
            ListProductCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { OpenListProduct(p); });
            //Nut Them hoa don
            AddBillCommand = new RelayCommand<Page>((p) => { return true; }, (p) => { AddBill(p); });
            //Nut Tai chinh
            FinancialPageCommand = new RelayCommand<HomePage>((p) => {
                if (User.IdRole == 1) return true;
                return false;
            }, (p) => { Financial(p); });
            //Nut Dang xuat
            LogOutCommand = new RelayCommand<DashBoard>((p) => { return true; }, (p) => { LogOut(p); });
            //Nut Tai khoan
            SettingCommand = new RelayCommand<DashBoard>((p) => { return true; }, (p) => { Setting(p); });
            //Nut Lich su dang nhap
            HistoryCommand = new RelayCommand<DashBoard>((p) => {
                if (User == null || User.IdRole == 2) return false;
                return true;
            },  (p) => { HistoryPage(p); });

            isChangeName = isChangePassword = isPressButton = false;
            LoadFrameCommand = new RelayCommand<DashBoard>((p) => { return true; }, (p) => { LoadFrame(p); });
            MenuCommand = new RelayCommand<DashBoard>((p) => { return true; }, (p) => { GotoMenu(p); });
            ShowPasswordCommand = new RelayCommand<SettingPage>((p) => { return true; }, (p) => { ShowPassword(p); });
            ChangePasswordCommand = new RelayCommand<SettingPage>((p) => { return true; }, (p) => { ChangePassword(p); });
            SaveCommand = new RelayCommand<SettingPage>((p) => { return true; }, (p) => { Save(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => EncodingPassword(p));
            PasswordConfirmChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => EncodingConfirmPassword(p));
            ChangeNameCommand = new RelayCommand<SettingPage>((p) => { return true; }, (p) => { ChangeName(p); });
            SaveNameCommand = new RelayCommand<SettingPage>((p) => { return true; }, (p) => { SaveName(p); });
        }


        private void HistoryPage(DashBoard p)
        {
            
            p.btnHistory.Background = new SolidColorBrush(Color.FromArgb(255, 0, 168, 155));
            p.btnSetting.Background = p.btnMenu.Background=Brushes.Transparent;
            p._mainFrame.Navigate(new HistoryPage());
        }

        private void LogOut(DashBoard p)
        {
            Dialog dialog = new Dialog();
            string mess = "Bạn muốn đăng xuất?";
            var x = dialog.DataContext as DialogViewModel;
            x.Announcement = mess;
            dialog.ShowDialog();
            if (x.Ok == true)
            {
                LoginWindow login = new LoginWindow(); 
                login.Show();
                User = new User(); 
                p.Close();
            }

        }

        private void GotoMenu(DashBoard p)
        {
            p.btnMenu.Background = new SolidColorBrush(Color.FromArgb(255, 0, 168, 155));
            p.btnSetting.Background =p.btnHistory.Background= Brushes.Transparent;
            p._mainFrame.NavigationService.Navigate(new HomePage());
        }

        private void SaveName(SettingPage p)
        {
            if (string.IsNullOrEmpty(p.txtName.Text))
            {
                OkDialog dialog = new OkDialog();
                string mess = "Tên không được để trống!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else
            {
                Dialog dialog = new Dialog();
                string mess = "Bạn muốn thay đổi?";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                {
                    User temp = DataProvider.Ins.DB.Users.Where(y => y.Id == User.Id).FirstOrDefault();
                    temp.DisplayName = p.txtName.Text;
                    DataProvider.Ins.DB.SaveChanges();
                    User = temp;
                    Account.user = User;
                    p.btnSaveName.Visibility = Visibility.Hidden;
                    p.txtName.IsReadOnly = true;
                    isChangeName = false;
                    p.iconChangeName.Kind = MaterialDesignThemes.Wpf.PackIconKind.PencilOff;
                    OkDialog dialog1 = new OkDialog();
                    string mess1 = "Lưu thành công!";
                    var x1 = dialog1.DataContext as DialogViewModel;
                    x1.Announcement = mess1;
                    dialog1.ShowDialog();
                    if (x1.Ok == true)
                        return;
                }
                else
                {
                    p.txtName.Text = User.DisplayName = TempName;
                    p.btnSaveName.Visibility = Visibility.Hidden;
                    p.txtName.IsReadOnly = true;
                    isChangeName = false;
                    p.iconChangeName.Kind = MaterialDesignThemes.Wpf.PackIconKind.PencilOff;
                }
            }
        }

        private void ChangeName(SettingPage p)
        {
            if (isChangeName == false)
            {
                isChangeName = isPressButton = true;
                p.iconChangeName.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pencil;
                p.txtName.IsReadOnly = false;
                p.btnSaveName.Visibility = Visibility.Visible;
                TempName = p.txtName.Text;
            }
            else if (isChangeName && isPressButton)
            {
                p.txtName.Text = User.DisplayName = TempName;
                p.btnSaveName.Visibility = Visibility.Hidden;
                p.txtName.IsReadOnly = true;
                isChangeName = false;
                p.iconChangeName.Kind = MaterialDesignThemes.Wpf.PackIconKind.PencilOff;
            }


        }

        private void EncodingConfirmPassword(PasswordBox p)
        {
            AgainPassword = p.Password;
        }
        private void EncodingPassword(PasswordBox p)
        {
            NewPassword = p.Password;
        }
        private void Save(SettingPage p)
        {
            if (string.IsNullOrEmpty(NewPassword) || NewPassword.Length < 6)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Mật khẩu phải lớn hơn 6 ký tự!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (NewPassword == Base64Decode(User.Password))
            {
                OkDialog dialog = new OkDialog();
                string mess = "Mật khẩu trùng mật khẩu cũ!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (String.IsNullOrEmpty(AgainPassword))
            {
                OkDialog dialog = new OkDialog();
                string mess = "Bạn chưa nhập lại mật khẩu!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if (NewPassword != AgainPassword)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Mật khẩu không trùng khớp!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else
            {
                Dialog dialog = new Dialog();
                string mess = "Bạn muốn thay đổi?";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                {
                    User temp = DataProvider.Ins.DB.Users.Where(y => y.Id == User.Id).FirstOrDefault();
                    temp.Password = EncodeTo64(NewPassword);
                    DataProvider.Ins.DB.SaveChanges();
                    User = temp;
                    Password = NewPassword;
                    p.pwdnew.Visibility = Visibility.Hidden;
                    p.pwdnew.Clear();
                    NewPassword = "";
                    p.pwdagain.Visibility = Visibility.Hidden;
                    p.pwdagain.Clear();
                    AgainPassword = "";
                    p.btnsave.Visibility = Visibility.Hidden;
                    p.btnchangepass.Background = Brushes.Transparent;
                    OkDialog dialog1 = new OkDialog();
                    string mess1 = "Lưu thành công!";
                    var x1 = dialog1.DataContext as DialogViewModel;
                    x1.Announcement = mess1;
                    dialog1.ShowDialog();
                    if (x1.Ok == true)
                        return;
                }
            }
        }

        private void ChangePassword(SettingPage p)
        {
            if (isChangePassword == false)
            {
                isChangePassword = true;
                p.pwdnew.Visibility = Visibility.Visible;
                p.pwdagain.Visibility = Visibility.Visible;
                p.btnsave.Visibility = Visibility.Visible;
                p.btnchangepass.Background = Brushes.Gray;
            }
            else
            {
                isChangePassword = false;
                p.pwdnew.Visibility = Visibility.Hidden;
                p.pwdnew.Clear();
                NewPassword = "";
                p.pwdagain.Visibility = Visibility.Hidden;
                p.pwdagain.Clear();
                AgainPassword = "";
                p.btnsave.Visibility = Visibility.Hidden;
                p.btnchangepass.Background = Brushes.Transparent;
            }

        }

        private void ShowPassword(SettingPage p)
        {
            if (p.icon.Kind == MaterialDesignThemes.Wpf.PackIconKind.EyeOff)
            {
                p.icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
                Password = Base64Decode(User.Password);
            }
            else
            {
                p.icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
                Password = LoadPassword();
            }
        }

        private void Setting(DashBoard p)
        {
            UserRole = DataProvider.Ins.DB.UserRoles.Where(x => x.Id == User.IdRole).First();
            Password = LoadPassword();
            p.btnMenu.Background =p.btnHistory.Background= Brushes.Transparent;
            p.btnSetting.Background = new SolidColorBrush(Color.FromArgb(255, 0, 168, 155));
            p._mainFrame.NavigationService.Navigate(new SettingPage());
        }

        private string LoadPassword()
        {
            string str = "";
            for (int i = 0; i < Base64Decode(User.Password).Length; i++)
                str += "*";
            return str;
        }

        private void Financial(HomePage p)
        {
            p.NavigationService.Navigate(new FinancialPage());
        }

        private void AddProduct(Page p)
        {
            p.NavigationService.Navigate(new AddProductPage());
        }
        private void AddBill(Page p)
        {
            AddBill x = new AddBill();
            var y = x.DataContext as AddBillViewModel;
            y.User = Account.user;
            p.NavigationService.Navigate(x);
        }
        private void LoadFrame(DashBoard p)
        {
            p.btnMenu.Background = new SolidColorBrush(Color.FromArgb(255, 0, 168, 155));
            p._mainFrame.NavigationService.Navigate(new HomePage());
        }
        private void OpenListProduct(Page p)
        {
            p.NavigationService.Navigate(new ListProductPage());
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type TargetType, object parameter, CultureInfo culture)
        {
            double newValue = double.Parse(value.ToString());
            return newValue.ToString("N0");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }// Convert Giá tiền
}
