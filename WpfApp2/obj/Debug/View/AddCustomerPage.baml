   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5      "    WpfApp2.View.AddCustomerPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WpfApp2.View     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N�Name$  wdAddCus��5	   	      AddCustomerVM � DataContext# [  5   
    N� Title$
 test��5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� -   5         ��Name$ btnbackward��5      $
��Left=�5      
�������
�������$��Center=�5      $��25��5      $��25��6   $��5q�5      -  'System.Windows.Input.NavigationCommands   
BrowseBack#��Z 5       / +MaterialDesignFloatingActionMiniLightButton#��[ 5       .��5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardArrowLeft=�5"      $��20��5#      $��20��5$      
���   �5%      5&      �� 5(   
   $
��Left=�5)      
�������
�������$��Center=�5,         BrowseForward#��Z 5-      $��25��5.      $��25��6   $��35 0 0 0q�5/      #��[ 51      .��52        $ KeyboardArrowRight=�53      $��20��54      $��20��55      57      �� 59   
   $
��Left=�6   
�������
�������$��Center=�5<      $��25��5=      $��25��6   #��[ 5@      $��65,0,0,0q�5A      ��5>      �� *ResetCommand+��5?      ��  �� ElementName$ wdAddCus��.��5B        $ Refresh=�5C      $��20��5D      $��20��5E      5F      �� 5H   
   $��0��6   $��THÊM KHÁCH HÀNG��5I      $��Roboto)�5J      $��20(�5K      $
��Bold"�5L      $��Center=�5M      $��Center=�5N      
�������	 J� Effect	 5P      3  -System.Windows.Media.Effects.DropShadowEffect  5Q      
   ShadowDepth$
 2Q�6#      	Direction$	 315Q�5R   #      Color$ Black��5S   #      Opacity$	 0.8Q�5T   #   5V      �� 5W   
   $��1��6   $��Roboto)�5Y      $��SemiBold"�5Z      $
��Left=�5[      $
��Left=�5\      $��Center=�5]      )  #MaterialDesignThemes.Wpf.HintAssist   
Foreground
 �����6  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner   Brush
 �����
����������#DDDDDD*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�5b      $��50 0 0 0q�5c      $��15(�5d      $��50��5e      $	��400��5f         Hint$ Mã khách hàng mới��5g       % !MaterialDesignFloatingHintTextBox#��[ 5h      ��5X      �� *ID+5h      �� 5j   
   $��2��6   $��Roboto)�5l      $��SemiBold"�5m      $
��Left=�5n      $
��Left=�5o      $��Center=�5p      
 �����
 �����
����������#DDDDDD$
 Dark=�5u      $��50 0 0 0q�5v      $��15(�5w      $��50��5x      $	��400��5y      $ Tên khách hàng mới��5z      #��[ 5{      ��5k      �� *NameCustomer+5{      �� 5|   
   $��3��6   $��Roboto)�5~      $��SemiBold"�5      $
��Left=�5�      $
��Left=�5�      $��Center=�5�      
 �����
 �����
����������#DDDDDD$
 Dark=�5�      $��50 0 0 0q�5�      $��15(�5�      $��50��5�      $	��400��5�      $ Số điện thoại��5�      #��[ 5�      ��5}      �� *Phone+5�      �� 5�   
   $��4��6   $��Roboto)�5�      $��SemiBold"�5�      $
��Left=�5�      $
��Left=�5�      $��Center=�5�      
 �����
 �����
����������#DDDDDD$
 Dark=�5�      $��50 0 0 0q�5�      $��15(�5�      $��50��5�      $	��400��5�      $ Địa chỉ��5�      #��[ 5�      ��5�      �� *	Address+5�      �� 5�   
   $��5��6   $��Thêm khách hàng��5�      $��Roboto)�5�      $��SemiBold"�5�      $��Center=�5�      $��15(�5�      $��0q�5�      $��Center=�5�      $��Right=�5�      
�������
�������+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5�      $��40��5�      $	��180��5�      $��0 0 30 0q�5�      ��5�      �� *SaveNewProductCommand+��5�      �� $ wdAddCus��5�      5�      5�      