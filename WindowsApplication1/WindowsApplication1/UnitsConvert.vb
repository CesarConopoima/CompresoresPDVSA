Public Class UnitsConvert

    Public Shared Function to_Psi(cantidad As String) As Double
        Dim unit As String = Split(cantidad, "_")(0)
        Dim quantity As Double = CDbl(Replace(Split(cantidad, "_")(1), ".", ","))
        Select Case unit
            Case "[psi]"
                Return quantity
            Case "[Pa]"
                Return quantity * 0.000145037738
            Case "[KPa]"
                Return quantity * 0.145037738
            Case "[MPa]"
                Return quantity * 145.037738
            Case "[bar]"
                Return quantity * 14.5037738
            Case "[m]"
                Return quantity * 1.42197
            Case "[mmHg]"
                Return quantity * 0.019337
            Case Else
                Return quantity
        End Select
    End Function

    Public Shared Function to_MCA(cantidad As String) As Double
        Dim unit As String = Split(cantidad, "_")(0)
        Dim quantity As Double = CDbl(Replace(Split(cantidad, "_")(1), ".", ","))
        Select Case unit
            Case "[psi]"
                Return quantity * 0.703
            Case "[Pa]"
                Return quantity * 0.00010197162
            Case "[KPa]"
                Return quantity * 0.10197162
            Case "[MPa]"
                Return quantity * 101.97162
            Case "[bar]"
                Return quantity * 10.2
            Case "[m]"
                Return quantity
            Case Else
                Return quantity
        End Select
    End Function

    Public Shared Function to_Kelvin(cantidad As String) As Double
        Dim unit As String = Split(cantidad, "_")(0)
        Dim quantity As Double = CDbl(Replace(Split(cantidad, "_")(1), ".", ","))
        Select Case unit
            Case "[°C]"
                Return quantity + 273.15
            Case "[K]"
                Return quantity
            Case "[F]"
                Return (quantity - 32) / 1.8 + 237.15
            Case "[R]"
                Return quantity * 5 / 9
            Case Else
                Return quantity
        End Select
    End Function
    Public Shared Function to_Rankine(cantidad As String) As Double
        Dim unit As String = Split(cantidad, "_")(0)
        Dim quantity As Double = CDbl(Replace(Split(cantidad, "_")(1), ".", ","))
        Select Case unit
            Case "[°C]"
                Return (quantity + 273.15) * 9 / 5
            Case "[K]"
                Return quantity * 9 / 5
            Case "[F]"
                Return quantity + 459.67
            Case "[R]"
                Return quantity
            Case Else
                Return quantity
        End Select
    End Function
    Public Shared Function to_RPM(cantidad As String) As Double
        Dim unit As String = Split(cantidad, "_")(0)
        Dim quantity As Double = CDbl(Replace(Split(cantidad, "_")(1), ".", ","))
        Select Case unit
            Case "[RPM]"
                Return quantity
            Case "[Hz]"
                Return quantity * 60
            Case Else
                Return quantity
        End Select
    End Function

End Class
