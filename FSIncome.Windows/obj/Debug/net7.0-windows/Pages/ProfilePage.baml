   M S B A M L   `   `   `  ����K  GFSIncome.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FSIncome.Windows.PagesFSIncome.Windows.Pages  5      (    "FSIncome.Windows.Pages.ProfilePage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:FSIncome.Windows.Pages     5        N� Title$  ProfilePage��5	       � 	Resources 5
       �� 
TargetType   buttonProfileTemplate ��Name �� Triggers P� Property P� Value �� Property �� Value  tabMouseOverColor	 �� 
TargetName  blackTransparentColor��%�  &	        7  7  �� 5   
   " ��6   .R�5      � .+�5      �� $ backgroundRectangle��6   �� 5      $��Center=�6#   $��Center=�6@   5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  �@�Cursor$
 Hand��6/   �� 5      8   $	 backgroundRectangle��6X    � ��5      P� 5       �@J�IsMouseOver$ False��61   . �5      �� 8  $	 backgroundRectangle��6\    � ��5      5      5      .��5      � ��5    
   �� 5!      
 �� ImageSource
 6   ��  �� Path$ [background2]� � ColumnDefinitions 5$   
   �� 5%      $��* �6   �� 5&      $	��150 �6    � RowDefinitions 5(   
   �� 5)      $��80 �6   �� 5*      $��* �6   .+�5-   
   �� $��2��6   $��2��6+   $��Hidden=�6<   $��Visible=�5.      .��5/      �� $��PROFILES��6   $
��Bold"�6)   $��10q�50      $��24(�6#   $
��1500��61     	textColor#��[ 6>   .��52      A�  A� Rows$ 1��6   $��
0,40,30,40q�6'   .+�53      �� -   5         ��Name$ button1��53      #��[  6.   #��[ 6`   $��SemiBold"�6�   $��50,0,0,0q�6�   $��Create new profile��6�   6�   �� 54      -   5        $ button2��54      #��[  6.   #��[ 6`   $��SemiBold"�6�   $��50,0,0,0q�6�   $��Create new profile��6�   $y�Hidden=�6�   6�   �� 55      -   5        $ button3��55      #��[  6.   #��[ 6`   $��SemiBold"�6�   $��50,0,0,0q�6�   $��Create new profile��6�   $y�Hidden=�6�   6�   �� 56      -   5        $ button4��56      #��[  6.   #��[ 6`   $��SemiBold"�6�   $��50,0,0,0q�6�   $��Create new profile��6�   $y�Hidden=�6�   6�   �� 57      -   5        $ button5��57      #��[  6.   #��[ 6`   $��SemiBold"�6�   $��50,0,0,0q�6�   $��Create new profile��6�   $y�Hidden=�6�   6�   58      59      5:       � 5<   
   -   5          �Name$ 	PageFrame��5<      $��2��6#   $��2��67   �� 5>   
   -   5        $ 
BackButton��5>      $��0��6>   $��1��6K   $
��BACK��5?      $	��120��6    $��50��6,     buttonTemplate#��[ 68   5@      5A      