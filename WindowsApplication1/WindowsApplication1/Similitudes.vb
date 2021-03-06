﻿Imports WindowsApplication1.CurvasEquipos
Public Class Similitudes
    'Definicion de los parametros de entrada para hacer la simitud dadas
    'las condiciones de succión de la máquina estas condiciones son: 
    'Presion de succión, Temp de succión, Z del gas en la succión
    'PM del gas en la succión, Coef politropico "K" del gas en la succión, RPM actual de la máquina

    Private P1actual As Double
    Public Property FullP1actual() As Double
        Get
            Return P1actual
        End Get
        Set(ByVal value As Double)
            P1actual = value
        End Set
    End Property
    Private T1actual As Double
    Public Property FullT1actual() As Double
        Get
            Return T1actual
        End Get
        Set(ByVal value As Double)
            T1actual = value
        End Set
    End Property
    Private Zactual As Double
    Public Property FullZactual() As Double
        Get
            Return Zactual
        End Get
        Set(ByVal value As Double)
            Zactual = value
        End Set
    End Property
    Private PMactual As Double
    Public Property FullPMactual() As Double
        Get
            Return PMactual
        End Get
        Set(ByVal value As Double)
            PMactual = value
        End Set
    End Property
    Private Kactual As Double
    Public Property FullKactual() As Double
        Get
            Return Kactual
        End Get
        Set(ByVal value As Double)
            Kactual = value
        End Set
    End Property
    Private RPMactual As Double
    Public Property FullRPMactual() As Double
        Get
            Return RPMactual
        End Get
        Set(ByVal value As Double)
            RPMactual = value
        End Set
    End Property
    Private Maquina As String
    Public Property FullMaquina() As String
        Get
            Return Maquina
        End Get
        Set(ByVal value As String)
            Maquina = value
        End Set
    End Property

    'Aquí constructor de la clase, sin parámetros
    Public Sub New()
        Me.P1actual = P1actual
        Me.T1actual = T1actual
        Me.Zactual = Zactual
        Me.PMactual = PMactual
        Me.Kactual = Kactual
        Me.RPMactual = RPMactual
        Me.Maquina = Maquina
    End Sub
    'aquí el constructor para inicializar la clase con los parametros
    'definidos arriba
    Public Sub New(P1actual As Double, T1actual As Double, Zactual As Double, PMactual As Double, Kactual As Double, RPMactual As Double, Maquina As String)
        Me.P1actual = P1actual
        Me.T1actual = T1actual
        Me.Zactual = Zactual
        Me.PMactual = PMactual
        Me.Kactual = Kactual
        Me.RPMactual = RPMactual
        Me.Maquina = Maquina
    End Sub
    'Este Diccionario daria un arreglo Y de la curva de del compresor especificado, transformado en Presión[],
    '*******Esta función retorna la curva en Presión, a partir de la curva en head para el punto de diseño********
    Public Function CurvaCompresorPresionDiseno(maquina As String) As Dictionary(Of String, Double(,))
        'Calculo de las constantes necesarias
        'ojo pensar en hacer una ayuda donde se especifiquen las ecuaciones que se usaron para hacer estas similitudes¡¡
        Dim puntosDisenoPresion As New Dictionary(Of String, Double(,))
        Dim Rdiseno, Runiv, PMdiseno, PMaire, specificGravityDiseno, coefPolitrodiseno, Zdiseno, T1diseno, P1diseno, ctte, HeadValues As Double
        PMdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_PMdiseno")                 '[Kg/Kmol]
        T1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_T1diseno")                 '[K]
        P1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_P1diseno")                 '[K]
        Zdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_Zdiseno")                   'Adimensional
        Runiv = 8314.3                                                                              '[J/Kg*K]
        PMaire = 28.97                                                                              '[Kg/Kmol]
        Rdiseno = Runiv / PMdiseno
        specificGravityDiseno = PMdiseno / PMaire
        coefPolitrodiseno = 1.3 - 0.31 * (specificGravityDiseno - 0.55)
        ctte = Zdiseno * Rdiseno * T1diseno * coefPolitrodiseno / (coefPolitrodiseno - 1)
        Dim longDatos As Integer = CurvaDisenoCompresorPresion(maquina).GetUpperBound(1)
        Dim newValuesPresion(1, longDatos) As Double
        For i As Integer = 0 To longDatos
            newValuesPresion(0, i) = CurvaDisenoCompresorPresion(maquina)(0, i)
            HeadValues = CurvaDisenoCompresorPresion(maquina)(1, i)
            newValuesPresion(1, i) = Math.Round(P1diseno * ((HeadValues) / (ctte) + 1) ^ (coefPolitrodiseno / (coefPolitrodiseno - 1)), 2)
        Next
        'Esta linea agrega el diccionario con el nombre de la máquina y los valores del arreglo con la similitud para pasar
        'de Presión a Head
        puntosDisenoPresion.Add(maquina, newValuesPresion)
        Return puntosDisenoPresion
    End Function

    'Este Diccionario daria un arreglo Y de la curva de del compresor especificado, transformado en Head[],
    'Para el compresor_1_jusepin los valores en X estan en [acfm] y las Y en Head[?]
    '*******Esta función retorna la curva en head, a partir de la curva en presión********
    Public Function CurvaCompresorHeadDiseno(maquina As String) As Dictionary(Of String, Double())
        'Calculo de las constantes necesarias
        'ojo pensar en hacer una ayuda donde se especifiquen las ecuaciones que se usaron para hacer estas similitudes¡¡
        Dim puntosDisenoHead As New Dictionary(Of String, Double())
        Dim Rdiseno, Runiv, PMdiseno, PMaire, specificGravityDiseno, coefPolitrodiseno, Zdiseno, T1diseno, P1diseno, ctte As Double
        PMdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_PMdiseno")                 '[Kg/Kmol]
        T1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_T1diseno")                 '[K]
        P1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_P1diseno")                 '[K]
        Zdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_Zdiseno")                   'Adimensional
        Runiv = 8314.3                                                                              '[J/Kg*K]
        PMaire = 28.97                                                                              '[Kg/Kmol]
        Rdiseno = Runiv / PMdiseno
        specificGravityDiseno = PMdiseno / PMaire
        coefPolitrodiseno = 1.3 - 0.31 * (specificGravityDiseno - 0.55)
        ctte = Zdiseno * Rdiseno * T1diseno * coefPolitrodiseno / (coefPolitrodiseno - 1)
        Dim longDatos As Integer = CurvaDisenoCompresorPresion(maquina).GetUpperBound(1)
        Dim newValuesHead(longDatos) As Double
        For i As Integer = 0 To longDatos
            newValuesHead(i) = Math.Round(ctte * ((CurvaDisenoCompresorPresion.Item(maquina)(1, i) / P1diseno) ^ ((coefPolitrodiseno - 1) / coefPolitrodiseno) - 1), 1)
        Next
        'Esta linea agrega el diccionario con el nombre de la máquina y los valores del arreglo con la similitud para pasar
        'de Presión a Head
        puntosDisenoHead.Add(maquina, newValuesHead)
        Return puntosDisenoHead
    End Function

    'Similitud para cualquier cambio en las condiciones de operación, incluyendo la cromatográfia
    'los nuevos parametros, para hacer la similitud, se pasan como miembros que se inicializan en la clase!!
    '*******Esta función hace similitud del HeadDeDiseño a partir de las condiciones actuales*******
    Public Function CurvaCompresorHeadActual(maquina As String) As Dictionary(Of String, Double())
        'Calculo de las constantes necesarias
        'ojo pensar en hacer una ayuda donde se especifiquen las ecuaciones que se usaron para hacer estas similitudes¡¡
        Dim puntosActualHead As New Dictionary(Of String, Double())
        Dim Ractual, Runiv, PMactual, PMaire, specificGravityactual, coefPolitroactual, Zactual, T1actual, P1actual, ctte As Double
        PMactual = FullPMactual                 '[Kg/Kmol]
        T1actual = FullT1actual                 '[K]
        P1actual = FullP1actual                 '[psi]
        Zactual = FullZactual                   'Adimensional
        Runiv = 8314.3                                                                              '[J/Kg*K]
        PMaire = 28.97                                                                              '[Kg/Kmol]
        Ractual = Runiv / PMactual
        specificGravityactual = PMactual / PMaire
        coefPolitroactual = 1.3 - 0.31 * (specificGravityactual - 0.55)
        ctte = Zactual * Ractual * T1actual * coefPolitroactual / (coefPolitroactual - 1)
        Dim longDatos As Integer = CurvaDisenoCompresorPresion(maquina).GetUpperBound(1)
        Dim newValuesHead(longDatos) As Double
        For i As Integer = 0 To longDatos
            newValuesHead(i) = Math.Round(P1actual * (CurvaDisenoCompresorRPM(maquina).Item(maquina)(1, i) / ctte + 1), 1)
        Next
        'Esta linea agrega el diccionario con el nombre de la máquina y los valores del arreglo con la similitud para pasar
        'de Presión a Head
        puntosActualHead.Add(maquina, newValuesHead)
        Return puntosActualHead
    End Function
    'Similitud para la curva Head de diseño cuando se cambian las rpm, esto retorna un arreglo de dos dimensiones el subindice 1 da la transformación en Head
    'Ojo aquí los calculos son cumbersome porque las similitudes con RPM se hacen sobre la curva en unidades de head, no se pueden hacer directo en unidades de presión
    Public Function CurvaDisenoCompresorRPM(maquina As String) As Dictionary(Of String, Double(,))
        Dim puntosDisenoHeadRPM As New Dictionary(Of String, Double(,))
        Dim Rdiseno, Runiv, PMdiseno, PMaire, specificGravityDiseno, coefPolitrodiseno, Zdiseno, T1diseno, P1diseno, ctte As Double
        PMdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_PMdiseno")                 '[Kg/Kmol]
        T1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_T1diseno")                 '[K]
        P1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_P1diseno")                 '[K]
        Zdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_Zdiseno")                   'Adimensional
        Runiv = 8314.3                                                                              '[J/Kg*K]
        PMaire = 28.97                                                                              '[Kg/Kmol]
        Rdiseno = Runiv / PMdiseno
        specificGravityDiseno = PMdiseno / PMaire
        coefPolitrodiseno = 1.3 - 0.31 * (specificGravityDiseno - 0.55)
        ctte = Zdiseno * Rdiseno * T1diseno * coefPolitrodiseno / (coefPolitrodiseno - 1)
        Dim longDatos As Integer = CurvaDisenoCompresorPresion.Item(maquina).GetUpperBound(1)
        Dim newValuesHeadRPM(2, longDatos) As Double
        Dim RPMDiseno As Integer = DictionarieCompresores.Item(maquina).Item(maquina & "_RPMdiseno")
        For i As Integer = 0 To longDatos
            newValuesHeadRPM(0, i) = Math.Round(CurvaDisenoCompresorPresion.Item(maquina)(0, i) * FullRPMactual / RPMDiseno, 1)
            newValuesHeadRPM(1, i) = Math.Round(CurvaCompresorHeadDiseno(maquina).Item(maquina)(i) * (FullRPMactual / RPMDiseno) ^ 2, 1) 'Esta linea retorna la similitud hecha en unidades de Head
            newValuesHeadRPM(2, i) = Math.Round(P1diseno * (newValuesHeadRPM(1, i) / (ctte) + 1) ^ (coefPolitrodiseno / (coefPolitrodiseno - 1)), 1) 'Esta linea retorna la similitud hecha en unidades de presión
        Next
        'Agrega el valor dal diccionario
        puntosDisenoHeadRPM.Add(maquina, newValuesHeadRPM)
        'Retorna un arreglo que se llama como diccionario, con el nombre de la máquina
        Return puntosDisenoHeadRPM
    End Function
    'Similitud para la presion con el cambio del cualquier propiedad en la succión, sea el gas o la TEMP SUCCIÓN, O en las rpm de operación
    Public Function CurvaCompresorPresionActual(maquina As String) As Dictionary(Of String, Double(,))
        Dim puntosDisenoPresionActual As New Dictionary(Of String, Double(,))
        Dim Runiv, PMaire, PMdiseno, T1diseno, P1diseno, Zdiseno, Rdiseno, Ractual, PMactual, specificGravityactual, specificGravitydiseno, coefPolitroactual, coefPolitrodiseno, Zactual, T1actual, P1actual, ctteActual As Double
        PMactual = FullPMactual                                                                     '[Kg/Kmol]
        T1actual = FullT1actual                                                                     '[K]
        P1actual = FullP1actual                                                                     '[psi]
        Zactual = FullZactual                                                                       'Adimensional
        PMdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_PMdiseno")                 '[Kg/Kmol]
        T1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_T1diseno")                 '[K]
        P1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_P1diseno")                 '[K]
        Zdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_Zdiseno")                   'Adimensional
        Runiv = 8314.3                                                                              '[J/Kg*K]
        PMaire = 28.97                                                                              '[Kg/Kmol]
        Ractual = Runiv / PMactual
        Rdiseno = Runiv / PMdiseno
        specificGravityactual = PMactual / PMaire
        specificGravitydiseno = PMdiseno / PMaire
        coefPolitroactual = 1.3 - 0.31 * (specificGravityactual - 0.55)
        coefPolitrodiseno = 1.3 - 0.31 * (specificGravitydiseno - 0.55)
        ctteActual = Zactual * Ractual * T1actual * coefPolitroactual / (coefPolitroactual - 1)  'esta constante es la del exponente en el cálculo del compresor
        Dim coef1 As Double = (coefPolitroactual - 1) / (coefPolitroactual)
        Dim coef2 As Double = coefPolitrodiseno / (coefPolitrodiseno - 1)
        Dim longDatos As Integer = CurvaDisenoCompresorPresion(maquina).GetUpperBound(1)
        Dim newValuesHead(1, longDatos) As Double 'Declaras la matriz que contendrá los valores nuevos hechos en la similitud
        Dim P2RPM As Double ' esta es la presión en la descarga cuando se hace similitud con rpm solamente
        For i As Integer = 0 To longDatos
            'Aquí se toma la curva de presión ya transformada para la nueva rpm de funcionamiento
            P2RPM = CurvaDisenoCompresorRPM(maquina).Item(maquina)(2, i)
            'Similitud para los valores de caudal
            newValuesHead(0, i) = Math.Round(CurvaDisenoCompresorRPM(maquina).Item(maquina)(0, i) * T1actual / T1diseno * P1diseno / P1actual * Zactual / Zdiseno * PMdiseno / PMactual, 3)
            'similitud para los valores de presión hechos con la similitud
            newValuesHead(1, i) = Math.Round(P1actual * (T1diseno / T1actual * Zdiseno / Zactual * PMactual / PMdiseno * coef2 * coef1 * ((P2RPM / P1diseno) ^ (coef1) - 1) + 1) ^ (coefPolitroactual / (coefPolitroactual - 1)), 1)
        Next
        'Esta linea agrega el diccionario con el nombre de la máquina y los valores del arreglo con la similitud para pasar
        'de Presión a Head
        puntosDisenoPresionActual.Add(maquina, newValuesHead)
        Return puntosDisenoPresionActual
    End Function
    '------------------------------------------------------------------------------------------------------
    '------------------------------Similitud de Bombas Centrífugas ----------------------------------------
    '------------------------------------------------------------------------------------------------------
    'Función para hacer similitud con el numero de etapas instaladas...,sabiendo que el máx num de étapas es 28 y que una de las bombas funciona actualmente
    'con 11 etapas... Ojo aquí la clase para traer todas las curvas de los equipos está inicializada y creada
    Public Function CurvaBombaEtapas(maquina As String, numeroDeEtapas As Integer, rpm As Integer) As Dictionary(Of String, Double(,))
        Dim curvaActual As New Dictionary(Of String, Double(,))
        Dim Bomba As New CurvasEquipos
        Dim LongDatos As Integer = Bomba.CurvaDisenoEquipo.Item(maquina).GetUpperBound(1)
        Dim newValuesHead(1, LongDatos) As Double 'Declaras la matriz
        For i As Integer = 0 To LongDatos
            newValuesHead(0, i) = Math.Round(Bomba.CurvaDisenoEquipo.Item(maquina)(0, i) * rpm / 3580, 2)
            newValuesHead(1, i) = Math.Round((Bomba.CurvaDisenoEquipo.Item(maquina)(1, i) * numeroDeEtapas / 28) * (rpm / 3580) ^ 2, 2)
        Next
        curvaActual.Add(maquina, newValuesHead)
        Return curvaActual
    End Function
    'Declaración de las propiedades de diseno para una máquina especifica
    'Una idea para hacer algo más gral es poner todas las condiciones
    'de diseno para todos los compresores existentes en un diccionario,
    'asi esta clase podria tener un flag que haga referencia a cual máquina nos
    'estamos refiriendo y asi usa los valores propios para esa máquina.
    'otra alternativa es hacer llamadas a la base de datos, con el mismo argumento
    'que se le habia pasado, por el momento usare simple definicion de las propiedades como
    'variables
    Public Shared Function DictionarieCompresores() As Dictionary(Of String, Dictionary(Of String, Double))
        Dim propiedades As New Dictionary(Of String, Double)
        Dim compresores As New Dictionary(Of String, Dictionary(Of String, Double))
        'Valores de diseño para turbo expansor
        propiedades.Add("Turbo_Expansor_P1diseno", 441)
        propiedades.Add("Turbo_Expansor_T1diseno", 283.71)
        propiedades.Add("Turbo_Expansor_Zdiseno", 0.93)
        propiedades.Add("Turbo_Expansor_PMdiseno", 18.17)
        propiedades.Add("Turbo_Expansor_Kdiseno", 1.27606)
        propiedades.Add("Turbo_Expansor_RPMdiseno", 13400)
        compresores.Add("Turbo_Expansor", propiedades)
        'Valores de diseño para los compresores centrífugos
        propiedades.Add("Compresor_1_TrenB_P1diseno", 441)
        propiedades.Add("Compresor_1_TrenB_T1diseno", 283.55)
        propiedades.Add("Compresor_1_TrenB_Zdiseno", 0.93)
        propiedades.Add("Compresor_1_TrenB_PMdiseno", 18.17)
        propiedades.Add("Compresor_1_TrenB_Kdiseno", 1.27606)
        propiedades.Add("Compresor_1_TrenB_RPMdiseno", 11000)
        compresores.Add("Compresor_1_TrenB", propiedades)
        'Aqui se está agregando otro compresor, seguir la convención, tipoDeMaquina_#_NombrePlanta
        propiedades.Add("Compresor_2_TrenB_P1diseno", 441)
        propiedades.Add("Compresor_2_TrenB_T1diseno", 283.55)
        propiedades.Add("Compresor_2_TrenB_Zdiseno", 0.93)
        propiedades.Add("Compresor_2_TrenB_PMdiseno", 18.17)
        propiedades.Add("Compresor_2_TrenB_Kdiseno", 1.27606)
        propiedades.Add("Compresor_2_TrenB_RPMdiseno", 11000)
        compresores.Add("Compresor_2_TrenB", propiedades)
        'Aqui las propiedades de los compresores reciprocantes de Jusepin
        propiedades.Add("compresor_Jusepin_1_Stroke", 7)
        propiedades.Add("compresor_Jusepin_1_Diametro", 12)
        propiedades.Add("compresor_Jusepin_1_DiametroBiela", 2)
        propiedades.Add("compresor_Jusepin_1_Area", 113.1)
        propiedades.Add("compresor_Jusepin_1_RPM", 750)
        compresores.Add("compresor_Jusepin_1", propiedades)
        propiedades.Add("compresor_Jusepin_2_Stroke", 7)
        propiedades.Add("compresor_Jusepin_2_Diametro", 7)
        propiedades.Add("compresor_Jusepin_2_DiametroBiela", 2)
        propiedades.Add("compresor_Jusepin_2_Area", 38.48)
        propiedades.Add("compresor_Jusepin_2_RPM", 750)
        compresores.Add("compresor_Jusepin_2", propiedades)
        'Aqui las propiedades de los compresores reciprocantes de Santa Barbara
        propiedades.Add("compresor_SB_1_Stroke", 5)
        propiedades.Add("compresor_SB_1_Diametro", 18.2)
        propiedades.Add("compresor_SB_1_DiametroBiela", 0)
        propiedades.Add("compresor_SB_1_Area", 268.8)
        propiedades.Add("compresor_SB_1_RPM", 590)
        compresores.Add("compresor_SB_1", propiedades)
        propiedades.Add("compresor_SB_2_Stroke", 5)
        propiedades.Add("compresor_SB_2_Diametro", 10)
        propiedades.Add("compresor_SB_2_DiametroBiela", 0)
        propiedades.Add("compresor_SB_2_Area", 86.6)
        propiedades.Add("compresor_SB_2_RPM", 590)
        compresores.Add("compresor_SB_2", propiedades)
        Return compresores
    End Function

    'Este Diccionario daria un arreglo de arreglo de los puntos X y Y de la curva de diseño  
    'Para el compresor_1_jusepin los valores en X estan en [acfm] y las Y en [psi]
    'Existen diferentes posibilidades en las unidades de estos valores... tener en cuenta!!
    Public Function CurvaDisenoCompresorPresion() As Dictionary(Of String, Double(,))
        'Pendiente de las unidades que se usan para representar estas curvas, en estos casos
        Dim puntosDisenoPresion As New Dictionary(Of String, Double(,))
        'Unidades para los compresores centrífugos, el caudal en ACFM y presión [psia]
        puntosDisenoPresion.Add("Compresor_1_TrenB", {{3992.6, 4338.1, 4735.0, 5169.5, 5665.1, 6104.7}, {499, 500, 499, 495.7, 491.7, 487.0}})
        puntosDisenoPresion.Add("Compresor_2_TrenB", {{3992.6, 4338.1, 4735.0, 5169.5, 5665.1, 6104.7}, {499, 500, 499, 495.7, 491.7, 487.0}})
        'Unidades de la curva del turboExpansor, el caudal en ACFM y el head está en [m]
        'puntosDisenoPresion.Add("Turbo_Expansor", {{5000, 5500, 6000, 6500, 7000, 7500, 8000, 8400}, {2420.45, 2429.95, 2372.99, 2313.67, 2195.02, 2019.42, 1841.44, 1661.1}})
        'Unidades de la curva del turboExpansor, el cuadal en ACFM y la presion en [psia]
        'usaremos esta por conveniencia, asi es 
        puntosDisenoPresion.Add("Turbo_Expansor", {{5000, 5500, 6000, 6500, 7000, 7500, 8000, 8400}, {449.91, 449.95, 449.74, 449.52, 449.08, 448.43, 447.77, 447.1}})
        Return puntosDisenoPresion

    End Function

End Class
