   M S B A M L   `   `   `  ����  SalonApp!    SalonApp.Views.BookingsPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      
�������.��5      � $��10q�6   ��5   
   �� 5        �� 
StartPoint$	  0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #4B0082��6    � Offset$	 0.0Q�6/   � 5      $ #8B004B��6   $	 1.0Q�6/   5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��	0,10,0,10q�6I   .+�5      �� -   5         ��Name$ btnAdd��5      $	��Add��6%   $��80��63   $��30��6>   $��
10,0,0,380q�6J   6^   �� 5      -   5        $ 	btnUpdate��5      $��Update��6(   $��80��69   $��30��6D   $��
70,0,0,380q�6P   6d   �� 5      -   5        $ 	btnDelete��5      $��Delete��6(   $��80��69   $��30��6D   $��
80,0,0,380q�6P   6d   5      �� 5   
   $ Vertical=�6   $��10q�6,   .+�5      � .+�5      �� -   5         ��Name$ txtName��5      $	��250��6+   $��30��67   $��255,57,255,-11q�6}   �� 5      -   5         ��Name$ placeholderName��5      $��Customer Name��65   
�������$��5,60,0,0q�5       $	��Top=�6.   $
��Left=�6F    J� IsHitTestVisible$ False��5!      	 K� ZIndex$	 1��65   5"      � 5%      
 � ColumnDefinitions
 5&      �� 5'      $
��470* �6'   �� 5(      $	��49* �6'   �� 5)      $
��241* �6'   .+�5+      �� -   5        $ txtNIC��5+      $	��250��6*   $��30��66   $��255,8,14,-8q�6|   $��2��6�   �� 5,      -   5        $ placeholderNIC��5,      $��
NIC Number��64   
�������$��5,12,0,0q�5-      $	��Top=�6.   $
��Left=�6F   $ False��5.      5/      � 52      .+�53      �� -   5        $ txtTime��53      $	��250��6+   $��30��67   $��255,6,255,-6q�6}   �� 54      -	   5        $ placeholderTime��54      $#��Booking Time (e.g., 10:00 AM)��65   
�������$��5,5,0,0q�55      $��Center=�6-   $
��Left=�6H   $ False��56      57      � 5:      .+�5;      �� -
   5        $ txtDate��5;      $	��250��6+   $��30��67   $��255,6,255,-6q�6}   �� 5<      -   5        $ placeholderDate��5<      $��Booking Date (YYYY-MM-DD)��65   
�������$��5,5,0,0q�5=      $��Center=�6-   $
��Left=�6H   $ False��5>      5?      � 5B      .+�5C      �� -   5        $ txtPhone��5C      $	��250��6,   $��30��68   $��255,6,255,-6q�6~   �� 5D      -   5        $ placeholderPhone��5D      $��Phone Number��66   
�������$��5,5,0,0q�5E      $��Center=�6-   $
��Left=�6H   $ False��5F      5G      � 5J      .+�5K      �� -   5        $ 
txtService��5K      $	��250��6.   $��30��6:   $��255,6,255,-6q�6�   �� 5L      -   5        $ placeholderService��5L      $��Booked Service��68   
�������$��5,5,0,0q�5M      $��Center=�6-   $
��Left=�6H   $ False��5N      5O      5P      &   System.Windows.Controls.DataGrid  5Q   
   -   5          Name$ bookingsTable��5Q      $��	0,264,0,0q�6*      AutoGenerateColumns$ False��6=      SelectionMode$ Single=�6Y      Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     5T      $	 NIC��6%   $ * 6J    62   �� *NIC+6J     5U      $ Booking Time��6%   $ * 6[    6;   �� *BookingTime+6[     5V      $ Booking Date��6%   $ * 6[    6;   �� *BookingDate+6[     5W      $ Phone��6%   $ * 6N    64   �� *Phone+6N     5X      $ Service��6%   $ * 6R    66   �� *	Service+6R   5Z      5[      5\      