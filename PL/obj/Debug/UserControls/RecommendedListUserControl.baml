   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLPL  5      #    PL.RecommendedListUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:PL     5        � 	Resources  5	        PL.ImageConverter   ImageConverter��%   &	          5
   
   6   5      .��5      ]� ��. .+�5   
   � $	��Top=�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$
 Bton��5      $��Show the reccomand list��6#   $��Center=�6E   $
��auto��6`   $��20,0,0,0q�6�   �� 5      -   5        $
��Cbox��5      $��1��6#    �� 
IsEditable .  �� Text$ Choose day of the week��6E   $��Center=�6c   5      � 5   
   $��Bottom=�6   .+�5      �� -   5        $ pdfBton��5      $!��Download the reccomand list��6&   $��Center=�6L   $
��auto��6g   6t   5      �� 5   
   -   5         ��Name$ 	scrollBar��5      $��10��6'   $
��auto��62   $��Right=�6A   �� 5   
   -   5         ��Name$ listView��5       �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$
 auto��63   	 �� DisplayMemberBinding	 6@   �� *Name+�� 5      $��Price��6%   $
 auto��64   	 6A   �� *Price+�� 5      $��Weight��6%   $
 auto��65   	 6B   �� *Weight+�� 5      $��Category��6%   $
 auto��67   	 6D   �� *Cat+�� 5       $��Description��6%   $
 auto��6:   	 6G   �� *Description+�� 5(      $��Image��6%   $
 auto��64   
 �� CellTemplate
 5)      �� 5*      .R�5+   "   �� ��5,   &   �� 5-   *    �� DecodePixelWidth$	 100��66    �� 	UriSource 5.   6   �� *
Image_path+ �� 	Converter# [  50   #   51      53      �� 54      $��	Available��6%   $
 auto��68   
 55      �� 56      .R�57   "   ��  ��Name$ CheckBox��6+   {�.   J� Opacity$ 10Q�6|    � ToolTip$: 4Select to enable or disable the product in the store��58   +    d� 	IsChecked 57   O   �� *	Available+ �� Mode$ TwoWay=�58   +   59      5;      5<      5>      5?      5@      