Public Class Processo
    Public nome As String
    Public tempoChegada As Integer
    Public tempoProcessamento As Integer
    Public prioridade As Byte

    Public Sub New()

    End Sub

    Public Sub New(ByVal nomeProcesso, ByVal tempoChegadaProcesso, ByVal tempoProcessamentoProcesso, ByVal prioridadeProcesso)
        nome = nomeProcesso
        tempoChegada = tempoChegadaProcesso
        tempoProcessamento = tempoProcessamentoProcesso
        prioridade = prioridadeProcesso
    End Sub

End Class
