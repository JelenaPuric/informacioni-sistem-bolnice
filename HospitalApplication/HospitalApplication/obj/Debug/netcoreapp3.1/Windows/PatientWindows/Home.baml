   M S B A M L   `   `   `  ����N  JHospitalApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:HospitalApplication.PropertiesHospitalApplication.Properties  5   	   O,clr-namespace:HospitalApplication.PropertiesHospitalApplication.Properties  5   	   g8clr-namespace:HospitalApplication.Windows.PatientWindows*HospitalApplication.Windows.PatientWindows  5   	   5    /HospitalApplication.Windows.PatientWindows.Home   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   C
properties,clr-namespace:HospitalApplication.Properties     5   	   :p,clr-namespace:HospitalApplication.Properties     5   	   Jlocal8clr-namespace:HospitalApplication.Windows.PatientWindows     5   	   -   5          � Title$
  Home��5
   	   $	��600��5   	   $	��900��5   	    � WindowStartupLocation$ CenterScreen=�5   	      WindowStyle#��[  5   	   .��5      � .+�5   
   � -   5         �Name$ panelHeader��5      $	��Top=�6F   $��50��6^   ���#014546��5       �� 5!       �� Triggers 5"      �� 5#       �� Binding 6&   �� -   'HospitalApplication.Properties.Settings   Default �� Source# Z  �� Path$ 	ColorMode� �� Value	 Light6x   .a�5$      �� 	 �� Property	 � ��
 �� Value
 �#0145466@   5%      5'      .+�5)      �� $��57 0 0 0q�6   .   (HospitalApplication.Properties.Resources   	HomeTitle#��Z 6*   $��Center=�6R   $��Center=�6o   
�������$��38(�6�   5*      � 5+   
   -   5        $ 	sidePanel��5+      $
��Left=�6"   $	��160��6=   ���#014546 K� ZIndex$ 2��6^   .+�5,      �� .+�5-      � $��50��6   .+�5.      �� -   5         ��Name$ HamburgerButton��5.   �   $
��Left=�6   $	��Top=�68   
������ $��50��6i   $��57��6u   
������ .��5/      �� $��Images/hamburger.png��6    50      51      �� 52      $��0 40 0 0q�6   $��Disabled=�6-   
������ 
������ $��15(�6�   
�������$
��Left=�6�   .@�53      �� -   5         ��Name$ MenuHome��53   A   $��45��6#   $��0 0 0 20q�6/   .��54      ��  �� Orientation$ 
Horizontal=�6%   .+�55      �� $��Images/home.png��6$   $��0 0 10 0q�6=   �� 56      $��Center=�6(   ��57   "   �� 58   &    �� 
TargetType" ��6,    59   *   �� 5:   .    6:   �� # Z $ Language� Serbian6�   .a�5;   2   �� 	 � ��   HomeHome#
 Z 6I   5=   /   �� 5>   .    6:   �� # Z $ Language� English6�   .a�5?   2   �� 	 � ��#
 Z 6I   5A   /   P� 5B   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   5D   /   5F   '   5H      5I      5J      �� 5K      -   5        $��MenuNotification��5K   A   $��45��6#   $��0 0 0 20q�6/   .��5L      �� $ 
Horizontal=�6%   .+�5M      �� $��Images/notification.png��6$   $��0 0 10 0q�6E   �� 5N         HomeNotifications#��Z 6(   $��Center=�6X   5O      5P      �� 5Q      -   5        $��
MenuSurvey��5Q   A   $��45��6#   $��0 0 0 20q�6/   .��5R      �� $ 
Horizontal=�6%   .+�5S      �� $��Images/survey.jpg��6$   $��0 0 10 0q�6?   �� 5T         HomeSurveys#��Z 6(   $��Center=�6R   5U      5V      �� 5W      -   5        $��MenuAnamnesis��5W   A   $��45��6#   $��0 0 0 20q�6/   .��5X      �� $ 
Horizontal=�6%   .+�5Y      �� $��Images/anamnesis.png��6$   $��0 0 10 0q�6B   �� 5Z         HomeAnamnesis#��Z 6(   $��Center=�6T   5[      5\      �� 5]      -	   5        $��MenuSettings��5]   A   $��45��6#   $��0 0 0 20q�6/   .��5^      �� $ 
Horizontal=�6%   .+�5_      �� $��Images/settings.png��6$   $��0 0 10 0q�6A   �� 5`         HomeSettings#��Z 6(   $��Center=�6S   5a      5b      5c      5d      5e       � 5g   
   -
   5          �Name$
 Main��5g      $��	57 50 0 0q�6     � NavigationUIVisibility$ Hidden=�61   5i      5j      