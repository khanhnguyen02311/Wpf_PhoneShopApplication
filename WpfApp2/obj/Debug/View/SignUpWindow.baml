   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5   	   =#clr-namespace:WpfApp2.MyUserControlWpfApp2.MyUserControl  5   	       WpfApp2.View.SignUpWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:WpfApp2.View  5   	   ,uc#clr-namespace:WpfApp2.MyUserControl  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5          �Name$  wdSignup��5   	      SignUpVM � DataContext# [  5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
Đăng ký��5   	   $	��500��6   $	��300��6&   .��5      � ��5   
   �� 5      .��5      �  � Color$ #02225e��6    � Offset$ 0Q�6/   � 5      $ #010d63��6   $	 1.0Q�6/   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��60 �6   �� 5      �� 5       $��40 �6   �� 5!      $��40 �6   �� 5"      $��20 �6   .+�5%   
   � $��0��6   .+�5&      (   "WpfApp2.MyUserControl.ControlBarUC  
	 � Tag	 6   �� *Title+
 �� ElementName$
 wdSignup��6K   5'      �� 5)   
   $��1��6   $��
Đăng ký��5*      $��Center=�5+      $��Center=�5,      $
��Bold"�5-       �� TextAlignment$ Center=�5.      $
��Wrap=�5/      
�������$��20(�51      $��Roboto)�52       J� Effect 53      3  -System.Windows.Media.Effects.DropShadowEffect  54         ShadowDepth$ 3Q�6#      	Direction$	 315Q�55   #      Color$ Black��56   #      Opacity$	 0.8Q�57   #   59      � 5;   
   $��2��6   $��Stretch=�5<      $��Stretch=�5=      $��	20 0 25 0q�5>       5@      �� 5A      �� 5B      �� 5C      �� 5D      �� 5E      �� 5F      �� 5G       � ColumnDefinitions 5I      �� 5J      $��60 �6#   �� 5K      .+�5N      '  !MaterialDesignThemes.Wpf.PackIcon  $��0��6&      Kind$ CardAccountDetailsOutline=�5O   &   $��Center=�5P   &   $��Center=�5Q   &   $��30��5R   &   $��30��62   ���#DDDDDD5S   &   �� 5U      -   5         ��Name$ txtnameuser��5W      $��0��5U      $��1��5V      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Họ và tên��5Y      $��Center=�5Z      $��Stretch=�5[      $��
10 0 10 10q�5\      $��Center=�5]       �� TextWrapping$
 Wrap=�5^       % !MaterialDesignFloatingHintTextBox#��[ 5_      $��12(�5`      $��4q�5a      $��Roboto)�5b      $��1��5c      
����������#DDDDDD*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�5f      ��5X      �� *DisplayName+5f        5k      $��1��6&   $ AccountOutline=�5l   &   $��Center=�5m   &   $��Center=�5n   &   $��30��5o   &   $��30��5p   &   ���#DDDDDD5q   &   �� 5r      -   5        $ txtlogin��5t      $��1��5r      $��1��5s      $��Medium&�5v      $ Tên đăng nhập��5w      $��Center=�5x      $��Stretch=�5y      $��
10 0 10 10q�5z      $��Center=�5{      $
 Wrap=�5|      #��[ 5}      $��12(�5~      $��4q�5      $��Roboto)�5�      $��1��5�      
����������#DDDDDD$
 Dark=�5�      $
��Bold"�5�      ��5u      �� *
UserName+5�        5�      $��4��6&   $ Email=�5�   &   $��Center=�5�   &   $��Center=�5�   &   $��30��5�   &   $��30��62   ���#DDDDDD5�   &   �� 5�      -   5        $ txtemail��5�      $��4��5�      $��1��5�      $ Email��5�      $��Center=�5�      $��Stretch=�5�      $��
10 0 10 10q�5�      $��Center=�5�      $
 Wrap=�5�      #��[ 5�      $��12(�5�      $��4q�5�      $��Roboto)�5�      $��1��5�      
����������#DDDDDD$
 Dark=�5�      ��5�      �� *Email+5�      � 5�      $��40��6   $��5��5�      $��1��5�      .+�5�      �� -   5        $��comboArrange��5�      $��12(�5�      $��Italic$�5�      $��Roboto)�5�      $��Stretch=�5�      $��Center=�5�      $��
10 0 10 10q�5�      $��30��5�      $��4q�5�      $��Bottom=�5�      $ Chọn quyền��5�      
����������#DDDDDD$
 Dark=�5�      ��5�      �� *ListPioryty+ �� SelectedItem 5�      �� *SelectedItem+.  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 64   �� *SelectionChangedCommand+ 	  CommandParameter 5�   ,   �� $
 wdSignup��5�      ��5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�5�      $��85��5�      $
��Left=�5�      .+�5�   "   ��  ��Name$ txbName��6,   $	��100��5�   ,   $
��Auto��5�   ,   $
��Left=�5�   ,   $��10(�5�   ,   ��5�   ,   �� *DisplayName+5�   ,   5�      5�      5�      5�        5�      $��6��6&   $ 
KeyOutline=�5�   &   $��Center=�5�   &   $��Center=�5�   &   $��30��5�   &   $��30��5�   &   ���#DDDDDD5�   &   �� 5�      -   5        $ txtcode��5�      $��1��5�      $��6��5�      {�.  $��Medium&�5�      $% Mã xác thực (quyền Admin)��5�      $��Center=�5�      $��Stretch=�5�      $��
10 0 10 10q�5�      $��4q�5�      $��Center=�5�      $
 Wrap=�5�      #��[ 5�      $��12(�5�      $��Roboto)�5�      $��Italic$�5�      $��1��5�      
����������#DDDDDD$
 Dark=�5�      $��Medium"�5�      ��5�      �� *Code+5�        5�      $��2��6&   $
 Lock=�5�   &   $��Center=�5�   &   $��Center=�5�   &   $��30��5�   &   $��30��5�   &   ���#DDDDDD5�   &   G� 5�      -   5         G�Name$ pwdlogin��5�      $��2��5�      $��1��5�      $ Mật khẩu��5�      $��Center=�5�      $��Stretch=�5�      $��
10 0 10 10q�5�      $��Center=�5�      $��12(�5�      $��Roboto)�5�      $
��Bold"�5      $��4q�5      ) %MaterialDesignFloatingHintPasswordBox#��[ 5     $��2��5       G� PasswordChar$  *��5     
����������#DDDDDD$
 Dark=�5      5
       5     $ PasswordChanged��6%   . 5     	   60   �� *PasswordChangedCommand+ 5  4   �� $
 pwdlogin��5     5       5     $��3��6&   $
 Lock=�5  &   $��Center=�5  &   $��Center=�5  &   $��30��5  &   $��30��5  &   ���#DDDDDD5  &   G� 5     -   5        $ againpwdlogin��5     $��3��5     $��1��5     $ Nhập lại mật khẩu��5     $��Center=�5     $��Stretch=�5      $��
10 0 10 10q�5!     $��Center=�5"     $��12(�5#     $��Roboto)�5$     $
��Bold"�5%     $��4q�5&     #��[ 5'     $��2��5(     $  *��5)     
����������#DDDDDD$
 Dark=�5,      5/       50     $ PasswordChanged��6%   . 51     	   60   �� *PasswordConfirmChangedCommand+ 52  0   �� $
 againpwdlogin��53     56     57     �� 5:  
   -	   5        ! ��Name$! 	btnSignup��5?     $��3��5:     $��30��5=     $	��120��5>     $��
Đăng ký��5@     $��Roboto)�5A     
�������  MaterialDesignRaisedButton#��[ 5C     ��5;     �� *SignupCommand+��5<     �� $
 wdSignup��5C     �� 5E  
   -
   5        $! btnLogin��5I     $��4��5E     $��30��5F     $	��120��5G     $��Đăng nhập��5H     $��Roboto)�5J     ���#1D1D2C
����������#DDDDDD$��Center=�5P     $��Center=�5Q        MaterialDesignOutlinedButton#��[ 5R     ��5K     �� *BackLoginCommand+��5L     �� $
 wdSignup��5R     5S     5T     