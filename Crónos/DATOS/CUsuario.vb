Public Class CUsuario
    Dim idUsuario, estatus, idEmpleado, idPermiso As Integer
    Dim codigo, usuario, password As String

    Public Property _idUsuario
        Get
            Return idUsuario
        End Get
        Set(ByVal value)
            idUsuario = value
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

    Public Property _usuario
        Get
            Return usuario
        End Get
        Set(ByVal value)
            usuario = value
        End Set
    End Property

    Public Property _password
        Get
            Return password
        End Get
        Set(ByVal value)
            password = value
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

    Public Property _idPermiso
        Get
            Return idPermiso
        End Get
        Set(ByVal value)
            idPermiso = value
        End Set
    End Property

    Public Property _estatus
        Get
            Return estatus
        End Get
        Set(value)
            estatus = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idUsuario As Integer, ByVal codigo As String, ByVal usuario As String, ByVal password As String, ByVal idEmpleado As Integer, ByVal idPermiso As Integer, ByVal estatus As Integer)
        _idUsuario = idUsuario
        _codigo = codigo
        _usuario = usuario
        _password = password
        _idEmpleado = idEmpleado
        _idPermiso = idPermiso
        _estatus = estatus
    End Sub
End Class
