   M S B A M L   `   `   `  ����G  CtelegramBot1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:telegramBot1telegramBot1  5   	       telegramBot1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:telegramBot1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � -   5         �Name$ mainGrid��5	       � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��5* �6   .+�5   
   �� -   5         ��Name$ userList��5      $��0��5      $	��300��5      $	��450��5      
�������$��15(�5      ��5      �� *Users+ �� SelectedItem 5      �� *CurrentUser+ �� Mode$ TwoWay=���5      �� 5      .R�5      �� ��6    �� *Nick+5      5      � 5   
   -   5        $ 	rightGrid��5      $��1��5       � RowDefinitions 5       �� 5!      $��7* �6    �� 5"      $��1* �6    �� 5#      $��1* �6    .+�5%      �� -   5        $ messages��5%      $��0��5&      $	��450��5'      $	��450��5(      
�������$��15(�5+      ��5*      �� *CurrentUser.Messages+5,      �� 5-      -   5         ��Name$ messageTextBox��5-      $��1��5.      
�����w�$��20(�50      $	��450��51       �� TextWrapping$
 Wrap=�52      ��53      �� *	Message+$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�.��55      
 J� InputBindings
 56      �� 57      
 �� Key$ Enter��6!    �� Command 6-   �� *SendMessage+.��58   )   59      �� 5:      -   5         ��Name$ sendMsgButton��5:      $��2��5;      
����ح�$
��Send��5=      $��30(�5>      $	��300��5?      ��5@      �� *SendMessage+5B      5C      5D      