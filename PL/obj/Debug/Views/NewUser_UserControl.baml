   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLPL  5          PL.NewUser_UserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:PL     5      .��5      � $��2��6   $��2��6     � RowDefinitions  5	   
   �� 5
      $	��200 �6   �� 5      ��5   
   �� 5       �� Color$ Green��6    �� Opacity$	 0.7Q�6,   .+�5   
   �� -   5         ��Name$ Welcome��5      $��Center=�6%   $��0��6C   $
��Wrap=�5      $��35(�6)   $��Add new user��67    �� TextAlignment$ Center=�6K   $��Bottom=�5      $	��600��6/   $��80��6;   5      �� 5   
   -   5         ��Name$
 Name��5      $��	User name��6   $
��Left=�62   $��
419,79,0,0q�5      $��1��6$   $	��Top=�61   �� 5   
   -   5         ��Name$ 
insertName��5      $
��Left=�6&   $
��auto��6A   $��1��6O   $��410,115,0,0q�5       �� TextWrapping$
 Wrap=�6'   $	��Top=�6Q   $	��120��6i   ��6;   �� *Name+6i   �� 5   
   -   5        $ Password��5      $��Password��6"   $��center=�65   $��404,206,818.333,0q�5      $��1��6+   $	��Top=�68   G� 5   
   -   5         G�Name$ insertPassword��5      $
��Left=�6.   $
��auto��6I   $��1��6W   $��394,241,0,0q�5      	 G� Password$	  ��6'   $	��Top=�63   $	��120��6K   �� 5   
   $
��Back��6   $
��auto��5      $
��auto��6   $��652,347,541.667,73.667q�6,   $��1��6L   ��5       �� *NewUserBackCommand+5   L   �� 5   
   $��Add new user��6   $
��auto��5      $
��auto��6   $��422,301,748.667,54.667q�6,   $��1��6L   ��5   (   �� *AddNewUserCommand+5   L   5       5!      