   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5   	   5clr-namespace:WpfApp2.ViewModelWpfApp2.ViewModel  5	   	   &     WpfApp2.View.DataFromExcelWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfApp2.View     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ,local1clr-namespace:WpfApp2.ViewModel  5	   	   -   5          �Name$  	dataexcel��5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      DataFromExcelVM � DataContext# [  5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseMoveWindowCommand+	   CommandParameter	 6O   �� 
 �� ElementName$
 	dataexcel��5       � 	Resources 5      &    WpfApp2.ViewModel.PriceConverter  PriceConverter��%   &	         5   
   6    5      ��5      �� 5   
   .��5      �  � Color$ #02225e��6    � Offset$ 0Q�6+   � 5      $ #181E36��6   $	 1.0Q�6+   5      .��5"      �  � RowDefinitions 5#   
   �� 5$      $��40 �6   �� 5%      $
��190* �6   �� 5&      $	��30* �6   �� 5'      $��70 �6   .+�5*   
   �� $��THÔNG BÁO��6   $��0��5+      $��Center=�5,      $��20(�5-      $
��Bold"�5.      $��Roboto)�5/      $��Center=�50      
������� J� Effect 52      3  -System.Windows.Media.Effects.DropShadowEffect  53         ShadowDepth$ 2Q�6#      	Direction$	 315Q�54   #      Color$ Black��55   #      Opacity$	 0.8Q�56   #   58      �� 59   
   -   5         ��Name$ btnOk��5;      $��3��59      $��
Đồng ý��5:      $	��120��5<      $��35��5=      $��Center=�5>      $��Center=�5?      $��Roboto)�5@      $��17(�5A      $��
0 0 130 10q�5D      ��5B      �� *	OkCommand+��5C      �� $
 	dataexcel��5D      �� 5E   
   -   5        $ 	btnCancel��5G      $��3��5E      $��
Hủy bỏ��5F      $	��120��5H      $��35��5I      $��Roboto)�5J      $��17(�5K      $��Center=�5N      $��Center=�5O      $��
130 0 0 10q�5P      ���#1D1D2C
����������#DDDDDD��5L      �� *CancelCommand+��5M      �� $
 	dataexcel��5S      �� 5T   
   -   5        $��
txtMessage��5U      $��2��5T      $��Roboto)�5W      $��14(�5X      $��30��5Y      $	��500��5Z      $��Center=�5[      $��Center=�5\       �� TextAlignment$ Center=�5]      $
��Bold"�5^      $
��Wrap=�5_      
���   ���5V      �� *Announcement+5`      � 5b   
   $��1��6   .+�5d      #  MaterialDesignThemes.Wpf.Card  $��10q�6"   $��Stretch=�5e   "   $��Stretch=�5f   "    J� Opacity$	 0.3Q�5g   "   �� 5h      -   5        $��akanaka��5j      $��Roboto)�5h      $��12(�5i      $��15q�5m      $��Stretch=�5n      ��5k      �� *ListFromExcel+ �� SelectedItem 5l      �� *SelectedItem+ 5p        ShadowEffect �� 
TargetType �� Property �� Value   
BlurRadius  	TextStyle��%�  &	       &	 �     �� 5q      " ��61   .�5r      ��  �@J�Effect 5s        5t   "   $ 20Q�63   $ White��5u   /   $	 0.7Q�5v   /   $ 0Q�5w   /   5y      5z      �� 5|      " ��6.   .�5}      ��  � ��$ Stretch=�6@   �� 5~       � ��$ 20��63   �� 5       � ��$ Stretch=�6>   �� 5�       � ��
 �����67   5�      5�       �� View 5�      �� 5�      .P�5�      ��  �� Width$	 100��6)    �� HeaderTemplate 5�      �� 5�   "   .R�5�   &   �� #��[ 6-   ._�5�   *   �� $
��Tên��64   #��[ 5�   -   $
��Bold"�5�   -   5�   +   5�   '   5�   #    �� CellTemplate 5�      �� 5�   "   .R�5�   &   �� #��[ 5�   0   ��5�   0   �� *Name+5�   0   5�   #   5�      �� 5�      $ 80��6)    5�      �� 5�   "   .R�5�   &   �� #��[ 6-   ._�5�   *   �� $��Id��64   #��[ 5�   -   $
��Bold"�5�   -   5�   +   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� #��[ 5�   0   ��5�   0   �� *Id+5�   '   5�   #   5�      �� 5�      $	 100��6)    5�      �� 5�   "   .R�5�   &   �� #��[ 6-   ._�5�   *   �� $��Ngày��64   #��[ 5�   -   $
��Bold"�5�   -   5�   +   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� #��[ 5�   (   ��5�   0   �� *Date+  �� StringFormat$  
dd-MM-yyyy��5�   '   5�   #   5�      �� 5�      $	 100��6)    5�      �� 5�   "   .R�5�   &   �� #��[ 6-   ._�5�   *   �� $
��Giá��64   #��[ 5�   -   $
��Bold"�5�   -   5�   +   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� #��[ 5�   0   ��5�   0   �� *Price+! �� 	Converter#! [ 5�   '   5�   #   5�      �� 5�      $	 140��6)    5�      �� 5�   "   .R�5�   &   �� #��[ 6-   ._�5�   *   �� $��Số lượng gốc��64   #��[ 5�   -   $
��Bold"�5�   -   5�   +   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� #��[ 5�   (   ��5�   0   �� *InitialAmount+5�   '   5�   #   5�      �� 5�      $	 160��6)    5�      �� 5�   "   .R�5�   &   �� #��[ 6-   ._�5�   *   �� $ ��Số lượng hiện tại��64   #��[ 5�   -   $
��Bold"�5�   -   5�   +   5�   '   5�   #    5�      �� 5�   "   .R�5�   &   �� #��[ 5�   (   ��5�   0   �� *CurrentAmount+5�   '   5�   #   5�      �� 5�      $	 100��6)    5�      �� 5�   "   .R�5   &   �� #��[ 6-   ._�5  *   �� $��Mô tả��64   #��[ 5  -   $
��Bold"�5  -   5  +   5  '   5  #    5     �� 5	  "   .R�5
  &   �� #��[ 5  (   ��5
  0   �� *Description+5  '   5  #   5     �� 5     $	 130��6)    5     �� 5  "   .R�5  &   �� #��[ 6-   ._�5  *   �� $��Id sản phẩm��64   #��[ 5  -   $
��Bold"�5  -   5  +   5  '   5  #    5     �� 5  "   .R�5  &   �� #��[ 5  (   ��5  0   �� *IdProductType+5   '   5!  #   5#     �� 5%     $	 130��6)    5&     �� 5'  "   .R�5(  &   �� #��[ 6-   ._�5)  *   �� $��Ảnh��64   #��[ 5*  -   $
��Bold"�5+  -   5,  +   5-  '   5.  #    50     �� 51  "   .R�52  &   �� #��[ 53  (   ��52  0   �� *	ImagePath+54  '   55  #   57     �� 59     $	 120��6)    5:     �� 5;  "   .R�5<  &   �� #��[ 6-   ._�5=  *   �� $��Vốn bỏ ra��64   #��[ 5>  -   $
��Bold"�5?  -   5@  +   5A  '   5B  #    5D     �� 5E  "   .R�5F  &   �� #��[ 5G  (   ��5F  0   �� *	Capital+#! [ 5H  '   5I  #   5K     5L      5O       5P     $ SelectionChanged��6%   . 5Q        60   �� *SelectionChangedCommand+	 5R  4   �� $
 wdListBillDetail��5S     5U     5V     5Y     5Z     