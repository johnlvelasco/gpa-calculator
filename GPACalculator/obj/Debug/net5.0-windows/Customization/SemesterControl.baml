   M S B A M L   `   `   `  ����H  DGPACalculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:GPACalculatorGPACalculator  5      #    GPACalculator.SemesterControl   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:GPACalculator     5      .��5	      �   � 	Resources  5
   
    �� 
TargetType �� Property �� Value��%K  '��       '�� �     �� 5      " ��6   .�5      ��  � ��$ 40(�6-   �� 5       �@��TextAlignment$ Center=�62   �� 5       � ��$ Center=�66   5      �� 5      " ��6   .�5      ��  � ��$ 40(�6-   �� 5       � ��$	 300��6*   �� 5       � ��$ 75��6+   5      5       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      .+�5   
   �� -   5        $��SemesterLabel��5      $��40(�6'   $��75��6c   $	��300��6o    �� TextAlignment$ Center=�6{   $��Center=�6�   $
��Left=�6�   6�   �� 5   
   $��1��6   ._�5      �� -   5         ��Name$ Labels��5   ]   $
��Left=�6   $
��1200��64    �� Orientation$ 
Horizontal=�6D   
�������.+�5      �� 
���   �$��0,0,1,0q�6-   ._�5       �� $	��600��6    Name62   5!      �� 5"      
���   �$��0,0,1,0q�6-   ._�5#      �� $	��250��6    Credit Hours6:   5$      �� 5%      
���   �$��0,0,1,0q�6-   ._�5&      �� $	��250��6    Grade63   5'      �� 5(      $	��100��6   5)      5*      �� 5,   
   -   5        $��CoursesStackPanel��5,   "   $��2��6   .+�5-      �� -   5         ��Name$ AddCourseButton��5-      $
��Left=�6@   $
��1200��6[   $	��100��6h   .��6u   Add New Course6�   5.      �� 5/   
   -   5        $ RemoveSemesterButton��5/   :   $��0��6   $��Right=�6   $	��400��6o   $��75��6{   $��	0,15,10,0q�6�   $	��Top=�6�   .��6�   Remove Semester6�   51      53      