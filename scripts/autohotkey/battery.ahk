PowerWriteProcessorStateValueIndex(100, "AC") ;Wall
PowerWriteProcessorStateValueIndex(25, "DC") ;Battery
ExitApp

;---------------------
PowerWriteProcessorStateValueIndex(Max := "", Mode := "") {
	l:=PowerEnumeratePlans(ActivePlan), VarSetCapacity(GUID_ACTIVE_POWER_SAVING, 16, 0), VarSetCapacity(GUID_PROCESSOR_SETTINGS_SUBGROUP, 16, 0)
	, DllCall("Ole32.dll\CLSIDFromString", "WStr", "{" ActivePlan.GUID "}", "Ptr", &GUID_ACTIVE_POWER_SAVING), VarSetCapacity(GUID_PROCESSOR_THROTTLE_MAXIMUM, 16, 0)
	, DllCall("Ole32.dll\CLSIDFromString", "WStr", "{54533251-82be-4824-96c1-47b60b740d00}", "Ptr", &GUID_PROCESSOR_SETTINGS_SUBGROUP)
	, DllCall("Ole32.dll\CLSIDFromString", "WStr", "{BC5038F7-23E0-4960-96DA-33ABAF5935EC}", "Ptr", &GUID_PROCESSOR_THROTTLE_MAXIMUM)
	, DllCall("PowrProf.dll\PowerWrite" Mode "ValueIndex", "Ptr", 0, "Ptr", &GUID_ACTIVE_POWER_SAVING
	, "Ptr", &GUID_PROCESSOR_SETTINGS_SUBGROUP, "Ptr", &GUID_PROCESSOR_THROTTLE_MAXIMUM, "UInt", Max, "UInt")
	for k, v in l
		if !(v.Default) {
			RunWait, % ComSpec " /c powercfg /s " v.GUID,, Hide
			break
		} RunWait, % ComSpec " /c powercfg /s " ActivePlan.GUID,, Hide
}

;------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

;enumerates all power plans
;for k, v in PowerEnumeratePlans()
;	MsgBox % "#" k "`nGUID: " v.GUID "`Name: " v.Name "`nDefault?: " v.Default
PowerEnumeratePlans(ByRef ActivePlan := "") {
	List := {}
	for k, v in StrSplit(CMD("powercfg /l"), ":", A_Space A_Tab)
		if (A_Index>1) {
			Info := {}, Info.GUID := SubStr(Trim(v), 1, 36), Info.Default := !!InStr(v, "*")
			, Info.Name := Trim(StrSplit(SubStr(v, InStr(v, "(")+1), ")")[1]), List.Push(Info)
			if (Info.Default)
				ActivePlan := Info
		} return List
}

;executes cmd command and return the result
CMD(CMD := "", Encoding := "UTF-8", ByRef ExitCode := "") {
	DllCall("Kernel32.dll\CreatePipe", "PtrP", hReadPipe, "PtrP", hWritePipe, "Ptr", 0, "UInt", 0)
	, DllCall("Kernel32.dll\SetHandleInformation", "Ptr", hWritePipe, "UInt", 1, "UInt", 1)
	, Size := VarSetCapacity(STARTUPINFO, A_PtrSize=4?68:104, 0), NumPut(Size, STARTUPINFO, 0, "UInt")
    , NumPut(0x100, STARTUPINFO, A_PtrSize=4?44:60, "UInt"), NumPut(hStdInRd, STARTUPINFO, A_PtrSize=4?56:80, "Ptr")
    , NumPut(hWritePipe, STARTUPINFO, A_PtrSize=4?60:88, "Ptr"), NumPut(hWritePipe, STARTUPINFO, A_PtrSize=4?64:96, "Ptr")
	, pi := CreateProcess(, ComSpec " /c " CMD,,,, 0x08000000,,, &STARTUPINFO)
	, DllCall("Kernel32.dll\CloseHandle", "Ptr", hWritePipe), Size := VarSetCapacity(Buff, 4095)
	while DllCall("Kernel32.dll\ReadFile", "Ptr", hReadPipe, "Ptr", &Buff, "UInt", Size, "PtrP", Bytes, "Ptr", 0)
        OutputVar .= StrGet(&Buff, Bytes, Encoding)
	DllCall("Kernel32.dll\CloseHandle", "Ptr", pi.handle), DllCall("Kernel32.dll\CloseHandle", "Ptr", hReadPipe)
	return OutputVar, DllCall("Kernel32.dll\GetExitCodeProcess", "Ptr", pi.handle, "UIntP", ExitCode)
} CreateProcess(ApplicationName := "", ByRef CommandLine := "", ProcessAttributes := 0, ThreadAttributes := 0, InheritHandles := true, CreationFlags := 0x08000000, Environment := 0, CurrentDirectory := "", StartupInfo := 0) {
	VarSetCapacity(PROCESS_INFORMATION, A_PtrSize=4?16:24, 0)
	, r := DllCall("Kernel32.dll\CreateProcess", "Ptr", ApplicationName=""?0:&ApplicationName, "Ptr", CommandLine=""?0:&CommandLine
	, "Ptr", ProcessAttributes, "Ptr", ThreadAttributes, "Int", !!InheritHandles, "UInt", CreationFlags, "Ptr", Environment, "Ptr", CurrentDirectory=""?0:&CurrentDirectory
	, "Ptr", StartupInfo, "Ptr", &PROCESS_INFORMATION)
	return r?{HANDLE: NumGet(PROCESS_INFORMATION, 0, "Ptr"), hThread: NumGet(PROCESS_INFORMATION, A_PtrSize, "Ptr")
	, ID: NumGet(PROCESS_INFORMATION, A_PtrSize=4?8:16, "Ptr"), ThreadID: NumGet(PROCESS_INFORMATION, A_PtrSize=4?12:24, "Ptr")}:0, ErrorLevel := !r
}
