   M S B A M L   `   `   `  ����H  DFBAContentApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FBAContentApp.ViewsFBAContentApp.Views  5      !    FBAContentApp.Views.History   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:FBAContentApp.Views     5      .��5
      �   � ColumnDefinitions  5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��Shipment History��6      
titleLabel#��[  6+   $��1��6O   $��4��6_   $��0��6s   �� 5    
   $
��Bold"�6   $��14(�6"   $��1��60   $��2��6@   $��1��6T   $��Center=�6a   $��Center=�6|   $��Search for Shipment ID ��6�   �� 5!   
   -   5        $��searchTextBox��5!      $��3��6O   $��2��6_   $��1��6s   $��Stretch=�6�   $��Center=�6�   ]� 5$   
   $��	50,0,50,0q�6   $��0��6I   $��6��6Y   $��2��6m   $��3��6z    � DataContext 6'   �� *	Shipments+.+�5'      �� $��	10,5,10,5q�6   $��Stretch=�6-   $	��Top=�6K   .+�5(      �� $
��Bold"�6   $��14(�6*   .��68   	Shipments6C   �� 5)      -   5        $��shipmentListBox��5)   6   $	��110��6   $
��Auto��6)   $	��Top=�6e    �� DisplayMemberPath$ 
ShipmentID��6}   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   ��6M   �� 6�   5*      �� 5-      $��	10,5,10,5q�6   $	��Top=�6,   .+�5.      �� $
��Bold"�6   $��14(�6*   ��68   ��  �� Path$ 
ShipmentID� �� FallbackValue$ Boxes��50      �� 51      -   5        $��
boxListBox��51   7   $	��130��6   $
��Auto��6)   $ BoxID��6l   $
 TrueY�6�    �� SelectionMode$ Extended=�6�   ��6I   �� $ Boxes�6�   52      �� 55      $��	10,5,10,5q�6   .+�56      �   57      �� 58      �� 59      �� 5:       5<      �� 5=      �� 5>      �� 5?      �� 5@      �� 5A      .+�5D      �� $��0,0,0,5q�6    $��0��61   $��0��6A   $
��Left=�6N   $
��Wrap=�6i   $��18(�6}   $
��Bold"�6�   $��
Ship From:��6�   �� 5E      $��2��6    $��0��60   $
��Left=�6=   $
��Wrap=�6X   $��18(�6l   $
��Bold"�6z   $��Ship To:��6�   6�   �� 5G      $��0��6    $��1��60   $
��Left=�6=   $
��Wrap=�6X   ��6l   �� $ CompanyShipFrom�6�   �� 5H      $��2��6    $��1��60   $
��Left=�6=   $
��Wrap=�6X   ��6l   �� $ FullfillmentShipTo�6�   �� 5J      $��	0,10,0,10q�6    $��0��63   $��2��6C   $��Right=�6P   $��WrapWithOverflow=�6l   $��18(�6�   $
��Bold"�6�   $��Ship Date: ��6�   6�   �� 5K      $��0,15,0,0q�6    $��1��62   $��2��6B   $��2��6V   $
��Left=�6c   $��WrapWithOverflow=�6~   ��6�   �� $ ShipmentDate�6�   �� 5M      $��0��6    $��3��60   $��3��6D   $
��Bold"�6Q   $��18(�6c   Contents String6�   �� 5N      $��0,0,0,20q�6    $��0��62   $��3��6B   $��4��6V   $
��Wrap=�6c   ��6w   �� $ Boxes/ContentString�6�   5O      5P      5Q      � 5T   
   $��Center=�6   $��Center=�61   $��1��6L   $��4��6\   $��5��6p   .+�5U      �� -   5         ��Name$ printPDFBtn��5U      $��Reprint PDF Label(s)��6F     amzwhseButton#��[ 6e   �� 5V      -   5        $ printBoxBtn��5V      $��Reprint Thermal Label(s)��6F   #��[ 6i   5W      �� 5Y   
   -   5        $��Back To Main Menu��5Y        BackToMenuBtn#��[ 6-   $��2��6t   $��2��6�   $��6��6�   5[      5\      