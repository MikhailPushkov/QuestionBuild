   M S B A M L   `   `   `  ����  
QuestBuild0    *QuestBuild.ShowWindows.ShowStudents_Window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  ShowStudents_Window��5   	   $	��360��6%   $	��600��62   .��5      � .+�5   
   �� $��Группа:��6   $
��Left=�6"   $��	10,10,0,0q�6=   $	��Top=�6P   �� 5   
   -   5         ��Name$ Cb_Group��5      $
��Left=�6%   $��	66,14,0,0q�6@   $	��Top=�6S   $	��125��6k   6w   &   System.Windows.Controls.DataGrid  5   
   -   5        $��Dg_Students��5      $
��Left=�6&   $��	10,41,0,0q�6A   $	��Top=�6T   $	��278��6l   $	��470��6y      AutoGenerateColumns .     Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО студента��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *fio+6U   5      �� 5   
   -   5         ��Name$ Button_AddStudents��5      $��Добавить��6-   $
��Left=�6@   $��
488,41,0,0q�6[   $	��Top=�6o   $��94��6�   $��60��6�   6�   �� 5   
   -   5        $ Button_Change��5      $��Изменить��6(   $
��Left=�6;   $��488,106,0,0q�6V   $	��Top=�6k   $��94��6�   $��60��6�   6�   �� 5   
   -   5        $ Button_Remove��5      $��Удалить��6(   $
��Left=�6:   $��488,171,0,0q�6U   $	��Top=�6j   $��94��6�   $��60��6�   6�   5      5      