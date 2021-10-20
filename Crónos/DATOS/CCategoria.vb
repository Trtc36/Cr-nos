Public Class CCategoria
    Dim idCategoria As Integer
    Dim codigo, categoria, descripcion As String

    Public Property _idCategoria
        Get
            Return idCategoria
        End Get
        Set(ByVal value)
            idCategoria = value
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

    Public Property _categoria
        Get
            Return categoria
        End Get
        Set(ByVal value)
            categoria = value
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

    Public Sub New(ByVal idCategoria As Integer, ByVal codigo As String, ByVal categoria As String, ByVal descripcion As String)
        _idCategoria = idCategoria
        _codigo = codigo
        _categoria = categoria
        _descripcion = descripcion
    End Sub
End Class
