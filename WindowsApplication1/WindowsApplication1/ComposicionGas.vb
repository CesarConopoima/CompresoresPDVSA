Public Class ComposicionGas

    'constructor de la clase
    'se construye pasando el parametro de la cadena de gases presente en la cromatografia
    Public Sub New(gases As String)
        Me.gases = gases
    End Sub

    Private gases As String
    Public Property Fullgases() As String
        Get
            Return gases
        End Get
        Set(ByVal value As String)
            gases = value
        End Set
    End Property

    Public Function GetPropertiesOfGasesMix() As Array
        Dim numberOfSpecies As Integer = (Split(Fullgases, ";").Count)
        Dim gasName As String
        Dim porcentaje As Double
        Dim pesoMolecularPorGas As Double
        Dim presionReducidaPorGas As Double
        Dim temperaturaReducidaPorGas As Double
        Dim totalPesoMolecular As Double
        Dim totalPresionCriticaPorGas As Double
        Dim totalTemperaturaCriticaPorGas As Double
        'In the split method, when it is not specified the separator is ","
        For i As Integer = 0 To numberOfSpecies - 2
            gasName = Split(Split(Fullgases, ";")(i), ":")(0)
            porcentaje = CDbl(Replace(Split(Split(Fullgases, ";")(i), ":")(1), ".", ",")) / 100
            pesoMolecularPorGas = porcentaje * GetPropertieOfGasName(gasName)(0)
            presionReducidaPorGas = porcentaje * GetPropertieOfGasName(gasName)(1)
            temperaturaReducidaPorGas = porcentaje * GetPropertieOfGasName(gasName)(2)
            totalPesoMolecular += pesoMolecularPorGas
            totalPresionCriticaPorGas += presionReducidaPorGas
            totalTemperaturaCriticaPorGas += temperaturaReducidaPorGas
        Next
        Return {totalPesoMolecular, totalPresionCriticaPorGas, totalTemperaturaCriticaPorGas}
    End Function

    'Retorna la gravedad especifica de la Mezcla de gases, considerando que el peso molecular del aire es
    '28.97 [Kg/Kgmol]
    Public Function getSpecifcGravity() As Double
        Return GetPropertiesOfGasesMix()(0) / 28.97
    End Function

    'Definir una función que contenga todas las propiedades de los posibles gases
    Private Function GetPropertieOfGasName(ByVal gas As String) As Array
        'El orden y las unidades de estos arreglos son Peso Molecular [Kg/Kgmol], Presión Critica [psia], Temperatura Crítica[Rankine],Factor acentrico [w]
        Select Case gas
            Case "C1"
                Return {16.04, 667.174, 343, 0.008}
            Case "C2"
                Return {30.07, 707.8, 549.77, 0.099}
            Case "C3"
                Return {44.09, 616.3, 665.68, 0.152}
            Case "IC4"
                Return {58.123, 529.1, 734.63, 0.181}
            Case "NC4"
                Return {58.123, 570.7, 765.29, 0.2}
            Case "IC5"
                Return {72.15, 490.4, 828.27, 0.229}
            Case "NC5"
                Return {72.15, 448.6, 845.27, 0.252}
            Case "C6"
                Return {86.177, 444.7, 868.41, 0.345}
            Case "CO2"
                Return {44.01, 1070, 547.47, 0.225}
            Case "N2"
                Return {28.013, 492.548, 227.14, 0.04}
                'el caso por defecto devuelve las propiedades del aire
            Case Else
                Return {28.97, 546.21, 238.59, 0.2}
        End Select
    End Function
    'Esto retorna la viscosidad en unidades de [Cp] centipoise
    Public Function ViscosidadEquivalente(TempActual As Double) As Double
        Dim numberOfSpecies As Integer = (Split(Fullgases, ";").Count)
        Dim gasName As String
        Dim TempCritica, PresionCritica, PM, omega, Letseu, porcentaje, sumaVisco As Double
        Dim chi, chi0, chi1 As Double
        '-------------------Propiedad de la mezcla necesaria--------------
        Dim temperaturaReducidadMezcla As Double = TempActual / GetPropertiesOfGasesMix()(2)
        'In the split method, when it is not specified the separator is ","
        For i As Integer = 0 To numberOfSpecies - 2
            gasName = Split(Split(Fullgases, ";")(i), ":")(0)
            porcentaje = CDbl(Replace(Split(Split(Fullgases, ";")(i), ":")(1), ".", ",")) / 100
            PM = GetPropertieOfGasName(gasName)(0)
            PresionCritica = GetPropertieOfGasName(gasName)(1)
            TempCritica = GetPropertieOfGasName(gasName)(2)
            omega = GetPropertieOfGasName(gasName)(3)
            chi = (TempCritica ^ (1 / 6)) / ((PM ^ 0.5) * (PresionCritica ^ (2 / 3)))
            chi0 = 0.015174 - 0.02135 * temperaturaReducidadMezcla + 0.0075 * (temperaturaReducidadMezcla ^ 2)
            chi1 = 0.042552 - 0.07674 * temperaturaReducidadMezcla + 0.034 * (temperaturaReducidadMezcla ^ 2)
            Letseu = (chi0 + omega * chi1) / chi
            sumaVisco += porcentaje * Math.Log(Letseu)
        Next
        Return Math.Exp(sumaVisco)
    End Function
    'Devuelve la densidad de la mezcla a paritr de la gravedad especifica de la mezcla y de la composición
    Public Function DensidadDeMezcla(ByVal gravedadEspecifica As Double)
        Dim PMMezcla As Double = GetPropertiesOfGasesMix()(0)
        Dim API As Double = (141.5 / gravedadEspecifica) - 131.5
        Return (141.5 / (131.5 + API)) * 62.4 * 16.0185
    End Function


End Class
