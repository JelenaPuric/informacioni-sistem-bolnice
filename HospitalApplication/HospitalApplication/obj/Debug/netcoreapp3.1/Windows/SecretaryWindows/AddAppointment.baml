   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    HospitalApplication:   4HospitalApplication.Windows.Secretary.AddAppointment   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  AddAppointment��5	   	   $	��450��6    $	��800��6-   .��5
      � .+�5   
   �� .+�5      (  "System.Windows.Controls.DatePicker  -   5        $
��Date��5   X   $
��0 10q�6    �� Today   DisplayDateStart# Z 6'      BlackoutDates 5      /  )System.Windows.Controls.CalendarDateRange  5      
   End# Z 6(    �� MinValue   Start# Z 6L    � 	Resources 5      :  4System.Windows.Controls.Primitives.DatePickerTextBox �� 
TargetType	 �� Property
 �� Value��%_   '        �� 5      "  6   .�5      �� 	 �@��
IsReadOnly$

 True��67   5      5      5      �� 5      $��Type Appointment:��6   62   �� 5      -   5        $��ComboTypeApppointment��5   %   $
��0 10q�6    �� SelectedIndex$ 0��6B   .@�5      �� $��RegularExamination��6   �� 5      $��	Operation��6   5      �� 5       $��Start time:��6   6,   �� 5"      -   5        $��Combo��5"   %   $
��0 10q�6   $ 0��62   .@�5#      �� $
��7:00��6   �� 5$      $
��7:30��6   �� 5%      $
��8:00��6   �� 5&      $
��8:30��6   �� 5'      $
��9:00��6   �� 5(      $
��9:30��6   �� 5)      $��10:00��6   �� 5*      $��10:30��6   �� 5+      $��11:00��6   �� 5,      $��11:30��6   �� 5-      $��12:00��6   �� 5.      $��12:30��6   �� 5/      $��13:00��6   �� 50      $��13:30��6   �� 51      $��14:00��6   �� 52      $��14:30��6   �� 53      $��15:00��6   �� 54      $��15:30��6   �� 55      $��16:00��6   �� 56      $��16:30��6   �� 57      $��17:00��6   �� 58      $��17:30��6   �� 59      $��18:00��6   �� 5:      $��18:30��6   �� 5;      $��19:00��6   �� 5<      $��19:30��6   5=      �� 5@      $$��Choose doctor for examination.��6   �� 5A      -   5        $��Combo3��5A   %   $
��0 10q�6   $ 0��63   5B      �� 5D      $'��!Postpone Appointment ( In days ):��6   �� 5E      -   5         ��Name$ 
textBox111��5E   "   $��23��6   $	��797��66    J� RenderTransformOrigin$ 0.5,0.5&�6B   .��6d   z�5F      V� 5G      .~�5H      �� �� 5I      �� 5J       �� Angle$ -0.012Q�6*   T� 5K      5L      .��5M   +   5N      �� 5P      -   5         ��Name$ ButtonOk��5P   "   $��OK��6   $��0 10 0 0q�6K   6_   5R      5T      5U      