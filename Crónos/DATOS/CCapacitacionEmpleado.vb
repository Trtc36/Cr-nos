Public Class CCapacitacionEmpleado
    Dim idEmpleado, idCapacitacion As Integer

    Public Property _idEmpleado
        Get
            Return idEmpleado
        End Get
        Set(ByVal value)
            idEmpleado = value
        End Set
    End Property

    Public Property _idCapacitacion
        Get
            Return idCapacitacion
        End Get
        Set(ByVal value)
            idCapacitacion = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idEmpleado As Integer, ByVal idCapacitacion As Integer)
        _idEmpleado = idEmpleado
        _idCapacitacion = idCapacitacion
    End Sub
End Class
