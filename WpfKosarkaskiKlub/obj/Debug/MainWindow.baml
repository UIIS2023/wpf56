   M S B A M L   `   `   `  ����L  HWpfKosarkaskiKlub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WpfKosarkaskiKlubWpfKosarkaskiKlub  5   	   "    WpfKosarkaskiKlub.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WpfKosarkaskiKlub     5   	     � Title$  KosarkaskiKlub��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5      $��Center=�6,   $��Center=�6I   $
��auto��6d   $
��auto��6r      
IsReadOnly .    AlternatingRowBackground
 �����   CanUserAddRows .     SelectionUnit$ FullRow=�5   I      SelectionMode$ Single=�6a   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $
��auto��6W    �� Orientation$ 
Horizontal=�6d   .+�5      �� -   5         ��Name$ btnIgrac��5      $��Igrac��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��80��6v   6�   �� 5      -   5        $ 
btnSponzor��5      $��Sponzor��6)   $
��Left=�6;   $��30��6V   $	��Top=�6b   $��80��6z   6�   �� 5      -   5        $ btnDres��5      $
��Dres��6&   $
��Left=�65   $��30��6P   $	��Top=�6\   $��80��6t   6   �� 5      -   5        $ btnArena��5      $��Arena��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��80��6v   6�   �� 5      -   5        $ 	btnTrener��5      $��Trener��6(   $
��Left=�69   $��30��6T   $	��Top=�6`   $��80��6x   6�   �� 5      -   5        $ btnKosarkaskiKlub��5      $��KosarkaskiKlub��60   $
��Left=�6I   $��30��6d   $	��Top=�6p   $��92��6�   6�   �� 5      -   5        $ btnLiga��5      $
��Liga��6&   $
��Left=�65   $��30��6P   $	��Top=�6\   $��80��6t   6   �� 5      -	   5        $ 	btnTrofej��5      $��Trofej��6(   $
��Left=�69   $��30��6T   $	��Top=�6`   $��80��6x   6�   �� 5      -
   5        $ 
btnNavijac��5      $��Navijac��6)   $
��Left=�6;   $��30��6V   $	��Top=�6b   $��80��6z   6�   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��510��6Z   $ 
Horizontal=�6f   .+�5      �� -   5        $ btnDodaj��5      $��Dodaj��6'   $	��170��67   6C   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $	��170��69   6E   �� 5      -   5        $ 	btnObrisi��5      $��Obriši��6(   $	��170��69   6E   5      ��5   
   �� 5       �� ImageSource$5 /C:\Users\TehnoCentar\Desktop\faks\pis\slika.jpg��6   	 j� Stretch$	 UniformToFill=�6W   5       5!      