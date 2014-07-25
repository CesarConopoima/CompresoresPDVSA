Public Class CurvasEquipos
    Public Function CurvaDisenoEquipo() As Dictionary(Of String, Double(,))
        'Pendiente de las unidades que se usan para representar estas curvas, en estos casos
        Dim puntosDisenoEquipo As New Dictionary(Of String, Double(,))
        puntosDisenoEquipo.Add("compresor_1_Jusepin", {{3992.6015, 4338.0788, 4734.9834, 5169.5161, 5665.0823, 6104.6823}, {499, 500, 499, 495.7179, 491.6505, 487.0334}})
        puntosDisenoEquipo.Add("Bomba_1_Jusepin", {{24.727, 60, 118.97, 166.07, 213.21, 260.33, 331.07, 390.17, 449.48, 496.97, 544.49, 592.07, 639.68, 699.22, 746.88}, {5484, 5452.6, 5390.6, 5358.6, 5297.2, 5250.5, 5128.8, 4919.2, 4547.3, 4220.2, 3863.7, 3462.9, 3047.3, 2498.3, 2038.5}})
        puntosDisenoEquipo.Add("Bomba_2_Jusepin", {{24.727, 60, 118.97, 166.07, 213.21, 260.33, 331.07, 390.17, 449.48, 496.97, 544.49, 592.07, 639.68, 699.22, 746.88}, {5484, 5452.6, 5390.6, 5358.6, 5297.2, 5250.5, 5128.8, 4919.2, 4547.3, 4220.2, 3863.7, 3462.9, 3047.3, 2498.3, 2038.5}})
        Return puntosDisenoEquipo
    End Function
End Class
