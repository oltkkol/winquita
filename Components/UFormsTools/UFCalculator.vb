Public Class UFCalculator
    Inherits DockContent
    Private Sub UFCalculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub InputChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtA.TextChanged, txtB.TextChanged
        Dim d1 As Double = ToNumber(txtA.Text)
        Dim d2 As Double = ToNumber(txtB.Text)

        txtResult.Text = StandardDeviation(New Double() {d1, d2})
    End Sub
End Class