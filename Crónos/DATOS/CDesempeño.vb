Public Class CDesempeño
    Dim idEvaluacion, idEmpleado, cMensual, pAlcance, eDirecta, eTotal As Integer
    Dim fecha As Date

    Public Property _idEvaluacion
        Get
            Return idEvaluacion
        End Get
        Set(ByVal value)
            idEvaluacion = value
        End Set
    End Property

    Public Property _idEmpleado
        Get
            Return idEmpleado
        End Get
        Set(ByVal value)
            idEmpleado = value
        End Set
    End Property

    Public Property _fecha
        Get
            Return fecha
        End Get
        Set(ByVal value)
            fecha = value
        End Set
    End Property

    Public Property _cMensual
        Get
            Return cMensual
        End Get
        Set(ByVal value)
            cMensual = value
        End Set
    End Property

    Public Property _pAlcance
        Get
            Return pAlcance
        End Get
        Set(ByVal value)
            pAlcance = value
        End Set
    End Property

    Public Property _eDirecta
        Get
            Return eDirecta
        End Get
        Set(ByVal value)
            eDirecta = value
        End Set
    End Property

    Public Property _eTotal
        Get
            Return eTotal
        End Get
        Set(ByVal value)
            eTotal = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idEvaluacion As Integer, ByVal idEmpleado As Integer, ByVal fecha As Date, ByVal cMensual As Integer, ByVal pAlcance As Integer, ByVal eDirecta As Integer, ByVal eTotal As Integer)
        _idEvaluacion = idEvaluacion
        _idEmpleado = idEmpleado
        _fecha = fecha
        _cMensual = cMensual
        _pAlcance = pAlcance
        _eDirecta = eDirecta
        _eTotal = eTotal
    End Sub
End Class
