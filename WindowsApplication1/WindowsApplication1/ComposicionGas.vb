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
            porcentaje = CDbl(Split(Split(Fullgases, ";")(i), ":")(1)) / 100
            pesoMolecularPorGas = porcentaje * GetPropertieOfGasName(gasName)(0)
            presionReducidaPorGas = porcentaje * GetPropertieOfGasName(gasName)(1)
            temperaturaReducidaPorGas = porcentaje * GetPropertieOfGasName(gasName)(2)
            totalPesoMolecular += pesoMolecularPorGas
            totalPresionCriticaPorGas += presionReducidaPorGas
            totalTemperaturaCriticaPorGas += temperaturaReducidaPorGas
        Next
        Return New Double(2) {totalPesoMolecular, totalPresionCriticaPorGas, totalTemperaturaCriticaPorGas}
    End Function

    'Retorna la gravedad especifica de la Mezcla de gases, considerando que el peso molecular del aire es
    '28.97 [Kg/Kgmol]
    Public Function getSpecifcGravity() As Double
        Return GetPropertiesOfGasesMix()(0) / 28.97
    End Function

    'Definir una función que contenga todas las propiedades de los posibles gases
    Private Function GetPropertieOfGasName(ByVal gas As String) As Array
        'El orden y las unidades de estos arreglos son Peso Molecular [Kg/Kgmol], Presión Critica [Bar abs], Temperatura Crítica[K]
        Select Case gas
            Case "C1"
                Return New Double(2) {16.04, 46, 190.6}
            Case "C2"
                Return New Double(2) {30.07, 48.8, 305.4}
            Case "C3"
                Return New Double(2) {44.09, 42.5, 369.8}
                'el caso por defecto devuelve las propiedades del aire
            Case Else
                Return New Double(2) {28.97, 37.66, 132.55}
        End Select
    End Function



End Class
