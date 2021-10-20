Public Class CModelo
    Dim idModelo, idMarca As Integer
    Dim codigo, modelo, descripcion As String

    Public Property _idModelo
        Get
            Return idModelo
        End Get
        Set(ByVal value)
            idModelo = value
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

    Public Property _modelo
        Get
            Return modelo
        End Get
        Set(ByVal value)
            modelo = value
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

    Public Property _idMarca
        Get
            Return idMarca
        End Get
        Set(ByVal value)
            idMarca = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idModelo As Integer, ByVal codigo As String, ByVal modelo As String, ByVal descripcion As String, ByVal idMarca As Integer)
        _idModelo = idModelo
        _codigo = codigo
        _modelo = modelo
        _descripcion = descripcion
        _idMarca = idMarca
    End Sub
End Class
