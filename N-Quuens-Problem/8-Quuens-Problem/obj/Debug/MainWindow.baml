   M S B A M L   `   `   `  ����K  G8-Quuens-Problem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:_8_Quuens_Problem_8_Quuens_Problem  5   	   "    _8_Quuens_Problem.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:_8_Quuens_Problem     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ N-Queens Problem��5	   	   $	��700��6"   $
��1160��6/   .��5
      � -   5         �Name$ gridView��5
       � ColumnDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $	��242 �6   �� 5      $	��242 �6   �� 5      $��15 �6    � RowDefinitions 5   
   �� 5      $��15 �6   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��15 �6   .+�5   
   � -   5        $ chessboardGrid��5      $��1��6'   $��2��64   $��1��6E   $	��610��6U   $	��610��6b   
���iii�5      �� 5   
   -   5         ��Name$ textInfoPanel��5      $��2��6,   $��1��6<   $��Center=�6I   .+�5      �� -   5        $ heuristicPanel��5      $��0,20,0,0q�61    �� Orientation$ 
Horizontal=�6C   .+�5       �� -   5         ��Name$ heuristicText��5       $
��Wrap=�64   $��Heuristic: ��6H   $��20(�6[   $	��Top=�6i   �� 5!      -   5        $ heuristicValueText��5!      $
��Wrap=�69   $��20(�6M   $	��Top=�6[   5"      �� 5#      -   5        $ 
stepsPanel��5#      $��0,20,0,0q�6-   $ 
Horizontal=�6?   .+�5$      �� -   5        $ 	stepsText��5$      $
��Wrap=�6/   $��Number of steps: ��6C   $��20(�6\   $	��Top=�6j   �� 5%      -	   5        $ stepsValueText��5%      $
��Wrap=�64   $��20(�6H   $	��Top=�6V   5&      �� 5'      -
   5        $ solvedPanel��5'      $��0,20,0,0q�6.   .+�5(      �� -   5        $ 
solvedText��5(      $
��Wrap=�61   $��Was the problem solved?��6E   $��20(�6d   $	��Top=�6r   �� 5)      -   5        $ solvedTextValue��5)      $��0,10,0,0q�65   $
��Wrap=�6H   $��20(�6]   $	��Top=�6k   5+      5,      �� 5.   
   -   5        $ chooseSizePanel��5.      $��Center=�6.   $��1��6L   $��3��6Y   $	��Top=�6i   .+�5/      �� -   5        $ chooseBoardSizeText��5/      $��Center=�65   $
��Wrap=�6R   $��
Board size��6f   $��20(�6x   $
��Bold"�6�   �� 50      -   5         ��Name$ chooseBoardSizeBox��50      $��Center=�63   $��0,20,0,0q�6P   $��80��6c   6n   51      �� 53   
   -   5        $ chooseAlgorithmPanel��53      $��2��63   $��2��6C   $��Center=�6P   $��Center=�6m   .+�54      �� -   5        $ chooseAlgorithmText��54      $
��Wrap=�65   $��Choose algorithm��6I   $��20(�6a   $
��Bold"�6o   $	��Top=�6�   �� 55      -   5        	 ��Name$	 hillClimbingBox��55      $��Hill climbing​��60   $��0,20,0,0q�6I   6[   �� 56      -   5        $	 simulatedAnnealingBox��56      $��Simulated annealing��66   $��0,20,0,0q�6T   6f   �� 57      -   5        $	 localBeamSearchBox��57      $��Local beam search��63   $��0,20,0,0q�6O   6a   �� 58      -   5        $	 geneticAlgorithmBox��58      $��Genetic algorithm​��64   $��0,20,0,0q�6Q   6c   59      �� 5;   
   -   5        $ algorithmAtributesPanel��5;      $��3��66   $��2��6F   $��Center=�6S   $��Center=�6p   5=      �� 5>   
   -   5        
 ��Name$
 newBoardButton��5>      $��Generete new board��6)   $��3��6F   $
��Left=�6V   $��
50,0,0,340q�6q   $��2��6�   $��Bottom=�6�   $��DemiBold"�6�   $��15(�6�   $	��150��6�   
�������6�   �� 5@   
   -   5        $
 	runButton��5@      $
��Run!��6$   $��3��63   $
��Left=�6C   $��
-40,0,0,40q�6^   $��2��6r   $��Bottom=�6   $��DemiBold"�6�   $��20(�6�   $��75��6�   
�������6�   5B      5C      