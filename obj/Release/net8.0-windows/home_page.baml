   M S B A M L   `   `   `  ���� @  <Matau, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2      WpfApp2.home_page   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     'localclr-namespace:WpfApp2       N� Title$  	home_page��.���� $
��Auto=�$��Disabled=�.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��20q�$	��Top=�$��Center=�.+��� $'��!우리는 함께 성장합니다.��$��24(�$
��Bold"�
��� � �$��Center=�$
��0,10q��� $��16(�
���   � �� TextAlignment$ Center=��� $X�R혼자 가면 빨리 갈 수 있지만, 함께 가면 멀리 갈 수 있습니다.���� �� $E�?입주사의 성장이 곧 우리의 성장이라 믿습니다.���� �� $\�V지식과 경험을 나누는 것이 모두의 발전을 이끈다고 생각합니다.��� $��1��$��20q� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+��� $��0��
������� �� CornerRadius$ 10��$��10q�
�������$��1q�._��� $��10q�.+��� $��pictures/data.jpg��$��Uniform=�$	��150��$��0,0,0,10q�z�T� -   TranslateImage1�� T� Y$ 0Q� � Triggers :�  :� RoutedEvent$ 
MouseEnter��.[��� .���� .��W�  �� TargetProperty$, &RenderTransform.(TranslateTransform.Y)�		 W� To	 -10
 g� Duration$
 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $, &RenderTransform.(TranslateTransform.Y)�	 0$
 0:0:0.2D��� $��정보제공��$��18(�$
��Bold"�$ Center=�$��0,0,0,10q��� $��14(�
�������$ Center=��� $'�!사회 구조의 변화로 인해���� �� $.�(앞으로는 1인기업 증가 추세는���� �� $!�가속화 될 것입니다.���� �� $*�$혼자서도 책상에 앉아 창업���� �� $�할 수 있습니다.���� $��1��
�������$ 10��$��10q�
�������$��1q�._��� $��10q�.+��� $��pictures/help2.jpg��$��Uniform=�$	��150��$��0,0,0,10q�z�T� -   TranslateImage2��$ 0Q� :� $ 
MouseEnter��.[��� .���� .��W� $, &RenderTransform.(TranslateTransform.Y)�	 -10$
 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $, &RenderTransform.(TranslateTransform.Y)�	 0$
 0:0:0.2D��� $��동기부여��$��18(�$
��Bold"�$ Center=�$��0,0,0,10q��� $��14(�
�������$ Center=��� $)�#안정성과 수익성을 동시에���� �� $(�"얻을 수 있는 꾸준한 수익���� �� $&� 창출이 가능한 매력적인���� �� $*�$매력적인 사업 모델입니다.���� $��2��
�������$ 10��$��10q�
�������$��1q�._��� $��10q�.+��� $��pictures/hope.jpg��$��Uniform=�$	��150��$��0,0,0,10q�z�T� -   TranslateImage3��$ 0Q� :� $ 
MouseEnter��.[��� .���� .��W� $, &RenderTransform.(TranslateTransform.Y)�	 -10$
 0:0:0.2D�:� $ 
MouseLeave��.[��� .���� .��W� $, &RenderTransform.(TranslateTransform.Y)�	 0$
 0:0:0.2D��� $��네트워킹 기회��$��18(�$
��Bold"�$ Center=�$��0,0,0,10q��� $��14(�
�������$ Center=��� $(�"기본적으로 공간임대업의���� �� $$�성격을 띄고 있으므로,���� �� $(�"요식업 등 타 업종에 비해���� �� $�상대적으로 운영이���� �� $�용이합니다.��