Public Class CProducto
    Dim idProducto, stock, idModelo, idCategoria, idProveedor As Integer
    Dim codigo, nombre As String
    Dim p_Venta, p_Compra As Double

    Public Property _idProducto
        Get
            Return idProducto
        End Get
        Set(ByVal value)
            idProducto = value
        End Set
    End Property

    Public Property _stock
        Get
            Return stock
        End Get
        Set(ByVal value)
            stock = value
        End Set
    End Property

    Public Property _idModelo
        Get
            Return idModelo
        End Get
        Set(ByVal value)
            idModelo = value
        End Set
    End Property

    Public Property _idCategoria
        Get
            Return idCategoria
        End Get
        Set(ByVal value)
            idCategoria = value
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

    Public Property _pVenta
        Get
            Return p_Venta
        End Get
        Set(ByVal value)
            p_Venta = value
        End Set
    End Property

    Public Property _pCompra
        Get
            Return p_Compra
        End Get
        Set(ByVal value)
            p_Compra = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idProducto As Integer, ByVal codigo As String, ByVal nombre As String, ByVal stock As Integer, ByVal idModelo As Integer, ByVal idCategoria As Integer, ByVal idProveedor As Integer, ByVal p_Venta As Double, ByVal p_Compra As Double)
        _idProducto = idProducto
        _codigo = codigo
        _nombre = nombre
        _stock = stock
        _idModelo = idModelo
        _idCategoria = idCategoria
        _idProveedor = idProveedor
        _pVenta = p_Venta
        _pCompra = p_Compra
    End Sub
End Class
