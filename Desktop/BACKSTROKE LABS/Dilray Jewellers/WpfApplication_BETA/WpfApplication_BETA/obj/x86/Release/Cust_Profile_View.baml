   M S B A M L   `   `   `  ���� p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  ` \Neodynamic.WPF.Barcode, Version=4.0.3500.0, Culture=neutral, PublicKeyToken=c6b33c3093a0d4cdO<clr-namespace:Neodynamic.WPF;assembly=Neodynamic.WPF.BarcodeNeodynamic.WPF  WpfApplication_BETA'   !WpfApplication1.Cust_Profile_View   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     cmyTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     Lmy1<clr-namespace:Neodynamic.WPF;assembly=Neodynamic.WPF.Barcode       � Title$  Cust_Profile_View��$	��740��$	��995��.��� $	��947��$	��652�����	#FFFFECCB.+�&   System.Windows.Controls.DataGrid  -   $��	dataGrid1��   AlternatingRowBackground
 �����   AutoGenerateColumns .  $��	36,41,0,0q�$	��224��$	��Top=����	#FFFCEFEF   CanUserAddRows . $
��Left=�$	��899��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� 	 �� Path$	 	Cust_Name�  $ Gender��$ 60  .  �� $	 gender�  $ Address��$	 130  .  �� $	 Cust_address�  $ Landline��$	 130  .  �� $	 Cust_landline�  $ Mobile��$	 100  .  �� $	 Cust_mobile�  $ EMail-ID��$	 130  .  �� $	 
Cust_email�  $ Authentication��$	 130  .  �� $	 	Cust_auth�  $ Profile Created On��$ 90  .  �� $	 Cust_profile_create��� -   $��button1��$��Goto MainPage��$��23��$
��Left=�$��617,285,0,0q�$	��Top=�$��93���� -   $��label1��$��Search Name��$��28��$
��Left=�$��285,285,0,0q�$	��Top=�-   'System.Windows.Controls.AutoCompleteBox  -   $��	Cust_Name��$
��Left=�$��380,285,0,0q�$	��Top=�$	��175��(  "Neodynamic.WPF.BarcodeProfessional  -   $��barcode��$
��Left=�$��107,392,0,0q�
   	Symbology$
 Code128=�   TextForeground
 �����$	��150��$	��100��$	��Top=��� -   $��textBox1��$��23��$
��Left=�$��427,424,0,0q�$	��Top=�$	��120���� -   $��button2��$��Gen Barcode��$��23��$
��Left=�$��306,424,0,0q�$	��Top=�$��75���� -   $��image1��$
��Left=�$��569,412,0,0q�$
��Fill=�$	��141��$��52��$	��Top=��� -	   $��button3��$��Print��$��23��$
��Left=�$��804,345,0,0q�$	��Top=�$��75��o� -
   $��menu1��$��33��$��3,3,0,0q�$	��Top=����	#FFE58D00.@�m� -   $��Add Customer��
��� ���
�������$��1q�
�������$��15(� m� Icon �� $4��./WpfApplication_BETA;component/Images/ava1.png��$
��Auto��m� -   $��View Customer Data��
��� ���
�������$��1q�
�������$��15(�m� -   $��
Apply Loan��
��� ���
�������$��1q�
�������$��15(�