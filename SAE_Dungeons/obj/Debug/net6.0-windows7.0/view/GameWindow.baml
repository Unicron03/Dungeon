   M S B A M L   `   `   `  ����G  CSAE_Dungeons, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SAE_Dungeons.viewSAE_Dungeons.view  5   	       SAE_Dungeons.GameWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SAE_Dungeons.view     5   	     � Title$  Dungeons��5   	   $	��850��6   $	��736��6'   .��5	      � -   5        $��MainGrid��5	       � RowDefinitions 5
   
    � ColumnDefinitions 5   
   .+�5   
   �� -   5        $��	trapEnter��5      $#��../assets/object/trapdoor.png��6!   $��0��6H   $��0��6X    K� ZIndex$ 2��6e   6v   �� 5   
   -   5        $��trapExit��5      $#��../assets/object/trapdoor.png��6    $ 2��6G   6X   �� 5   
   -   5        $��dijkstra��5      
���  �� J� Opacity$	 0.3Q�6/   �� 5   
   -   5        $��knight��5      $��0��6   $��0��6.   $��../assets/knight.png��6;   $ 3��6Y   6j   �� 5   
   -   5        $��chest��5      $ ��../assets/object/chest.png��6   $ 2��6A   6R   �� 5   
   -   5        $	��ork��5      $ ��../assets/monsters/ork.png��6   $ 2��6?   $y�Hidden=�6P   6d   �� 5   
   -   5        $��orkD2��5      $ ��../assets/monsters/ork.png��6   $ 2��6A   $y�Hidden=�6R   6f   �� 5   
   -	   5        $��chestGUI��5      $��Bottom=�6    $
��Left=�6;   $��20q�6V   $ ��../assets/object/chest.png��6b   6�   �� 5   
   -
   5        $��GUIPanel��5      $#��../assets/inventory/panel.png��6    $��35��6G   $��90��6\   $��0q�6h   $
��Left=�6s   �� 5   
   -   5        $��GUISlot1��5      $"��../assets/inventory/slot.png��6    $��35��6F   $��70��6[   $��70��6g   $��10, 10, 10, 10q�6r   $
��Left=�6�   �� 5   
   -   5        $��GUISlot2��5      $"��../assets/inventory/slot.png��6    $��35��6F   $��70��6[   $��70��6g   $��90, 10, 10, 10q�6r   $
��Left=�6�   �� 5   
   -   5        $��GUISlot3��5      $"��../assets/inventory/slot.png��6    $��35��6F   $��70��6[   $��70��6g   $��170, 10, 10, 10q�6r   $
��Left=�6�   �� 5    
   -   5        $��contentGUITreasure��5       $ ��../assets/object/chest.png��6*   $��35��6N   $��45��6c   $��45��6o   $��22, 10, 10, 10q�6z   $y�Hidden=�6�   $
��Left=�6�   �� 5!   
   -   5        $��contentGUIPickaxe��5!      $"��../assets/object/pickaxe.png��6)   $��35��6O   $��45��6d   $��45��6p   $��102, 10, 10, 10q�6{   $
��Left=�6�   �� 5"   
   -   5        $��contentGUIPotion��5"      $!��../assets/object/potion.png��6(   $��35��6M   $��45��6b   $��45��6n   $��194, 10, 10, 10q�6y   $
��Left=�6�   �� 5$   
   -   5        $��knightPV��5$      $��30(�6    $��20��6.   $��35��6;   $��270, 10, 10, 10q�6P   $��Center=�6i   $
��Left=�6�   �� 5%   
   -   5        $��GUIpv��5%      $#��../assets/inventory/heart.png��6   $��35��6D   $��320, 10, 10, 10q�6Y   $
��Left=�6r   $��45��6�   $��45��6�   �� 5'   
   -   5        $��GUIButtonPath��5'      $��Choose Path��6&   $��35��6S   $��400, 10, 10, 10q�6h   $
��Left=�6�   $��35��6�   $	��100��6�   5(      5)      