   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5   <   ` \Neodynamic.WPF.Barcode, Version=4.0.3500.0, Culture=neutral, PublicKeyToken=c6b33c3093a0d4cdO<clr-namespace:Neodynamic.WPF;assembly=Neodynamic.WPF.BarcodeNeodynamic.WPF 6�    WpfApplication_BETA'   !WpfApplication1.Cust_Profile_View   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   cmyTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5   <   Lmy1<clr-namespace:Neodynamic.WPF;assembly=Neodynamic.WPF.Barcode     6�     � Title$  Cust_Profile_View��6	   $	��740��6#   $	��995��60   .��5      � $	��947��6   $	��652��6   ���	#FFFFECCB.+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dataGrid1��5   g      AlternatingRowBackground
 �����   AutoGenerateColumns .  $��	36,41,0,0q�6T   $	��224��6�   $	��Top=�6�   ���	#FFFCEFEF   CanUserAddRows . $
��Left=�6�   $	��899��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6H      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6V      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� 	 �� Path$	 	Cust_Name�6b     5	      $ Gender��6E   $ 60 6U    .  6%   �� $	 gender�6`     5
      $ Address��6K   $	 130 6\    .  6%   �� $	 Cust_address�6h     5      $ Landline��6L   $	 130 6^    .  6%   �� $	 Cust_landline�6j     5      $ Mobile��6J   $	 100 6Z    .  6%   �� $	 Cust_mobile�6f     5      $ EMail-ID��6I   $	 130 6[    .  6%   �� $	 
Cust_email�6g     5      $ Authentication��6H   $	 130 6`    .  6%   �� $	 	Cust_auth�6l     5      $ Profile Created On��6R   $ 90 6n    .  6%   �� $	 Cust_profile_create�6y   5      �� 5   
   -   5        $��button1��5   e   $��Goto MainPage��6   $��23��6)   $
��Left=�65   $��617,285,0,0q�6P   $	��Top=�6t   $��93��6�   6�   �� 5   
   -   5        $��label1��5   b   $��Search Name��6   $��28��6&   $
��Left=�62   $��285,285,0,0q�6M   $	��Top=�6p   -   'System.Windows.Controls.AutoCompleteBox  5   
   -   5        $��	Cust_Name��5   M   $
��Left=�6   $��380,285,0,0q�68   $	��Top=�6^   $	��175��6v   (  "Neodynamic.WPF.BarcodeProfessional  5   
   -   5        $��barcode��5   R   $
��Left=�6"   $��107,392,0,0q�6=   
   	Symbology$
 Code128=�6a      TextForeground
 �����$	��150��6�   $	��100��6�   $	��Top=�6�   �� 5   
   -   5        $��textBox1��5   N   $��23��6   $
��Left=�6   $��427,424,0,0q�69   $	��Top=�6^   $	��120��6v   �� 5   
   -   5        $��button2��5   c   $��Gen Barcode��6   $��23��6'   $
��Left=�63   $��306,424,0,0q�6N   $	��Top=�6r   $��75��6�   6�   �� 5   
   -   5        $��image1��5   @   $
��Left=�6   $��569,412,0,0q�6+   $
��Fill=�6N   $	��141��6]   $��52��6i   $	��Top=�6u   �� 5   
   -	   5        $��button3��5   ]   $��Print��6   $��23��6!   $
��Left=�6-   $��804,345,0,0q�6H   $	��Top=�6l   $��75��6�   6�   o� 5   
   -
   5        $��menu1��5   ,   $��33��6   $��3,3,0,0q�6   $	��Top=�69   ���	#FFE58D00.@�5      m� -   5        $��Add Customer��5      
��� ���
�������$��1q�5      
�������$��15(�6F    m� Icon 5      �� 5      $4��./WpfApplication_BETA;component/Images/ava1.png��6   $
��Auto��6T   5       m� 5!      -   5        $��View Customer Data��5!      
��� ���
�������$��1q�5"      
�������$��15(�6F   5$      m� 5%      -   5        $��
Apply Loan��5%      
��� ���
�������$��1q�5&      
�������$��15(�6F   5(      5)      5*      5+      