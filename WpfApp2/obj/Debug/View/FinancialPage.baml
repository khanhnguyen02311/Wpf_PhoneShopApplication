   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp2.ViewWpfApp2.View  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      =#clr-namespace:WpfApp2.MyUserControlWpfApp2.MyUserControl  5   	        WpfApp2.View.FinancialPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WpfApp2.View     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      2uc#clr-namespace:WpfApp2.MyUserControl     5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   -   5          N�Name$  financialPage��5   	      FinancialVM � DataContext# [  5   	    N� Title$ Tài chính��5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadFinancialCommand+   CommandParameter 5   $   ��  �� ElementName$ financialPage��5      .��5      � 	 � ColumnDefinitions	 5   
   �� 5      �� 5      
 � RowDefinitions
 5   
   �� 5      $��40 �6   �� 5       �� 5!      $��20 �6   �� 5"      �� 5#      $��25 �6   .+�5&   
   �� $��TÀI CHÍNH��6   $��Center=�5'      $��Center=�5(      $��Roboto)�5)      $
��Bold"�5*      $��0��5+      $��0��5,      $��2��5-      $��20(�5.      
������� J� Effect 50      3  -System.Windows.Media.Effects.DropShadowEffect  51         ShadowDepth$ 2Q�6#      	Direction$	 315Q�52   #      Color$ Black��53   #      Opacity$	 0.8Q�54   #   56      �� 59   
   $
��Left=�5:      
�������
�������$��Center=�5=      $��25��5>      $��25��6   $��5q�5?      -  'System.Windows.Input.NavigationCommands   
BrowseBack#��Z 5@       / +MaterialDesignFloatingActionMiniLightButton#��[ 5A      .��5B      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardArrowLeft=�5C      $��20��5D      $��20��5E      5F      �� 5H   
   $
��Left=�5I      
�������
�������$��Center=�5L      $��25��5M      $��25��6   $��35,0,0,0q�5N         BrowseForward#��Z 5O      #��[ 5P      .��5Q        $ KeyboardArrowRight=�5R      $��20��5S      $��20��5T      5U      �� 5V   
   $
��Left=�6   
�������
�������$��Center=�5Y      $��25��5Z      $��25��6   #��[ 5]      $��65,0,0,0q�5^      ��5[      �� *RefreshCommand+��5\      �� $ financialPage��.��5_        $ Refresh=�5`      $��20��5a      $��20��5b      5c      �� 5e   
   $��Thống kê tồn kho��6   $��Center=�5f      $��Center=�5g      $��2��5h      $��0��5i      $��14(�5j      $��Roboto)�5k      $��Italic$�5l      ���#DDDDDD5m      #  MaterialDesignThemes.Wpf.Card  5o   
   $��1��6   $��	20 5 10 5q�5p       J� Opacity$	 0.5Q�5q      #	  LiveCharts.Wpf.CartesianChart	  5s   
   $��1��6   $��25 10 15 10q�5t      &
   LiveCharts.Wpf.Charts.Base.Chart 
  LegendLocation$ Right=�5v      ���#DDDDDD 
  Series 5u      �� *AmountTonKhoChart+ 
  AxisX 5z        LiveCharts.Wpf.Axis     Title$ Loại hàng tồn kho��6      
ShowLabels .    
Foreground �#DDDDDD   Labels 5{      �� *AmountTonKhoLabels+5}       
  AxisY 5�        $ Số lượng��6    �#DDDDDD   MinValue$ 0Q�5�         	Separator 5�        LiveCharts.Wpf.Separator  5�         StrokeThickness$ 1Q�6(      Stroke �	#8EFFFFFF    StrokeDashArray$  8R�6O   5�      ! 
  DataTooltip! 5�      #  LiveCharts.Wpf.DefaultTooltip  5�      "   
BulletSize$" 20Q�6%   ���#3030305�   %   5�      �� 5�   
   $,��&Tỉ lệ lãi suất các mặt hàng��6   $��Center=�5�      $��Center=�5�      $��2��5�      $��1��5�      $��14(�5�      $��Roboto)�5�      $��Italic$�5�      ���#DDDDDD5�        5�   
   $��1��6   $��1��5�      $��	10 5 20 5q�5�      
�������$��1q�5�      $	 0.5Q�5�        LiveCharts.Wpf.PieChart  5�   
   $��1��6   $��1��5�      $��15 10 25 10q�5�      $ Right=�5�      ���#DDDDDD 5�      �� *ProportionLoiNhuanChart+! 5�        5�      $" 20Q�6%   ���#3030305�   )   5�      �� 5�   
   $*��$Thống kê nhập xuất theo ngày��6   $��Center=�5�      $	��Top=�5�      $��4��5�      $��0��5�      $��2��5�      $��14(�5�      $��Roboto)�5�      $��Italic$�5�      ���#DDDDDD5�        5�   
   $��3��6   $��0��5�      $
��20 5q�5�      $��2��5�      
�������$��1q�5�      $	 0.5Q�5�      	  5�   
   $��3��6   $��0��5�      $��2��5�      $��25 10q�5�      $ Right=�5�      ���#DDDDDD 5�      �� *DifferenceNhapXuatChart+ 5�        $ Thời gian��6    �#DDDDDD 5�      �� *DifferenceNhapXuatLabels+5�       5�        $ Số tiền��6    �#DDDDDD$ 0Q�5�       5�        5�      $ 1Q�6(    �	#8EFFFFFF$  8R�6O   5�      ! 5�        5�      $" 20Q�6%   ���#3030305�   )   5�      5�      5�      