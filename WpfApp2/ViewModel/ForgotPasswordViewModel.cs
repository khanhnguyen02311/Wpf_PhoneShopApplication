using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp2.Model;
using WpfApp2.View;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp2.ViewModel
{
    public class ForgotPasswordViewModel:BaseViewModel
    {
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }
        private string _OTPCode;
        public string OTPCode { get => _OTPCode; set { _OTPCode = value; OnPropertyChanged(); } }
        private string Code;
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _AgainPassword;
        public string AgainPassword { get => _AgainPassword; set { _AgainPassword = value; OnPropertyChanged(); } }
        public ICommand SendOTPCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand PasswordConfirmChangedCommand { get; set; }

        public ICommand ContinueCommand { get; set; }
        public ICommand YesCommand { get; set; }
        public ICommand BackLoginCommand { get; set; }
        public ForgotPasswordViewModel()
        {
            Refresh();
            SendOTPCommand = new RelayCommand<ForgotPasswordWindow>((p) => { return true; }, (p) => { SendOTP(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => EncodingPassword(p));
            PasswordConfirmChangedCommand = new RelayCommand<PasswordBox>((p) => true, (p) => EncodingConfirmPassword(p));
            ContinueCommand = new RelayCommand<ForgotPasswordWindow>((p) => {                
                return true;
            }, (p) => { Countinue(p); });
            YesCommand = new RelayCommand<ForgotPasswordWindow>((p) => { return true; }, (p) => { Yes(p); });
            BackLoginCommand = new RelayCommand<ForgotPasswordWindow>((p) => { return true; }, (p) => { Refresh(); LoginWindow login = new LoginWindow(); login.Show(); p.Close(); });
        }

        private void Yes(ForgotPasswordWindow p)
        {
            if (p.pwdpnewpass.Password.Length < 6)
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
            else
            {
                var temp = DataProvider.Ins.DB.Users.Where(y => y.UserName == UserName).First();
                temp.Password = Password;
                DataProvider.Ins.DB.SaveChanges();               
                p.kind1.Visibility = p.kind2.Visibility = p.pwdpagainpass.Visibility = p.pwdpnewpass.Visibility = Visibility.Hidden;
                p.btnOk.Visibility = Visibility.Hidden;
                p.btnsendOTP.IsEnabled = true;
                p.txtemail.IsReadOnly = p.txtnameuser.IsReadOnly = false;
                Refresh();
                p.pwdpagainpass.Password = p.pwdpnewpass.Password = null;
                p.txtOTP.Visibility = p.kind.Visibility = Visibility.Hidden;
                p.txtOTP.IsEnabled = true;
                p.btnContinue.IsEnabled = false;
                OkDialog dialog = new OkDialog();
                string mess = "Đổi mật khẩu mới thành công!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if(x.Ok==true)
                    return;
            }
        }

        private void Refresh()
        {
            UserName = Email = OTPCode =null;
        }

        private void Countinue(ForgotPasswordWindow p)
        {
            if (OTPCode != Code)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Sai mã OTP!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else
            {
                p.kind1.Visibility = p.kind2.Visibility = p.pwdpagainpass.Visibility = p.pwdpnewpass.Visibility = Visibility.Visible;
                p.btnOk.Visibility = Visibility.Visible;
                p.txtOTP.IsEnabled = false;
                p.btnContinue.IsEnabled = false;
            }
        }

        private void SendOTP(ForgotPasswordWindow p)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(UserName))
            {
                OkDialog dialog = new OkDialog();
                string mess = "Dữ liệu trống!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else if(DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName).Count()<=0)
            {
                OkDialog dialog = new OkDialog();
                string mess = "Tài khoản không tồn tại!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }
            else
            {
                var acc = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName).First();
                if (acc.Email != Email)
                {
                    OkDialog dialog = new OkDialog();
                    string mess = "Email không khớp với tài khoản!";
                    var x = dialog.DataContext as DialogViewModel;
                    x.Announcement = mess;
                    dialog.ShowDialog();
                    if (x.Ok == true)
                        return;
                }
                else
                {                   
                    string  from, pass, messageBody;
                    Random rand = new Random();
                    Code = (rand.Next(999999)).ToString();

                    MailMessage message = new MailMessage();
                    from = "lttquit2021@gmail.com";
                    pass = "laptrinhtrucquan2021";
                    messageBody = "Chào, " + acc.DisplayName + ".\nMã OTP của bạn là " + Code + "\nXin cảm ơn!";
                    message.To.Add(Email);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "Quên mật khẩu?";


                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {

                        smtp.Send(message);                        
                        p.btnsendOTP.IsEnabled = false;
                        p.txtemail.IsReadOnly = p.txtnameuser.IsReadOnly = true;  
                        p.txtOTP.Visibility=p.kind.Visibility= Visibility.Visible;
                        p.btnContinue.IsEnabled = true;
                        CountDown cd = new CountDown(p);
                        cd.Display();
                        OkDialog dialog = new OkDialog();
                        string mess = "Gửi thành công!\nMời nhập mã OTP";
                        var x = dialog.DataContext as DialogViewModel;
                        x.Announcement = mess;
                        dialog.ShowDialog();
                        if (x.Ok == true)
                            return;

                    }
                    catch { }


                }
            }
        }
        private void EncodingConfirmPassword(PasswordBox p)
        {
            AgainPassword = EncodeTo64(p.Password);
        }

        private void EncodingPassword(PasswordBox p)
        {
            Password = EncodeTo64(p.Password);
        }
        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
}
