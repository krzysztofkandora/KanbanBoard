   M S B A M L   `   `   `  ����   kanbanboard     kanbanboard.EditTaskWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Edytuj Zadanie��$	��400��$	��400��.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��Tytuł zadania:��$��Center=�$��0��$��0��$��0,5,10,5q��� -    ��Name$ TaskTitleTextBox��$��0��$��1��$��0,5,0,5q��� $��Opis zadania:��$��Center=�$��1��$��0��$��0,5,10,5q��� -   $ TaskDescriptionTextBox��$��1��$��1��$��0,5,0,5q� �� AcceptsReturn$
 True��$��80�� �� TextWrapping$
 Wrap=��� $��Przypisz do użytkownika:��$��Center=�$��2��$��0��$��0,5,10,5q��� -    ��Name$ UserComboBox��$��2��$��1��$��0,5,0,5q� �� DisplayMemberPath$ login���� $��Status zadania:��$��Center=�$��3��$��0��$��0,5,10,5q��� -   $ StatusComboBox��$��3��$��1��$��0,5,0,5q�.@��� $
��Nowe��
 � Tag$
 Nowe���� $��Zaplanowane��$ Zaplanowane���� $��	W trakcie��$ WTrakcie���� $��
Testowanie��$ 
Testowanie���� $��
Ukończone��$ 	Ukonczone���� -   $��Zapisz Zmiany��$��4��$��0��$��2��$��0,15,0,0q�$��Center=�$	��150��