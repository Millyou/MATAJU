   M S B A M L   `   `   `  ����@  <Matau, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5          WpfApp2.ProgressStatus   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:WpfApp2     5        N� Title$  ProgressStatus��5	      .��5      ��  �� Orientation$ Vertical=�6   $	��Top=�6(   $��10,30,10,10q�6@   $	��430��6U   .+�5   
   � $��0,0,0,10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��▶ 예약 현황��6   $��16(�6'   $
��Bold"�65   $��Center=�6G   �� 5      -   5         ��Name$ SalesInquirybtn��5      $��조회��6.   $��80��6;   $��20��6F   $��1��6R   $��Right=�6b   $��0,0,10,0q�6~   $��Center=�6�   6�   5      �� 5   
   $
��Auto=�6   $
��Auto=�6<   $	��120��6_   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ SalesStatusGrid1��5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         
IsReadOnly$
 True��5         HeadersVisibility$	 All=�5      $��Stretch=�5      $��Stretch=�5       	   ColumnHeaderStyle	 5"      �� 5#      
 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  6   .�5$      ��  �� Property � �� �� Value$ Center=�6G   5%         Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ 고유번호��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
UniqueId+6T     5)      $ 지역��6)   $	 150 6P    65   �� *Region+6P     5*      $ 분양모델��6)   $ 60 6Q    67   �� *Model+6Q     5+      $ 수량��6)   $ 60 6R    65   �� *
Quantity+6R     5,      $ 금액��6)   $	 100 6P    65   �� *Amount+6P     5-      $ 진행현황��6)   $	 150 6R    67   �� *Status+6R     5.      $ 비고��6)   $	 150 6Q    65   �� *	Remarks+6Q   50      51      � 54   
   $��	0,10,0,10q�6    55      �� 56      $��* �6#   �� 57      $
��Auto �6#   .+�5:      �� $��▶ 구매 현황��6   $��16(�6'   $
��Bold"�65   $��Center=�6G   �� 5;      -   5        $ PurchaseInquiry��5;      $��조회��6.   $��80��6;   $��20��6F   $��1��6R   $��Right=�6b   $��0,0,10,0q�6~   $��Center=�6�   6�   5<      �� 5?   
   $
��Auto=�6   $
��Auto=�6<   $	��120��6_   .��5A        -   5        $ SalesStatusGrid2��5A      $ False��5B      $ False��5C      $
 True��5D      $	 All=�5E      $��Stretch=�5F      $��Stretch=�5G      	 5J      �� 5K      "
  6   .�5L      ��  � ��$ Center=�6G   5M       5O        5P      $ 고유번호��6)   $ 60 6T    67   �� *
UniqueId+6T     5Q      $ 지역��6)   $	 150 6P    65   �� *Region+6P     5R      $ 분양모델��6)   $ 60 6Q    67   �� *Model+6Q     5S      $ 수량��6)   $ 60 6R    65   �� *
Quantity+6R     5T      $ 금액��6)   $	 100 6P    65   �� *Amount+6P     5U      $ 상태��6)   $	 150 6P    65   �� *Status+6P     5V      $ 비고��6)   $	 150 6Q    65   �� *	Remarks+6Q   5X      5Y      5Z      5\      