﻿Public Class CalculosCompresores
    'Unidades para que esto solo deben ser consistentes, la relación de compresión elimina la unidades de la presión
    Public Function TempDescarga(kGas As Double, PresionDescarga As Double, PresionSuccion As Double, TempSuccion As Double, ns As Double) As Double
        Return TempSuccion * (1 + (((PresionDescarga / PresionSuccion) ^ ((kGas - 1) / kGas) - 1) / ns))
    End Function
    'Unidades en m^3/hr, Presion en pascales y Temp en Kelvin, unidades SI Rgas=286.99689 [J/Kg*K]
    Public Function FlujoMasico(Qactual As Double, PresionSuccion As Double, Z1actual As Double, RGas As Double, TempSuccion As Double) As Double
        Return Qactual * PresionSuccion / (Z1actual * TempSuccion * RGas)
    End Function
    'Las unidades Geometricas estan en [in], y la unidades que retorna la función son m^3/h
    Public Function FlujoVolumetrico_SimpleEfecto(Diametro As Double, Stroke As Double, RPM As Double) As Double
        Dim Area As Double = 3.14159 * Diametro ^ 2 / 4
        Return (60 * (2.54 / 100) ^ 3) * Area * Stroke * RPM
    End Function
    'Las unidades Geometricas estan en [in], y la unidades que retorna la función son m^3/h
    Public Function FlujoVolumetrico_DoubleEfecto(DiametroCilindro As Double, DiametroBiela As Double, Stroke As Double, RPM As Double) As Double
        Dim Areacilindro = 3.14159 * DiametroCilindro ^ 2 / 4
        Dim Areabiela = 3.14159 * DiametroBiela ^ 2 / 4
        Return (60 * (2.54 / 100) ^ 3) * (2 * Areacilindro - Areabiela) * Stroke * RPM
    End Function

End Class
