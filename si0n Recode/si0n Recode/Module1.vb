Imports si0n.cUsefulFuncs
Imports si0n.cSDK
Imports si0n.KeyBinds

'Just to provide some credits:
'https://www.unknowncheats.me/forum/counterstrike-global-offensive/139780-vb-net-external-esp-recoil-crosshair.html got me kinda started with the memory class and the other stuff
'Credits to Mercy for his Raytracing resources
'Klorik, he helped me with the knifechanger
'The guy who made the sigscanning function
'Unknowncheats.me for the resources i used to make this

Module Module1

    Public Misc_thread As Threading.Thread = New Threading.Thread(AddressOf loop_Misc)
    Public Aimbot_thread As Threading.Thread = New Threading.Thread(AddressOf loop_Aimbot)
    Public ESP_thread As Threading.Thread = New Threading.Thread(AddressOf loop_esp)
    Public SkinChanger_thread As Threading.Thread = New Threading.Thread(AddressOf loop_SkinChanger)
    Public KnifeChanger_thread As Threading.Thread = New Threading.Thread(AddressOf loop_KnifeChanger)

    Dim off As String = "                      "
    Sub Main(args As String())
        Console.Title = "si0n"
        Console.ForegroundColor = ConsoleColor.Magenta
        wl("")
        wl(off & " _______ _________ _______  _       ")
        wl(off & "|  ____ \\__   __/|  __   || \    /|")
        wl(off & "| |    \/   | |   | |  |  ||  \  | |")
        wl(off & "| |_____    | |   | | /   ||   \ | |")
        wl(off & "|_____  |   | |   | |/ /| || |\ \| |")
        wl(off & "      | |   | |   |   / | || | \   |")
        wl(off & "/\____| |___| |___|  |__| || |  \  |")
        wl(off & "\_______|\_______/|_______||/    \_|")
        wl("")
        Console.ForegroundColor = ConsoleColor.White
        wl("================================================================================")
        wl("")

        CheckIfAppIsAllreadyRunning()

        Console.ForegroundColor = ConsoleColor.Green

        wl("searching process...")
        Do Until mem.Setup("csgo")
            sleep(1000)
        Loop
        wl("process found...")
        wl("modules found...")
        wl("cheat started...")
        Console.ForegroundColor = ConsoleColor.White
        wl(cfg.ConfigPath.ToString)

        If Not cfg.exists Then
            Settings.Save()
        End If

        If Not System.IO.File.Exists("Offsets.ini") Then
            wl("")
            Console.ForegroundColor = ConsoleColor.Red
            wl("Offsets file not found. Check if its there.")
        End If

        Settings.Load()

        Misc_thread.Start()
        Aimbot_thread.Start()
        ESP_thread.Start()
        SkinChanger_thread.Start()
        KnifeChanger_thread.Start()
        KnifeChanger_thread.Priority = Threading.ThreadPriority.Highest
        Aimbot_thread.Priority = Threading.ThreadPriority.Highest

        Console.Beep()
        Console.Read()
    End Sub

    Public Sub loop_Misc()
        While True
            InGame = Engine.Ingame
            Caption = GetCaption()
            RestartIfCsgoNotValid()

            If GetAsyncKeyState(SkinchangerKey) Then Engine.Fullupdate()
            If GetAsyncKeyState(Keys.Down) Then Misc.Rankscan()
            If GetAsyncKeyState(Keys.F5) Then
                Settings.Load()
                Console.Beep()
                sleep(300)
            End If

            If InGame And Caption = GameCaption Then
                If Settings.Bhop Then Misc.Bhop()
                If Settings.Noflash Then Misc.Noflash(Settings.NoflashMaxAlpha)
                If Settings.Nohands Then Misc.Nohands()
                If Settings.Radar Then Misc.Radar()
                Misc.ThirdPerson(Settings.Thirdperson)
            End If

            sleep(1)
        End While
    End Sub

    Public Sub loop_Aimbot()
        While True

            If InGame And Caption = GameCaption Then
                If Settings.Aimbot Then Aimbot.Aimbot(Settings.AimSpot, Settings.FovRifles, Settings.SmoothRifles, Settings.FovPistols, Settings.SmoothPistols, Settings.FovSnipers, Settings.SmoothSnipers)

                If Settings.Trigger Then Triggerbot.Triggerbot(Settings.TriggerMode)
            End If

            sleep(1)
        End While
    End Sub

    Public Sub loop_esp()
        While True

            If InGame Then
                pLocalPlayer.ptr = cBasePlayer.LocalPlayer()
                If Settings.ESP Or Settings.clrRender Then ESP.GlowESP(Settings.ESP, Settings.clrRender, Settings.ESPmode)
            End If

            sleep(1)
        End While
    End Sub

    Public Sub loop_SkinChanger()
        While True

            If InGame And Not GetAsyncKeyState(Keys.Tab) Then
                If Settings.SkinChangera Then SkinChanger.Skinchanger()
            End If

            sleep(1)
        End While
    End Sub

    Public Sub loop_KnifeChanger()
        While True

            If InGame Then
                If Settings.KnifeChangera Then KnifeChanger.KnifeChanger(Settings.KnifeModel)
            ElseIf Not InGame Then
                KnifeChanger.Reset()
            End If

            sleep(1)
        End While
    End Sub

End Module
