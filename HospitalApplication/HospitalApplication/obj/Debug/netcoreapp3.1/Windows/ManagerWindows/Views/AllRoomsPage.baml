   M S B A M L   `   `   `  ����N  JHospitalApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:HospitalApplication.Windows.ManagerWindows.Views0HospitalApplication.Windows.ManagerWindows.Views  5      C    =HospitalApplication.Windows.ManagerWindows.Views.AllRoomsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Plocal>clr-namespace:HospitalApplication.Windows.ManagerWindows.Views     5        N� Title$  AllRoomsPage��5      $	��552��6   .��5
      � .+�5   
   �� .��5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��	All rooms��6    $��30(�61   $
��Left=�6?   $��50,0,0,0q�6Z   $��Bottom=�6l   �� 5      $��../Images/search.png��6   $��15��6:   $��15��6E   $��Right=�6Q   $��Bottom=�6m   $��
502,0,10,0q�6�   �� 5      -   5         ��Name$ 
filterRoom��5      $	��100��62   $��20��6>   $��Right=�6J   $��Bottom=�6f   $��	0,0,100,0q�6�   5      �� 5      -   5        $��lvDataBinding��5   .   $��	11,10,0,0q�6   $	��200��6C   $	��Top=�6P   $��Center=�6h   $
��Auto��6�    �� View 5      �� 5      .P�5      �� $��	Room type��6-    �� Width$	 120��6@    �� DisplayMemberBinding 6L   �� *
RoomType+�� 5      $��Capacity��6-   $	 120��6?    6K   �� *
Capacity+�� 5      $��Number Of Floors��6-   $	 120��6G    6S   �� *NumberOfFloors+�� 5      $��Occupied��6-   $	 120��6?    6K   �� *
Occupied+�� 5      $��Room Id��6-   $	 120��6>    6J   �� *RoomId+�� 5      $��Room number��6-   $	 120��6B    6N   �� *
RoomNumber+5      5      ]� 5      $��Center=�6   .+�5      �� -   5        $��Add new room��5      $
��Left=�66   $��
50,20,10,0q�6Q   $	��Top=�6e   $	��100��6}   $��35��6�   6�   �� 5       -   5        $��Delete ��5       $
��Left=�60   $��	0,20,10,0q�6K   $	��Top=�6^   $	��120��6v   $��35��6�   6�   �� 5!      -   5        $��Search ��5!      $
��Left=�60   $��	0,20,10,0q�6K   $	��Top=�6^   $	��120��6v   $��35��6�   6�   �� 5"      -   5        $
��Edit��5"      $
��Left=�6-   $��	0,20,10,0q�6H   $	��Top=�6[   $	��120��6s   $��35��6   6�   �� 5#      -   5        $��Refresh List��5#      $
��Left=�64   $��	0,20,10,0q�6O   $	��Top=�6b   $	��120��6z   $��35��6�   6�   5$      �� 5%      $��Renovations��6   $��30(�6/   $
��Left=�6=   $��50,105,0,10q�6X   ]� 5&      .+�5'      (� $	��300��6   $��Center=�6*   $��100,0,0,200q�6G   .��5(      &   System.Windows.Controls.Calendar  5)      �� 5*      .+�5+      �� $��Right=�6#   $	��120��6?   $��35��6K   $	��Top=�6W   $��0,5,50,0q�6o   �� 5,      $��Duration in days: ��6$   $��20(�6>   $��Right=�6L   $��	0,20,50,0q�6h   �� 5-      -   5        $ DurationInDays��5-   "   $	��120��6:   $��35��6F   $��Right=�6R   $��Center=�6n   $��20(�6�   $��	0,10,50,0q�6�   �� 5.      -	   5         ��Name$ Submit��5.   !   $��Submit��61   $��Right=�6B   $	��120��6^   $��35��6j   $��
0,110,50,0q�6v   5/      50      51      52      53      55      