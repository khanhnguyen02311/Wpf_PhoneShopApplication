   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5   	   5clr-namespace:WpfApp2.ViewModelWpfApp2.ViewModel  5	   N   "    WpfApp2.View.ListProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp2.View     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   ,local1clr-namespace:WpfApp2.ViewModel  6N   -   5          N�Name$  wdListproduct��5   	      ListProductVM � DataContext# [  5
       N� Title$ ListProduct��5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadWindowCommand+5       � 	Resources 5      &    WpfApp2.ViewModel.PriceConverter  PriceConverter��%   &	         5   
   6    5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   �� $��0��6   $��DANH SÁCH SẢN PHẨM��5       $��20(�5!      $��Roboto)�5"      $
��Bold"�5#      
�������$��Center=�5%      $��Center=�5&      	 J� Effect	 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(      
   ShadowDepth$
 2Q�6#      	Direction$	 315Q�5)   #      Color$ Black��5*   #      Opacity$	 0.8Q�5+   #   5-      �� 50   
   -   5         ��Name$ btnbackward��52      $
��Left=�51      
�������
�������$��Center=�55      $��25��56      $��25��6   $��5q�57      -  'System.Windows.Input.NavigationCommands   
BrowseBack#��Z 58       / +MaterialDesignFloatingActionMiniLightButton#��[ 5:      ��59      ��  �� ElementName$ wdListproduct��.��5;      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardArrowLeft=�5<      $��20��5=      $��20��5>      5@      �� 5B   
   $
��Left=�5C      
�������
�������$��Center=�5F         BrowseForward#��Z 5G      $��25��5I      $��25��6   $��35 0 0 0q�5J      #��[ 5L      ��5H      �� $ wdListproduct��.��5M        $ KeyboardArrowRight=�5N      $��20��5O      $��20��5P      5R      �� 5T   
   $
��Left=�5U      
�������
�������$��Center=�5X      $��25��5[      $��25��6   $��65 0 0 0q�5\      #��[ 5^      ��5Y      �� *RefreshCommand+��5Z      �� $ wdListproduct��.��5_        $ Refresh=�5`      $��20��5a      $��20��5b      5d      �� 5f   
    �� Orientation$ 
Horizontal=�6   $��Right=�5g      $��Center=�5h      $
��20 0q�5i      .+�5j      �� $��30��6   $��90��6!     MaterialDesignRaisedButton#��[ 5k      $��Thêm SP��5l      $��0q�5m      +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 15��5n      $��Center=�5o      $��Center=�5p       � ToolTip$ THÊM SẢN PHẨM��5s      $��Roboto)�5t      $��14(�5u      
�������$��Center=�5w      $��Center=�5x      $��0 0 5 0q�5y      ��5q      �� *AddProductCommand+��5r      �� $ wdListproduct��5y      �� 5{      $��30��6   $��80��6!   #��[ 5|      $��Xuất��5}      $��0q�5~      $ 15��5      $��Center=�5�      $��Center=�5�      $ XUẤT DS SP RA EXCEL��5�      
�������$��Roboto)�5�      $��14(�5�      $��Center=�5�      $��Center=�5�      $��0 0 5 0q�5�      ��5�      �� *ExportCommand+��5�      �� $ wdListproduct��5�      �� 5�      $��30��6   $��80��6!   #��[ 5�      $��Nhập��5�      $��0q�5�      $ 15��5�      $��Center=�5�      $��Center=�5�      $ THÊM SP TỪ EXCEL��5�      $��Roboto)�5�      $��14(�5�      
�������$��Center=�5�      $��Center=�5�      ��5�      �� *ImportCommand+��5�      �� $ wdListproduct��5�      5�      � 5�   
   $��1��6    � ColumnDefinitions 5�      �� 5�      $
��2.2* �6#   �� 5�      $��95 �6#   �� 5�      $
��1.5* �6#   �� 5�      $��1* �6#   �� 5�      $��1* �6#   �� 5�      $	��100 �6#    5�      �� 5�      .+�5�      �� -   5        $��editSearchProduct��5�      $��0��5�      $
��Left=�5�      $��30��5�      $��Center=�5�      $��Stretch=�5�      ���#DDDDDD$��14(�5�      $��4q�5�      $��Roboto)�5�      )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Tên sản phẩm��5�      $��20 0 5 0q�5�      ��5�      �� *TextSearchProduct+5�      �� 5�      -   5        $��btnSearchProduct��5�      $��1��5�      $��30��5�      $��85��6!   $
��Left=�5�       ' #MaterialDesignRaisedSecondaryButton#��[ 5�      ���#DDDDDD
�������$ 3��5�      $��Tìm kiếm��5�      $��0q�5�      $��Center=�5�      $��Center=�5�      $��Roboto)�5�      $��14(�5�      $��Center=�5�      $��Center=�5�      ��5�      �� *SearchProductCommand+��5�      �� $ wdListproduct��5�      �� 5�      -   5         ��Name$ comboProductArrange��5�      $��2��5�      $
��Left=�5�      $��14(�5�      $
��Left=�5�      $��Center=�5�      $��4q�5�      $  Sắp xếp theo giá cả��5�      ���#DDDDDD*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�5�      $��Italic$�5�      $��Roboto)�5�      $��Stretch=�5�      $��Center=�5�      $��30��5�      $	��5 0q�5�      ��5�      �� *ArrangePrice+ �� SelectedIndex 5�      �� *SelectedItem+ 5�        5�      $ SelectionChanged��6%   . 5�         60   �� *SelectionChangedCommand+   CommandParameter 5�   ,   �� $ comboProductArrange��5�      5�      �� 5�      -   5        $��editFilterFrom��5�      $��3��5�      $
��Left=�5�      $��14(�5�      $
 Từ��5�       
  FloatingOffset$ 0,-15&�5�       
  FloatingScale$	 .95Q�5�      ���#DDDDDD$
 Dark=�5�      $��Stretch=�5�      $��Center=�5�      $��Roboto)�5�       % !MaterialDesignFloatingHintTextBox#��[ 5�      $��30��5�      $	��5 0q�5�      $��4q�5�      ��5�      �� *TextPriceFrom+5�      �� 5      -   5        $��
txtPriceTo��5     $��4��5      $
��Left=�5     $��14(�5     $ Đến��5     $ 0,-15&�5     $	 .95Q�5     ���#DDDDDD$
 Dark=�5	     $��Stretch=�5
     $��Center=�5     $��Roboto)�5     #��[ 5     $��30��5     $	��5 0q�5     $��4q�5     ��5     �� *TextPriceTo+5     �� 5     -   5        $��btnSearchPrice��5     $��6��5     $
��Tìm��5     $
��Bold"�5     $��14(�5     $��1q�5     $��Right=�5     $��Center=�5     ���#1D1D2C���#DDDDDD
�������$��Roboto)�5      #��[ 5!     $��30��5"     $��70��5#     $��0 0 20 0q�5$     ��5     �� *FindPriceCommand+��5     �� $ btnSearchProduct��5$     5'     �� 5(  
   $��2��6   $ 
Horizontal=�5)     $��Center=�5*     $��Bottom=�5+     $��0 0 0 10q�5,     .+�5.     �� 
������ ���#DDDDDD$��Center=�52     $��25��53     $��25��6%   $��0 0 10 0q�54     #��[ 55     $��1��6^   ��50     �� *PreviousPageCommmand+��51     �� $ wdListproduct��.��56       $ KeyboardArrowLeft=�57  %   $��20��58  %   $��20��59  %   ���#DDDDDD5:  %   5;     �� 5=     -	   5        $ comboPageIndex��5=     $��2q�5A     $��14(�5B     $
��Bold"�5C     $��0q�5D     $��Italic$�5E     ���#DDDDDD$
 Dark=�5G     $��Roboto)�5H     $��Center=�5I     $��Center=�5J     $��55��5K     $��0 0 10 0q�5L      �� Text 5>     �� *TextComboboxPage+ �� Mode$ TwoWay=���5?     �� *
ListPage+$ TwoWay=� 5@     �� *
NumPages+$ TwoWay=� 5N       5O     $ SelectionChanged��6%   . 5P        60   �� *SelectionPageCommand+ 5Q  ,   �� $ comboPageIndex��5R     5V     �� 5X     
������ ���#DDDDDD$��Center=�5\     $��25��5]     $��25��6%   $��0q�5^     #��[ 5_     $��1��6^   ��5Y     �� *NextPageCommmand+��5Z     �� $ wdListproduct��.��5`       $ KeyboardArrowRight=�5a     $��20��5b     $��20��5c     ���#DDDDDD5d     5e     5h     �� 5i  
   -
   5        $��	lvproduct��5k     $��Stretch=�5l     $��Stretch=�5m     $��2��5n     $��20 10 20 40q�6    ��5i     �� *ListProduct+ 5j     �� *SelectedItemProduct+��5p     �� 5q     .R�5r     A�   A� Columns$  6��6"   ! A� Rows$! 2��5s  "   5t     5u     ��5x     �� 5y     .R�5z     �� $ Vertical=�6!   .+�5{     �� 	 5|       5}  "   $ #051533��5~  %   $	 270Q�5  %   $
 1Q�5�  %   "   
BlurRadius$" 10Q�5�  %   ._�5�     �� $��Uniform=�5�  $   $��Center=�5�  $   $	��125��5�  $   $	��100��60   $��Center=�5�  $   ��5�  $   �� *	ImagePath+# J� Clip# 5�  "   @� 5�  &   $ @� RadiusX$$ 50Q�5�  )   % @� RadiusY$% 50Q�5�  )   & @� Center$& 50,50&�5�  )   5�     5�     �� 5�     $	��110��5�  $   ' �� TextAlignment$' Center=�5�  $   $
��Wrap=�5�  $   $��11(�5�  $   $��Center=�5�  $   $��Roboto)�5�  $   $
��Bold"�5�  $   ���#DDDDDD��5�  $   �� *Name+5�  $   �� 5�     $��Roboto)�5�  $   $��Center=�5�  $   $' Center=�5�  $   ���#ec1c24���#DDDDDD$��10(�5�  $   ( �� Padding$( 1q�5�  $   ��5�  $   �� ) �� Path$) Price�* �� 	Converter#* [ �� 5�  %   .�6+   B� .�65   đ68   6D   5�     5�     5�      5�       5�     $ PreviewMouseLeftButtonUp��6!   . 5�        6,   �� *SelectProductCommand+ 5�  ,   �� $ wdListproduct��5�     5�     5�     5�     