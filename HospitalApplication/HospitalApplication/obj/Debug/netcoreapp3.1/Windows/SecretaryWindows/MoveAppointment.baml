   M S B A M L   `   `   `  ����N  JHospitalApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:HospitalApplication.Windows.Secretary%HospitalApplication.Windows.Secretary  5   	   ;    5HospitalApplication.Windows.Secretary.MoveAppointment   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Elocal3clr-namespace:HospitalApplication.Windows.Secretary     5   	     � Title$  MoveAppointment��5   	   $	��926��6!   $	��844��6.   .��5	      � $��0,0,149,111q�6    � ColumnDefinitions 5
   
   �� 5      $
��293* �6   �� 5      $
��507* �6   .+�5   
   �� $ ��All scheduled appointments��6   $
��Left=�65   $��30(�6P   
���   �$��219,226,0,493q�6q   $��2��6�   �� 5   
   -   5        $��lvUsers��5   +   $��45,329,-91,105q�6   $
��True��6:   $��2��6_    �� View 5      �� 5      .P�5      ��  �� Width$	 120��6%   $��Type Appointment��61    �� DisplayMemberBinding 6K   �� *AppointmentType+�� 5      $	 120��6%   $��	Doctor ID��61    6D   �� *	DoctorsId+�� 5      $	 120��6%   $��
Patient ID��61    6E   �� *
PatientsId+�� 5      $	 120��6%   $��Examination start��61    6L   �� *ExaminationStart+�� 5      $	 120��6%   $��Room ID��61    6B   �� *RoomId+�� 5      $	 120��6%   $��Examination ID��61    6I   �� *ExaminationId+5      5      �� 5   
   -   5        $��Move appointment��5   /   $
��Left=�6J   $��	27,53,0,0q�6e   $	��Top=�6x   $��70��6�   $	��132��6�   $��1��6�   �� 5   
   -   5        $��Refresh List��5   +   $
��Left=�6B   $��
190,53,0,0q�6]   $	��Top=�6q   $��70��6�   $	��132��6�   $��1��6�   5       5!      