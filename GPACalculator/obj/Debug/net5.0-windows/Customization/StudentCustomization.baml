   M S B A M L   `   `   `  ����H  DGPACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GPACalculatorGPACalculator  5   	   (    "GPACalculator.StudentCustomization   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:GPACalculator     5   	   $
��1080��5   	   $
��1920��6   .��5	      �   � ColumnDefinitions  5
   
   �� 5      �� 5      $	��600 �6    � 	Resources 5   
    �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 40(�6-   �� 5       � ��$
 Bold"�6/   �� 5       �@��TextAlignment$ Center=�62   5      5      .+�5   
   �� -   5         ��Name$ SemesterDisplayBorder��5      $��0��60    �� Padding$ 25q�6@   ._�5      #   GPACalculator.SemesterDisplay  5      �� 5   
   $��1��6   $��0,100q�6%   .+�5      �� 
���   �$��2q�6)    �� CornerRadius$	 150��6=   $��1��6P   $	��300��6`   $	��300��6m   ._�5      �� -   5         ��Name$ textGPADisplay��5      $��75(�64   $��Center=�6B   $��Center=�6]   GPA6   5      �� 5      $��1��6   $
��0,50q�6)   .+�5      �� Student Name6*   �� 5       -   5        	 ��Name$	 StudentNameTextBox��5       $	��500��66   $	��100��6B   $��30(�6O   
 �� TextAlignment$
 Center=�6]   6v   5!      �� 5"      -   5         ��Name$ btnCompleteStudent��5"      $��1��6I   $	��300��6Y   $	��100��6e   $��30(�6r   .��6�   Complete Student6�   �� 5#      -   5        $ btnCalculateGPA��5#      $��10q�6C   $��1��6O   $	��300��6_   $	��100��6k   $��30(�6x   .��6�   Calculate GPA6�   5$      5&      5'      