@Code
    ViewBag.Title = "Home Page"
End Code
<script type="text/javascript">
    function AddSelectedItems() {
        MoveSelectedItems(lbAvailable, lbChoosen);
        UpdateButtonState();
    }
    function AddAllItems() {
        MoveAllItems(lbAvailable, lbChoosen);
        UpdateButtonState();
    }
    function RemoveSelectedItems() {
        MoveSelectedItems(lbChoosen, lbAvailable);
        UpdateButtonState();
    }
    function RemoveAllItems() {
        MoveAllItems(lbChoosen, lbAvailable);
        UpdateButtonState();
    }
    function MoveSelectedItems(srcListBox, dstListBox) {
        srcListBox.BeginUpdate();
        dstListBox.BeginUpdate();
        var items = srcListBox.GetSelectedItems();
        for (var i = items.length - 1; i >= 0; i = i - 1) {
            dstListBox.AddItem(items[i].text, items[i].value);
            srcListBox.RemoveItem(items[i].index);
        }
        srcListBox.EndUpdate();
        dstListBox.EndUpdate();
    }
    function MoveAllItems(srcListBox, dstListBox) {
        srcListBox.BeginUpdate();
        var count = srcListBox.GetItemCount();
        for (var i = 0; i < count; i++) {
            var item = srcListBox.GetItem(i);
            dstListBox.AddItem(item.text, item.value);
        }
        srcListBox.EndUpdate();
        srcListBox.ClearItems();
    }
    function UpdateButtonState() {
        btnMoveAllItemsToRight.SetEnabled(lbAvailable.GetItemCount() > 0);
        btnMoveAllItemsToLeft.SetEnabled(lbChoosen.GetItemCount() > 0);
        btnMoveSelectedItemsToRight.SetEnabled(lbAvailable.GetSelectedItems().length > 0);
        btnMoveSelectedItemsToLeft.SetEnabled(lbChoosen.GetSelectedItems().length > 0);
    }
    MVCxClientGlobalEvents.AddControlsInitializedEventHandler(function (s, e) {
        UpdateButtonState();
    });
</script>
<table>
    <tr>
        <td>
            @Html.DevExpress().ListBox( _
                Sub(settings)
                        settings.Name = "lbAvailable"
                        settings.Properties.SelectionMode = ListEditSelectionMode.CheckColumn
                        settings.Properties.Items.Add("ASPxHTMLEditor Suite", "ASPxHTMLEditor")
                        settings.Properties.Items.Add("ASPxEditors Library", "ASPxEditors")
                        settings.Properties.Items.Add("ASPxperience Suite", "ASPxperience")
                        settings.Properties.Items.Add("ASPxPivotGrid Suite", "ASPxPivotGrid")
                        settings.Properties.Items.Add("XtraReports Suite", "XtraReports")
                        settings.Properties.Items.Add("XtraCharts Suite", "XtraCharts")
                        settings.Properties.ClientSideEvents.SelectedIndexChanged = "function(s, e) { UpdateButtonState(); }"
                        settings.Properties.EnableClientSideAPI = True
                        settings.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                End Sub).GetHtml()
        </td>
        <td>
            @Html.DevExpress().ListBox( _
                Sub(settings)
                        settings.Name = "lbChoosen"
                        settings.Properties.SelectionMode = ListEditSelectionMode.CheckColumn
                        settings.Properties.ClientSideEvents.SelectedIndexChanged = "function(s, e) { UpdateButtonState(); }"
                        settings.Properties.EnableClientSideAPI = True
                        settings.Width = System.Web.UI.WebControls.Unit.Pixel(200)
                End Sub).GetHtml()
        </td>
    </tr>
</table>
@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnMoveSelectedItemsToRight"
            settings.Text = "Add"
            settings.ClientSideEvents.Click = "function(s, e) { AddSelectedItems();  }"
    End Sub).GetHtml()
@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnMoveAllItemsToRight"
            settings.Text = "Add All"
            settings.ClientSideEvents.Click = "function(s, e) { AddAllItems(); }"
    End Sub).GetHtml()
@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnMoveSelectedItemsToLeft"
            settings.Text = "Remove "
            settings.ClientSideEvents.Click = "function(s, e) { RemoveSelectedItems(); }"
    End Sub).GetHtml()
@Html.DevExpress().Button( _
    Sub(settings)
            settings.Name = "btnMoveAllItemsToLeft"
            settings.Text = "Remove All"
            settings.ClientSideEvents.Click = "function(s, e) { RemoveAllItems(); }"
    End Sub).GetHtml()