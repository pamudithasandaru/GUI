   M S B A M L   `   `   `  ����  SalonApp"    SalonApp.Views.EmployeesPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      
�������.��5      � $��10q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0,0,0,10q�5      $
��Left=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� -   5         ��Name$ btnAdd��5      $	��100��5      $��35��5      $��5q�5       $	��Add��5"      �� 5#      -   5        $ 	btnUpdate��5$      $	��100��5%      $��35��5&      $��5q�5'      $��Update��5)      �� 5*      -   5        $ 	btnDelete��5+      $	��100��5,      $��35��5-      $��5q�5.      $��Delete��50      51      � 54   
   $��1��6   $��	0,10,0,10q�6    � ColumnDefinitions 55      �� 56      $
��Auto �6#   �� 57      $��* �6#   .+�5:      �� $��0��5;      $��0,0,10,0q�5<      $��Center=�5=      .+�5>      �� $��0,0,0,5q�5?      $
��Bold"�5@      $��Name:��5A      �� 5B      $��0,0,0,5q�5C      $
��Bold"�5D      $��Basic Salary:��5E      �� 5F      $��0,0,0,5q�5G      $
��Bold"�5H      $��OT (Hours):��5I      5J      �� 5L      $��1��6   .+�5M      �� -   5         ��Name$ txtName��5N      $	��250��5O      $��30��5P      $��0,0,0,5q�5Q      �� 5R      -   5        $ txtBasicSalary��5S      $	��250��5T      $��30��5U      $��0,0,0,5q�5V      �� 5W      -   5        $ 
txtOTHours��5X      $	��250��5Y      $��30��5Z      $��0,0,0,5q�5[      5\      5]      &   System.Windows.Controls.DataGrid  5`   
   -   5          Name$ employeeTable��5a      $��2��5b      $	��300��5c      $��0,10,0,0q�5d         AutoGenerateColumns$ False��5e         SelectionMode$ Single=�5f         Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 5i      
   Header$

 Name��5k      1  +System.Windows.Controls.DataGridBoundColumn   Binding 5j      �� *Name+5k        5l      $	 * 5m      $
 Basic Salary��5o       5n      �� *BasicSalary+5o        5p      $	 * 5q      $
 
OT (Hours)��5s       5r      �� *	OTHours+5s        5t      $	 * 5u      $
 Full Salary��5w       5v      �� *
FullSalary+5w      5y      5{      5|      