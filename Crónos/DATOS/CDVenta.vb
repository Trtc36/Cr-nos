Public Class CDVenta
    Dim folio As String
    Dim idDVenta, idProducto, cantidad As Integer
    Dim pVenta As Double

    Public Property _idDVenta
        Get
            Return idDVenta
        End Get
        Set(ByVal value)
            idDVenta = value
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

    Public Property _pVenta
        Get
            Return pVenta
        End Get
        Set(ByVal value)
            pVenta = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idDVenta As Integer, ByVal folio As String, ByVal idProducto As Integer, ByVal cantidad As Integer, ByVal pVenta As Double)
        _idDVenta = idDVenta
        _folio = folio
        _idProducto = idProducto
        _cantidad = cantidad
        _pVenta = pVenta
    End Sub
End Class
