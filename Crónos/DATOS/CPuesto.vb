Public Class CPuesto
    Dim idPuesto As Integer
    Dim codigo, puesto, descripcion, responsabilidades, obligaciones As String
    Dim sAutorizado As Double

    Public Property _idPuesto
        Get
            Return idPuesto
        End Get
        Set(ByVal value)
            idPuesto = value
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

    Public Property _puesto
        Get
            Return puesto
        End Get
        Set(ByVal value)
            puesto = value
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

    Public Property _responsabilidades
        Get
            Return responsabilidades
        End Get
        Set(ByVal value)
            responsabilidades = value
        End Set
    End Property

    Public Property _obligaciones
        Get
            Return obligaciones
        End Get
        Set(ByVal value)
            obligaciones = value
        End Set
    End Property

    Public Property _sAutorizado
        Get
            Return sAutorizado
        End Get
        Set(ByVal value)
            sAutorizado = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idPuesto As Integer, ByVal codigo As String, ByVal puesto As String, ByVal descripcion As String, ByVal responsabilidades As String, ByVal obligaciones As String, ByVal sAutorizado As Double)
        _idPuesto = idPuesto
        _codigo = codigo
        _puesto = puesto
        _descripcion = descripcion
        _responsabilidades = responsabilidades
        _obligaciones = obligaciones
        _sAutorizado = sAutorizado
    End Sub
End Class
