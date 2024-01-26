#SingleInstance, force

PrintScreen::
		ifWinExist, ahk_exe Discord.exe ahk_class Chrome_WidgetWin_1
			WinClose, ahk_exe Discord.exe ahk_class Chrome_WidgetWin_1

		else
			Run C:\Users\Alan Schneider\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Discord Inc\Discord.lnk
		return
;ExitApp


!End::
		Send, Thank you for your time,
		Send,{Enter}
		Send, Alan Schneider
		return