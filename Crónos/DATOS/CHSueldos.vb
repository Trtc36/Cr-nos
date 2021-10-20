Public Class CHSueldos
    Dim idSueldo, idEmpleado As Integer
    Dim sueldo As Double
    Dim fecha As Date

    Public Property _idSueldo
        Get
            Return idSueldo
        End Get
        Set(ByVal value)
            idSueldo = value
        End Set
    End Property

    Public Property _sueldo
        Get
            Return sueldo
        End Get
        Set(ByVal value)
            sueldo = value
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

    Public Sub New(ByVal idSueldo As Integer, ByVal sueldo As Double, ByVal fecha As Date, ByVal idEmpleado As Integer)
        _idSueldo = idSueldo
        _sueldo = sueldo
        _fecha = fecha
        _idEmpleado = idEmpleado
    End Sub
End Class
