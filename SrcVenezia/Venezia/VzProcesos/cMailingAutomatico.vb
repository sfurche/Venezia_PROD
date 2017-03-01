Imports VzAdmin

Public Class cMailingAutomatico

    Public Shared Function EnviarMailsPendientes(ByRef pAdmin As cAdmin) As Boolean
        EnviarMailsPendientes = False
        Dim lEmail As cEmail = Nothing
        Dim lArray As ArrayList = Nothing

        Try
            lArray = cEmail.GetMailingxEstado(pAdmin, 0)

            For Each lEmail In lArray
                lEmail.Enviar()
            Next

            EnviarMailsPendientes = True
        Catch ex As Exception
            pAdmin.Log.fncGrabarLogERR("Error en cMailingAutomatico.EnviarMailsPendientes:" & ex.Message)
        End Try
    End Function
End Class
