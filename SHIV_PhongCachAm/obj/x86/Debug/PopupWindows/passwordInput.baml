   M S B A M L   `   `   `  ����K  GSHIV_PhongCachAm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:SHIV_PhongCachAm.PopupWindowsSHIV_PhongCachAm.PopupWindows  5   	   1    +SHIV_PhongCachAm.PopupWindows.passwordInput   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:SHIV_PhongCachAm.PopupWindows     5   	     � Title$  Đăng nhập��5   	   $	��130��6   $	��190��6(    � WindowStyle$ 
ToolWindow=�64    � WindowStartupLocation$ CenterScreen=�6M    � Icon$M G/SHIV_PhongCachAm;component/sumitomo_heavy_industries_416x416_LE3_4.ico��6r   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.3* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $��20 �6#   �� 5      $��* �6#   �� 5      $
��1.3* �6#   .+�5      �� $��1��6   $��	Username ��6(   $
��Bold"�69   $��Center=�6K   �� 5      -   5        $��txtUserName��5      $��2��6)   $��admin��69   $��0,0,20,0q�6F   $
��Bold"�6X   $��Center=�6j   5      � 5   
   $��2��6    5      �� 5      $��20 �6#   �� 5      $��* �6#   �� 5      $
��1.3* �6#   .+�5      �� $��1��6   $��	Password ��6(   $
��Bold"�69   $��Center=�6K   G� 5       -   5        $��txtPassword��5       $��2��6-   $��0,0,20,0q�6=   $
��Bold"�6O   $��Center=�6a   5!      �� 5"   
   -   5        $��btnConfirmPass��5"   /   $��3��6   $��0,0,0,3q�6   $��80��6x   $��20��6�   
�������$��OK��6�   $
��Bold"�6�   5#      5$      