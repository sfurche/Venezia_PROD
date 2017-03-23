
Imports vzStock

Public Class cOrdenCompraDet

    Private _Id_OC_Detalle As Integer
    Private _Id_OrdenDeCompra As Integer
    Private _Articulo As cArticulo
    Private _Cantidad As Integer
    Private _PrecioUnitario As Double

    Public Property Id_OC_Detalle As Integer
        Get
            Return _Id_OC_Detalle
        End Get
        Set(value As Integer)
            _Id_OC_Detalle = value
        End Set
    End Property

    Public Property Id_OrdenDeCompra As Integer
        Get
            Return _Id_OrdenDeCompra
        End Get
        Set(value As Integer)
            _Id_OrdenDeCompra = value
        End Set
    End Property

    Public Property Articulo As cArticulo
        Get
            Return _Articulo
        End Get
        Set(value As cArticulo)
            _Articulo = value
        End Set
    End Property

    Public Property Cantidad As Integer
        Get
            Return _Cantidad
        End Get
        Set(value As Integer)
            _Cantidad = value
        End Set
    End Property

    Public Property PrecioUnitario As Double
        Get
            Return _PrecioUnitario
        End Get
        Set(value As Double)
            _PrecioUnitario = value
        End Set
    End Property

End Class
