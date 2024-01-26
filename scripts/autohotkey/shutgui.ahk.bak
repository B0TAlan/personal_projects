#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.

#SingleInstance,Force


Gui, Add, Text,,Would you like to sleep or shutdown computer
Gui, Add, Button,x40 y60 w55 h30 gSleep,sleep
Gui, Add, Button,x+30 y60 w60 h30 gShut,shutdown
Gui, Add, Button,x+30 y60 w55 h30 gCan,cancel
Gui, Show, w300 h100,Power
return

Can:
	ExitApp
return

Sleep:
	Run, "C:\Users\Alan Schneider\Documents\scripts\Batch\sleep.bat"
	ExitApp
return

Shut:
	Run, "C:\Users\Alan Schneider\Documents\scripts\Batch\shut.bat"
	ExitApp
return