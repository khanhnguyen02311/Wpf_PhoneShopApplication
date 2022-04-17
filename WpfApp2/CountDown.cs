using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using WpfApp2.View;
using WpfApp2.ViewModel;

namespace WpfApp2
{

    public class CountDown
    {
        public ForgotPasswordWindow window;
        DispatcherTimer timer = new DispatcherTimer();
        int seconds = 60;
        public CountDown(ForgotPasswordWindow window=null)
        {
            this.window = window;
        }

        public void Display()
        {

            window.btnsendOTP.Content = seconds.ToString()+" (s)";
            window.btnsendOTP.IsEnabled = false;
            timer.Tick += Timer_Tick; ;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            window.btnsendOTP.Content = (seconds--).ToString() + " (s)";
            if(window.btnContinue.IsEnabled == false && seconds > 1)
            {
                timer.Stop();
                window.btnsendOTP.Content = "Gửi OTP";
                
            }
            else if (seconds <0 )
            {
                timer.Stop();
                window.btnsendOTP.Content = "Gửi OTP";
                window.btnsendOTP.IsEnabled = true;
                window.btnContinue.IsEnabled = false;
                window.txtemail.IsReadOnly = window.txtnameuser.IsReadOnly = false;
                window.txtOTP.Text = null;
                window.txtOTP.Visibility = System.Windows.Visibility.Hidden;
                window.kind.Visibility = System.Windows.Visibility.Hidden;
                OkDialog dialog = new OkDialog();
                string mess = "OTP đã hết hạn!Vui lòng nhận mã mới!";
                var x = dialog.DataContext as DialogViewModel;
                x.Announcement = mess;
                dialog.ShowDialog();
                if (x.Ok == true)
                    return;
            }

        }
    }
}
