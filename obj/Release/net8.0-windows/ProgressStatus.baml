   M S B A M L   `   `   `  ���� @  <Matau, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2      WpfApp2.ProgressStatus   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WpfApp2       N� Title$  ProgressStatus��.����  �� Orientation$ Vertical=�$	��Top=�$��10,30,10,10q�$	��430��.+�� $��0,0,0,10q� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��▶ 예약 현황��$��16(�$
��Bold"�$��Center=��� -    ��Name$ SalesInquirybtn��$��조회��$��80��$��20��$��1��$��Right=�$��0,0,10,0q�$��Center=��� $
��Auto=�$
��Auto=�$	��120��.��&   System.Windows.Controls.DataGrid  -     Name$ SalesStatusGrid1��   AutoGenerateColumns$ False��   CanUserAddRows$ False��   
IsReadOnly$
 True��   HeadersVisibility$	 All=�$��Stretch=�$��Stretch=�	   ColumnHeaderStyle	 �� 
 �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"
  .���  �� Property � �� �� Value$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 고유번호��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
UniqueId+  $ 지역��$	 150  �� *Region+  $ 분양모델��$ 60  �� *Model+  $ 수량��$ 60  �� *
Quantity+  $ 금액��$	 100  �� *Amount+  $ 진행현황��$	 150  �� *Status+  $ 비고��$	 150  �� *	Remarks+� $��	0,10,0,10q� �� $��* ��� $
��Auto �.+��� $��▶ 구매 현황��$��16(�$
��Bold"�$��Center=��� -   $ PurchaseInquiry��$��조회��$��80��$��20��$��1��$��Right=�$��0,0,10,0q�$��Center=��� $
��Auto=�$
��Auto=�$	��120��.��  -   $ SalesStatusGrid2��$ False��$ False��$
 True��$	 All=�$��Stretch=�$��Stretch=�	 �� "
  .���  � ��$ Center=�   $ 고유번호��$ 60  �� *
UniqueId+  $ 지역��$	 150  �� *Region+  $ 분양모델��$ 60  �� *Model+  $ 수량��$ 60  �� *
Quantity+  $ 금액��$	 100  �� *Amount+  $ 상태��$	 150  �� *Status+  $ 비고��$	 150  �� *	Remarks+