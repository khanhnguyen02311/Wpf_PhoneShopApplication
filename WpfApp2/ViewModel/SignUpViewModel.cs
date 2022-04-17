using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.View;
namespace WpfApp2.ViewModel
{
    public class SignUpViewModel: BaseViewModel
    {
        private bool isSignUp;
        public bool IsSignUp { get => isSignUp; set => isSignUp = value; }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }
        
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }


        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _AgainPassword;
        public string AgainPassword { get => _AgainPassword; set { _AgainPassword = value; OnPropertyChanged(); } }
        private UserRole _SelectedItem;
        public UserRole SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        public ObservableCollection<UserRole> _ListPioryty;
       
        public ObservableCollection<UserRole> ListPioryty { get => _ListPioryty; set { _ListPioryty = value; OnPropertyChanged(); } }
        private string _Code;
        public string Code { get => _Code; set { _Code = value; OnPropertyChanged(); } }
        public ICommand SignupCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand PasswordConfirmChangedCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public ICommand BackLoginCommand { get; set; }
        public ICommand LoadWindowCommand { get; set; }
        public SignUpViewModel()
        {
            DisplayName = "";
            UserName = "";
            Password = "";
            Email = "";
            AgainPassword = "";
            ListPioryty = new ObservableCollection<UserRole>(DataProvider.Ins.DB.UserRoles);
            SignupCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { SignUp(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => EncodingPassword(p));
            PasswordConfirmChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => EncodingConfirmPassword(p));
            BackLoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { LoginWindow login = new LoginWindow();login.Show();p.Close(); });
            SelectionChangedCommand = new RelayCommand<SignUpWindow>((p) => true, (p) => SelectionChanged(p));
            LoadWindowCommand = new RelayCommand<SignUpWindow>((p) => true, (p) => LoadWd(p));
        }

        private void LoadWd(SignUpWindow p)
        {
            DisplayName = "";
            UserName = "";
            Email = "";
            Password = "";
            AgainPassword = "";
            p.pwdlogin.Password = "";
            p.againpwdlogin.Password = "";
            p.comboArrange.SelectedItem = null;
            Code = "";
            p.txtcode.IsEnabled = false;
        }

        private void SelectionChanged(SignUpWindow p)
        {
            if (SelectedItem == null)
                return;
            if (SelectedItem.DisplayName == "Admin")
                p.txtcode.IsEnabled = true;
            else
                p.txtcode.IsEnabled = false;
        }

        private void EncodingConfirmPassword(PasswordBox p)
        {
            AgainPassword = EncodeTo64(p.Password);
        }

        private void EncodingPassword(PasswordBox p)
        {
            Password = EncodeTo64(p.Password);
        }

        private void SignUp(Window p)
        {
            isSignUp = false;
            if (p == null)
                return;
            if (string.IsNullOrEmpty(DisplayName))
            {
                OkDialog dialog = new OkDialog();
                string mess = "Họ và tên không được để trống!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            if( UserName.Length < 6)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Tên đăng nhập phải từ 6 ký tự trở lên!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            if(DataProvider.Ins.DB.Users.Where(x=> x.UserName==UserName).Count()>0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Tên đăng nhập đã tồn tại!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            if (Password.Length < 6)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Mật khẩu phải từ 6 ký tự trở lên!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            if (Password != AgainPassword)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Mật khẩu nhập lại không trùng khớp!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
            {
                OkDialog dialog = new OkDialog();
                string mess = "Chưa nhập Email hoặc Email không hợp lệ!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            if (SelectedItem == null)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Chưa chọn quyền!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            if(SelectedItem.DisplayName=="Admin" && (string.IsNullOrEmpty(Code)||Code != "123456"))
            {
                OkDialog dialog = new OkDialog();
                string mess = "Nhập sai keycode!\nKhông thể tạo quyền Admin";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
           
            else
            {
                Dialog dialog = new Dialog();
                string mess = "Bạn muốn đăng ký tài khoản này?";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                {
                    var user = new User();
                    user.UserName = UserName;
                    user.DisplayName = DisplayName;
                    user.Password = Password;
                    user.IdRole = SelectedItem.Id;
                    user.Email = Email;
                    DataProvider.Ins.DB.Users.Add(user);
                    DataProvider.Ins.DB.SaveChanges();
                    OkDialog dialog1 = new OkDialog();
                    string mess1 = "Đăng ký thành công!";
                    isSignUp = true;
                    var x1 = dialog1.DataContext as DialogViewModel;
                    x1.Announcement = mess1;
                    dialog1.ShowDialog();
                    if (x1.Ok == true)
                        return;
                }
                return;
            }

        }
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
       
    }
}
