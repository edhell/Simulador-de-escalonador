Public Class Escalonador
    Public threads As Integer
    Public custoTrocaContexto As Integer
    Public rrQuantum As Integer

    Public fila1 As New List(Of Processo)
    Public fila2 As New List(Of Processo)
    Public fila3 As New List(Of Processo)
    Public fila4 As New List(Of Processo)
    Public fila5 As New List(Of Processo)

    Public Sub New()

    End Sub

    Public Sub New(ByVal threadsEsc As Integer, ByVal custoTrocaContextoEsc As Integer, ByVal rrQuantumEsc As Integer, ByVal fila_1 As List(Of Processo), ByVal fila_2 As List(Of Processo), ByVal fila_3 As List(Of Processo), ByVal fila_4 As List(Of Processo), ByVal fila_5 As List(Of Processo))
        threads = threadsEsc
        custoTrocaContexto = custoTrocaContextoEsc
        rrQuantum = rrQuantumEsc
        fila1 = fila_1
        fila2 = fila_2
        fila3 = fila_3
        fila4 = fila_4
        fila5 = fila_5

    End Sub

End Class
