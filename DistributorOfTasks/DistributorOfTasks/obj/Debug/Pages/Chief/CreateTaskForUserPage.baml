   M S B A M L   `   `   `  ����M  IDistributorOfTasks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:DistributorOfTasks.Pages.ChiefDistributorOfTasks.Pages.Chief  5      :    4DistributorOfTasks.Pages.Chief.CreateTaskForUserPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:DistributorOfTasks.Pages.Chief     5        N� Title$  CreateTaskForUserPage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��5* �6   .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,50q�62   .+�5      �� $��Title: ��6   $��18(�6*   $��
0,0, 62, 0q�68   �� 5      -   5        $��TitleTextBox��5      $	��150��6.   $
��Auto��6=   $	��230��6J   $��15(�6Y   5      �� 5      $ 
Horizontal=�6   $��0,0,0,50q�62   .+�5      �� $��Description: ��6   $��18(�60   �� 5      -   5        $��DescriptionTextBox��5       �� TextWrapping$
 Wrap=�64   $	��230��6H   $	��300��6T   $��15(�6a   5      5      �� 5   
   $��1��6   $ 
Horizontal=�6%   .+�5      �� -   5        $��UserComboBox��5       �� SelectedIndex$ 0��6+   $��30��6=   $	��Top=�6I   $��17(�6a   �� 5      -   5        $��PriorityComboBox��5      $ 0��6/   $��30��6A   $	��Top=�6M   $��17(�6e   (  "System.Windows.Controls.DatePicker  5       -   5        $��DeadlineDatePicker��5       $	��200��64   $��30��6@   $	��Top=�6L   5!      �� 5#   
   -   5        $��
SaveButton��5#   !   $��1��6   $��Create task��63   $	��100��6I   $	��200��6V   $��Bottom=�6b   $��Right=�6}   $��	0,0,50,50q�6�   6�   5$      5%      