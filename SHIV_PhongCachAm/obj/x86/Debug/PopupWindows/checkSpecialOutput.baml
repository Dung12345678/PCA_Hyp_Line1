   M S B A M L   `   `   `  ����K  GSHIV_PhongCachAm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SHIV_PhongCachAm.PopupWindowsSHIV_PhongCachAm.PopupWindows  5   	   6    0SHIV_PhongCachAm.PopupWindows.checkSpecialOutput   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:SHIV_PhongCachAm.PopupWindows     5   	     � Title$!  Nhập xuất đặc biệt��5   	   $	��230��6$   $	��550��61    � WindowStartupLocation$ CenterScreen=�6=    � Icon$M G/SHIV_PhongCachAm;component/sumitomo_heavy_industries_416x416_LE3_4.ico��6b    � 	Resources 5	         comboBoxSpecialOutput �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value
 � ColumnDefinitions �� Orientation �� Path��%_  &	        �� 5
   
   " ��6.   .�5      ��  � �� 5      �� 5      .R�5      � ��5      �� 5   "   " �6(    5   &   P� 5   *    �@J�IsMouseOver	 . . �5   .   ��  � �� �	#FFEAF6FF6K   5   +   5   #   
 5      �� 5   "   $��10 �63   �� 5   "   $��* �63   .+�5      �� $��1��6)   $ 
Horizontal=�69   .+�5   "   �� $��Italic$�6E   ��6,   �� $ Id�6E   �� 5   "   $	�� - ��6,   $��Italic$�67   �� 5   "   $��Italic$�6G   
���������6,   �� $
 Info�6Z   5       5!      5"      5$      5%      5&      .��5'      �  � RowDefinitions 5(   
   �� 5)      $
��3.5* �6   �� 5*      $��7* �6   .+�5,   
   �� $��0��6   $��	15,20,0,0q�6   $��18(�60   $
��Bold"�6>   $8��2Lựa chọn điều kiện xuất đặc biệt :��6P   � 5-   
   $��1��6   .+�5.      �� .+�5/      �� -   5        $��
lblInfo001��5/      #��[  6-   $��	20,0,20,5q�6\   ��6o   �� �� 50      -   5        $��
lblInfo002��50      #��[  6-   $��	20,0,20,5q�6\   ��6o   �� �� 51      -   5        $��
lblInfo003��51      #��[  6-   $��	20,0,20,5q�6\   ��6o   �� �� 52      -   5        $��
btnConfirm��52      $��
20,10,20,5q�6+   $��25��6?   $��Xác nhận��6K   $
��Bold"�6^   $��Center=�6p   $	��100��6�   
�������6�   53      54      55      56      