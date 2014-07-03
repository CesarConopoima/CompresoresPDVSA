Public Class TablaBD

    Private Sub CompresorBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CompresorBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CompresorBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CompresoresDataSet1)

    End Sub

    Private Sub TablaBD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CompresoresDataSet1.Compresor' table. You can move, or remove it, as needed.
        Me.CompresorTableAdapter.Fill(Me.CompresoresDataSet1.Compresor)

    End Sub
End Class