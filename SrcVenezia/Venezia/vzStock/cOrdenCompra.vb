Imports VzComercial

Public Class cOrdenCompra

    Private _Id_OrdenDeCompra As Integer
    Private _Fecha As Date
    Private _Proveedor As cProveedor
    Private _Articulos As ArrayList
    Private _Importe As Double
    Private _FechaEntrega As Date

    Public Property Id_OrdenDeCompra As Integer
        Get
            Return _Id_OrdenDeCompra
        End Get
        Set(value As Integer)
            _Id_OrdenDeCompra = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
        End Set
    End Property

    Public Property Proveedor As cProveedor
        Get
            Return _Proveedor
        End Get
        Set(value As cProveedor)
            _Proveedor = value
        End Set
    End Property

    Public Property Articulos As ArrayList
        Get
            Return _Articulos
        End Get
        Set(value As ArrayList)
            _Articulos = value
        End Set
    End Property

    Public ReadOnly Property Importe As Double
        Get
            Importe = 0
            Dim lItem As cOrdenCompraDet = Nothing
            For Each lItem In Me._Articulos
                Importe = Importe + (lItem.Cantidad * lItem.PrecioUnitario)
            Next
            Return Importe
        End Get
    End Property

    Public Property FechaEntrega As Date
        Get
            Return _FechaEntrega
        End Get
        Set(value As Date)
            _FechaEntrega = value
        End Set
    End Property


End Class
