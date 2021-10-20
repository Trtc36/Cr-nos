Public Class CMarca
    Dim idMarca As Integer
    Dim codigo, marca, descripcion As String

    Public Property _idMarca
        Get
            Return idMarca
        End Get
        Set(ByVal value)
            idMarca = value
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

    Public Property _marca
        Get
            Return marca
        End Get
        Set(ByVal value)
            marca = value
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

    Public Sub New()

    End Sub

    Public Sub New(ByVal idMarca As Integer, ByVal codigo As String, ByVal marca As String, ByVal descripcion As String)
        _idMarca = idMarca
        _codigo = codigo
        _marca = marca
        _descripcion = descripcion
    End Sub
End Class
