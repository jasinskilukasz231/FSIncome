   M S B A M L   `   `   `  ����K  GFSIncome.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FSIncome.Windows.PagesFSIncome.Windows.Pages  5      %    FSIncome.Windows.Pages.MainPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:FSIncome.Windows.Pages     5        N� 
Background
  ����� N� Title$ MainPage��5
      .��5      � ��5   
   �� 5       �� ImageSource 6   ��  �� Path$ [background4]� � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $	��100 �6   �� 5      $��60 �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 
BackButton��5      $��0��6%   $��4��62   $��10q�6B      buttonTemplate#��[  6N   $
��BACK��5      6    �� 5   
   -   5         ��Name$ DateTextBlock��5      $
��Bold"�6+     	textColor#��[ 6=   $��16(�6e    �� TextAlignment$ Right=�6s   $��0��6�   $��10q�6�   $��1��6�   �� 5   
   -   5        $ SeasonTextBlock��5      $
��Bold"�6-   #��[ 6?   $��16(�6g   $
 Left=�6u   $��0��6�   $��10q�6�   $��2��6�    � 5    
   -   5        	  �Name$	 	PageFrame��5         blackTransparentColor#��[ 6#   $��1��6W   $��1��6g   $��4��6t   �� 5!   
   $��1��6   #��[ 6"   .+�5"      �� -   5        $ moneyButton��5"   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6u   
������ $��MONEY��6�   $��16(�6�   �� 5#      -   5        $ machinesButton��5#   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6x   
������ $��MACHINES��6�   $��16(�6�   �� 5$      -   5        $ fieldsButton��5$   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6v   
������ $��FIELDS��6�   $��16(�6�   �� 5%      -   5        $ animalsButton��5%   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6w   
������ $��ANIMALS��6�   $��16(�6�   �� 5&      -	   5        $ transactionsButton��5&   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6|   
������ $��TRANSACTIONS��6�   $��16(�6�   �� 5'      -
   5        $ historyButton��5'   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6w   
������ $��HISTORY��6�   $��16(�6�   �� 5(      -   5        $ marketButton��5(   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6v   
������ $��MARKET��6�   $��16(�6�   �� 5)      -   5        $ editProfileButton��5)   `   $��5,3,5,0q�6   $
��Bold"�6&   #��[ 68   $��45��6{   
������ $��EDIT PROFILE��6�   $��16(�6�   � 5*      $	��100��6    5+      �� 5,      $��* �6$   �� 5-      $��* �6$   .+�5/      �� -   5        $ NextDay��5/      $
��Bold"�6*   #��[ 6<   $��5,0,5,0q�6d   $��1��6u   $��50��6�   
������ $��Next Day��6�   $��16(�6�   50      52      54      55      