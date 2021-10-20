Public Class CReconocimiento
    Dim idPremio, idEmpleado, gratificacion As Integer
    Dim reconocimiento, descripcion, motivo As String
    Dim fecha As Date

    Public Property _idPremio
        Get
            Return idPremio
        End Get
        Set(ByVal value)
            idPremio = value
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

    Public Property _reconocimiento
        Get
            Return reconocimiento
        End Get
        Set(ByVal value)
            reconocimiento = value
        End Set
    End Property

    Public Property _descripcion
        Get
            Return descripcion
        End Get
        Set(ByVal value)
            descripcion = value
        End Set
    End Property

    Public Property _motivo
        Get
            Return motivo
        End Get
        Set(ByVal value)
            motivo = value
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

    Public Property _gratificacion
        Get
            Return gratificacion
        End Get
        Set(ByVal value)
            gratificacion = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idPremio As Integer, ByVal idEmpleado As Integer, ByVal reconocimiento As String, ByVal descripcion As String, ByVal motivo As String, ByVal fecha As Date, ByVal gratificacion As Integer)
        _idPremio = idPremio
        _idEmpleado = idEmpleado
        _reconocimiento = reconocimiento
        _descripcion = descripcion
        _motivo = motivo
        _fecha = fecha
        _gratificacion = gratificacion
    End Sub
End Class
