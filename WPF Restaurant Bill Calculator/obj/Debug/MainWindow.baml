   M S B A M L   `   `   `  ����S  O301292283(LING LIN)_LAB3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:LAB3LAB3  5   	       LAB3.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:LAB3     5   	     � Title$   Restaurant Bill Calculator��5   	   $	��450��6,   $	��800��69   .��5	      �  J� RenderTransformOrigin$ 0.827,0.598&�6   .+�5
   
   �� -   5        $��cmbBeverage��5
      $
��Left=�6&   $	��Top=�6A   $��	10,10,0,0q�6Y   $	��142��6l   6x   �� 5   
   -   5        $��cmbAppetizer��5      $
��Left=�6'   $	��Top=�6B   $��
159,10,0,0q�6Z   $	��142��6n   6z   �� 5   
   -   5        $��cmbMainCourse��5      $
��Left=�6(   $	��Top=�6C   $��
308,10,0,0q�6[   $	��142��6o   6{   �� 5   
   -   5        $��
cmbDessert��5      $
��Left=�6%   $	��Top=�6@   $��
458,10,0,0q�6X   $	��142��6l   6x   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ menuItemsDataGrid��5      $
��Left=�6.   $	��Top=�6I   $	��588��6a   $	��213��6m   $��	10,51,0,0q�6z      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     5      $ Category��6%   $	 150 6T    67   �� *
Category+6T     5      $ Price��6%   $	 150 6N    64   �� *Price+6N     5      $ Quantity��6%   $	 150 6T    67   �� *
Quantity+6T   5      �� 5   
   -   5        $��	/Logo.jpg��5      $��373,10,-229,363q�6:   �� 5   
    �� Orientation$ Vertical=�6   $
��Left=�6,   $	��Top=�6G   $��
630,80,0,0q�6_   .+�5      �� -   5        	 ��Name$	 StudentName��5      $��Student Name: Ling Lin��6)   $y�Visible=�6J   �� 5      -   5        $	 	StudentId��5      $��Student Id: 301292283��6'   $y�Visible=�6G   5      �� 5   
   $ Vertical=�6   $
��Left=�6,   $	��Top=�6G   $��
20,269,0,0q�6_   $	��128��6s   $��90��6�   .+�5       �� -	   5        $	 Subtotal��5       $��	Subtotal:��6&   $y�Visible=�6:   �� 5!      -
   5        $		 Tax��5!      $
��Tax:��6!   $y�Visible=�60   �� 5"      -   5        $	 Total��5"      $��Total:��6#   $y�Visible=�64   5#      �� 5$   
   $ Vertical=�6   $��Right=�6,   $	��Top=�6H   $��0,269,202,0q�6`   .+�5%      �� -   5        $��Display All Bills��5%      $	��120��61   $��0,5,0,5q�6=   6N   �� 5&      -   5        $��Add Item(s)��5&      $	��120��6+   $��0,5,0,5q�67   6H   �� 5'      -   5        $��Remove Item(s)��5'      $	��120��6.   $��0,5,0,5q�6:   6K   �� 5(      -   5        $��
Clear Bill��5(      $	��120��6*   $��0,5,0,5q�66   6G   �� 5)      -   5        $��Generate Invoice��5)      $	��120��60   $��0,5,0,5q�6<   6M   5*      5+      5,      