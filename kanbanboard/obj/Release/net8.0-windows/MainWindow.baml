   M S B A M L   `   `   `  ����   kanbanboard    kanbanboard.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Kanban Board��$	��600��$	��800��.���  � RowDefinitions �� $
��Auto ��� $��* �.+���  �� Orientation$ 
Horizontal=�$��Center=�$��0��.+��� -   $��	Odśwież��$	��100��$��5q��� -   $��Dodaj zadanie��$	��100��$��5q��� -   $��Usuń zadanie��$	��100��$��5q�&   System.Windows.Controls.DataGrid  -     Name$ KanbanDataGrid��$��1��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Nowe��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 	   CellTemplate	 �� .R��� ���� *Nowe+���� .R��� 
�������$��1q�$��5q�
 �� Padding$
 5q�._��� .+��� $
��Bold"����� *title+�� $
��Wrap=�$��CharacterEllipsis=�$��80������ *description+�� ���� *assigned_user+�� -   $��Edytuj��$��5q��� -   $��Szczegóły������   $ Zaplanowane��$ * 	 �� .R��� ���� *Zaplanowane+���� .R��� 
�������$��1q�$��5q�$
 5q�._��� .+��� $
��Bold"����� *title+�� $
��Wrap=�$��CharacterEllipsis=�$��80������ *description+�� ���� *assigned_user+�� -   $��Edytuj��$��5q��� -   $��Szczegóły������   $ 	W trakcie��$ * 	 �� .R��� ���� *
WTrakcie+���� .R��� 
�������$��1q�$��5q�$
 5q�._��� .+��� $
��Bold"����� *title+�� $
��Wrap=�$��CharacterEllipsis=�$��80������ *description+�� ���� *assigned_user+�� -	   $��Edytuj��$��5q��� -
   $��Szczegóły������   $ 
Testowanie��$ * 	 �� .R��� ���� *
Testowanie+���� .R��� 
�������$��1q�$��5q�$
 5q�._��� .+��� $
��Bold"����� *title+�� $
��Wrap=�$��CharacterEllipsis=�$��80������ *description+�� ���� *assigned_user+�� -   $��Edytuj��$��5q��� -   $��Szczegóły������   $ 
Ukończone��$ * 	 �� .R��� ���� *	Ukonczone+���� .R��� 
�������$��1q�$��5q�$
 5q�._��� .+��� $
��Bold"����� *title+�� $
��Wrap=�$��CharacterEllipsis=�$��80������ *description+�� ���� *assigned_user+�� -   $��Edytuj��$��5q��� -   $��Szczegóły������ 