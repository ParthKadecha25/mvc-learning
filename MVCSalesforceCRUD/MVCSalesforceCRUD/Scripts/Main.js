(function (m, $, undefined) {

    var globalDeleteOpportunityUrl = "";
    var globalDeleteOpportunityLineItemUrl = "";
    var itemToDelete = "";

    m.Init = function (deleteOpportunityUrl, deleteOpportunityLineItemUrl) {
        globalDeleteOpportunityUrl = deleteOpportunityUrl;
        globalDeleteOpportunityLineItemUrl = deleteOpportunityLineItemUrl;
    }

    // After "Delete" operation
    $("#confirm-delete").on("hide.bs.modal", function (e) {
        $("#btnLoader").hide();
    });

    // Asking for confirmation to delete
    $(document).on("click", ".jsConfirmDelete", function (e) {
        var itemId = $(this).attr("id");
        itemToDelete = $(this).attr("data-itemtype");
        $("#btnDelete").attr("data-confirmedid", itemId);
        $("#btnDelete").show();
        $("#btnCancel").show();
        $("#btnLoader").hide();
        $("#confirm-delete").modal("show");
    });

    // On Deleting the item
    // Calling the controller method for deleting the opportunity and line item
    $(document).on("click", "#btnDelete", function (e) {
        var $this = $(this);
        $this.hide();
        $("#btnCancel").hide();
        $("#btnLoader").show();

        var confirmedId = $this.attr("data-confirmedid");
        var args = JSON.stringify({ "itemid": confirmedId });
        var reqestURL = "";
        if (itemToDelete == "lineitem") {
            reqestURL = globalDeleteOpportunityLineItemUrl;
        }
        if (itemToDelete == "opportunity") {
            reqestURL = globalDeleteOpportunityUrl;
        }
        $.ajax({
            cache: false,
            contentType: "application/json;charset=utf-8",
            type: "POST",
            dataType: "JSON",
            url: reqestURL,
            data: args,
            success: function (data) {
                $("#confirm-delete").modal("hide");
                if (data.IsDeleted) {
                    $("#opportunity_" + confirmedId).remove();
                    $("#lineitem_" + confirmedId).remove();
                    $("#status-delete").find(".jsSuccessMsg").text(data.Details);
                    $("#status-delete").find(".jsErrorMsg").text('');
                    $("#status-delete").find("#delete-success").show();
                    $("#status-delete").find("#delete-fail").hide();
                } else {
                    $("#status-delete").find(".jsSuccessMsg").text('');
                    $("#status-delete").find(".jsErrorMsg").text(data.Details);
                    $("#status-delete").find("#delete-success").hide();
                    $("#status-delete").find("#delete-fail").show();
                }
                $("#status-delete").modal("show");
                $this.removeAttr("data-confirmedid");
                return false;
            },
            error: function (err) {
                $("#status-delete").find(".jsSuccessMsg").text('');
                $("#status-delete").find(".jsErrorMsg").text(err);
                $("#status-delete").find("#delete-success").hide();
                $("#status-delete").find("#delete-fail").show();
                $("#status-delete").modal("show");
                $this.removeAttr("data-confirmedid");
                return false;
            }
        });
    });

}(window.Main = window.Main || {}, jQuery));