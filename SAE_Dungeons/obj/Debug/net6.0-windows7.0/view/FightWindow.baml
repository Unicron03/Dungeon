   M S B A M L   `   `   `  ����G  CSAE_Dungeons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SAE_Dungeons.viewSAE_Dungeons.view  5      #    SAE_Dungeons.view.FightWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:SAE_Dungeons.view     5        � Title$  Fight Window��5      $	��855��6   $	��736��6)   $��24(�65   .��5
      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      $��147.2 �6   �� 5      $��147.2 �6   �� 5      $��147.2 �6   �� 5      $��147.2 �6   �� 5      $��147.2 �6   .+�5   
   �� $��Center=�6   $��Center=�6-   $��2��6H   $��2��6\   $	��125��6m   $��../assets/knight.png��6y   �� 5   
   $��VS��6   $��96(�6   $��2��6+   $��2��6;   $��Center=�6L   $��Bottom=�6i   �� 5   
   $��Center=�6   $��Center=�6-   $��3��6H   $��2��6X   $��2��6l   $	��125��6}   $ ��../assets/monsters/ork.png��6�   �� 5!   
   -   5        $��knightPV��5!      $��20��6    $��2��6-   $��Right=�6:   $��Center=�6V   $��10q�6q   $��36(�6}   �� 5"   
   $
��Left=�6   $��Center=�6+   $��2��6F   $��1��6S   $��64��6c   $#��../assets/inventory/heart.png��6n   �� 5#   
   -   5        $��	monsterPV��5#      $��20��6!   $��2��6.   $��3��6;   $��Right=�6K   $��Center=�6g   $��10q�6�   $��36(�6�   �� 5$   
   $
��Left=�6   $��Center=�6+   $��2��6F   $��4��6S   $��64��6c   $#��../assets/inventory/heart.png��6n   �� 5&   
   
���   �$��3��6!   $��5��6.   $��10��6B   $��	25,0,35,0q�6N   �� 5(   
   $<��6Attendez que le monstre attaque pour contre attaquer !��6   $��4��6Q   $��5��6^   $��Center=�6r   �� 5)   
   -   5        $��orkState��5)      $��Attendez...��6    $��6��66   $��1��6C   $��3��6S   $��Center=�6g   $��Center=�6�   $��34(�6�   $
��Bold"�6�   $y�Hidden=�6�   �� 5*   
   -   5        $��Prêt ?��5*      $��5��6"   $��2��6/   6?   �� 5+   
   -   5        $��attackButton��5+      $��
Attaquer !��6%   $��5��6:   $��1��6G   $y�Hidden=�6W   6k   5,      5-      