#SingleInstance, force
;def
Menu, ql, Add, umassd, umd
Menu, ql, Add, Coin, coin
Menu, ql, Add, email, todo
Menu, ql, Add, mycourses, mycourses
Menu, ql, Add, cengage, cen
Menu, ql, Add, hr, hrdirect


;Binds
F7:: Media_Play_Pause ; play/pause

F10:: Menu, ql, Show ; show menu

F21:: Menu, ql, Show ; show menu

;F13:: Send, #{Tab} ; comand tab

!Right:: Send, ^#{Right} ; switch desktop r

!Left:: Send, ^#{Left} ; switch desktop l

!/:: Send, ^#{d} ; make new desktop

!Delete:: Send, ^#{F4} ; delet desktop

;functions
umd:
Run, "https://www.umassd.edu/"
Return

coin:
Run, "https://campus.sa.umasscs.net/psc/csm/EMPLOYEE/SA/c/SA_LEARNER_SERVICES.SSS_STUDENT_CENTER.GBL?gsmobile=1"
Return

mycourses:
Run, "https://umassd.umassonline.net/webapps/portal/execute/tabs/tabAction?tab_tab_group_id=_19_1"
Return

cen:
Run, "https://www.cengage.com/"
Return

hrdirect:
Run, "https://hr-direct.hcm.umasscs.net/psc/hcm/EMPLOYEE/HRMS/c/NUI_FRAMEWORK.PT_LANDINGPAGE.GBL"
return

todo:
Run,	"https://outlook.office.com/"
return