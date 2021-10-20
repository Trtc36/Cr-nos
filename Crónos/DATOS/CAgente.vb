Public Class CAgente
    Dim idAgente, idProveedor As Integer
    Dim codigo, nombre, paterno, materno, telefono, mail As String

    Public Property _idAgente
        Get
            Return idAgente
        End Get
        Set(ByVal value)
            idAgente = value
        End Set
    End Property

    Public Property _idProveedor
        Get
            Return idProveedor
        End Get
        Set(ByVal value)
            idProveedor = value
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

    Public Property _paterno
        Get
            Return paterno
        End Get
        Set(ByVal value)
            paterno = value
        End Set
    End Property

    Public Property _materno
        Get
            Return materno
        End Get
        Set(ByVal value)
            materno = value
        End Set
    End Property

    Public Property _telefono
        Get
            Return telefono
        End Get
        Set(ByVal value)
            telefono = value
        End Set
    End Property

    Public Property _mail
        Get
            Return mail
        End Get
        Set(ByVal value)
            mail = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idAgente As Integer, ByVal codigo As String, ByVal nombre As String, ByVal paterno As String, ByVal materno As String, ByVal telefono As String, ByVal mail As String, ByVal idProveedor As Integer)
        _idAgente = idAgente
        _codigo = codigo
        _nombre = nombre
        _paterno = paterno
        _materno = materno
        _telefono = telefono
        _mail = mail
        _idProveedor = idProveedor
    End Sub
End Class
