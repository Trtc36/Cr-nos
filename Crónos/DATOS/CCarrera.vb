Public Class CCarrera
    Dim idCarrera As Integer
    Dim codigo, carrera, nivel As String

    Public Property _idCarrera
        Get
            Return idCarrera
        End Get
        Set(ByVal value)
            idCarrera = value
        End Set
    End Property

    Public Property _codigo
        Get
            Return codigo
        End Get
        Set(ByVal value)
            codigo = value
        End Set
    End Property

    Public Property _carrera
        Get
            Return carrera
        End Get
        Set(ByVal value)
            carrera = value
        End Set
    End Property

    Public Property _nivel
        Get
            Return nivel
        End Get
        Set(ByVal value)
            nivel = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idCarrera As Integer, ByVal codigo As String, ByVal carrera As String, ByVal nivel As String)
        _idCarrera = idCarrera
        _codigo = codigo
        _carrera = carrera
        _nivel = nivel
    End Sub

End Class
