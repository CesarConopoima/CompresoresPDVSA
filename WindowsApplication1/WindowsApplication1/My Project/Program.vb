Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

Namespace TestSplashScreen
	NotInheritable Class Program
		Private Sub New()
		End Sub
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Friend Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Inicio())
		End Sub
	End Class
End Namespace
