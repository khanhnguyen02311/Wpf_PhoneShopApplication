   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5          WpfApp2.View.SettingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WpfApp2.View     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      -   5          N�Name$  pagesetting��5         DashBoardVM � DataContext# [  5       N� Title$ SettingPage��5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��0��5      $��3��5       $��TÀI KHOẢN��5!      $��Roboto)�5"      $��20(�5#      $
��Bold"�5$      $��Center=�5%      $��Center=�5&      
������� J� Effect 5(      3  -System.Windows.Media.Effects.DropShadowEffect  5)         ShadowDepth$ 2Q�6#      	Direction$	 315Q�5*   #      Color$ Black��5+   #   	   Opacity$		 0.8Q�5,   #   5.      �� 50   
   $��1��6   $��0��51      $��Roboto)�53      $��SemiBold"�54      $��Center=�55      $��15(�56      $��50��57      
 �� 
IsReadOnly
 . $
��50 0q�59      )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 �����
����������#DDDDDD   Hint$ Mã User��5=       % !MaterialDesignFloatingHintTextBox#��[ 5>      ��52      �� *	User.Id+5>      �� 5A   
   $��1��6   $��1��5B      $��Roboto)�5D      $��SemiBold"�5E      $��Center=�5F      $��15(�5G      
 . $��50��5I      $
��50 0q�5J      $ Quyền hạn��5K      
 �����
����������#DDDDDD#��[ 5O      ��5C      �� *UserRole.DisplayName+5O      �� 5R   
   -   5         ��Name$ txtName��5T      $��2��5R      $��0��5S      $��Roboto)�5V      $��SemiBold"�5W      $��Center=�5X      $��15(�5Y      
 . 
 �����
����������#DDDDDD$��50��5^      $
��50 0q�5_      $ Tên nhân viên��5`      #��[ 5a      ��5U      �� *User.DisplayName+ �� Mode$ OneWay=�5a      �� 5d   
   $��3��6   $��0��5e      
 . $��Roboto)�5h      $��SemiBold"�5i      $��Center=�5j      $��15(�5k      $��50��5l      $
��50 0q�5m      
 �����
����������#DDDDDD$ Tên đăng nhập��5q      #��[ 5r      ��5g      �� *User.UserName+5r      �� 5t   
   $��3��6   $��1��5u      
 . $��Roboto)�5x      $��SemiBold"�5y      $��Center=�5z      $��15(�5{      $��50��5|      $
��50 0q�5}      
 �����
����������#DDDDDD$ Email��5�      #��[ 5�      ��5w      �� *
User.Email+5�      �� 5�   
   -   5         ��Name$ btnSaveName��5�      $��2��5�      $��1��5�      $
��Lưu��5�      $��Roboto)�5�      $y�Hidden=�5�      $��SemiBold"�5�      $��Center=�5�      $��15(�5�       % !MaterialDesignFlatSecondaryButton#��[ 5�      $��0q�5�      $��Center=�5�      $��40��5�      $	��200��5�      ��5�      �� *SaveNameCommand+��5�      ��  �� ElementName$ pagesetting��5�      �� 5�   
   -   5        $ btnChangeName��5�      $��2��5�      $��0��5�      $��Roboto)�5�      $��SemiBold"�5�      $��Center=�5�      $��15(�5�        MaterialDesignFlatButton#��[ 5�      $��0q�5�      $��Right=�5�      $��Center=�5�      $��30��5�      $��50��5�      ��5�      �� *ChangeNameCommand+��5�      �� $ pagesetting��.��5�      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ iconChangeName��5�   &      Kind$ 	PencilOff=�5�   &   $��20��5�   &   $
��auto��5�   &   5�      �� 5�   
   -   5        $	 pwd��5�      $��4��5�      $��0��5�      
 . $��Roboto)�5�      $��SemiBold"�5�      $��Center=�5�      $��15(�5�      $��50��5�      $
��50 0q�5�      
 �����
����������#DDDDDD$ Mật khẩu��5�      #��[ 5�      ��5�      �� *
Password+5�      �� 5�   
   $��4��6   $��0��5�      $��30��5�      $��50��5�       ! MaterialDesignFlatLightButton#��[ 5�      $��Right=�5�      $��Center=�5�      ��5�      �� *ShowPasswordCommand+��5�      �� $ pagesetting��.��5�        -   5        $
 icon��5�      $ EyeOff=�5�      $��Right=�5�      $��Center=�5�      $��20��5�      $
��auto��5�      ���#00a89b5�      5�      �� 5�   
   -   5        $ btnchangepass��5�      $��4��5�      $��1��5�      $��Đổi mật khẩu��5�      $��arial)�5�      $��SemiBold"�5�      $��Center=�5�      $��15(�5�      #��[ 5�      $��0q�5�      $��Center=�5�      $��30��5�      $	��200��5�      ��5�      �� *ChangePasswordCommand+��5�      �� $ pagesetting��5�      G� 5�   
   -	   5         G�Name$ pwdnew��5�      $��5��5�      $��0��5�      $��Roboto)�5�      $��SemiBold"�5�      $y�Hidden=�5�      $��Center=�5�      $��15(�5�      
 �����
����������#DDDDDD$��50��5�      $	��200��5�      $ Mật khẩu mới��5�       ) %MaterialDesignFloatingHintPasswordBox#��[ 5�      .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�         	EventName$ PasswordChanged��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� *PasswordChangedCommand+   CommandParameter 5�      �� $ pwdnew��5�      5�      G� 5�   
   -
   5        $ pwdagain��5�      $��5��5�      $��1��5�      $��Roboto)�5�      $��SemiBold"�5�      $��Center=�5�      $��15(�5�      $y�Hidden=�5      $��50��5     
 �����
����������#DDDDDD$	��200��5     $ Nhập lại mật khẩu��5     #��[ 5      5       5	     $ PasswordChanged��6!   . 5
        6,   �� *PasswordConfirmChangedCommand+ 5  4   �� $ pwdagain��5     5     �� 5  
   -   5        $ btnsave��5     $��5��5     $��3��5     $
��Lưu��5     $��Roboto)�5     $y�Hidden=�5     $��SemiBold"�5     $��Center=�5     $��15(�5     #��[ 5     $��0q�5     $��Center=�5     $��50��5     $	��200��5     ��5     �� *SaveCommand+��5     �� $ pagesetting��5     5!     5"     