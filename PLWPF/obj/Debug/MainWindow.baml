   M S B A M L   `   `   `  ????@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     ? 
ResizeMode$  CanMinimize=?5   	    ? Title$ Hosting Menager??5	   	   $??486.856??6!   $??661.24??62    ? 	Resources 5
         goBackLinearGradientBrush ? Color ? Offset??%?   &	        ?? 5   
   .??5      ? $ LightSkyBlue??6   $ 0Q?5      ? 5      $ LightSlateGray??6   $	 0.5Q?5      ? 5      $ 	LightBlue??6   $ 1Q?5      5      5      .??5      ? $??0,0,1,-1q?6    ? ColumnDefinitions 5   
   ?? 5      ?? 5      $??0* ?6   .+?5   
   ?? -   5         ??Name$ guestButton??5      $??Guest Request??6&   $??Stretch=?6>   $??441,143,78,0q?6\   $	??Top=?6r   $??42??6?   
???2?2?$??14(?6?   ?? 5   
   -   5        $ 
hostButton??5      $??Login as host??6%   $??Stretch=?6=   $??260,191,267,0q?6[   $	??Top=?6r   $??42??6?   
??? ???$??14(?6?   ?? 5   
   -   5        $ adminButton??5      $??Login as admin??6&   $??Stretch=?6?   $??74,232,447,0q?6]   $	??Top=?6s   $??42??6?   
??? E??$??14(?6?   ?? 5   
   $??בס''ד??6   $
??Left=?6    $??
607,10,0,0q?6;   $	??Top=?6O   $??26??6g   $??37??6s   ?? 5   
   -   5        $ 
exitButton??5      $??Exit Program??6%   #??[  6<   $
??Left=?6t   $??
10,391,0,0q?6?   $	??Top=?6?   $??85??6?   $??28??6?   o? 5   
   $
??Left=?6   $??26??6*   $??	10,10,0,0q?66   $	??Top=?6I   $??25??6a    J? RenderTransformOrigin$ 
2.12,1.914&?6l   .@?5      m? -   5         m?Name$ languageMenuItem??5      $??25??61   $??25??6<   	 m? Icon	 5       ?? 5!      $??/Images/language.png??6   6<   .@?5#      m? -   5        $??English??5#      	 5$      ?? 5%      $??/Images/US_flag.png??6    6?   5'      m? 5(      -   5        $??
עברית??5(      	 5)      ?? 5*      $??/Images/Israel_flag.png??6    6C   5,      5-      5.      ??5/   
   ?? 50      
 ?? ImageSource$!
 /Images/backgroundImage.jpg??6   54      55      