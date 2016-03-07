Imports System.IO
Imports System.Security.AccessControl
Public Class Form1

   
    Dim ExtArray(500) As String
    Dim Audio As String() = {"Audio", ".mp3", ".wav", ".wma", ".rm", ".ogg", ".mid", ".m4a", ".mpa", ".m3u"}
    Dim Video As String() = {"Video", ".wmv", ".m4v", ".vob ", ".mp4", ".mov", "mkv", ".avi", ".divx", ".mpeg", ".mpg", ".m4p", ".flv", ".webm", ".3gp"}
    Dim Document As String() = {"Document", ".docx", ".doc", ".txt", ".xls", ".pdf", ".rtf", ".tex", ".wpd", ".xlsx", ".pptx", ".ppt"}
    Dim Code As String() = {"Code", "vbs", ".c", ".h", ".vb", ".xhtml", ".rss", ".cpp", ".java", ".php", ".html", ".css", ".py", ".aspx", ".json", ".js", ".jsp", ".do", ".htm", ".cfm", ".xml", ".xaml", ".pl", ".asp", ".fs", ".cs", ".sln"}
    Dim Images As String() = {"Images", ".jpg", ".jpeg", ".png", ".tiff", ".gif", ".bmp", ".svg", ".psd", ".tiff"}
    Dim Data As String() = {"Data", ".csv", ".dat", ".raw", ".sdf", ".vcf", ".xml"}
    Dim Database As String() = {"Database", ".db", ".accdb", ".accdc", ".adb", ".cdb", ".dbc", ".dbf", ".dbs", ".mdb", ".mdf", ".odb", ".sdb", ".sqlite", ".sqlite3", ".sqlitedb", ".xld", ".pdb"}
    Dim Executable As String() = {"Executable", ".apk", ".exe", ".app", ".bat", ".cgi", ".com", ".gadget", ".jar", ".pif", ".wsf", ".msi", ".bin", ".inf"}
    Dim Subtitle As String() = {"Subtitle", ".srt", "sub", ".sbv", ".ifo", ".idx"}
    Dim Certificate As String() = {"Certificate", ".cer", ".cert", ".pem", ".ssl", ".crt", ".csr", ".pfx", ".crl", ".stl", ".key"}
    Dim Shortcuts As String() = {"Shortcuts", ".lnk"}
    Dim Plugins As String() = {"Plugins", ".crx", ".plugin", ".xpi"}
    Dim Fonts As String() = {"Fonts", ".ttf", ".fnt", ".fon", ".otf"}
    Dim SystemFile As String() = {"System", ".cab", ".sys", ".cpl", ".ico", ".drv", ".cur"}
    Dim Config As String() = {"Config", ".cfg", ".ini", ".dll"}
    Dim Compressed As String() = {"Compressed", ".7z", ".rar", ".zip", ".deb", ".pkg", ".tar.gz"}
    Dim ISO As String() = {"ISO", ".iso", ".dmg", ".vcd", ".mdf"}
    Dim Backup As String() = {"Backup", ".bak", ".tmp"}
    Dim Torrents As String() = {"Torrents", ".torrent"}
    Dim Misc As String() = {"Misc", ".crdownload", ".part", ".aup", ".orig", ""}
    Dim i As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.ShowDialog()
        FolderPath.Text = FolderBrowserDialog1.SelectedPath
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Directory.Exists(FolderPath.Text) = False Then
            MessageBox.Show("Please enter a valid path.")
            Exit Sub
        End If
        Process.Start(FolderPath.Text)
    End Sub

    Function CheckExt(ByVal DataCollection As String(), ByVal PresentCollection As String(), ByVal Path As String) As Boolean
        Dim securityRules As DirectorySecurity = New DirectorySecurity()
        securityRules.AddAccessRule(New FileSystemAccessRule(System.Security.Principal.WindowsIdentity.GetCurrent().Name, FileSystemRights.FullControl, AccessControlType.Allow))

        For Each item As String In PresentCollection
            If DataCollection.Contains(item) Then
                Directory.CreateDirectory(Path & "\" & DataCollection(0), securityRules)
                Return True
            End If
        Next
        Return False
    End Function

    Sub PlaceFiles(ByVal DataCollection As String(), ByVal file As String)

        If DataCollection.Contains(System.IO.Path.GetExtension(file)) Then
            If System.IO.File.Exists(FolderPath.Text & "\" & DataCollection(0) & "\" & System.IO.Path.GetFileName(file)) Then
                System.IO.File.Delete(file)
            Else
                System.IO.File.Move(file, FolderPath.Text & "\" & DataCollection(0) & "\" & System.IO.Path.GetFileName(file))
            End If

        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Directory.Exists(FolderPath.Text) = False Then
            MessageBox.Show("Please enter a valid path.")
            Exit Sub
        End If
        Dim PathName As String = FolderPath.Text
        Dim FileNames As String() = Directory.GetFiles(FolderPath.Text)
        For Each FileName As String In FileNames
            If ExtArray.Contains(Path.GetExtension(FileName)) = False Then
                ExtArray(i) = Path.GetExtension(FileName)
            End If
            i = i + 1
        Next

        CheckExt(Audio, ExtArray, PathName)
        CheckExt(Video, ExtArray, PathName)
        CheckExt(Document, ExtArray, PathName)
        CheckExt(Code, ExtArray, PathName)
        CheckExt(Images, ExtArray, PathName)
        CheckExt(Data, ExtArray, PathName)
        CheckExt(Database, ExtArray, PathName)
        CheckExt(Executable, ExtArray, PathName)
        CheckExt(Compressed, ExtArray, PathName)
        CheckExt(SystemFile, ExtArray, PathName)
        CheckExt(Misc, ExtArray, PathName)
        CheckExt(ISO, ExtArray, PathName)
        CheckExt(Torrents, ExtArray, PathName)
        CheckExt(Backup, ExtArray, PathName)
        CheckExt(Config, ExtArray, PathName)
        CheckExt(Subtitle, ExtArray, PathName)
        CheckExt(Certificate, ExtArray, PathName)
        CheckExt(Shortcuts, ExtArray, PathName)
        CheckExt(Plugins, ExtArray, PathName)
        CheckExt(Fonts, ExtArray, PathName)

        For Each FileName As String In FileNames
            PlaceFiles(Audio, FileName)
            PlaceFiles(Video, FileName)
            PlaceFiles(Document, FileName)
            PlaceFiles(Code, FileName)
            PlaceFiles(Images, FileName)
            PlaceFiles(Data, FileName)
            PlaceFiles(Database, FileName)
            PlaceFiles(Executable, FileName)
            PlaceFiles(Compressed, FileName)
            PlaceFiles(SystemFile, FileName)
            PlaceFiles(Misc, FileName)
            PlaceFiles(ISO, FileName)
            PlaceFiles(Torrents, FileName)
            PlaceFiles(Backup, FileName)
            PlaceFiles(Config, FileName)
            PlaceFiles(Subtitle, FileName)
            PlaceFiles(Certificate, FileName)
            PlaceFiles(Shortcuts, FileName)
            PlaceFiles(Plugins, FileName)
            PlaceFiles(Fonts, FileName)
        Next

        MessageBox.Show("Your folder has been sorted!")
    End Sub
End Class
