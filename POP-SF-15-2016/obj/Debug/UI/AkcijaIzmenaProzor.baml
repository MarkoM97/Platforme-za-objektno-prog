   M S B A M L   `   `   `  ����I  EPOP-SF-15-2016, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:POP_SF_15_2016.UIPOP_SF_15_2016.UI  5   	   *    $POP_SF_15_2016.UI.AkcijaIzmenaProzor   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:POP_SF_15_2016.UI     5   	     � Title$  AkcijaIzmenaProzor��5   	   $	��350��6$   $	��350��61    � 	Resources 5	      *   $POP_SF_15_2016.UI.ValidatorConverter   	converter��%   &	          5   
   6#   5      .��5      � $��0,0,0,-1q�6    � RowDefinitions 5   
   �� 5      $	��65* �6   �� 5      $	��46* �6   �� 5      $	��43* �6   �� 5      $	��46* �6   �� 5      $	��42* �6   �� 5      $	��78* �6    � ColumnDefinitions 5   
   �� 5      $
��143* �6   �� 5      $
��199* �6   .+�5   
   �� $��Right=�6   $��Naziv��63   $
��Left=�6C   $��61,5,0,0q�6^   $��1��6p   $	��Top=�6}   $��82��6�   $��33��6�   �� 5   
   $��Right=�6   $��Pocetak��63   $
��Left=�6E   $��	61,10,0,0q�6`   $��2��6s   $	��Top=�6�   $��82��6�   $��29��6�   �� 5   
   $��Right=�6   $��	Zavrsetak��63   $
��Left=�6G   $��	61,10,0,0q�6b   $��3��6u   $	��Top=�6�   $��82��6�   $��29��6�   �� 5   
   $��Right=�6   $��Popust��63   $
��Left=�6D   $��	61,10,0,0q�6_   $��4��6r   $	��Top=�6   $��82��6�   $��28��6�   �� 5   
   -   5         ��Name$ tbNaziv��5   .   $��1��6?   $
��Left=�6O   $��28��6j   $��10,5,0,0q�6v   $��1��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��146��6�   ��6   ��  �� Path$ Naziv�6�   �� 5   
   $��%��6   $��1��6   $
��Left=�6,   $��	57,10,0,0q�6G   $��4��6Z   $	��Top=�6g   $��24��6   $��20��6�   �� 5!   
   -   5        $ tbPopust��5!      $��1��6$   $
��Left=�64   $��23��6O   $��	10,10,0,0q�6[   $��4��6n   $
 Wrap=�6{   $	��Top=�6�   $��47��6�   .��6�   ��5"      �� 5#      $ Popust�6    �� UpdateSourceTrigger$ PropertyChanged=�6(    �� ValidationRules 5$      +   %POP_SF_15_2016.UI.dobleValidationRule  5%      5'      .��5(      5)      (  "System.Windows.Controls.DatePicker  5+   
   -   5        	  Name$	 	dpPocetak��5+   A   $��1��6T   $��	10,7,46,6q�6d   $��2��6w   
   SelectedDate
 6   �� $ PocetakAkcije�6w     5,   
   -   5        $	 dpZavršetak��5,   a      DisplayDateStart$ 
01/01/2017X�6   $��1��6v   $��10,10,46,10q�6�   $��3��6�      Text$ Pera123��6�      IsTodayHighlighted .  
 63   �� $ ZavrsetakAkcije�6�   �� 5-   
   -   5         ��Name$ 
btnSacuvaj��5-      $��Sacuvaj��6%   $��1��67   $
��Left=�6G   $��	10,40,0,0q�6b   $��5��6u   $	��Top=�6�   $	��130��6�   $��28��6�   6�   �� 5/   
   
���  ��$
��Bold"�6%   $��1��6�   $
��Left=�6�   $��16��6�   $��	10,41,0,0q�6�   $
��Wrap=�6�   $	��Top=�6  $	��146��6  $��3��6+  $��2��68  ��67   ��  �� ElementName$ tbPopust��$ (Validation.Errors)� �� 	Converter# [  68  50      51      