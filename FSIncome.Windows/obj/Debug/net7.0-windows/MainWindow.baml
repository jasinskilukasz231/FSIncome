   M S B A M L   `   `   `  ����K  GFSIncome.Windows, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FSIncome.WindowsFSIncome.Windows  5   	   !    FSIncome.Windows.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QScottPlot.WPF, Version=4.1.63.0, Culture=neutral, PublicKeyToken=e53b06131e34a3aae aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:FSIncome.Windows     5   	   $	��800��5   	   $	��600��5	   	     � 
ResizeMode$  NoResize=�5
   	    � Title$ FSIncome��5   	   $	��600��6   $	��800��6'    � 	Resources 5       �� 
TargetType   optionsButtonTemplate �� Path �� Triggers P� Property P� Value �� Property	 �� Value��%  &	        �� 5   
   " ��6   .R�5      � .+�5      �� ��6   �� $ [settingsButtonImage]�5       5      P� 5       �@J�IsMouseOver$
 True��61   . �5      ��  � ��
	 �  ��63   �� 5       �@�Cursor$
	 Hand��6/   5      5      5      .��5      � -   5        
 �Name$
 StartingPageGrid��5      ��5   
   �� 5        �� ImageSource 6   �� $ [background0]� � ColumnDefinitions 5#   
   �� 5$      $��* �6   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $	��100 �6   �� 5(      $��80 �6    � RowDefinitions 5+   
   �� 5,      $��* �6   �� 5-      $��* �6   �� 5.      $	��100 �6   �� 5/      $��80 �6   .+�53   
   �� -   5         ��Name$ ButtonStart��53      $��2��6?   $��START��54      $��34(�6!   $��1��6/   $��1��6<   $��20,50,20,50q�55        buttonTemplate#��[ 6&   57      �� 58   
   -   5        $ ButtonOptions��58      $��2��59      $��3��6   $��20q�6.   $��0q�5:      #��[  6%    � 5<   
   -   5          �Name$ 	PageFrame��5<      $��5��6#   $��4��67     � NavigationUIVisibility$ Hidden=�5=      5>      5?      