Public Class CIncidencia
    Dim idIncidencia, idEmpleado As Integer
    Dim fecha As Date
    Dim tIncidencia, area As String

    Public Property _idIncidencia
        Get
            Return idIncidencia
        End Get
        Set(ByVal value)
            idIncidencia = value
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

    Public Property _fecha
        Get
            Return fecha
        End Get
        Set(ByVal value)
            fecha = value
        End Set
    End Property

    Public Property _tIncidencia
        Get
            Return tIncidencia
        End Get
        Set(ByVal value)
            tIncidencia = value
        End Set
    End Property


    Public Property _area
        Get
            Return area
        End Get
        Set(ByVal value)
            area = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idIncidencia As Integer, ByVal idEmpleado As Integer, ByVal fecha As Date, ByVal tIncidencia As String, ByVal area As String)
        _idIncidencia = idIncidencia
        _idEmpleado = idEmpleado
        _fecha = fecha
        _tIncidencia = tIncidencia
        _area = area
    End Sub
End Class
