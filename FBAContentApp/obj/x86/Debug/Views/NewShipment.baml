   M S B A M L   `   `   `  ����H  DFBAContentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FBAContentApp.ViewsFBAContentApp.Views  5      %    FBAContentApp.Views.NewShipment   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:FBAContentApp.Views     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��Auto �6   6,   .+�5    
   �� $��Process Shipment��6      
titleLabel#��[  6+   $��1��6O   $��4��6_   $��0��6s   �� 5"   
   -   5         ��Name$ btn_AddBoxes��5"      $��	Add Boxes��6'   $��2��6;   $��2��6K   $��1��6`   $��	0,20,0,20q�6m   $��30, 5, 30, 5q�6�   6�   �� 5$   
   -   5         ��Name$ lsbx_AddedBoxes��5$      $
��auto��6,   $��Center=�6;   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6`   $��1��6�   $��4��6�   $��2��6�   $��3��6�   �� 5&   
   -   5         ��Name$ txblck_ChooseWhse��5&      $"��Choose the Amazon Warehouse:��6+   $��Center=�6R   $	��Top=�6o   $��1��6�   $��4��6�   $��5��6�   �� 5(   
   -   5        $ lbl_BoxCountMessage��5(        newShipLabelStyle#��[ 6-   $��Boxes loaded��6X   $��6��6o   $��1��6|   $��2��6�   �� 5)   
   -   5        $ lbl_BoxCount��5)      $��0��6&   #��[ 62   $��3��6]   $��2��6m   $��6��6�   �� 5+   
   -   5         ��Name$ cmbx_AmazonWhses��5+      $
��Auto��6-   $��30,30,10,30q�6;   $��14(�6P   $��0��6_   $��3��6o   $��7��6�   �� 5,   
   -   5        $ btn_AddWhse��5,      $��Add New Warehouse��6&     ShipmentButtonsStyle#��[ 6B   $��3��6p   $��3��6�   $��7��6�   $��12(�6�   $��10,30,30,30q�6�   6�   �� 5.   
   $��1��6   $��4��6%   $��8��69   .+�5/      �� -   5        $ btn_PrintBoxes��5/   2   $��Print Thermal Labels��6J   #��[ 6i   �� 50      -	   5        $ btn_PrintPDF��50   0   $��Print to PDF��6F   #��[ 6]   �� 51      -
   5        $ 	btn_Clear��51   -   $��	Clear All��6@   #��[ 6T   52      �� 55   
   -   5        $ btn_BackToMain��55      $��Back To Main Menu��6)     BackToMenuBtn#��[ 6b   $��2��6�   $��2��6�   $��9��6�   58      59      