   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLPL  5          PL.Manager_UserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:PL     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � $��2��6     � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��3* �6   ��5   
   �� 5       �� Color$ Yellow��6    �� Opacity$	 0.7Q�6-   .+�5   
   �� -   5         ��Name$ label��5      $��welcome manager!��6   $��30(�6:   $��Center=�6H   $��0��6f   �� 5   
   -   5         ��Name$ 
tabControl��5      $��Stretch=�6)   $��Stretch=�5       �� TabStripPlacement$
 Left=�62   $��1��6K   .@�5/      �� $��Product catalog��6   $��20(�6/   .��50      "   PL.ProductCatalogUserControl  51      �� 52      $��Add Product��6   $��20(�6+   .��53         PL.AddProductUserControl  54      �� 55      $��Product charts��6   $��20(�6.   .��56         PL.MChartsUserControl  57      58      �� 59   
   $��
disconnect��6   $	��100��5:      $��60��6   $��2��6*   $��25,150q�67   $
��Left=�6G   $��Bottom=�6b   ��59   &   �� *DisconnectCommand+5:   b   �� 5;   
   -   5        $	��100��5<      $��60��6   $��2��6*   $��25,50q�67   $
��Left=�6F   $��Bottom=�6a   .��5>      �� $��close the system��6   $
��Wrap=�60    �� TextAlignment$ Center=�6D   5?      5@      5A      