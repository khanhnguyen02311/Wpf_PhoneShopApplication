   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5   	   =#clr-namespace:WpfApp2.MyUserControlWpfApp2.MyUserControl  5   	       WpfApp2.View.HomePage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp2.View     5   	   2uc#clr-namespace:WpfApp2.MyUserControl     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          N�Name$  homepage��5
   	    N� Title$ Trang chủ��5   	      DashBoardVM � DataContext# [  5   	   .��5      �  � RowDefinitions 5   
   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ listProductTitle��5      $��0��5      $��Danh sách sản phẩm��5      $��18(�5      $��Segoe UI)�5      $��Light"�5      $��Italic$�5      
�������$��Center=�5!      $��Center=�5"      $��	0 190 0 0q�5#       J� Effect 5$      3  -System.Windows.Media.Effects.DropShadowEffect  5%         ShadowDepth$
 1.25Q�6#      Color$ #151515��5&   #   +  %MaterialDesignThemes.Wpf.ShadowAssist	   Darken	 . 5'   #   5)      �� 5+   
   -   5        
 ��Name$
 btnListproduct��5+      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 35��5.      $	��180��5/      $	��180��50      $��1q�51      
����������#02225e$��0 0 0 30q�54      ��5,      �� *ListProductCommand+��5-      ��  �� ElementName$ homepage�� J� BitmapEffect 56      F� 57       F� ShadowDepth$
 1.25Q�6)    F� Color$ #282828��58   )   	 .  F� Softness$ 20Q�5:   )   .��5<      �� -   5        $��ListProductBorder��5<      $	��120��5=      $	��120��5>       �� CornerRadius$ 15��5?      ��5@      �� 5A       j� Stretch$ UniformToFill=�6!    �� ImageSource$' !/Resources/Images/listproduct.png��5B      5D      5E      �� 5G   
   $��0��6   $��1��5H      $��Thêm sản phẩm��5I      $��18(�5J      $��Segoe UI)�5K      $��Light"�5L      $��Italic$�5M      
�������$��Center=�5O      $��Center=�5P      $��	0 190 0 0q�5Q       5R        5S      $
 1.25Q�6#   $ #151515��5T   #   	 . 5U   #   5W      �� 5X   
   -   5        $
 btnAddproduct��5X      $ 35��5[      $	��180��5\      $	��180��5]      $��1q�5^      
����������#02225e$��1��5a      $��0��6!   $��0 0 0 30q�5b      ��5Y      �� *AddProductPageCommand+��5Z      �� $ homepage�� 5c      F� 5d      $
 1.25Q�6)   $ #282828��5e   )   	 . $ 20Q�5g   )   .��5i      �� -   5        $��AddProductBorder��5i      $	��120��5j      $	��120��5k      $ 15��5l      ��5m      �� 5n      $ UniformToFill=�6!   $&  /Resources/Images/addproduct.jpg��5o   !   5q      5r      �� 5t   
   $��1��6   $��0��5u      $��Tài chính��5v      $��18(�5w      $��Segoe UI)�5x      $��Light"�5y      $��Italic$�5z      
�������$��Center=�5|      $��Center=�5}      $��	0 190 0 0q�5~       5        5�      $
 1.25Q�6#   $ #151515��5�   #   	 . 5�   #   5�      �� 5�   
   -   5        $
 btnFinancial��5�      $ 35��5�      $	��180��5�      $	��180��5�      $��1q�5�      
����������#02225e$��0��5�      $��1��5�      $��0 0 0 30q�5�      ��5�      �� *FinancialPageCommand+��5�      �� $ homepage�� 5�      F� 5�      $
 1.25Q�6)   $ #282828��5�   )   	 . $ 20Q�5�   )   .��5�      �� -   5        $��	Financial��5�      $	��120��5�      $	��120��5�      $ 15��5�      ��5�      �� 5�      $ UniformToFill=�6!   $# /Resources/Images/statics.jpg��5�      5�      5�      �� 5�   
   $��1��6   $��1��5�      $��Tạo đơn hàng mới��5�      $��18(�5�      $��Segoe UI)�5�      $��Light"�5�      $��Italic$�5�      
�������$��Center=�5�      $��Center=�5�      $��	0 190 0 0q�5�       5�        5�      $
 1.25Q�6#   $ #151515��5�   #   	 . 5�   #   5�      �� 5�   
   -	   5        $
 btnNewproduct��5�      $ 35��5�      $	��180��5�      $	��180��5�      $��1q�5�      
����������#02225e$��1��5�      $��1��5�      $��0 0 0 30q�5�      ��5�      �� *AddBillCommand+��5�      �� $ homepage�� 5�      F� 5�      $
 1.25Q�6)   $ #282828��5�   )   	 . $ 20Q�5�   )   .��5�      �� -
   5        $��
Newproduct��5�      $	��120��5�      $	��120��5�      $ 15��5�      ��5�      �� 5�      $ UniformToFill=�6!   $ /Resources/Images/new.png��5�   !   5�      5�      �� 5�   
   $��0��6   $
��Left=�5�      
�������
�������$	��Top=�5�      $��25��5�      $��25��6   $	��5 7q�5�      -  'System.Windows.Input.NavigationCommands   
BrowseBack#��Z 5�       / +MaterialDesignFloatingActionMiniLightButton#��[ 5�      {�.  .��5�      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardArrowLeft=�5�      $��20��5�      $��20��5�      5�      �� 5�   
   $
��Left=�6   
�������
�������$	��Top=�5�         BrowseForward#��Z 5�      $��25��5�      $��25��6   $
��35 7q�5�      #��[ 5�      ��5�      �� $ wdListproduct��.��5�        $ KeyboardArrowRight=�5�      $��20��5�      $��20��5�      5�      5�      5�      