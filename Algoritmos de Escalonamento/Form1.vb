Imports System.Threading

Public Class Form1

    Private letras As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"

    Private Sub gerarAleatorio(richTextBox As RichTextBox)
        Try
            Me.Invoke(Sub() TabControl2.Enabled = False)
            Me.Invoke(Sub() Button21.Enabled = False)

            Dim r As New Random
            Dim processos As New List(Of Processo)

            Dim cnt1 As Integer
            Dim cnt2 As Integer
            Dim cnt3 As Integer

            Dim qntProcs As Integer = 100 + r.Next(500)

            For index = 1 To qntProcs

                If cnt3 = 9 Then
                    cnt2 += 1
                    cnt3 = 0
                Else cnt3 += 1
                End If

                If cnt2 = 26 Then
                    cnt2 = 0
                    cnt1 += 1
                End If

                ' Maximo permitido é 26*26*9 = 6.084
                If cnt1 = 26 Then : MsgBox("Atingiu o maximo de processos.") : Return : End If
                Dim p As New Processo

                p.nome = letras.Substring(cnt1, 1) + letras.Substring(cnt2, 1) + cnt3.ToString

                If processos.Count > 0 Then
                    p.tempoChegada = processos.Item(processos.Count - 1).tempoChegada + r.Next(100)
                    p.tempoProcessamento = 1 + r.Next(100)
                Else
                    p.tempoChegada = r.Next(100)
                    p.tempoProcessamento = 1 + r.Next(100)
                End If
                p.prioridade = r.Next(3)

                processos.Add(p)

            Next

            Dim contTempProcessamento As Integer

            Me.Invoke(Sub() richTextBox.Text = "")
            Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = 0)
            Dim porc As Double = 100 / processos.Count
            Dim porcTotal As Double = 0

            Dim texto As String

            For Each p In processos
                texto &= p.nome & " - " & p.tempoChegada & " - " & p.tempoProcessamento & " - " & p.prioridade & vbNewLine
                contTempProcessamento += p.tempoProcessamento
                Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = porcTotal)
                porcTotal += porc
            Next

            Me.Invoke(Sub() richTextBox.Text = texto)
            Me.Invoke(Sub() Me.ToolStripStatusLabel1.Text = "Gerou & " & processos.Count & " processos.")
            Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = 100)

        Catch ex As Exception
            Me.Invoke(Sub() Me.ToolStripStatusLabel1.Text = "Erro ao gerar processos. " & ex.Message)
            Me.Invoke(Sub() Me.ToolStripProgressBar1.Value = 0)
        End Try

        Me.Invoke(Sub() TabControl2.Enabled = True)
        Me.Invoke(Sub() Button21.Enabled = True)

    End Sub

    '' Fila 1: Gerar Processos 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim tr1 As New Thread(AddressOf gerarAleatorio)
        tr1.Start(RichTextBox2)

        Me.ToolStripStatusLabel1.Text = "Gerando processos para Fila 1..."

    End Sub

    '' Fila 2: Gerar Processos 
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim tr2 As New Thread(AddressOf gerarAleatorio)
        tr2.Start(RichTextBox3)

        Me.ToolStripStatusLabel1.Text = "Gerando processos para Fila 2..."

    End Sub

    '' Fila 3: Gerar Processos 


    '' Fila 4: Gerar Processos 


    '' Fila 5: Gerar Processos 


End Class
