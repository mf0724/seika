   M S B A M L   `   `   `  ����  ColorBasics-WPF5    /Microsoft.Samples.Kinect.ColorBasics.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Color Basics��5      $	��735��6   $	��770��6'    � 	Resources 5         MediumGreyBrush �� Color  KinectPurpleBrush  KinectBlueBrush �� 
TargetType �� Property �� Value  SnapshotButton �� 
TargetType �� Orientation ��Name	 �� TextAlignment
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%1  &	        &	 #     &	 F     '�� i     &	 �     7  7  �� 5   
   $ 	#ff6e6e6e��62   �� 5   
   $ 	#ff52318f��64   �� 5	   
   $ 	#ff00BCF2��62   �� 5
   
   " ��6   .�5      ��  �@J�SnapsToDevicePixels . 64   5      �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ 
Horizontal=�6)   
������ .+�5   "   �� $ SnapText��6,   #��z��6>   $
	 Left=�6_   $��Center=�6u   8��  $��15(�6�   � 5   "   $��9,0,0,0q�6'   .+�5   &   �� $
 
SnapNormal��6,   $��Images\SnapNormal.png��6@   $
��None=�6_   $��Center=�6n   �� 5   &   $
 	SnapHover��6,   $��Images\SnapHover.png��6?   $
��None=�6]   $��Center=�6l   $y�	Collapsed=�6�   5   #   5      5       5      P� 5       �@J�IsMouseOver . . �5   "   �� $ 
SnapNormal��6Q    � y�$ 	Collapsed=�6?   6Q   �� 5   "   $ 	SnapHover��6O    � y�$ Visible=�6?   6O   �� 5   "   8  $ SnapText��6h    � ��5      5!      5#      5$      5%      .��5'      � -   5        $��
layoutGrid��5'      $��	10 0 10 0q�6    � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $��* �6   �� 5+      $
��Auto �6   �� 5,      $
��Auto �6   .+�5.   
   (� $��1��6    (� Stretch$ Uniform=�6   $��Center=�61   .��5/      �� -   5        $��Image��5/      $	��640��6!   $	��480��6-   50      �� 51   
   -   5        $��	statusBar��51   ?   $��3��6   $��Stretch=�6!   $��Bottom=�6P   
�������#��[  6~   .@�52      �� $��0 0 0 10q�6   .��53      �� -   5        $��statusBarText��53      $��-1 0 0 0q�61   JHPress 'Screenshot' to save a screenshot to your 'My Pictures' directory.6�   54      55      �� 56   
   -   5         ��Name$ ShotPictureButton��56      $��Button��6,   $
��Left=�6=   $��2��6X   $	��Top=�6e   $	��106��6}   $��32��6�   6�   �� 57   
   -   5         ��Name$ 
TimerLabel��57      $��Label��6$   $
��Left=�64   $��10,0,0,0q�6O   $	��Top=�6a   $��2��6y   $"��Hiragino Kaku Gothic ProN W3)�6�   $��24(�6�   $
��Bold"�6�   �� 58   
   -   5        $ VersionInfoButton��58      $��Button��6,   $
��Left=�6=   $��	579,0,0,0q�6X   $��2��6k   $	��Top=�6x   $	��142��6�   $��32��6�   6�   59      5:      