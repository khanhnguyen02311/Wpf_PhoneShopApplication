   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5   	   =#clr-namespace:WpfApp2.MyUserControlWpfApp2.MyUserControl  5   �   '    !WpfApp2.View.ForgotPasswordWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp2.View     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6N   ,uc#clr-namespace:WpfApp2.MyUserControl  6�   -   5          �Name$  ForgotPasswd��5   	    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$
 None=�5
   	      ForgotPassVM � DataContext# [  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ ForgotPasswordWindow��5   	   $	��450��6'   $	��450��5   	   .��5      � ��5   
   �� 5      .��5      �  � Color$ #02225e��6    � Offset$ 0Q�6/   � 5      $ #010d63��6   $	 1.0Q�6/   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��60 �6   �� 5      �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��15 �6   .+�5!   
   � $��0��6   .+�5"      (   "WpfApp2.MyUserControl.ControlBarUC  
	 � Tag	 6   �� *Title+
 �� ElementName$
 wdSignup��6K   5#      �� 5%   
   $��1��6   $��Khôi phục mật khẩu��5&      $��Center=�5'      $��Center=�5(      $
��Bold"�5)       �� TextAlignment$ Center=�5*      $
��Wrap=�5+      
�������$��20(�5-      $��Roboto)�5.       J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         ShadowDepth$ 3Q�6#      	Direction$	 315Q�51   #      Color$ Black��52   #      Opacity$	 0.8Q�53   #   55      � 57   
   $��2��6   $��Stretch=�58      $��Stretch=�59      $��20q�5:       5<      �� 5=      �� 5>      �� 5?      �� 5@      �� 5A       � ColumnDefinitions 5D      �� 5E      $��60 �6#   �� 5F      .+�5I      '  !MaterialDesignThemes.Wpf.PackIcon  $��0��6&      Kind$ Account=�5J   &   $��Center=�5K   &   $��Center=�5L   &   $��30��5M   &   $��30��62   ���#DDDDDD5N   &   �� 5P      -   5         ��Name$ txtnameuser��5R      $��0��5P      $��1��5Q      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhập tên đăng nhập��5T      $��Center=�5U      $��Stretch=�5V      $��
10 0 10 10q�5W      $��Center=�5X       �� TextWrapping$
 Wrap=�5Y       % !MaterialDesignFloatingHintTextBox#��[ 5Z      $��12(�5[      $��4q�5\      $
��Bold"�5]      $��Roboto)�5^      $��1��5_      
����������#DDDDDD��5S      �� *
UserName+5a        5f      $��1��6&   $ Email=�5g   &   $��Center=�5h   &   $��Center=�5i   &   $��30��5j   &   $��30��5k   &   ���#DDDDDD5l   &   �� 5m      -   5        $ txtemail��5o      $��1��5m      $��1��5n      $��Medium&�5q      $ Nhập Email của bạn��5r      $��Center=�5s      $��Stretch=�5t      $��
10 0 10 10q�5u      $��Center=�5v      $
 Wrap=�5w      #��[ 5x      $��12(�5y      $��4q�5z      $��Roboto)�5{      $��1��5|      
����������#DDDDDD*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�5      $
��Bold"�5�      ��5p      �� *Email+5�        5�      -   5          Name$
 kind��5�   &   $��2��5�   &   $	 Key=�5�   &   $y�Hidden=�5�   &   $��Center=�5�   &   $��Center=�5�   &   $��30��5�   &   $��30��5�   &   ���#DDDDDD5�   &   �� 5�      -   5        $ txtOTP��5�      $��2��5�      $��1��5�      $y�Hidden=�5�      $ Mã xác thực��5�      $��Center=�5�      $��Stretch=�5�      $��
10 0 10 10q�5�      $��Center=�5�      $��12(�5�      $��Roboto)�5�      $
��Bold"�5�      $��4q�5�      #��[ 5�      $��2��5�      
����������#DDDDDD$
 Dark=�5�      ��5�      �� *	OTPCode+.��5�   B   5�        5�      -   5        $ kind1��5�   &   $��3��5�   &   $y�Hidden=�5�   &   $ Password=�5�   &   $��Center=�5�   &   $��Center=�5�   &   $��30��5�   &   $��30��5�   &   ���#DDDDDD5�   &   G� 5�      -   5         G�Name$ pwdpnewpass��5�      $��3��5�      $��1��5�       G� PasswordChar$ *��5�      $y�Hidden=�5�      $ Nhập mật khẩu mới��5�      $��Center=�5�      $��Stretch=�5�      $��
10 0 10 10q�5�      $��Center=�5�      $��12(�5�      $��Roboto)�5�      $
��Bold"�5�      $��4q�5�       ) %MaterialDesignFloatingHintPasswordBox#��[ 5�      $��2��5�      
����������#DDDDDD$
 Dark=�5�      .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PasswordChanged��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 60   �� *PasswordChangedCommand+ 	  CommandParameter 5�   4   �� $
 pwdpnewpass��5�      5�        5�      -   5        $ kind2��5�   &   $��4��5�   &   $ Password=�5�   &   $y�Hidden=�5�   &   $��Center=�5�   &   $��Center=�5�   &   $��30��5�   &   $��30��5�   &   ���#DDDDDD5�   &   G� 5�      -	   5        $ pwdpagainpass��5�      $��4��5�      $��1��5�      $ *��5�      $y�Hidden=�5�      $# Nhập lai mật khẩu mới��5�      $��Center=�5�      $��Stretch=�5�      $��
10 0 10 10q�5�      $��Center=�5�      $��12(�5�      $��Roboto)�5�      $
��Bold"�5�      $��4q�5�      #��[ 5�      $��2��5�      
����������#DDDDDD$
 Dark=�5�       5�        5�      $ PasswordChanged��6%   . 5�      	   60   �� *PasswordConfirmChangedCommand+ 5�   4   �� $
 pwdpagainpass��5�      5�      5�      � 5�   
   $��3��6    5�      �� 5�      �� 5�      �� 5�      .+�5�      �� -
   5         ��Name$ btnContinue��5�      $��0��5�      $��30��5�      $	��120��5�      {�.  $��Tiếp tục��5�      $��Roboto)�5�      
�������$��20 0 0 0q�5�        MaterialDesignRaisedButton#��[ 5�      ��5�      �� *ContinueCommand+��5�      �� $
 ForgotPasswd��5�      �� 5�      -   5        $ 
btnsendOTP��5     $��1��5�      $��30��5      $	��120��5     $��	Gửi OTP��5     $��Roboto)�5     
�������#��[ 5     ��5�      �� *SendOTPCommand+��5�      �� $
 ForgotPasswd��5     �� 5     -   5        $ btnOk��5     $��2��5     $��30��5     $y�Hidden=�5     $	��120��5     $��Đổi mật khẩu��5     $��Roboto)�5     
�������$��Center=�5     $��0 0 20 0q�5     #��[ 5     ��5	     �� *
YesCommand+��5
     �� $
 ForgotPasswd��5     5     �� 5  
   -   5        $ btnLogin��5     $��4��5     $��30��5     $	��150��5     $��Trở về đăng nhập��5     $��Roboto)�5     ���#1D1D2C
����������#DDDDDD$��Center=�5"     $��Center=�5#        MaterialDesignOutlinedButton#��[ 5$     ��5     �� *BackLoginCommand+��5     �� $
 ForgotPasswd��5$     5&     5'     