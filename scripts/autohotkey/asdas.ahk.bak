#SingleInstance, Force

Menu, ql, Add, steam, steam
Menu, ql, Add, epic, ep
Menu, ql, Add, spotify, spot
Menu, ql, Add
Menu, media, Add, youtube, yt
Menu, media, Add, twitch, tw
Menu, media, Add, dopebox, db
Menu, media, Add, anime, an
Menu, ql, Add, Media, :media

;layer := 0
SetCapsLockState, OFF
NumLock::
	KeyWait, NumLock
	If (A_PriorKey="NumLock")
		SetNumLockState, % GetKeyState("NumLock", "T") ? "Off" :  "On"
Return

#If, GetKeyState("NumLock", "T") ;Your CapsLock hotkeys go below

F22:: Send, +#{T}
#If, !GetKeyState("NumLock", "T")
F15:: send, ^c
F16:: Send, ^V
F17:: Send, #v
F13::Menu, ql, show
F22:: run, explorer.exe ms-screenclip: return
;F21:: Send,{F10}

steam:
Run, "C:\Users\Alan Schneider\Documents\scripts\Batch\steam.bat"
return

ep:
Run, "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Epic Games Launcher.lnk"
return

spot:
Run, "C:\Users\Alan Schneider\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Spotify.lnk"
return

yt:
Run, "https://youtube.com"
return

tw:
Run, "https://twitch.tv"
return

db:
Run, "https://dopebox.se/"
return

an:
Run, "https://aniwatch.to/"
return

null:
return