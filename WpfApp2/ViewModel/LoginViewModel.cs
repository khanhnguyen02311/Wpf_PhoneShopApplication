using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.View;
using WpfApp2.Model;

namespace WpfApp2.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        #region Command
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand LoadLoginWindowCommand { get; set; }
        public ICommand OpenSignupCommand { get; set; }

        public ICommand ForgotPassWordCommand { get; set; }
        #endregion

        public LoginViewModel()
        {
            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            LoadLoginWindowCommand= new RelayCommand<LoginWindow>((p) => { return true; }, (p) => { LoadLoginWindow(p); });
            ForgotPassWordCommand = new RelayCommand<LoginWindow>((p) => { return true; }, (p) => { ForgotPassWord(p); });
            OpenSignupCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { 
                SignUpWindow signUpWindow = new SignUpWindow();
                signUpWindow.Show();
                p.Close(); 
            });
        }

        private void ForgotPassWord(LoginWindow p)
        {
            ForgotPasswordWindow window = new ForgotPasswordWindow();
            window.Show();
            p.Close();
        }

        private void LoadLoginWindow(LoginWindow p)
        {
            IsLogin = false;
            Password = "";
            UserName = "";
        }

        private void Login(Window p)
        {
            if (p == null)
                return;
            
            string passEncode = Base64Encode(Password);

            var accCount = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName && x.Password == passEncode).Count();
            if (accCount > 0)
            {
                IsLogin = true;
                DashBoard dashBoard = new DashBoard();
                
                var y = DataProvider.Ins.DB.Users.ToList();
                foreach(User i in y)
                {
                    if(i.UserName==UserName)
                    {
                       var x = dashBoard.DataContext as DashBoardViewModel;
                       x.User = i;
                       Account.user = i;
                        History history = new History()
                        {
                            DisplayName = i.DisplayName,
                            UserName = i.UserName,
                            TimeToLogIn = System.DateTime.Now,
                           
                        };
                        DataProvider.Ins.DB.Histories.Add(history);
                        DataProvider.Ins.DB.SaveChanges();
                       break;
                    }    
                }
                dashBoard.Show();
                p.Close();
            }
            else
            {
                IsLogin = false;
                OkDialog dialog = new OkDialog();
                string mess = "Tài khoản hoặc mật khẩu không tồn tại!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;   
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
