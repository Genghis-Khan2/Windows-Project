   M S B A M L   `   `   `  ����=  9PL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLPL  5   	       PL.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   "localclr-namespace:PL     5   	     � Icon$  market-icon.ico��5   	    � Title$  ��5	   	   #��Z��6   #��Z��5
       � WindowStartupLocation$ CenterScreen=�6G    � WindowState$ 	Maximized=�5   	    � 
ResizeMode$ NoResize=�6!    � 	Resources 5      (   "PL.StateMachineVisibilityConverter   StateMachineConverter��%   &	          5   
   60   5      .��5      � .+�5   
   � -   5         �Name$ start��5      $��3��6   $��2��6+   y�5      �� *StateMachine.State+ �� 	Converter# [   �� ConverterParameter$ Start��	 � RowDefinitions	 5      �� 5      $��* �6    �� 5      $��2* �6    �� 5      $��* �6    ��5      �� 5      
 �� Color$
 Yellow��6"    �� Opacity$	 0.7Q�61   .+�5       �� $%��Welcome to the Marcating system��6    
 Header#���  6@   �� 5!      -   5         ��Name$
 Name��5!      $��
User name:��6"   $��1��67   $��474,150.333,640.333,133q�6D   $
��Auto��6e   �� 5"      -   5         ��Name$ 
insertName��5"      $
��Left=�6*   $��1��6E   $��20(�6R   $��664,146.333,0,0q�5#       �� TextWrapping$
 Wrap=�6+   $	��Top=�6U   $	��120��6m   $��39��6y   ��6?   �� *Name+6y   �� 5$      -   5        $ Password��5$      $��	Password:��6&   $��1��6:   $��482,226.333,656.333,51q�6H   $
��Auto��6h   G� 5%      -   5         G�Name$ insertPassword��5%      $
��Left=�62   $��39��6M   $��1��6Y   $��664,231.333,0,0q�5&       G� Password$  ��6+   $	��Top=�67   $	��120��6O   $��20(�6[   �� 5'      -   5         ��Name$ enterUserButton��5'      $��Enter as user��6.   $��2��6F   $	��150��5(      $��574,79,565.333,55.667q�6D   ��6   �� *UserEntryCommand+6D   �� 5)      -   5        $ enterManagerButton��5)      $��Enter as manager��61   $��2��6M   $	��150��5*      $��898,81,241.333,53.667q�6G   ��6   �� *ManagerEntryCommand+6G   �� 5+      -   5        $ newUserButton��5+      $��Create new user��6,   $��2��6G   $	��150��5,      $��294,79,845.333,55.667q�6H   ��6   �� *CreateNewUserCommand+6H   5-      � 5/   
   -	   5        $ manager��5/      y�6    �� *StateMachine.State+# [  $ Manager��.+�52         PL.Manager_UserControl  53      � 55   
   -
   5        $
 user��55      y�6   �� *StateMachine.State+# [  $
 User��.+�58          PL.RegularUser_UserControl  59      � 5;   
   -   5        $ newUser��5;      y�6    �� *StateMachine.State+# [  $ NewUser��.+�5>         PL.NewUser_UserControl  5?      5A      5E      