   M S B A M L   `   `   `  ����I  EPOP-SF-15-2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:POP_SF_15_2016.UIPOP_SF_15_2016.UI  5   	   &     POP_SF_15_2016.UI.NamestajProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:POP_SF_15_2016.UI     5   	     � Title$  NamestajProzor��5   	   $	��400��6    $	��700��6-   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgNamestaj��5
   .      AutoGenerateColumns .    
IsReadOnly . $��
0,120,0,73q�6�   �� 5   
   -   5         ��Name$ btnDodaj��5      $��Dodaj��6#   $
��Left=�63   $��
97,316,0,0q�6N   $	��Top=�6b   $	��132��6z   $��30��6�   6�   �� 5   
   -   5        $ 	btnIzmeni��5      $��Izmeni��6$   $
��Left=�65   $��260,316,0,0q�6P   $	��Top=�6e   $	��132��6}   $��30��6�   6�   �� 5   
   -   5        $ 	btnObrisi��5      $��Obrisi��6$   $
��Left=�65   $��418,316,0,0q�6P   $	��Top=�6e   $	��132��6}   $��30��6�   6�   �� 5   
   $��Pretraga po :��6   $
��Left=�6(   $��	62,21,0,0q�6C   $	��Top=�6V   $��76��6n   �� 5   
   -   5        $��
tbPretraga��5   7   $
��Left=�6I   $��23��6d   $��
296,24,0,0q�6p    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $��cbKriterijumPretrage��5      $
��Left=�6/   $��
138,25,0,0q�6J   $	��Top=�6^   $	��101��6v   �� 5   
   $��Pretrazi��6   $
��Left=�6#   $��
244,21,0,0q�6>   $	��Top=�6R   $��26��6j   $��61��6v   �� 5   
   $��Sortiraj po��6   $
��Left=�6&   $��	62,74,0,0q�6A   $	��Top=�6T   $��76��6l   �� 5   
   -   5        $��cbSortiranje��5      $
��Left=�6'   $��
138,78,0,0q�6B   $	��Top=�6V   $	��101��6n   	� 5   
   -   5        $��	rbRastuce��5   2   $��Rastuce��6C   $
��Left=�6U   $��
244,74,0,0q�6p   $	��Top=�6�   $��19��6�   $��76��6�   	� 5   
   -	   5        $��rbOpadajuce��5   4   $��	Opadajuce��6G   $
��Left=�6[   $��
244,90,0,0q�6v   $	��Top=�6�   	� 5   
   -
   5        $��rbBezFiltera��5   5   $��Bez filtera��6I   $
��Left=�6_   $��
325,81,0,0q�6z   $	��Top=�6�   5      5      