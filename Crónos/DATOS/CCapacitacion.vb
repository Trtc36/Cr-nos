Public Class CCapacitacion
    Dim idCapacitacion As Integer
    Dim codigo, nombre, tema As String
    Dim fecha As Date

    Public Property _idCapacitacion
        Get
            Return idCapacitacion
        End Get
        Set(ByVal value)
            idCapacitacion = value
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

    Public Property _nombre
        Get
            Return nombre
        End Get
        Set(ByVal value)
            nombre = value
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

    Public Property _tema
        Get
            Return tema
        End Get
        Set(ByVal value)
            tema = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idCapacitacion As Integer, ByVal codigo As String, ByVal nombre As String, ByVal fecha As Date, ByVal tema As String)
        _idCapacitacion = idCapacitacion
        _codigo = codigo
        _nombre = nombre
        _fecha = fecha
        _tema = tema
    End Sub
End Class
