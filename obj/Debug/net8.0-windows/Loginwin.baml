   M S B A M L   `   `   `  ����	  Matau    WpfApp2.Loginwin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Login��5   	   $	��500��6   $	��900��6$    � 
ResizeMode$ NoResize=�60   
���   � � WindowStartupLocation$ CenterScreen=�6Y   .��5      � ���#F2F2F2 � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5	      $
��1.2* �6   .+�5   
   r� -   5         r�Name$ videoPlayer��5   '   $��0��6    r� Source$W QC:\Users\신종덕\OneDrive\바탕 화면\프로젝트\Mataju\resource\loginb.mp4?�5       r� LoadedBehavior$
 Play=�6\    r� Stretch$
 Fill=�6r    � Cursor$  ��6�   � 5   
   $��1��6   	 � RowDefinitions	 5      �� 5      $��1* �6    �� 5      $
��0.5* �6    �� 5      $
��0.5* �6    �� 5      $��1* �6    .+�5      �� $��0��6   $��Login��6%   $��24(�5       $
��Bold"�6&   $��Center=�68   $	��Top=�6U   $��0,94,0,0q�6m   �� 5#      $��1��6   $��	15,0,15,0q�6&   .+�5$      �� $��	아이디��6   $��14(�6'   $��15,0,0,0q�65   �� 5%      -   5        
 ��Name$
 nameText��5%      $��30��6,   $	��200��68   $��	0,10,0,10q�6D   $��Center=�6W   5&      �� 5)      $��1��6   $��
15,96,15,0q�6&   $��2��6:   .+�5*      �� $��비밀번호��6   $��14(�6(   $��15,0,0,0q�66   G� 5+      -   5         G�Name$ pwText��5+      $��30��6.   $	��200��6:   $��	0,10,0,10q�6F   $��Center=�6Y   5,      �� 5/      $��3��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��0,10,0,0q�6\   .+�50      �� -   5         ��Name$ loginBtn��50      $	��Top=�6+   $��	로그인��6C   $��80��6Q   $��30��6\   $
��12,0q�6h   6v   �� 51      -   5        $ signBtn��51      $	��Top=�6*   $��회원가입��6B   $��80��6Q   $��30��6\   $
��12,0q�6h   6v   52      53      54      55      