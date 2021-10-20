Public Class CProveedor
    Dim idProveedor As Integer
    Dim codigo, tProveedor, personalidad, rSocial, nombre, paterno, materno, RFC, tVialidad, nVialidad, colonia, ciudad, estado, cp, telefono, mail As String

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

    Public Property _tProveedor
        Get
            Return tProveedor
        End Get
        Set(ByVal value)
            tProveedor = value
        End Set
    End Property

    Public Property _personalidad
        Get
            Return personalidad
        End Get
        Set(ByVal value)
            personalidad = value
        End Set
    End Property

    Public Property _rSocial
        Get
            Return rSocial
        End Get
        Set(ByVal value)
            rSocial = value
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

    Public Property _RFC
        Get
            Return RFC
        End Get
        Set(ByVal value)
            RFC = value
        End Set
    End Property

    Public Property _tVialidad
        Get
            Return tVialidad
        End Get
        Set(ByVal value)
            tVialidad = value
        End Set
    End Property

    Public Property _nVialidad
        Get
            Return nVialidad
        End Get
        Set(ByVal value)
            nVialidad = value
        End Set
    End Property

    Public Property _colonia
        Get
            Return colonia
        End Get
        Set(ByVal value)
            colonia = value
        End Set
    End Property

    Public Property _ciudad
        Get
            Return ciudad
        End Get
        Set(ByVal value)
            ciudad = value
        End Set
    End Property

    Public Property _estado
        Get
            Return estado
        End Get
        Set(ByVal value)
            estado = value
        End Set
    End Property

    Public Property _cp
        Get
            Return cp
        End Get
        Set(ByVal value)
            cp = value
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

    Public Sub New(ByVal idProveedor As Integer, ByVal codigo As String, ByVal tProveedor As String, ByVal personalidad As String, ByVal rSocial As String, ByVal nombre As String, ByVal paterno As String, ByVal materno As String, ByVal RFC As String, ByVal tVialidad As String, ByVal nVialidad As String, ByVal colonia As String, ByVal ciudad As String, ByVal estado As String, ByVal cp As String, ByVal telefono As String, ByVal mail As String)
        _idProveedor = idProveedor
        _codigo = codigo
        _tProveedor = tProveedor
        _personalidad = personalidad
        _rSocial = rSocial
        _nombre = nombre
        _paterno = paterno
        _materno = materno
        _RFC = RFC
        _tVialidad = tVialidad
        _nVialidad = nVialidad
        _colonia = colonia
        _ciudad = ciudad
        _estado = estado
        _cp = cp
        _telefono = telefono
        _mail = mail
    End Sub
End Class
