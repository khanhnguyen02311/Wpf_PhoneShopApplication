   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5      !    WpfApp2.View.AddProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      &localclr-namespace:WpfApp2.View  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  60   -   5        $��pageaddproduct��5	         AddProductVM  � DataContext#  [  5
       N� Title$ AddProductPage��5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+   CommandParameter 6F   ��  �� ElementName$ pageaddproduct��5      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   	 � RowDefinitions	 5   
   �� 5      $��40 �6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      $��10 �6   .+�5!   
   �� $��THÊM MỚI SẢN PHẨM��6   $��Roboto)�5"      
�������$��20(�5$      $
��Bold"�5%      $��Center=�5&      $��Center=�5'      $��1��5(      
 J� Effect
 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         ShadowDepth$ 2Q�6#      	Direction$	 315Q�5+   #      Color$ Black��5,   #      Opacity$	 0.8Q�5-   #   5/      �� 51   
   $��1��6   $��Roboto)�53      $
��Bold"�54      $��15(�55      $��50��56      $��Stretch=�57      $��Center=�58      $��	20 0 10 0q�59      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên sản phẩm��5:      $��0 0 4 0q�5;       % !MaterialDesignFloatingHintTextBox#��[ 5<      
����������#DDDDDD*  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�5?         
Foreground
 �����6  0MaterialDesignThemes.Wpf.BottomDashedLineAdorner   Brush
 �������52      �� *NameProduct+5A      �� 5B   
   $��2��6   $��Roboto)�5D      $
��Bold"�5E      $��15(�5F      $��50��5G      $��Stretch=�5H      $��Center=�5I      $��	20 0 10 0q�5J      $ Mã sản phẩm��5K      $��0 0 4 0q�5L      #��[ 5M      
����������#DDDDDD$
 Dark=�5P      
 �����
 �������5C      �� *	IdProduct+5R      �� 5S   
   $��3��6   $��Roboto)�5U      $
��Bold"�5V      $��15(�5W      $��50��5X      $��Stretch=�5Y      $��Center=�5Z      $��	20 0 10 0q�5[      $ Giá sản phẩm��5\      $��0 0 4 0q�5]      #��[ 5^      
����������#DDDDDD$
 Dark=�5a      
 �����
 �������5T      �� *PriceProduct+5c      �� 5d   
   $��4��6   $��Roboto)�5f      $
��Bold"�5g      $��15(�5h      $��50��5i      $��Stretch=�5j      $��Center=�5k      $��	20 0 10 0q�5l      $ Mô tả sản phẩm��5m      $��0 0 4 0q�5n      #��[ 5o      
����������#DDDDDD$
 Dark=�5r      
 �����
 �������5e      �� *DescriptionProduct+5t      �� 5u   
   $��5��6   $��Roboto)�5w      $
��Bold"�5x      $��15(�5y      $��50��5z       �� 
IsReadOnly . $��Stretch=�5|      $��Center=�5}      $��	20 0 10 0q�5~      $ Mã loại sản phẩm��5      $��0 4 4 0q�5�      #��[ 5�      
����������#DDDDDD$
 Dark=�5�      
 �����
 �������5v      �� *SelectedItem.Id+5�      �� 5�   
   -   5        $��comboProductTypes��5�      $��1��5�      $��1��5�      $��2��5�       & "MaterialDesignFloatingHintComboBox#��[ 5�      $��0 4 4 0q�5�      
 � Tag$
 null��5�      $��Roboto)�5�      $
��Bold"�5�      $��15(�5�      $��50��5�      $��Stretch=�5�      $��Center=�5�      $��	55 0 10 5q�5�      $  Chọn loại sản phẩm��5�      
����������#DDDDDD$
 Dark=�5�      
 �����
 �������5�      �� *ListTypeItem+ �� SelectedItem 5�      �� *SelectedItem+ �� Text 5�      �� *NameTypeProduct+��5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�5�      $��84��5�      $
��Left=�5�      .+�5�      ��  ��Name$ txbName��5�   !   $	��100��5�   !   $
��Auto��5�   !   $
��Left=�5�   !   ��5�   !   �� *Name+5�   !   5�      5�      5�      �� 5�   
   $��1��6   $��1��5�      $��25��5�      $��25��6   $��Center=�5�      $
��Left=�5�      $��20q�5�       * &MaterialDesignFloatingActionMiniButton#��[ 5�      
���������5�      �� *OpenTypeProductCommand+��5�      �� $ pageaddproduct��.��5�      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$	 Add=�6&   $��20��5�   &   $��20��5�   &   
�������5�   &   5�      �� 5�   
   $��Loại sản phẩm��6   $
��Bold"�5�      $��1��5�      $��17(�5�      $��Roboto)�5�      $��1��5�      $��55 0 0 0q�5�      $
��Left=�5�      $��Center=�5�      ���#DDDDDD5�      �� 5�   
   $��1��6   $��3��6!   $��25��5�      $��25��6   $��20q�5�      $��Center=�5�      $
��Left=�5�      #��[ 5�      
���������5�      �� *LoadImageCommand+��5�      �� $ wdAddproduct��.��5�      	  $	 Add=�6&   $��20��5�   &   $��20��5�   &   
�������5�   &   5�      �� 5�   
   $��Ảnh sản phẩm��6   $
��Bold"�5�      $��1��5�      $��3��5�      $��17(�5�      $��Roboto)�5�      $��Stretch=�5�      $��Center=�5�      $��	55 0 10 0q�5�      ���#DDDDDD5�      �� 5�   
   $��1��6   $��4��5�      $��2��5�      
 5�        5�      $ White��6#   $	 270Q�5�   #   $ 1Q�5�   #      
BlurRadius$ 10Q�5�   #   ._�5�      �� -   5        $��
imgProduct��5�      $��UniformToFill=�5�      $	��150��5�      $	��150��6    $��Stretch=�5�      ��5�      �� *ImageProduct+ J� Clip 5�      @� 5�       @� RadiusX$ 75Q�5�       @� RadiusY$ 75Q�5�       @� Center$ 75,75&�5�      5�      5�      (
  "System.Windows.Controls.DatePicker
  5�   
   -   5         
 Name$ 	DateInput��5�      $��1��5�      $��2��6"   $��Roboto)�5�      $
��Bold"�5�      $��15(�5�      $��50��5      $��Stretch=�5     $��Center=�5     $��Center=�5     $��	20 0 20 0q�5     $ Ngày nhập kho��5     $��0 0 4 0q�5      ( $MaterialDesignFloatingHintDatePicker#��[ 5     
����������#DDDDDD$
 Dark=�5
     
 �����
 �����  
  Text  5�      �� *
DateText+! �� Mode$! OneWayToSource=�5     �� 5  
   $��2��6   $��2��5     $��Roboto)�5     $
��Bold"�5     $��15(�5     $��50��5     $��Stretch=�5     $��Center=�5     $��	20 0 20 0q�5     $ Số lượng nhập kho��5     $��0 4 4 0q�5     #��[ 5     
����������#DDDDDD$
 Dark=�5     
 �����
 �������5     �� *AmountProduct+5     �� 5  
   $��3��6   $��2��5      $��Roboto)�5"     $
��Bold"�5#     $��15(�5$     $��50��5%     $��Stretch=�5&     $��Center=�5'     $��	20 0 20 0q�5(     $ Vốn bỏ ra��5)     $��0 4 4 0q�5*     #��[ 5+     
����������#DDDDDD$
 Dark=�5.     
 �����
 �������5!     �� *	Capital+50     �� 51  
   $��2��6   $��4��52     $��2��53     $
��Lưu��56     $
��Bold"�57     
�������
�������+  %MaterialDesignThemes.Wpf.ButtonAssist"   CornerRadius$" 5��5:     $��35��5;     $	��130��5<     $��17(�5=     $��0q�5>     $��Roboto)�5?     $��Bottom=�5@     $��Right=�5A     $��	0 0 20 20q�5B     ��54     �� *SaveNewProductCommand+��55     �� $ pageaddproduct��5B     �� 5F  
   $
��Left=�5G     
�������
�������$��Center=�5J     $��25��5K     $��25��6   $��5q�5L     -  'System.Windows.Input.NavigationCommands#   
BrowseBack#��Z# 5M      / +MaterialDesignFloatingActionMiniLightButton#��[ 5N     .��5O     	  $ KeyboardArrowLeft=�5P     $��20��5Q     $��20��5R     5S     �� 5U  
   $
��Left=�5V     
�������
�������$��Center=�5Y     $��25��5Z     $��25��6   $��35,0,0,0q�5[     $   BrowseForward#��Z$ 5\     #��[ 5]     .��5^     	  $ KeyboardArrowRight=�5_     $��20��5`     $��20��5a     5b     �� 5c  
   $
��Left=�6   
�������
�������$��Center=�5f     $��25��5g     $��25��6   #��[ 5j     $��65,0,0,0q�5k     ��5h     �� *RefreshCommand+��5i     �� $ pageaddproduct��.��5l     	  $ Refresh=�5m     $��20��5n     $��20��5o     5p     5s     5t     