   M S B A M L   `   `   `  ����J  FMyBlockNoteTry1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MyBlockNoteTry1MyBlockNoteTry1  5   	   )    #MyBlockNoteTry1.ThemeSettingsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   )localclr-namespace:MyBlockNoteTry1  5   	     � Title$  ThemeSettingsWindow��5	   	   $	��450��6%   $	��410��62   .��5
      � .+�5   
   �� -   5         ��Name$ ButtonOK��5      $��OK��6#   $��	10,0,0,31q�60   $��30��6C   $��Bottom=�6O   $
��Left=�6j   $	��180��6�   6�   �� 5   
   -   5        $ ButtonCancel��5      $��Cancel��6'   $��	0,0,10,31q�68   $��30��6K   $��Bottom=�6W   $��Right=�6r   $	��180��6�    �� IsCancel . 6�   ]� 5   
   $��50��6   $��0,10,0,0q�6    $	��Top=�62   $
��Left=�6J   $	��400��6e   .+�5      #  Xceed.Wpf.Toolkit.ColorPicker  -   5          Name$ ColorPickerBackground��5      $	��382��6>   $��Bottom=�6J   6�   �� 5      -   5         ��Name$ ColorLabelBackground��5      $��Задний фон��62   $	��380��6G   $	��Top=�6S   5      ]� 5   
   $��50��6   $��0,65,0,0q�6    $	��Top=�62   $
��Left=�6J   $	��400��6e   .+�5        -   5        $ ColorPickerFont��5      $	��382��68   $��Bottom=�6D   6�   �� 5      -   5        $ ColorLabelFont��5      $��
Шрифт��6,   $	��380��6<   $	��Top=�6H   5      ]� 5   
   $��50��6   $��	0,120,0,0q�6    $	��Top=�63   $
��Left=�6K   $	��400��6f   .+�5        -   5        $ ColorPickerSelector��5      $	��382��6<   $��Bottom=�6H   6�   �� 5      -   5        $ ColorLabelSelector��5      $��Выделение��60   $	��380��6D   $	��Top=�6P   5      �� 5   
   -	   5        $ ButtonReset��5      $��Reset��6&   $
��Left=�66   $��
10,175,0,0q�6Q   $	��Top=�6e   $	��150��6}   6�   5      5      