Public Class Similitudes
    'Definicion de los parametros de entrada para hacer la simitud dadas
    'las condiciones de succión de la máquina
    'estas condiciones son: Presion de succión, Temp de succión, Z del gas en la succión
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


    'Este Diccionario daria un arreglo de arreglo de los puntos X y Y de la curva de diseño  
    'Para el compresor_1_jusepin los valores en X estan en [acfm] y las Y en [psi]
    'Existen diferentes posibilidades en las unidades de estos valores... tener en cuenta!!
    Public Function CurvaDisenoCompresorPresion() As Dictionary(Of String, Double(,))
        Dim puntosDisenoPresion As New Dictionary(Of String, Double(,))
        puntosDisenoPresion.Add("compresor_1_Jusepin", {{3992.6015, 4338.0788, 4734.9834, 5169.5161, 5665.0823, 6104.6823, 6455.4921, 6853.0325}, {499, 500, 499, 495.7179, 491.6505, 487.0334, 487.0334, 487.0334}})
        Return puntosDisenoPresion
    End Function

    'Este Diccionario daria un arreglo Y de la curva de del compresor especificado, transformado en Head[],
    'Este tipo de funciones haran similitudes de uno de los valores a la ves!, sea similitud para X o para Y
    'Para el compresor_1_jusepin los valores en X estan en [acfm] y las Y en Head[?]

    Public Function CurvaDisenoCompresorHead(maquina As String) As Dictionary(Of String, Double())
        'Calculo de las constantes necesarias
        'ojo pensar en hacer una ayuda donde se especifiquen las ecuaciones que se usaron para hacer estas similitudes¡¡
        Dim puntosDisenoHead As New Dictionary(Of String, Double())
        Dim Rdiseno, Runiv, PMdiseno, PMaire, specificGravityDiseno, coefPolitrodiseno, Zdiseno, T1diseno, P1diseno, ctte As Double
        PMdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_PMdiseno")                 '[Kg/Kmol]
        T1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_T1Diseno")                 '[K]
        P1diseno = DictionarieCompresores.Item(maquina).Item(maquina & "_P1Diseno")                 '[K]
        Zdiseno = DictionarieCompresores.Item(maquina).Item(maquina & "_ZDiseno")                   'Adimensional
        Runiv = 8314.3                                                                              '[J/Kg*K]
        PMaire = 28.97                                                                              '[Kg/Kmol]
        Rdiseno = Runiv / PMdiseno
        specificGravityDiseno = PMdiseno / PMaire
        coefPolitrodiseno = 1.3 - 0.31 * (specificGravityDiseno - 0.55)
        ctte = Zdiseno * Rdiseno * T1diseno * coefPolitrodiseno / (coefPolitrodiseno - 1)
        Dim longDatos As Integer = CurvaDisenoCompresorPresion(maquina).GetUpperBound(1)
        Dim newValuesHead(longDatos) As Double

        For i As Integer = 0 To longDatos
            newValuesHead(i) = ctte * ((CurvaDisenoCompresorPresion.Item(maquina)(1, i) / P1diseno) ^ ((coefPolitrodiseno - 1) / coefPolitrodiseno) - 1)
        Next
        'Esta linea agrega el diccionario con el nombre de la máquina y los valores del arreglo con la similitud para pasar
        'de Presión a Head
        puntosDisenoHead.Add(maquina, newValuesHead)
        Return puntosDisenoHead

    End Function

    'Declaración de las propiedades de diseno para una máquina especifica
    'Una idea para hacer algo más gral es poner todas las condiciones
    'de diseno para todos los compresores existentes en un diccionario,
    'asi esta clase podria tener un flag que haga referencia a cual máquina nos
    'estamos refiriendo y asi usa los valores propios para esa máquina.
    'otra alternativa es hacer llamadas a la base de datos, con el mismo argumento
    'que se le habia pasado, por el momento usare simple definicion de las propiedades como
    'variables
    Public Function DictionarieCompresores() As Dictionary(Of String, Dictionary(Of String, Double))
        Dim propiedades As New Dictionary(Of String, Double)
        Dim compresores As New Dictionary(Of String, Dictionary(Of String, Double))
        propiedades.Add("compresor_1_Jusepin_P1Diseno", 441)
        propiedades.Add("compresor_1_Jusepin_T1Diseno", 283.55)
        propiedades.Add("compresor_1_Jusepin_ZDiseno", 0.93)
        propiedades.Add("compresor_1_Jusepin_PMdiseno", 18.17)
        propiedades.Add("compresor_1_Jusepin_Kdiseno", 1.27606)
        propiedades.Add("compresor_1_Jusepin_RPMdiseno", 11000)
        compresores.Add("compresor_1_Jusepin", propiedades)
        'Aqui se está agregando otro compresor, seguir la convención, tipoDeMaquina_#_NombrePlanta
        propiedades.Add("compresor_2_Jusepin_P1Diseno", 500)
        propiedades.Add("compresor_2_Jusepin_T1Diseno", 290)
        propiedades.Add("compresor_2_Jusepin_ZDiseno", 0.9)
        propiedades.Add("compresor_2_Jusepin_PMdiseno", 20)
        propiedades.Add("compresor_2_Jusepin_Kdiseno", 1.29)
        propiedades.Add("compresor_2_Jusepin_RPMdiseno", 10000)
        compresores.Add("compresor_2_Jusepin", propiedades)
        Return compresores
    End Function
End Class
