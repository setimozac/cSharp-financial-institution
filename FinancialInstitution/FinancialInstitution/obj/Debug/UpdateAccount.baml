   M S B A M L   `   `   `  ����O  KFinancialInstitution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FinancialInstitutionFinancialInstitution  5   	   (    "FinancialInstitution.UpdateAccount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FinancialInstitution     5   	     � WindowStartupLocation$  Manual=�5   	   $��0q�5	   	   
������� � Icon$ /Images/create.png��5   	    � Title$ Update Account��5   	   $	��750��6    $	��754��6-   .��5      � .+�5   
   �� $��Customer Information:��6   $
��Left=�60   $��33��6K   $��	87,17,0,0q�6W   $	��Top=�6j   $	��141��6�    J� RenderTransformOrigin$ 0.922,0.424&�6�   $
��Bold"�6�   �� 5   
   $��Name:��6   $
��Left=�6    $��30��6;   $��	42,77,0,0q�6G   $	��Top=�6Z   $��54��6r   �� 5   
   -   5        $��LblCustomerName��5      $
��name��6'   $
��Left=�66   $��30��6Q   $��
117,77,0,0q�6]   $	��Top=�6q   $	��233��6�   �� 5   
   $��
Open date:��6   $
��Left=�6%   $��30��6@   $��
390,77,0,0q�6L   $	��Top=�6`   $��82��6x   �� 5   
   -   5        $��LblOpenDate��5      $
��date��6#   $
��Left=�62   $��30��6M   $��
500,77,0,0q�6Y   $	��Top=�6m   $	��199��6�   �� 5   
   $��Account type:��6   $
��Left=�6*   $��68��6E   $��
93,136,0,0q�6Q   $	��Top=�6e   $	��574��6}   .��5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5        $��CkbChecking��5      $��Checking��6.   $	��100��6A   $��30,0,0,0q�6M   �� 5      -   5        $��	CkbSaving��5      $��Saving��6,   $	��100��6=   �� 5      -   5        $��CkbTaxFreeSaving��5      $��Tax free saving��63   $	��150��6M   �� 5      -   5        $��	CkbCredit��5      $��Credit��6,   $	��100��6=   5      5      �� 5   
   -   5        $��LvUpdateAccount��5      $
��Left=�6*   $	��271��6E   $��	0,249,0,0q�6R   $	��Top=�6e   $	��745��6}    �� View 5      �� 5      .P�5      �� $��Account Number��6%    �� Width$	 150��6=    �� DisplayMemberBinding 6I   �� *AccountNumber+�� 5      $��Account Type��6%   $	 150��6;    6G   �� *AccountType+�� 5       $��Balance��6%   $	 150��66    6B   �� *	Balance+5!      5#      �� 5$   
   -   5        $��BtnUpdateAccountCancel��5$      $��Cancel��6/   $
��Left=�6@   $��48��6[   $��173,571,0,0q�6g   $	��Top=�6|   $	��125��6�   6�   �� 5%   
   -	   5        $��BtnUpdateAccountUpdate��5%      $��Update��6/   $
��Left=�6@   $��48��6[   $��383,571,0,0q�6g   $	��Top=�6|   $	��125��6�   6�   5'      5(      