Public Class CurvasEquipos
    Public Function CurvaDisenoEquipo() As Dictionary(Of String, Double(,))
        'Pendiente de las unidades que se usan para representar estas curvas, en estos casos
        Dim puntosDisenoEquipo As New Dictionary(Of String, Double(,))
        'Esta curva es para la bomba 0690 
        'La curva de esta bomba es para 
        'una bomba: -0.6709x^2+9.9651x+1629.6
        'dos bombas en paralelo : -0.1677x^2+4.9826x+1629.6
        'tres bombas en paralelo: -0.0745x^2+3.3217x+1629.6
        'Estas curvas son multiplicadas por 1000^2 en el término a, por 1000 en el término b, para que sean utiles en el hardyCross
        puntosDisenoEquipo.Add("compresor_1_Jusepin", {{3992.6015, 4338.0788, 4734.9834, 5169.5161, 5665.0823, 6104.6823}, {499, 500, 499, 495.7179, 491.6505, 487.0334}})
        'Esta primera curva es la curva de la bomba 0690, que esta en la parte superior, las unidades estan en GPM y Pies para la altura equivalente
        puntosDisenoEquipo.Add("Bomba_1_Jusepin", {{24.727, 60, 118.97, 166.07, 213.21, 260.33, 331.07, 390.17, 449.48, 496.97, 544.49, 592.07, 639.68, 699.22, 746.88}, {5484, 5452.6, 5390.6, 5358.6, 5297.2, 5250.5, 5128.8, 4919.2, 4547.3, 4220.2, 3863.7, 3462.9, 3047.3, 2498.3, 2038.5}})
        'Esta curva es para la bomba 1480 
        'La curva de esta bomba es para 
        'una bomba: -0.266x^2+3.7061x+1160.9
        'dos bombas en paralelo : -0.0665x^2+1.853x+1160.9
        'tres bombas en paralelo: -0.0296x^2+1.2354x+1160.9
        'Estas curvas son multiplicadas por 1000^2 en el término a, por 1000 en el término b, para que sean utiles en el hardyCross
        'Ojo esta curva ya esta en L/s y m
        puntosDisenoEquipo.Add("Bomba_2_Jusepin", {{0.344036079, 3.691326501, 7.265305602, 12.31470113, 15.60567742, 18.84033327, 22.01910399, 25.36824295, 28.7747181, 32.06857129, 36.15819127, 40.02194905, 42.63533243, 45.19342373, 47.18387538}, {1179.510377, 1173.535321, 1169.813043, 1159.751625, 1149.348222, 1134.516471, 1110.839058, 1084.986105, 1052.5182, 1011.193629, 952.3542446, 882.4274554, 838.7618074, 779.6245723, 724.7943137}})
        'Aqui defino las curvas del npsh de las bombas
        'NPSHrequerido de la bomba 1480, el primer arreglo son GPM el segundo son Feet, pendiente luego para hacer conversion!
        puntosDisenoEquipo.Add("Bomba_1480_NPSHReq", {{0, 100, 200, 240, 280, 320, 360, 400, 420, 460, 480, 500}, {12, 12, 12, 12, 13, 14, 16, 18, 20, 26, 30, 36}})
        Return puntosDisenoEquipo
    End Function
End Class
