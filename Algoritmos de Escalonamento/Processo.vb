Public Class Processo
    Public nome As String
    Public tempoChegada As Integer
    Public tempoProcessamento As Integer
    Public prioridade As Byte
    Public executado As Boolean
    Public executando As Boolean
    Public threadExecucao As Integer
    Public tempoDeEspera As Integer
    Public tempoDeExecucao

    Public Sub New()

    End Sub

    Public Sub New(ByVal nomeProcesso As String, ByVal tempoChegadaProcesso As Integer, ByVal tempoProcessamentoProcesso As Integer, ByVal prioridadeProcesso As Integer)
        nome = nomeProcesso
        tempoChegada = tempoChegadaProcesso
        tempoProcessamento = tempoProcessamentoProcesso
        prioridade = prioridadeProcesso
    End Sub

    Public Sub executar()
        executado = True
        executando = False
    End Sub

    Public Function jaExecutou()
        Return executado
    End Function

End Class
