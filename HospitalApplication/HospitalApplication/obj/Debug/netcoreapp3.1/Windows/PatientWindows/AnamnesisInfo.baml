   M S B A M L   `   `   `  ����N  JHospitalApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:HospitalApplication.WindowsHospitalApplication.Windows  5   	   /    )HospitalApplication.Windows.AnamnesisInfo   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;local)clr-namespace:HospitalApplication.Windows     5   	     � Title$  AnamnesisInfo��5   	   $	��480��6   $	��700��6,    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	      WindowStyle#��[  5   	   .��5      � .+�5   
   �� .+�5      � $��
50 10 50 0q�6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��3* �6'   .+�5      �� $��Patient:��6   $��0��6,   �� 5      -   5        $��	PatientId��5      $��1��6-   5      � 5      $��
50 10 50 0q�6    5      �� 5      $��* �6'   �� 5      $��3* �6'   .+�5      �� $��Appointment ID:��6   $��0��63   �� 5      -   5        $��ExaminationId��5      $��1��61   5      � 5      $��
50 10 50 0q�6    5      �� 5       $��* �6'   �� 5!      $��3* �6'   .+�5#      �� $��Date:��6   $��0��6)   �� 5$      -   5        $
��Date��5$      $��1��6(   5%      � 5&      $��
50 10 50 0q�6    5'      �� 5(      $��* �6'   �� 5)      $��3* �6'   .+�5+      �� $��General information:��6   $��0��68   �� 5,      -   5         ��Name$ GeneralInformation��5,   s   " �� VerticalScrollBarVisibility$
 Auto=�6   $��1��6=   ${�False��6M    �� TextWrapping$
 Wrap=�6_   $��Center=�6�   $��60��6�   5-      � 5.      $��
50 10 50 0q�6    5/      �� 50      $��* �6'   �� 51      $��3* �6'   .+�53      �� $��Main problems:��6   $��0��62   �� 54      -   5        $ MainProblems��54   s   $
 Auto=�6   $��1��6=   ${�False��6M   $
 Wrap=�6_   $��Center=�6�   $��60��6�   55      � 56      $��
50 10 50 0q�6    57      �� 58      $��* �6'   �� 59      $��3* �6'   .+�5;      �� $��Current disease:��6   $��0��64   �� 5<      -   5        $ CurrentDisease��5<   s   $
 Auto=�6   $��1��6=   ${�False��6M   $
 Wrap=�6_   $��Center=�6�   $��60��6�   5=      � 5>      $��
50 10 50 0q�6    5?      �� 5@      $��* �6'   �� 5A      $��3* �6'   .+�5C      �� $��General problems:��6   $��0��65   �� 5D      -   5        $ GeneralProblems��5D   s   $
 Auto=�6   $��1��6=   ${�False��6M   $
 Wrap=�6_   $��Center=�6�   $��60��6�   5E      � 5F      $��
50 10 50 0q�6    5G      �� 5H      $��* �6'   �� 5I      $��3* �6'   .+�5K      �� $��Patients Comment:��6   $��0��65   �� 5L      -   5        $ PatientsComment��5L   s   $
 Auto=�6   $��1��6=   ${�False��6M   $
 Wrap=�6_   $��Center=�6�   $��60��6�   5M      5N      5O      5P      