   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLPL  5      "    PL.ProductCatalogUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:PL     5      -   5          >�Name$  uc��5       � 	Resources 5
        PL.ImageConverter   ImageConverter��%   &	          5   
   6   5      .��5      ]� ��. .+�5   
   �� -   5         ��Name$ 	scrollBar��5      $��10��6'   $
��auto��62   $��Right=�6A   �� 5   
   -   5         ��Name$ listView��5      ��6%   ��  �� Path$ Products� �� View 5      �� 5      .P�5      �� $
��Name��6%    �� Width$
 auto��63    �� DisplayMemberBinding 6@   �� *Name+�� 5      $��Price��6%   $
 auto��64    6A   �� *Price+�� 5      $��Weight��6%   $
 auto��65    6B   �� *Weight+�� 5      $��Category��6%   $
 auto��67    6D   �� *Cat+�� 5      $��Description��6%   $
 auto��6:    6G   �� *Description+�� 5      $��Id��6%   $
 auto��61    �� CellTemplate 5      �� 5      .R�5   "   �� $��	Underline{�6@   
����  �	 � Cursor$
	 Hand��6n   ��6,   �� *Id+6n   5      5       �� 5!      $��Image��6%   $
 auto��64    5"      �� 5#      .R�5$   "   �� ��5%   &   �� 5&   *   
 �� DecodePixelWidth$	
 100��66    �� 	UriSource 5'   6   �� *
Image_path+ �� 	Converter# [  5)   #   5*      5,      �� 5-      $��	Available��6%   $
 auto��68    5.      �� 5/      .R�50   "   ��  ��Name$ CheckBox��6+    J� Opacity$ 10Q�6j    � ToolTip$: 4Select to enable or disable the product in the store��51   +    d� 	IsChecked 50   =   �� *	Available+ �� Mode$ TwoWay=�51   +   52      54      55      57      5:      5<      