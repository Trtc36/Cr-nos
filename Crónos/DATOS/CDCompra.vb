Public Class CDCompra
    Dim folio As String
    Dim idDCompra, idProducto, cantidad As Integer
    Dim pCompra As Double

    Public Property _idDCompra
        Get
            Return idDCompra
        End Get
        Set(ByVal value)
            idDCompra = value
        End Set
    End Property
    Public Property _folio
        Get
            Return folio
        End Get
        Set(ByVal value)
            folio = value
        End Set
    End Property

    Public Property _idProducto
        Get
            Return idProducto
        End Get
        Set(ByVal value)
            idProducto = value
        End Set
    End Property

    Public Property _cantidad
        Get
            Return cantidad
        End Get
        Set(ByVal value)
            cantidad = value
        End Set
    End Property

    Public Property _pCompra
        Get
            Return pCompra
        End Get
        Set(ByVal value)
            pCompra = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idDCompra As Integer, ByVal folio As String, ByVal idProducto As Integer, ByVal catidad As Integer, ByVal pCompra As Double)
        _idDCompra = idDCompra
        _folio = folio
        _idProducto = idProducto
        _cantidad = catidad
        _pCompra = pCompra
    End Sub
End Class
