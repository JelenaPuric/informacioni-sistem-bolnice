   M S B A M L   `   `   `  ����N  JHospitalApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:HospitalApplication.Windows.Secretary%HospitalApplication.Windows.Secretary  5   	   :    4HospitalApplication.Windows.Secretary.EditNewsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:HospitalApplication.Windows.Secretary     5   	     � Title$  EditNewsWindow��5   	   $	��450��6    $	��800��6-   .��5	      � $��	0,0,10,11q�6   .+�5
   
   �� -   5        $��	ComboBox1��5
   %   $��0,55,0,0q�6   $��Center=�66   $	��Top=�6S   $	��246��6k   $��23��6w   .@�5      �� $��General��6   6/   �� 5      $��Discount��6   60   �� 5      $��	Important��6   61   5      �� 5   
   -   5        $��textBoxTitle��5   M   $��23��6   $��Center=�6   $��0,86,0,0q�6;   $	��Top=�6a   $	��246��6y   �� 5   
   -   5        $��textBoxDuration��5   N   $��23��6   $��Center=�6   $��	0,115,0,0q�6;   $	��Top=�6e   $	��246��6}   �� 5   
   -   5        $��textBoxDescription��5   �    �� AcceptsReturn$
 True��6    �� TextWrapping$
 Wrap=�6'   " �� VerticalScrollBarVisibility$ Visible=�6;   $	��182��6a   $��Center=�6n   $	��Top=�6�   $	��246��6�   $��	0,156,0,0q�6�   �� 5   
   -   5        $��textBlockTypeNews��5   O   $��23��6   $
��Left=�6    $��
168,55,0,0q�6;   $��Type of News:��6h   $	��Top=�6}   $	��110��6�    J� RenderTransformOrigin$ 1.054,0.562&�6�   �� 5   
   -   5        $��textBlockTitleNews��5   O   $��23��6   $
��Left=�6    $��
168,87,0,0q�6;   $��Title��6i   $	��Top=�6v   $	��110��6�   �� 5   
   -   5        $��textBlockDuration��5   P   $��22��6   $
��Left=�6    $��168,116,0,0q�6;   $��Duration(days):��6i   $	��Top=�6�   $	��110��6�   �� 5   
   -   5        $��textBlockDescription��5   P   $��23��6   $
��Left=�6    $��168,156,0,0q�6;   $��Description:��6l   $	��Top=�6�   $	��110��6�   $ 0.992,0.656&�6�   �� 5   
   -	   5        $��Ok��5      $
��Left=�65   $��262,365,0,0q�6P   $	��Top=�6e   $��43��6}   $	��100��6�   �� 5   
   -
   5        $��Cancel��5      $
��Left=�6=   $��410,365,0,0q�6X   $	��Top=�6m   $��43��6�   $��98��6�   5      5       