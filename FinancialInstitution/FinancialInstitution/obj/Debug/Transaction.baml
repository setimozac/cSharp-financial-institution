   M S B A M L   `   `   `  ����O  KFinancialInstitution, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FinancialInstitutionFinancialInstitution  5   	   &     FinancialInstitution.Transaction   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FinancialInstitution     5   	     � WindowStartupLocation$  Manual=�5   	   $��0q�5	   	   
������� � Icon$ /Images/create.png��5   	    � Title$ Transaction��5   	   $	��750��6   $	��754��6*   .��5      �  � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��* �6   .+�5   
   o� $	��Top=�6   $��0��6%   .@�5      m� $
��File��6   $��60��6%   .@�5      m� -   5         m�Name$ MenuItemExit��5      $
��Exit��6L   5      5      m� 5      $��Authentication��6   $	��100��6/   {�.  .@�5      m� -   5        $ MenuItemEmpLogin��5      $��Employee Login��65    m� Icon 5      �� 5      $��/Images/employee-icon.png��6    5      m� 5      -   5        $ MenuItemClientLogin��5      $��Client password��69    5       �� 5!      $��/Images/dial.png��6    5#      �� 5$      m� 5%      -   5        $ MenuItemEmpLogout��5%      $��Employee Logout��66    5&      �� 5'      $��/Images/employee-icon.png��6    5)      5*      m� 5,      $��Tools��6   $��60��6&   .@�5-      m� -   5        $ MenueItemCalendar��5-      $��Calendar��6X   m� 5.      -   5        $ MenueItemCalculator��5.      $��
Calculator��6\   m� 5/      -   5        $ MenueItemTakePhoto��5/      {�.  $��
Take Photo��6J   50      52      � 53   
   $��1��6   .+�54      �� $��Name:��6   $
��Left=�6$   $��24,9,0,0q�6?   $	��Top=�6Q   $��55��6i   �� 55      -   5        $��LblCustomerName��55      $�� ��6+   $
��Left=�66   $��	101,9,0,0q�6Q   $	��Top=�6d   $	��157��6|   �� 56      $��User Id:��6   $
��Left=�6'   $��	300,9,0,0q�6B   $	��Top=�6U   $��55��6m   �� 57      -	   5        $��	LblUserId��57      $�� ��6%   $
��Left=�60   $��	360,9,0,0q�6K   $	��Top=�6^   $	��157��6v   �� 58      $��Select an account:��6   $
��Left=�61   $��
120,47,0,0q�6L   $	��Top=�6`   $	��140��6x   $��right=�6�   �� 59      -
   5        $��CbFromAccount��59      $
��Left=�6,   $��
280,47,0,0q�6G   $	��Top=�6[   $	��120��6s   6   �� 5:      $��Balance:��6   $
��Left=�6'   $��
440,47,0,0q�6B   $	��Top=�6V   �� 5;      -   5        $��LBalanceOfFromAccount��5;      $�� ��61   $
��Left=�6<   $��
510,47,0,0q�6W   $	��Top=�6k   $	��147��6�   �� 5<      $��Amount:��6   $
��Left=�6&   $��
120,87,0,0q�6A   $	��Top=�6U   $	��140��6m   $��right=�6y   �� 5=      -   5        $��TbAmount��5=      $
��Left=�6&   $��23��6A   $��
280,89,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5>      -   5        $��BtnTransactionDeposit��5>      $��Deposit��62   $
��Left=�6D   $��37��6_   $��225,134,0,0q�6k   $	��Top=�6�   $	��115��6�   6�   �� 5?      -   5        $��BtnTransactionWithdraw��5?      $��Withdraw��63   $
��Left=�6F   $��37��6a   $��420,135,0,0q�6m   $	��Top=�6�   $	��115��6�   6�   	� 5@      -   5        $��RbToYourAccount��5@      $�� ��61    	� 	GroupName$ 	ToAccount��6<   $
��Left=�6R   $��
95,215,0,0q�6m   $	��Top=�6�   6�   �� 5A      $��To your account:��6   $
��Left=�6/   $��120,207,0,0q�6J   $	��Top=�6_   $	��140��6w   $��right=�6�   �� 5B      -   5        $��CbToAccount��5B      {�.  $
��Left=�6<   $��280,207,0,0q�6W   $	��Top=�6l   $	��120��6�   6�   �� 5C      $��Balance:��6   $
��Left=�6'   $��440,207,0,0q�6B   $	��Top=�6W   �� 5D      -   5        $��LBalanceOfToAccount��5D      $�� ��6/   $
��Left=�6:   $��510,207,0,0q�6U   $	��Top=�6j   $��76��6�   	� 5E      -   5         	�Name$ RbToOtherUserAccount��5E      $�� ��68   $ 	ToAccount��6C   $
��Left=�6Y   $��
95,265,0,0q�6t   $	��Top=�6�   6�   �� 5F      $��To other user's account:��6   $
��Left=�67   $��120,257,0,0q�6R   $	��Top=�6g   $	��140��6   $��right=�6�   �� 5G      -   5        	 ��Name$	 TbToOtherAccount��5G      $
��Left=�60   $��23��6K   $��280,259,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��120��6�   �� 5H      -   5        $��BtnTransactionCancel��5H      $��Cancel��61   $
��Left=�6B   $��41��6]   $��225,313,0,0q�6i   $	��Top=�6~   $	��115��6�   6�   �� 5I      -   5        $��BtnTransactionTransfer��5I      $��Transfer��63   $
��Left=�6F   $��37��6a   $��420,315,0,0q�6m   $	��Top=�6�   $	��115��6�   6�   �� 5J      -   5        $��LvTransaction��5J      $
��Left=�6,   $	��307��6G   $��
53,388,0,0q�6T   $	��Top=�6h   $	��630��6�   
 �� View
 5K      �� 5L      .P�5N      �� $��ShowAccount��6)    �� Width$	 180��6>    �� DisplayMemberBinding 6J   �� *ShowAccount+�� 5O      $��ShowRecieverAccount��6)   $	 180��6F    6R   �� *ShowRecieverAccount+�� 5Q      $��Amount��6)   $	 100��69    6E   �� *Amount+�� 5R      $��Transaction Date��6)   $	 150��6C    6O   �� *TransactionDate+5S      5U      5W      5X      5Y      