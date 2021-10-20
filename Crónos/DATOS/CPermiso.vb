Public Class CPermiso
    Dim idPermiso As Integer
    Dim codigo, tPermiso, alcance As String

    Public Property _idPermiso
        Get
            Return idPermiso
        End Get
        Set(ByVal value)
            idPermiso = value
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

    Public Property _tPermiso
        Get
            Return tPermiso
        End Get
        Set(ByVal value)
            tPermiso = value
        End Set
    End Property

    Public Property _alcance
        Get
            Return alcance
        End Get
        Set(ByVal value)
            alcance = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idPermiso As Integer, ByVal codigo As String, ByVal tPermiso As String, ByVal alcance As String)
        _idPermiso = idPermiso
        _codigo = codigo
        _tPermiso = tPermiso
        _alcance = alcance
    End Sub
End Class
