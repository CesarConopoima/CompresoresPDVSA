Public Class CalculoCondensado
    'Ojo pendiente cuando se inicialice la clase, de llevar el valor de la humedad absoluta 
    'A su forma adimensional, normalmente el de la carta psicrométrica que incluimos en el código
    'esta en gr/Kg aire
    'es decir dividir entre mil del valor 
    Private HumedadAbsoluta As Double
    Public Property FullHumedadAbsoluta() As Double
        Get
            Return HumedadAbsoluta
        End Get
        Set(ByVal value As Double)
            HumedadAbsoluta = value
        End Set
    End Property
    'Ojo inicializar este miembro en [Pa] para ser consistentes con los calculos posteriores
    Private PresionActual As Double
    Public Property FullPresionActual() As Double
        Get
            Return PresionActual
        End Get
        Set(ByVal value As Double)
            PresionActual = value
        End Set
    End Property
    'Ojo inicializar este miembro en [Kelvin] para ser consistentes con los calculos posteriores
    Private TemperaturaActual As Double
    Public Property FullTemperaturaActual() As Double
        Get
            Return TemperaturaActual
        End Get
        Set(ByVal value As Double)
            TemperaturaActual = value
        End Set
    End Property
    'Miembro de la clase para la cantidad de aire que entra en el sistema en [Kg/s]
    Private FlujoMasicoAire As Double
    Public Property FullFlujoMasicoAire() As Double
        Get
            Return FlujoMasicoAire
        End Get
        Set(ByVal value As Double)
            FlujoMasicoAire = value
        End Set
    End Property

    'Constructor con argumento
    Sub New(HumedadAbsoluta As Double, PresionActual As Double, TemperaturaActual As Double, FlujoMasicoAire As Double)
        Me.FlujoMasicoAire = FlujoMasicoAire
        Me.HumedadAbsoluta = HumedadAbsoluta
        Me.PresionActual = PresionActual
        Me.TemperaturaActual = TemperaturaActual
    End Sub
    'Función para evaluación de presión de saturación Antoin, ojo la temperatura
    'debe venir en Kelvin, el resultado sale en [Pa]
    'Temperatura en [K]
    Private Function PsatAntoin() As Double
        Dim Pcritica As Double = 22392825 '[Pa] Presión critica del agua
        Dim ctte As Double = 6.53247 - 3985.439 / (FullTemperaturaActual - 38.9974)
        Return Pcritica * Math.Exp(ctte)
    End Function
    'Cálculo de la presión de vapor, en función de las unidades de presión con que se inicialice la clase 
    'Para ser consistentes forzadamente en [Pa]
    Private Function PresionVapor() As Double
        Return FullHumedadAbsoluta * FullPresionActual / (0.621294 + FullHumedadAbsoluta)
    End Function
    'Calculo de la cantidad de vapor de agua que entra en el sistema [Kg/s]
    Private Function FlujoMasicoVapor() As Double
        Return FullFlujoMasicoAire * FullHumedadAbsoluta
    End Function
    'Función que retorna la cantidad de agua condensada, darle un rango que permita darle un error al calculo para prevenir
    'A los operadores de los condensados
    'Considerare tres posibles escenarios:
    '1) Donde se está cerca del condensado (13700[Pa]==2Psi) por debajo de la presión de saturación)
    '2) Donde se esta en el condensado 
    '3) Donde no se esta condensando
    'Las unidades de esto es tasa de agua condensada por segundo [Kg/s].... quizas sea más conveniente sacar en gr/min or gr/hora

    Public Function LiquidoCondensado() As Double
        If (PresionVapor() - 13700) > PsatAntoin() Then
            Return 1
        ElseIf PresionVapor() >= PsatAntoin() Then
            Return FlujoMasicoVapor() - 0.621294 * PsatAntoin() * FullFlujoMasicoAire / (FullPresionActual - PsatAntoin())
        Else
            Return 0
        End If
    End Function


End Class

