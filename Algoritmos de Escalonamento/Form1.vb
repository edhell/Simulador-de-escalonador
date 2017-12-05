Imports System.Threading
Imports Algoritmos_de_Escalonamento

Public Class Form1

    Private letras As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    '' Ao inicializar
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MsgBox("Olá! Esta aplicação foi feita para fins instucionais." & vbNewLine &
        '"Mais informações em: www.edinfo.com.br", MsgBoxStyle.OkOnly, "Eduardo Dumke")

    End Sub

#Region "Entradas"

#Region "Fila 1"
    '' Fila 1: Gerar Processos 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        gerarProcAleatorios(RichTextBox2, "Fila 1")

    End Sub

    '' FILA 1 - Carregar Arquivo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        carregarArquivo(RichTextBox2, "Fila 1")
    End Sub

    '' Fila 1 TESTAR:
    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        testarFilas(RichTextBox2, "Fila 1")
    End Sub

    '' Fila 1 LIMPAR
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limparFila(RichTextBox2, "Fila 1")
    End Sub
#End Region

#Region "Fila 2"

    '' Fila 2: Gerar Processos 
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        gerarProcAleatorios(RichTextBox3, "Fila 2")
    End Sub

    '' FILA 2 - Carregar Arquivo
    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        carregarArquivo(RichTextBox2, "Fila 2")
    End Sub

    '' Fila 2 TESTAR:
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        testarFilas(RichTextBox2, "Fila 2")
    End Sub

    '' Fila 2 LIMPAR
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        limparFila(RichTextBox2, "Fila 2")
    End Sub
#End Region

#Region "Fila 3"
    '' Fila 3: Gerar Processos 
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        gerarProcAleatorios(RichTextBox4, "Fila 3")
    End Sub

    '' FILA 3 - Carregar Arquivo
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        carregarArquivo(RichTextBox4, "Fila 3")
    End Sub

    '' Fila 3 TESTAR:
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        testarFilas(RichTextBox4, "Fila 3")
    End Sub

    '' Fila 3 LIMPAR
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        limparFila(RichTextBox4, "Fila 3")
    End Sub
#End Region

#Region "Fila 4"
    '' Fila 4: Gerar Processos 
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        gerarProcAleatorios(RichTextBox5, "Fila 4")
    End Sub

    '' FILA 4 - Carregar Arquivo
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        carregarArquivo(RichTextBox5, "Fila 4")
    End Sub

    '' Fila 4 TESTAR:
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        testarFilas(RichTextBox5, "Fila 4")
    End Sub

    '' Fila 4 LIMPAR
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        limparFila(RichTextBox5, "Fila 4")
    End Sub
#End Region

#Region "Fila 5"
    '' Fila 5: Gerar Processos 
    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        gerarProcAleatorios(RichTextBox6, "Fila 5")
    End Sub

    '' FILA 5 - Carregar Arquivo
    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        carregarArquivo(RichTextBox6, "Fila 5")
    End Sub

    '' Fila 5 TESTAR:
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        testarFilas(RichTextBox6, "Fila 5")
    End Sub

    '' Fila 5 LIMPAR
    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        limparFila(RichTextBox6, "Fila 5")
    End Sub
#End Region

    '' FUNCAO CARREGAR ARQUIVO
    Private Sub carregarArquivo(ByRef richDestino As RichTextBox, ByVal filaNome As String)
        richDestino.Text = ""
        ToolStripStatusLabel1.Text = filaNome & ": Carregando arquivo."
        Try
            Dim OpenFileDialog1 As New OpenFileDialog
            OpenFileDialog1.Filter = "Arquivos de texto |*.txt"
            OpenFileDialog1.Title = "Selecione um arquivo de texto"
            OpenFileDialog1.ShowDialog()
            richDestino.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)

            ToolStripStatusLabel1.Text = filaNome & ": Arquivo " & OpenFileDialog1.SafeFileName & " carregado."
        Catch ex As Exception
            'MsgBox("Erro ao abrir arquivo. " & ex.Message)
            ToolStripStatusLabel1.Text = filaNome & ": Erro ao carregar o arquivo. " & ex.Message
        End Try

    End Sub

    '' FUNCAO GERAR PROCESSOS ALEATORIOS
    Private Sub gerarProcAleatorios(ByRef richDestino As RichTextBox, ByVal filaNome As String)
        Dim tr2 As New Thread(AddressOf gerarAleatorio)
        tr2.Start(richDestino)

        Me.ToolStripStatusLabel1.Text = "Gerando processos para " & filaNome & "..."
    End Sub
    '' FUNCAO para Gerar Processos Aleatórios
    Private Sub gerarAleatorio(richTextBox As RichTextBox)
        Try
            Me.Invoke(Sub() TabControl2.Enabled = False)
            Me.Invoke(Sub() Button21.Enabled = False)

            Dim r As New Random
            Dim processos As New List(Of Processo)

            Dim cnt1 As Integer
            Dim cnt2 As Integer
            Dim cnt3 As Integer

            'Dim qntProcs As Integer = 100 + r.Next(6659)
            Dim qntProcs As Integer = 10 + r.Next(1000)

            For index = 1 To qntProcs
                '' Verifica digito do nome do processo:
                If cnt3 = 9 Then
                    cnt2 += 1
                    cnt3 = 0
                Else cnt3 += 1
                End If

                '' Verifica letra do nome do processo:
                If cnt2 = 26 Then
                    cnt2 = 0
                    cnt1 += 1
                End If

                '' Maximo permitido é 26*26*10 = 6.759
                If cnt1 = 26 Then : MsgBox("Atingiu o maximo de processos.") : GoTo fim : End If
                Dim p As New Processo

                '' Cria o nome:
                p.nome = letras.Substring(cnt1, 1) + letras.Substring(cnt2, 1) + cnt3.ToString

                '' Se for o primeiro processo, chegada 0:
                If processos.Count > 0 Then
                    p.tempoChegada = processos.Item(processos.Count - 1).tempoChegada + r.Next(100)
                    p.tempoProcessamento = 1 + r.Next(100)
                Else
                    p.tempoChegada = r.Next(100)
                    p.tempoProcessamento = 1 + r.Next(100)
                End If

                '' Define uma prioridade:
                p.prioridade = r.Next(3)

                '' Adiciona la lista de processos:
                processos.Add(p)

            Next

            Dim contTempProcessamento As Integer

            Me.Invoke(Sub() richTextBox.Text = "")
            Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = 0)
            Dim porc As Double = 100 / processos.Count
            Dim porcTotal As Double = 0
            Dim texto As String = ""

            '' Adiciona a lista de processos no campo de texto:
            For Each p In processos
                texto &= p.nome & " - " & p.tempoChegada & " - " & p.tempoProcessamento & " - " & p.prioridade & vbNewLine

                contTempProcessamento += p.tempoProcessamento
                Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = porcTotal)
                porcTotal += porc
            Next

            '' Informa a aplicação que terminou:
            Me.Invoke(Sub() richTextBox.Text = texto)

            Me.Invoke(Sub() Me.ToolStripStatusLabel1.Text = "Gerou " & processos.Count & " processos.")
            Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = 100)

        Catch ex As Exception
            Me.Invoke(Sub() Me.ToolStripStatusLabel1.Text = "Erro ao gerar processos. " & ex.Message)
            Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = 0)
        End Try

fim:    '' Reabilita comandos:
        Me.Invoke(Sub() TabControl2.Enabled = True)
        Me.Invoke(Sub() Button21.Enabled = True)

    End Sub

    '' FUNCAO TESTAR
    Private Sub testarFilas(ByVal richOrigem As RichTextBox, ByVal filaNome As String)
        Dim erro As String = testarFila(richOrigem)

        If erro = "#####true!" Then
            ToolStripStatusLabel1.Text = filaNome & ": Aparentemente OK!"
        Else
            ToolStripStatusLabel1.Text = filaNome & ": Há erros na linha: " & erro
        End If

    End Sub
    '' FUNCAO TESTAR Fila de processos
    Private Function testarFila(richTextBox1 As RichTextBox) As String
        Dim ultimaLinha As String = vbNull
        Try
            For Each linha In richTextBox1.Lines
                ' Exemplo: AA1 - 70 - 57 - 2
                ultimaLinha = linha
                If linha.Length > 1 Then
                    Dim x() As String = linha.Split("-")
                    Dim nome As String = x(0).Trim
                    Dim tChegada As Integer = CInt(x(1).Trim)
                    Dim tExec As Integer = CInt(x(2).Trim)
                    Dim prioridade As Integer = CInt(x(3).Trim)
                    If prioridade < 0 AndAlso prioridade > 2 Then
                        Return ultimaLinha
                    End If

                End If
            Next

            '' Se ocorreu tudo bem:
            Return "#####true!"
        Catch ex As Exception
            Return ultimaLinha
        End Try

    End Function

    '' FUNCAO LIMPAR
    Private Sub limparFila(ByRef richDestino As RichTextBox, ByVal filaNome As String)
        richDestino.Text = ""
        ToolStripStatusLabel1.Text = filaNome & ": Limpa."
    End Sub

#End Region

#Region "Outras Funções"

    '' Selecionou Algoritmo
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 5 Or ComboBox1.SelectedIndex = 6 Then
            NumericUpDown3.Enabled = True
        Else
            NumericUpDown3.Enabled = False
        End If
    End Sub

    '' Transforma Entradas em fila de processos
    Private Function pegarProcessosFila(lines() As String, ByVal filaNome As String) As List(Of Processo)
        Dim fila As New List(Of Processo)

        For Each linha In lines
            If linha.Length > 1 Then
                Dim x() As String = linha.Split("-")
                Dim nome As String = filaNome & "_" & x(0).Trim
                Dim tChegada As Integer = CInt(x(1).Trim)
                Dim tExec As Integer = CInt(x(2).Trim)
                Dim prioridade As Integer = CInt(x(3).Trim)
                fila.Add(New Processo(nome, tChegada, tExec, prioridade))
            End If
        Next

        Return fila
    End Function

    '' Adiciona Linha no log de informações
    Private Sub addInfo(ByVal linha As String)
        RichTextBox7.Text &= linha & vbNewLine
    End Sub

#End Region

    '' BOTAO EXECUTAR
    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click

        '' Variaveis Utilizadas
        Dim threads As Integer = NumericUpDown1.Value
        Dim custoTrocaContexto As Integer = NumericUpDown2.Value
        Dim rrQuantum As Integer = NumericUpDown3.Value

        Dim fila1 As New List(Of Processo)
        Dim fila2 As New List(Of Processo)
        Dim fila3 As New List(Of Processo)
        Dim fila4 As New List(Of Processo)
        Dim fila5 As New List(Of Processo)

        '' Limpa log de informações
        RichTextBox7.Clear()

        '' Testa conteúdo das filas:
        If testarFila(RichTextBox2) = "#####true!" Then : fila1 = pegarProcessosFila(RichTextBox2.Lines, "Fila_1")
        Else : ToolStripStatusLabel1.Text = "Há erros na fila 1." : Return : End If
        If testarFila(RichTextBox3) = "#####true!" Then : fila2 = pegarProcessosFila(RichTextBox3.Lines, "Fila_2")
        Else : ToolStripStatusLabel1.Text = "Há erros na fila 2." : Return : End If
        If testarFila(RichTextBox4) = "#####true!" Then : fila3 = pegarProcessosFila(RichTextBox4.Lines, "Fila_3")
        Else : ToolStripStatusLabel1.Text = "Há erros na fila 3." : Return : End If
        If testarFila(RichTextBox5) = "#####true!" Then : fila4 = pegarProcessosFila(RichTextBox5.Lines, "Fila_4")
        Else : ToolStripStatusLabel1.Text = "Há erros na fila 4." : Return : End If
        If testarFila(RichTextBox6) = "#####true!" Then : fila5 = pegarProcessosFila(RichTextBox6.Lines, "Fila_5")
        Else : ToolStripStatusLabel1.Text = "Há erros na fila 5." : Return : End If

        Dim esc As New Escalonador(threads, custoTrocaContexto, rrQuantum, fila1, fila2, fila3, fila4, fila5)

        '' Mostra informações
        If ComboBox1.SelectedIndex > -1 Then
            addInfo("# Threads: " & threads)
            addInfo("# Custo de troca de contexto: " & custoTrocaContexto)

            If fila1.Count > 0 Then : addInfo("# Processos Fila 1: " & fila1.Count) : End If
            If fila2.Count > 0 Then : addInfo("# Processos Fila 2: " & fila2.Count) : End If
            If fila3.Count > 0 Then : addInfo("# Processos Fila 3: " & fila3.Count) : End If
            If fila4.Count > 0 Then : addInfo("# Processos Fila 4: " & fila4.Count) : End If
            If fila5.Count > 0 Then : addInfo("# Processos Fila 5: " & fila5.Count) : End If

            Button21.Enabled = False
        End If


        '' Verifica o algoritmo e executa:
        Select Case ComboBox1.SelectedIndex
            Case -1 '' Nenhum
                MsgBox("Escolha um algoritmo.")
                ComboBox1.Focus()

            Case 0 '' FIFO
                '' Thread que será o "escalonador"
                Dim tr1 As New Thread(AddressOf escalonarProcessos_FIFO)

                '' Mostra informações
                addInfo("Iniciando execução com algoritmo FIFO:")
                ToolStripStatusLabel1.Text = "Iniciando execução com algoritmo FIFO."

                tr1.Priority = ThreadPriority.Highest
                tr1.Start(esc)

            Case 1 '' SJF / SRT
                '' Thread que será o "escalonador"
                Dim tr1 As New Thread(AddressOf escalonarProcessos_SJF)

                MsgBox("Esta sendo implementado: " & ComboBox1.Items(2))

                '' Mostra informações
                addInfo("Iniciando execução com algoritmo SJF / SRT:")
                ToolStripStatusLabel1.Text = "Iniciando execução com algoritmo SJF / SRT."

                tr1.Priority = ThreadPriority.Highest
                tr1.Start(esc)

            Case 2 '' SJF/ SRT Preemptivo
                MsgBox("Falta implementar: " & ComboBox1.Items(2))
                Return

                '' Thread que será o "escalonador"
                Dim tr1 As New Thread(AddressOf escalonarProcessos_SJF_P)

                '' Mostra informações
                addInfo("Iniciando execução com algoritmo SJF / SRT Preemptivo:")
                ToolStripStatusLabel1.Text = "Iniciando execução com algoritmo SJF / SRT Preemptivo."

                tr1.Priority = ThreadPriority.Highest
                tr1.Start(esc)

            Case 3 '' Prioridade
                MsgBox("Falta implementar: " & ComboBox1.Items(3))
                Return

                '' Thread que será o "escalonador"
                Dim tr1 As New Thread(AddressOf escalonarProcessos_Prioridade)

                '' Mostra informações
                addInfo("Iniciando execução com algoritmo Prioridade:")
                ToolStripStatusLabel1.Text = "Iniciando execução com algoritmo Prioridade."

                tr1.Priority = ThreadPriority.Highest
                tr1.Start(esc)

            Case 4 '' RR
                MsgBox("Falta implementar: " & ComboBox1.Items(5))
                Return

                '' Thread que será o "escalonador"
                Dim tr1 As New Thread(AddressOf escalonarProcessos_RR)

                '' Mostra informações
                addInfo("Iniciando execução com algoritmo RR:")
                ToolStripStatusLabel1.Text = "Iniciando execução com algoritmo RR."

                tr1.Priority = ThreadPriority.Highest
                tr1.Start(esc)

                'addInfo("RR Quantum: " & rrQuantum)

            Case 5 '' Loteria
                MsgBox("Falta implementar: " & ComboBox1.Items(7))
                Return

                '' Thread que será o "escalonador"
                Dim tr1 As New Thread(AddressOf escalonarProcessos_Loteria)

                '' Mostra informações
                addInfo("Iniciando execução com algoritmo Loteria")
                ToolStripStatusLabel1.Text = "Iniciando execução com algoritmo Loteria."

                tr1.Priority = ThreadPriority.Highest
                tr1.Start(esc)

            Case Else
                MsgBox("Erro ao escolher algoritmo.")

        End Select


    End Sub

    '' ESCALONAR Processos: FIFO
    Private Sub escalonarProcessos_FIFO(ByVal escalonador As Escalonador)
        Dim cronometro As New Stopwatch
        cronometro.Start()
        Dim filaExecucao As New Queue(Of Processo)
        Dim processosExecutados As New List(Of Processo)

        Dim fila1 As New Queue(escalonador.fila1)
        Dim fila2 As New Queue(escalonador.fila2)
        Dim fila3 As New Queue(escalonador.fila3)
        Dim fila4 As New Queue(escalonador.fila4)
        Dim fila5 As New Queue(escalonador.fila5)

        Dim temItems As Boolean = True
        While temItems
            If fila1.Count > 0 Then : filaExecucao.Enqueue(fila1.Dequeue) : End If
            If fila2.Count > 0 Then : filaExecucao.Enqueue(fila2.Dequeue) : End If
            If fila3.Count > 0 Then : filaExecucao.Enqueue(fila3.Dequeue) : End If
            If fila4.Count > 0 Then : filaExecucao.Enqueue(fila4.Dequeue) : End If
            If fila5.Count > 0 Then : filaExecucao.Enqueue(fila5.Dequeue) : End If

            If fila1.Count = 0 And fila2.Count = 0 And fila3.Count = 0 And fila4.Count = 0 And fila5.Count = 0 Then
                temItems = False
            End If
        End While
        Dim totalItens As Integer = filaExecucao.Count

        Me.Invoke(Sub() addInfo("Fila de execução com " & filaExecucao.Count & " itens."))

        '' Executa os processos:
        'Dim processoAtual As New Processo
        Dim threadAtual As Integer = 1
        Dim processoAtual As New Processo
        Dim processando As New List(Of Processo)
        Dim CPULivre As UInteger = 0
        Dim CPUTotal As UInteger = 0
        Dim CPUCustoTroca As UInteger = 0
        Dim tempoEsperaTotal As UInteger = 0
        Dim tempoExecucaoTotal As UInteger = 0

        Dim tempoAtual As UInteger = 0

        While filaExecucao.Count > 0 Or processando.Count > 0

            '' Adiciona processos às threads:
            For index = processando.Count To escalonador.threads - 1
                If filaExecucao.Count > 0 Then
                    processoAtual = filaExecucao.Dequeue
                    processoAtual.threadExecucao = index + 1
                    processando.Add(processoAtual)
                    'Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & processoAtual.nome & "' na fila de espera da Thread " & index + 1 & "."))
                End If
            Next

            Dim processandoAdicionar = New List(Of Processo)
            '' Verifica cada processo que esta na fila dos "prontos":
            For Each p In processando
                '' Verifica se começa a executar:
                If p.tempoChegada <= tempoAtual And p.executando = False Then

                    Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & p.nome & "' escalonado na Thread " & p.threadExecucao & "."))
                    Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & p.nome & "' executando na Thread " & p.threadExecucao & "."))
                    p.executando = True

                    '' Adiciona tempo de troca de contexto:
                    tempoAtual += escalonador.custoTrocaContexto
                    CPUCustoTroca += escalonador.custoTrocaContexto
                End If

                '' Verifica se tem processos ativos:
                If p.tempoChegada <= tempoAtual And p.executado = False Then
                    p.tempoDeExecucao += 1
                    tempoExecucaoTotal += 1
                Else
                    CPULivre += 1
                End If

                '' Se acabou executou tudo:
                If (p.tempoChegada + p.tempoProcessamento) <= tempoAtual Then
                    p.executar()
                    Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & p.nome & "' finalizado na Thread " & p.threadExecucao & "."))
                    processosExecutados.Add(p)

                    '' Adiciona proximo:
                    If filaExecucao.Count > 0 Then
                        processoAtual = filaExecucao.Dequeue
                        processoAtual.threadExecucao = p.threadExecucao
                        processandoAdicionar.Add(processoAtual)
                        'Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & processoAtual.nome & "' na fila de espera da Thread " & processoAtual.threadExecucao & "."))
                    End If
                End If
            Next

            '' Remover quais foram executados:
            Dim processandoNova = New List(Of Processo)
            processandoNova.AddRange(processando)
            For Each p In processandoNova
                If p.executado Then
                    processando.Remove(p)
                End If
            Next

            '' Verifica Processos prontos para serem executados:
            For Each p In filaExecucao
                If p.tempoChegada <= tempoAtual Then
                    p.tempoDeEspera += 1
                    tempoEsperaTotal += 1
                End If
            Next

            '' Adiciona o proximo na fila:
            processando.AddRange(processandoAdicionar)

            '' Adiciona +1 ao contador:
            tempoAtual += 1

            '' Se quantidade de processos for maior que fila, adiciona ao tempo livre de cpu
            If totalItens < escalonador.threads Then
                CPULivre += (escalonador.threads - processando.Count)
            End If

        End While

        '' Ao finalizar
        cronometro.Stop()
        Dim ts As TimeSpan = cronometro.Elapsed
        Dim tCronometro = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10)

        Me.Invoke(Sub() addInfo(tempoAtual & ": Terminou de executar todos processos."))
        Me.Invoke(Sub() addInfo("#" & ": Tempo decorrido: " & tCronometro))
        Me.Invoke(Sub() addInfo("#" & ": Custo total de troca de contexto: " & CPUCustoTroca))
        Me.Invoke(Sub() addInfo("#" & ": Tempo médio de espera: " & tempoEsperaTotal / processosExecutados.Count))
        Me.Invoke(Sub() addInfo("#" & ": Tempo médio de CPU: " & tempoExecucaoTotal / processosExecutados.Count))
        Me.Invoke(Sub() addInfo("#" & ": Total de tempo de CPU Livre (Somando todas threads): " & CPULivre))
        Me.Invoke(Sub() addInfo("#" & ": Tempo maximo de CPU (Somando todas threads): " & tempoAtual * escalonador.threads))
        Me.Invoke(Sub() addInfo("#" & ": Aproveitamento de CPU: " & 100 - (CPULivre / (tempoAtual * escalonador.threads)) * 100 & "%"))
        Me.Invoke(Sub() RichTextBox7.SelectionStart = RichTextBox7.Text.Length - 1)
        Me.Invoke(Sub() RichTextBox7.ScrollToCaret())
        Me.Invoke(Sub() ToolStripStatusLabel1.Text = "Terminou de executar todos processos em: " & tCronometro)
        Me.Invoke(Sub() Button21.Enabled = True)

    End Sub

    '' ESCALONAR Processos: SJF / SRT
    Private Sub escalonarProcessos_SJF(ByVal escalonador As Escalonador)
        Dim cronometro As New Stopwatch
        cronometro.Start()
        Dim filaProntoExecucao As New Queue(Of Processo)
        Dim filaProcessos As New Queue(Of Processo)
        Dim processando As New List(Of Processo)
        Dim processosExecutados As New List(Of Processo)

        Dim fila1 As New Queue(escalonador.fila1)
        Dim fila2 As New Queue(escalonador.fila2)
        Dim fila3 As New Queue(escalonador.fila3)
        Dim fila4 As New Queue(escalonador.fila4)
        Dim fila5 As New Queue(escalonador.fila5)

        Dim temItems As Boolean = True
        While temItems
            If fila1.Count > 0 Then : filaProcessos.Enqueue(fila1.Dequeue) : End If
            If fila2.Count > 0 Then : filaProcessos.Enqueue(fila2.Dequeue) : End If
            If fila3.Count > 0 Then : filaProcessos.Enqueue(fila3.Dequeue) : End If
            If fila4.Count > 0 Then : filaProcessos.Enqueue(fila4.Dequeue) : End If
            If fila5.Count > 0 Then : filaProcessos.Enqueue(fila5.Dequeue) : End If

            If fila1.Count = 0 And fila2.Count = 0 And fila3.Count = 0 And fila4.Count = 0 And fila5.Count = 0 Then
                temItems = False
            End If
        End While
        Dim totalItens As Integer = filaProcessos.Count

        Me.Invoke(Sub() addInfo("Fila de execução com " & filaProcessos.Count & " itens."))

        ''Executa os processos:
        Dim threadAtual As Integer = 1
        Dim processoAtual As New Processo
        Dim CPULivre As UInteger = 0
        Dim CPUTotal As UInteger = 0
        Dim CPUCustoTroca As UInteger = 0
        Dim tempoEsperaTotal As UInteger = 0
        Dim tempoExecucaoTotal As UInteger = 0

        Dim tempoAtual As UInteger = 0

        While filaProcessos.Count > 0 Or processando.Count > 0
            '' Adiciona processos às threads:
            For index = processando.Count To escalonador.threads - 1
                If filaProcessos.Count > 0 Then
                    processoAtual = filaProcessos.Dequeue
                    processoAtual.threadExecucao = index + 1
                    processando.Add(processoAtual)
                    'Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & processoAtual.nome & "' na fila de espera da Thread " & index + 1 & "."))
                End If
            Next

            Dim processandoAdicionar = New List(Of Processo)
            '' Verifica cada processo que esta na fila dos "prontos":
            For Each p In processando
                '' Verifica se começa a executar:
                If p.tempoChegada <= tempoAtual And p.executando = False Then

                    Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & p.nome & "' escalonado na Thread " & p.threadExecucao & "."))
                    Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & p.nome & "' executando na Thread " & p.threadExecucao & "."))
                    p.executando = True

                    '' Adiciona tempo de troca de contexto:
                    tempoAtual += escalonador.custoTrocaContexto
                    CPUCustoTroca += escalonador.custoTrocaContexto
                End If

                '' Verifica se tem processos ativos:
                If p.tempoChegada <= tempoAtual And p.executado = False Then
                    p.tempoDeExecucao += 1
                    tempoExecucaoTotal += 1
                Else
                    CPULivre += 1
                End If

                '' Se acabou executou tudo:
                If (p.tempoChegada + p.tempoProcessamento) <= tempoAtual Then
                    p.executar()
                    Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & p.nome & "' finalizado na Thread " & p.threadExecucao & "."))
                    processosExecutados.Add(p)

                    '' Adiciona proximo:
                    If filaProcessos.Count > 0 Then
                        processoAtual = filaProcessos.Dequeue
                        processoAtual.threadExecucao = p.threadExecucao
                        processandoAdicionar.Add(processoAtual)
                        'Me.Invoke(Sub() addInfo(tempoAtual & ": Processo '" & processoAtual.nome & "' na fila de espera da Thread " & processoAtual.threadExecucao & "."))
                    End If
                End If
            Next

            '' Remover quais foram executados:
            Dim processandoNova = New List(Of Processo)
            processandoNova.AddRange(processando)
            For Each p In processandoNova
                If p.executado Then
                    processando.Remove(p)
                End If
            Next

            '' Verifica Processos prontos para serem executados:
            For Each p In filaProcessos
                If p.tempoChegada <= tempoAtual Then
                    p.tempoDeEspera += 1
                    tempoEsperaTotal += 1
                End If
            Next

            '' Adiciona o proximo na fila:
            processando.AddRange(processandoAdicionar)

            '' Adiciona +1 ao contador:
            tempoAtual += 1

            '' Se quantidade de processos for maior que fila, adiciona ao tempo livre de cpu
            If totalItens < escalonador.threads Then
                CPULivre += (escalonador.threads - processando.Count)
            End If

        End While

        '' Ao finalizar
        cronometro.Stop()
        Dim ts As TimeSpan = cronometro.Elapsed
        Dim tCronometro = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10)

        Me.Invoke(Sub() addInfo(tempoAtual & ": Terminou de executar todos processos."))
        Me.Invoke(Sub() addInfo("#" & ": Tempo decorrido: " & tCronometro))
        Me.Invoke(Sub() addInfo("#" & ": Custo total de troca de contexto: " & CPUCustoTroca))
        Me.Invoke(Sub() addInfo("#" & ": Tempo médio de espera: " & tempoEsperaTotal / processosExecutados.Count))
        Me.Invoke(Sub() addInfo("#" & ": Tempo médio de CPU: " & tempoExecucaoTotal / processosExecutados.Count))
        Me.Invoke(Sub() addInfo("#" & ": Total de tempo de CPU Livre (Somando todas threads): " & CPULivre))
        Me.Invoke(Sub() addInfo("#" & ": Tempo maximo de CPU (Somando todas threads): " & tempoAtual * escalonador.threads))
        Me.Invoke(Sub() addInfo("#" & ": Aproveitamento de CPU: " & 100 - (CPULivre / (tempoAtual * escalonador.threads)) * 100 & "%"))
        Me.Invoke(Sub() RichTextBox7.SelectionStart = RichTextBox7.Text.Length - 1)
        Me.Invoke(Sub() RichTextBox7.ScrollToCaret())
        Me.Invoke(Sub() ToolStripStatusLabel1.Text = "Terminou de executar todos processos em: " & tCronometro)
        Me.Invoke(Sub() Button21.Enabled = True)

    End Sub

    Private Sub escalonarProcessos_SJF_P()
        Throw New NotImplementedException()
    End Sub

    Private Sub escalonarProcessos_Prioridade()
        Throw New NotImplementedException()
    End Sub

    Private Sub escalonarProcessos_RR()
        Throw New NotImplementedException()
    End Sub

    Private Sub escalonarProcessos_Loteria()
        Throw New NotImplementedException()
    End Sub


End Class
