   M S B A M L   `   `   `  ����L  HWpfKosarkaskiKlub, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfKosarkaskiKlub.FormeWpfKosarkaskiKlub.Forme  5   	   ,    &WpfKosarkaskiKlub.Forme.KosarkaskiKlub   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WpfKosarkaskiKlub.Forme     5   	     � Title$!  Dodaj/Izmeni KosarkaskiKlub��5   	   $	��320��6-   $	��320��6:   .��5	      � .+�5
   
   �� $��
Ime Kluba:��6   $
��Left=�6%   $��	30,25,0,0q�6@   $	��Top=�6S   �� 5   
   -   5         ��Name$ txtImeKluba��5      $
��Left=�6'   $��23��6B   $��
140,25,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sačuvaj��6%   $
��Left=�67   $��
40,248,0,0q�6R   $	��Top=�6f   $��75��6~    J� RenderTransformOrigin$ 0.498,2.783&�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkaži��6$   $
��Left=�65   $��194,248,0,0q�6P   $	��Top=�6e   $��75��6}   6�   �� 5   
   $��Drzava Kluba:��6   $
��Left=�6(   $��	30,54,0,0q�6C   $	��Top=�6V   �� 5   
   $��Godina Osvajanja:��6   $
��Left=�6,   $��	30,85,0,0q�6G   $	��Top=�6Z   �� 5   
   $��Vrednost Kluba:��6   $
��Left=�6*   $��
30,119,0,0q�6E   $	��Top=�6Y   $��23��6q   �� 5   
   -   5        $ txtDrzavaKluba��5      $
��Left=�6*   $��23��6E   $��
140,57,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtGodinaOsvajanja��5      $
��Left=�6.   $��23��6I   $��
140,88,0,0q�6U   $
 Wrap=�6i   $�� ��6}   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtVrednostKluba��5      $
��Left=�6,   $��23��6G   $��140,119,0,0q�6S   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   �� 5   
   $��Liga:��6   $
��Left=�6    $��
30,147,0,0q�6;   $	��Top=�6O   �� 5   
   $��Arena:��6   $
��Left=�6!   $��
30,175,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ cbLiga��5      $
��Left=�6#   $��140,147,0,0q�6>   $	��Top=�6S   $	��120��6k    �� SelectedValuePath$ ligaID��6w   �� 5   
   -   5        $ cbArena��5      $
��Left=�6$   $��140,175,0,0q�6?   $	��Top=�6T   $	��120��6l   $ arenaID��6x   5      5      