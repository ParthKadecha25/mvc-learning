(function (m, $, undefined) {

    var globalDeleteOpportunityUrl = "";

    m.Init = function (deleteOpportunityUrl) {
        globalDeleteOpportunityUrl = deleteOpportunityUrl;
    }

    // After "Delete Opportunity" operation
    $("#confirm-delete").on("hide.bs.modal", function (e) {
        $("#btnLoader").hide();
        $(this).find(".jsBtnDelete").removeAttr("data-confirmedid");
    });

    // Asking for confirmation to delete the opportunity
    $(document).on("click", ".jsConfirmDeleteOpportunity", function (e) {
        var opportunityId = $(this).attr("id");
        $("#btnDeleteOpportunity").attr("data-confirmedid", opportunityId);
        $("#btnDeleteOpportunity").show();
        $("#btnCancel").show();
        $("#btnLoader").hide();
        $("#confirm-delete").modal("show");
    });

    // On Deleting the opportunity
    // Calling the controller method for deleting the opportunity
    $(document).on("click", "#btnDeleteOpportunity", function (e) {
        var $this = $(this);
        $this.hide();
        $("#btnCancel").hide();
        $("#btnLoader").show();

        var confirmedId = $this.attr("data-confirmedid");
        var args = JSON.stringify({ "opportunityId": confirmedId });

        $.ajax({
            cache: false,
            contentType: "application/json;charset=utf-8",
            type: "POST",
            dataType: "JSON",
            url: globalDeleteOpportunityUrl,
            data: args,
            success: function (data) {
                $("#confirm-delete").modal("hide");
                if (data.IsDeleted) {
                    $("#opportunity_" + confirmedId).remove();
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