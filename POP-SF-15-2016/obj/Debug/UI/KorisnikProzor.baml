   M S B A M L   `   `   `  ����I  EPOP-SF-15-2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:POP_SF_15_2016.UIPOP_SF_15_2016.UI  5   	   &     POP_SF_15_2016.UI.KorisnikProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:POP_SF_15_2016.UI     5   	     � Title$  KorisnikProzor��5   	   $	��300��6    $	��500��6-   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgKorisnik��5
         AutoGenerateColumns .    
IsReadOnly . $
��0,84q�6�   �� 5   
   -   5         ��Name$ btnDodaj��5      $��Dodaj��6#   $
��Left=�63   $��
59,215,0,0q�6N   $	��Top=�6b   $	��109��6z   $��29��6�   6�   �� 5   
   -   5        $ 	btnIzmeni��5      $��Izmeni��6$   $
��Left=�65   $��202,215,0,0q�6P   $	��Top=�6e   $	��108��6}   $��29��6�   6�   �� 5   
   -   5        $ 	btnObrisi��5      $��Obrisi��6$   $
��Left=�65   $��343,215,0,0q�6P   $	��Top=�6e   $	��108��6}   $��29��6�   6�   �� 5   
   $��Pretrazi po��6   $
��Left=�6&   $��	53,10,0,0q�6A   $	��Top=�6T   $��69��6l   �� 5   
   -   5        $��cbKriterijumPretrage��5      $
��Left=�6/   $��
127,14,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5   
   $��Pretrazi��6   $
��Left=�6#   $��
258,10,0,0q�6>   $	��Top=�6R   $��69��6j   �� 5   
   -   5        $��
tbPretraga��5   7   $
��Left=�6I   $��23��6d   $��
317,13,0,0q�6p    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   $��Sortiraj��6   $
��Left=�6#   $��	53,41,0,0q�6>   $	��Top=�6Q   $��69��6i   �� 5   
   -   5         ��Name$ cbKriterijumSortiranja��5      $
��Left=�63   $��
127,47,0,0q�6N   $	��Top=�6b   $	��120��6z   	� 5   
   -   5        $��	rbRastuce��5   2   $��Rastuce��6C   $
��Left=�6U   $��
275,42,0,0q�6p   $	��Top=�6�   	� 5   
   -	   5        $��rbOpadajuce��5      $��	Opadajuce��6)   $
��Left=�6=   $��
275,57,0,0q�6X   $	��Top=�6l   6�   5      5      