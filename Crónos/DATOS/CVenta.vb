Public Class CVenta
    Dim idVenta, idCliente, idEmpleado As Integer
    Dim folio, tVenta As String
    Dim fecha As Date

    Public Property _idVenta
        Get
            Return idVenta
        End Get
        Set(ByVal value)
            idVenta = value
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

    Public Property _idCliente
        Get
            Return idCliente
        End Get
        Set(ByVal value)
            idCliente = value
        End Set
    End Property

    Public Property _tVenta
        Get
            Return tVenta
        End Get
        Set(ByVal value)
            tVenta = value
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

    Public Sub New()

    End Sub

    Public Sub New(ByVal idVenta As Integer, ByVal folio As String, ByVal fecha As Date, ByVal idCliente As Integer, ByVal tVenta As String, ByVal idEmpleado As Integer)
        _idVenta = idVenta
        _folio = folio
        _fecha = fecha
        _idCliente = idCliente
        _tVenta = tVenta
        _idEmpleado = idEmpleado
    End Sub

End Class
