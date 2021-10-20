Public Class CCompra
    Dim idCompra, idProveedor, idAgente As Integer
    Dim folio, tPago, tCompra As String
    Dim fecha As Date

    Public Property _idCompra
        Get
            Return idCompra
        End Get
        Set(ByVal value)
            idCompra = value
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

    Public Property _fecha
        Get
            Return fecha
        End Get
        Set(ByVal value)
            fecha = value
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

    Public Property _tPago
        Get
            Return tPago
        End Get
        Set(ByVal value)
            tPago = value
        End Set
    End Property

    Public Property _tCompra
        Get
            Return tCompra
        End Get
        Set(ByVal value)
            tCompra = value
        End Set
    End Property

    Public Property _idAgente
        Get
            Return idAgente
        End Get
        Set(ByVal value)
            idAgente = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idCompra As Integer, ByVal folio As String, ByVal fecha As Date, ByVal idProveedor As String, ByVal tPago As String, ByVal tCompra As String, ByVal idAgente As Integer)
        _idCompra = idCompra
        _folio = folio
        _fecha = fecha
        _idProveedor = idProveedor
        _tPago = tPago
        _tCompra = tCompra
        _idAgente = idAgente
    End Sub
End Class
