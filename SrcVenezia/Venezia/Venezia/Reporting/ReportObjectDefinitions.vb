﻿Namespace ReportObjectDefinitions

    Public Class cRptDefiniciones

    End Class

#Region "Tesoreria"

    Public Class RptObjDefLiquidacion
        Private _Vendedor As String
        Private _Fecha As Date
        Private _Total As Double
        Private _Importe_Cash As Double
        Private _id_Liquidacion As Integer
        Private _Importe_Cheques As Double
        Private _Importe_Retenciones As Double
        Private _Importe_Transferencias As Double
        Private _Importe_NCredito As Double
        Private _Observaciones As String
        Private _Id_Estado As String
        Private _Estado As String

        Public Property Vendedor As String
            Get
                Return _Vendedor
            End Get
            Set(value As String)
                _Vendedor = value
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

        Public Property Total As Double
            Get
                Return _Total
            End Get
            Set(value As Double)
                _Total = value
            End Set
        End Property

        Public Property Importe_Cash As Double
            Get
                Return _Importe_Cash
            End Get
            Set(value As Double)
                _Importe_Cash = value
            End Set
        End Property

        Public Property Id_Liquidacion As Integer
            Get
                Return _id_Liquidacion
            End Get
            Set(value As Integer)
                _id_Liquidacion = value
            End Set
        End Property

        Public Property Importe_Cheques As Double
            Get
                Return _Importe_Cheques
            End Get
            Set(value As Double)
                _Importe_Cheques = value
            End Set
        End Property

        Public Property Importe_Retenciones As Double
            Get
                Return _Importe_Retenciones
            End Get
            Set(value As Double)
                _Importe_Retenciones = value
            End Set
        End Property

        Public Property Importe_Transferencias As Double
            Get
                Return _Importe_Transferencias
            End Get
            Set(value As Double)
                _Importe_Transferencias = value
            End Set
        End Property

        Public Property Importe_NCredito As Double
            Get
                Return _Importe_NCredito
            End Get
            Set(value As Double)
                _Importe_NCredito = value
            End Set
        End Property

        Public Property Observaciones As String
            Get
                Return _Observaciones
            End Get
            Set(value As String)
                _Observaciones = value
            End Set
        End Property

        Public Property Id_Estado As String
            Get
                Return _Id_Estado
            End Get
            Set(value As String)
                _Id_Estado = value
            End Set
        End Property

        Public Property Estado As String
            Get
                Return _Estado
            End Get
            Set(value As String)
                _Estado = value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class

    Public Class RptObjDefCheques

        Private _id_cheque As Integer
        Private _id_liquidacion As Integer
        Private _propio As String
        Private _banco As String
        Private _numero As String
        Private _directo As String
        Private _cruzado As String
        Private _orden As String
        Private _fecha_pago As Date
        Private _fecha_vencimiento As Date
        Private _importe As Double
        Private _observaciones As String
        Private _estado As String

        Public Property id_cheque As Integer
            Get
                Return _id_cheque
            End Get
            Set(value As Integer)
                _id_cheque = value
            End Set
        End Property

        Public Property id_liquidacion As Integer
            Get
                Return _id_liquidacion
            End Get
            Set(value As Integer)
                _id_liquidacion = value
            End Set
        End Property

        Public Property propio As String
            Get
                Return _propio
            End Get
            Set(value As String)
                _propio = value
            End Set
        End Property

        Public Property banco As String
            Get
                Return _banco
            End Get
            Set(value As String)
                _banco = value
            End Set
        End Property

        Public Property numero As String
            Get
                Return _numero
            End Get
            Set(value As String)
                _numero = value
            End Set
        End Property

        Public Property directo As String
            Get
                Return _directo
            End Get
            Set(value As String)
                _directo = value
            End Set
        End Property

        Public Property cruzado As String
            Get
                Return _cruzado
            End Get
            Set(value As String)
                _cruzado = value
            End Set
        End Property

        Public Property fecha_pago As Date
            Get
                Return _fecha_pago
            End Get
            Set(value As Date)
                _fecha_pago = value
            End Set
        End Property

        Public Property fecha_vencimiento As Date
            Get
                Return _fecha_vencimiento
            End Get
            Set(value As Date)
                _fecha_vencimiento = value
            End Set
        End Property

        Public Property importe As Double
            Get
                Return _importe
            End Get
            Set(value As Double)
                _importe = value
            End Set
        End Property

        Public Property observaciones As String
            Get
                Return _observaciones
            End Get
            Set(value As String)
                _observaciones = value
            End Set
        End Property

        Public Property estado As String
            Get
                Return _estado
            End Get
            Set(value As String)
                _estado = value
            End Set
        End Property

        Public Property orden As String
            Get
                Return _orden
            End Get
            Set(value As String)
                _orden = value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class

    Public Class RptObjDefChequesxProvFOPDH
        Private _Fecha As Date
        Private _Numero As String
        Private _Importe As Double
        Private _FPagoCh As Date
        Private _Banco As String
        Private _Origen As String
        Private _OP As Integer
        Private _Liq As Integer

        Public Property Fecha As Date
            Get
                Return _Fecha
            End Get
            Set(value As Date)
                _Fecha = value
            End Set
        End Property

        Public Property Numero As String
            Get
                Return _Numero
            End Get
            Set(value As String)
                _Numero = value
            End Set
        End Property

        Public Property Importe As Double
            Get
                Return _Importe
            End Get
            Set(value As Double)
                _Importe = value
            End Set
        End Property

        Public Property FPagoCh As Date
            Get
                Return _FPagoCh
            End Get
            Set(value As Date)
                _FPagoCh = value
            End Set
        End Property

        Public Property Banco As String
            Get
                Return _Banco
            End Get
            Set(value As String)
                _Banco = value
            End Set
        End Property

        Public Property Origen As String
            Get
                Return _Origen
            End Get
            Set(value As String)
                _Origen = value
            End Set
        End Property

        Public Property OP As Integer
            Get
                Return _OP
            End Get
            Set(value As Integer)
                _OP = value
            End Set
        End Property

        Public Property Liq As Integer
            Get
                Return _Liq
            End Get
            Set(value As Integer)
                _Liq = value
            End Set
        End Property

    End Class

    Public Class RptObjDefOrdenDePagoPorFecha

        Private _estado As String
        Private _Nombre As String
        Private _fechaD As Date
        Private _fechaH As Date
        Private _id_orden As Integer
        Private _fecha As Date
        Private _importe_cash As Double
        Private _importe_transferencia As Double
        Private _importe_cheques As Double
        Private _tipo_destino As String
        Private _destino As String
        Private _CodProve As Integer
        Private _id_estado As Integer
        Private _observaciones As String

        Public Property Estado As String
            Get
                Return _estado
            End Get
            Set(value As String)
                _estado = value
            End Set
        End Property

        Public Property Nombre As String
            Get
                Return _Nombre
            End Get
            Set(value As String)
                _Nombre = value
            End Set
        End Property

        Public Property FechaD As Date
            Get
                Return _fechaD
            End Get
            Set(value As Date)
                _fechaD = value
            End Set
        End Property

        Public Property FechaH As Date
            Get
                Return _fechaH
            End Get
            Set(value As Date)
                _fechaH = value
            End Set
        End Property

        Public Property Id_orden As Integer
            Get
                Return _id_orden
            End Get
            Set(value As Integer)
                _id_orden = value
            End Set
        End Property

        Public Property Fecha As Date
            Get
                Return _fecha
            End Get
            Set(value As Date)
                _fecha = value
            End Set
        End Property

        Public Property Importe_cash As Double
            Get
                Return _importe_cash
            End Get
            Set(value As Double)
                _importe_cash = value
            End Set
        End Property

        Public Property Importe_transferencia As Double
            Get
                Return _importe_transferencia
            End Get
            Set(value As Double)
                _importe_transferencia = value
            End Set
        End Property

        Public Property Importe_cheques As Double
            Get
                Return _importe_cheques
            End Get
            Set(value As Double)
                _importe_cheques = value
            End Set
        End Property

        Public Property Tipo_destino As String
            Get
                Return _tipo_destino
            End Get
            Set(value As String)
                _tipo_destino = value
            End Set
        End Property

        Public Property Destino As String
            Get
                Return _destino
            End Get
            Set(value As String)
                _destino = value
            End Set
        End Property

        Public Property CodProve As Integer
            Get
                Return _CodProve
            End Get
            Set(value As Integer)
                _CodProve = value
            End Set
        End Property

        Public Property Id_estado As Integer
            Get
                Return _id_estado
            End Get
            Set(value As Integer)
                _id_estado = value
            End Set
        End Property

        Public Property Observaciones As String
            Get
                Return _observaciones
            End Get
            Set(value As String)
                _observaciones = value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class

    Public Class RptObjDefChequesRankingxCliente
        Private _NroCli As String
        Private _Cliente As String
        Private _Total As Double
        Private _Porcentaje As Double
        Private _UltFPago As Date

        Public Property NroCli As String
            Get
                Return _NroCli
            End Get
            Set(value As String)
                _NroCli = value
            End Set
        End Property

        Public Property Cliente As String
            Get
                Return _Cliente
            End Get
            Set(value As String)
                _Cliente = value
            End Set
        End Property

        Public Property Total As Double
            Get
                Return _Total
            End Get
            Set(value As Double)
                _Total = value
            End Set
        End Property

        Public Property Porcentaje As Double
            Get
                Return _Porcentaje
            End Get
            Set(value As Double)
                _Porcentaje = value
            End Set
        End Property

        Public Property UltFPago As Date
            Get
                Return _UltFPago
            End Get
            Set(value As Date)
                _UltFPago = value
            End Set
        End Property
    End Class

#End Region

End Namespace

