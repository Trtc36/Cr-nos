Public Class CEmpleado
    Dim idEmpleado, idPuesto, idCarrera As Integer
    Dim codigo, nombre, paterno, materno, tVialidad, nVialidad, colonia, ciudad, estado, cp, telefono, mail, estatus As String
    Dim fNacimiento, fIngreso, fSalida As Date

    Public Property _idEmpleado
        Get
            Return idEmpleado
        End Get
        Set(ByVal value)
            idEmpleado = value
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

    Public Property _paterno
        Get
            Return paterno
        End Get
        Set(ByVal value)
            paterno = value
        End Set
    End Property

    Public Property _materno
        Get
            Return materno
        End Get
        Set(ByVal value)
            materno = value
        End Set
    End Property

    Public Property _fNacimiento
        Get
            Return fNacimiento
        End Get
        Set(ByVal value)
            fNacimiento = value
        End Set
    End Property

    Public Property _tVialidad
        Get
            Return tVialidad
        End Get
        Set(ByVal value)
            tVialidad = value
        End Set
    End Property

    Public Property _nVialidad
        Get
            Return nVialidad
        End Get
        Set(ByVal value)
            nVialidad = value
        End Set
    End Property

    Public Property _colonia
        Get
            Return colonia
        End Get
        Set(ByVal value)
            colonia = value
        End Set
    End Property

    Public Property _ciudad
        Get
            Return ciudad
        End Get
        Set(ByVal value)
            ciudad = value
        End Set
    End Property

    Public Property _estado
        Get
            Return estado
        End Get
        Set(ByVal value)
            estado = value
        End Set
    End Property

    Public Property _cp
        Get
            Return cp
        End Get
        Set(ByVal value)
            cp = value
        End Set
    End Property

    Public Property _telefono
        Get
            Return telefono
        End Get
        Set(ByVal value)
            telefono = value
        End Set
    End Property

    Public Property _mail
        Get
            Return mail
        End Get
        Set(ByVal value)
            mail = value
        End Set
    End Property

    Public Property _estatus
        Get
            Return estatus
        End Get
        Set(ByVal value)
            estatus = value
        End Set
    End Property

    Public Property _fIngreso
        Get
            Return fIngreso
        End Get
        Set(ByVal value)
            fIngreso = value
        End Set
    End Property

    Public Property _fSalida
        Get
            Return fSalida
        End Get
        Set(ByVal value)
            fSalida = value
        End Set
    End Property

    Public Property _idPuesto
        Get
            Return idPuesto
        End Get
        Set(ByVal value)
            idPuesto = value
        End Set
    End Property

    Public Property _idCarrera
        Get
            Return idCarrera
        End Get
        Set(ByVal value)
            idCarrera = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal idEmpleado As Integer, ByVal codigo As String, ByVal nombre As String, ByVal paterno As String, ByVal materno As String, ByVal fNacimiento As Date, ByVal tVialidad As String, ByVal nVialidad As String, ByVal colonia As String, ByVal ciudad As String, ByVal estado As String, ByVal cp As String, ByVal telefono As String, ByVal mail As String, ByVal estatus As String, ByVal fIngreso As Date, ByVal fSalida As Date, ByVal idPuesto As Integer, ByVal idCarrera As Integer)
        _idEmpleado = idEmpleado
        _codigo = codigo
        _nombre = nombre
        _paterno = paterno
        _materno = materno
        _fNacimiento = fNacimiento
        _tVialidad = tVialidad
        _nVialidad = nVialidad
        _colonia = colonia
        _ciudad = ciudad
        _estado = estado
        _cp = cp
        _telefono = telefono
        _mail = mail
        _estatus = estatus
        _fIngreso = fIngreso
        _fSalida = fSalida
        _idPuesto = idPuesto
        _idCarrera = idCarrera
    End Sub

End Class
