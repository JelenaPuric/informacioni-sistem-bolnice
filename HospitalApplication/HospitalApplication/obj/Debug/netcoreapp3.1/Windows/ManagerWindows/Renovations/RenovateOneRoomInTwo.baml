   M S B A M L   `   `   `  ����N  JHospitalApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullDclr-namespace:HospitalApplication.Windows.ManagerWindows.Renovations6HospitalApplication.Windows.ManagerWindows.Renovations  5   	   Q    KHospitalApplication.Windows.ManagerWindows.Renovations.RenovateOneRoomInTwo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   VlocalDclr-namespace:HospitalApplication.Windows.ManagerWindows.Renovations     5   	     � Title$  RenovateOneRoomInTwo��5   	   $	��200��6&   $	��480��63   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��252* �6   .+�5   
   �� -   5        $��textBlockCapacity��5   N   $��23��6   $
��Left=�6    $��	67,20,0,0q�6;   $��Room id to renovate:��6g   $	��Top=�6�   $	��110��6�   �� 5   
   -   5        $��textBlockNumberOfFloors��5   N   $��23��6   $
��Left=�6    $��	67,50,0,0q�6;   $��Start day of renovation:��6m   $	��Top=�6�   $	��130��6�   �� 5   
   -   5        $��textBlockEndDayRenovation��5   N   $��23��6   $
��Left=�6    $��	67,80,0,0q�6;   $��End day of renovation:��6o   $	��Top=�6�   $	��130��6�   �� 5   
   -   5        $��textBoxRoomId��5   M   $��23��6   $
��Left=�6   $��
203,20,0,0q�69   $	��Top=�6b   $	��222��6z   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��PickStartDate��5   E   $
��Left=�6   $��
203,50,0,0q�61   $	��Top=�6Z   $	��222��6r     5   
   -   5        $��PickEndDate��5   E   $
��Left=�6   $��
203,80,0,0q�61   $	��Top=�6X   $	��222��6p   �� 5   
   -   5        $��Submit��5   ^   $��Submit��6   $��23��6"   $��Center=�6.   $��	0,126,0,0q�6K   $	��Top=�6l   $��70��6�   6�   5      5      