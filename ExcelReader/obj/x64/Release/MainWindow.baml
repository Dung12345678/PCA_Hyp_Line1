   M S B A M L   `   `   `  ����   ExcelReader+    %SchoolManagement_ExcelData.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Manage Excel Data��$	��350��$	��575��
����·�.���  � RowDefinitions �� $	��40* ��� $
��202* �.+��� -   $��btnRefreshRecord��$��Refresh Record��$��0��$��16(�$��
342,1,26,5q�&   System.Windows.Controls.DataGrid  -   $��dataGridStudent��   AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    RowBackground
 �����$��2��
����ح�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
Student ID��   Width$ 70 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	StudentID+  $
 Name�� �� *Name+  $ Email��$	 140  �� *Email+  $ Class��$ 80  �� *Class+  $ Address��$	 170  �� *	Address+�� $
��Left=�$��	20,10,0,0q�$��0��$	��Top=�$
��Bold"�$��16(�
��� � �$%��Showing All Student Information��