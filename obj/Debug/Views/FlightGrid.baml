   M S B A M L   `   `   `  ����J  FFlightSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FlightSimulator.ViewsFlightSimulator.Views  5      &     FlightSimulator.Views.FlightGrid   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8Controls#clr-namespace:FlightSimulator.Views     5      Y UDynamicDataDisplay, Version=0.3.0.0, Culture=neutral, PublicKeyToken=5b7d744a7263923f=d34http://research.microsoft.com/DynamicDataDisplay/1.0  5      .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � -   5        $��1��5      $��0��6   $��2��6,   $��2��6=    � 	Resources 5       �� 
TargetType   
LabelStyle �� Property �� Value 
 rotate �� Angle��%  &	        &	 �     �� 5      " ��6   .�5      ��  � ��$ 20(�61   �� 5       � ��$ Center=�6<   �� 5       � ��$
 Bold"�63   �� 5       � ��
 �   �63   �� 5       � ��$ 4q�6/   5      �� 5      $ 90Q�61   5        5!      �� 5"      $
��Auto �6#   �� 5#      $��* �6#     5%      �� 5&      $��* �6    �� 5'      $
��Auto �6    .+�5)      �� #��[  6    � LayoutTransform# [ 6<   $��Center=�6f   Lon6�   8  2Microsoft.Research.DynamicDataDisplay.ChartPlotter  5*      -   5        $��plotter��5*   Q   $��0��6   $��1��6+      LegendVisible .  5+      �� 5,      $��1��6   $��2��6%   #��[  69   $��Center=�6]   Lat6   5-      �� 5.   
   
�������$��86��6(   $��20��63   $��0��6?   $��Right=�6O   $	��Top=�6k   $��0,5,5,0q�6�   ��6�   �� *ConnectCommand+��6�   �� *
ButtonText+�� 5/   
   $
��Left=�6   
�������$��86��6g   $��20��6r   $��1��6~   $��5q�6�   $	��Top=�6�   $��Setting��6�   ��6D   �� *SettingCommand+6�   52      53      