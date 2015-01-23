var pageRatingMaxCommentLength = 500;

$(document).ready(function()
{
    // Bind events to buttons
    $("#btnPageRatingYes,#btnPageRatingNo,#btnPageRatingDontKnow").bind("click", pageRating_MoveToStep2);

    $("#btnPageRatingBack").bind("click", function()
    {
        $("#divPageRatingWidgetStep1").css("display", "block");
        $("#divPageRatingWidgetStep2").css("display", "none");
        $("#divPageRatingWidgetStep3").css("display", "none");
    });

    $("#btnPageRatingSubmit").bind("click", pageRating_Submit);

    $("#taPageRatingComments").val("");

    $("#taPageRatingComments")
        .bind("keyup", pageRating_CheckMaxLength)
        .bind("keydown", pageRating_CheckMaxLength)
        .bind("change", pageRating_CheckMaxLength)
        .bind("blur", pageRating_CheckMaxLength);

});

function pageRating_MoveToStep2()
{
    $("#spnPageRatingYesMessage").css("display", "none");
    $("#spnPageRatingNoMessage").css("display", "none");
    $("#spnPageRatingDNMessage").css("display", "none");

    var choiceData;
    switch (this.id)
    {
        case "btnPageRatingYes":
            $("#spnPageRatingYesMessage").css("display", "block");
            choiceData = "Yes";
            break;
        case "btnPageRatingNo":
            $("#spnPageRatingNoMessage").css("display", "block");
            choiceData = "No";
            break;
        case "btnPageRatingDontKnow":
            $("#spnPageRatingDNMessage").css("display", "block");
            choiceData = "Dont\\' Know";
            break;
    }


    var pageTitle = $("title").html().replace(/'/g, "\\'");
    pageTitle = pageTitle.replace(/\n/g, "");
    pageTitle = pageTitle.replace(/\r/g, "");
    pageTitle = pageTitle.replace(/\t/g, "");

    var jsonData = "{choice: '" + choiceData + "'," +
                    "url: '" + document.location + "'," +
                    "title: '" + pageTitle + "'" +
                    "}";

    $.ajax(
    {
        type: "POST",
        url: "/WebService/NsccService.asmx/SubmitPageRating",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            //console.log(msg);
            $("#hfPageRatingId").val(msg.d.id);
            //alert("Posted");
        },
        error: function(XMLHttpRequest, textStatus, errorThrown)
        {
            // typically only one of textStatus or errorThrown will have info
            this; // the options for this ajax request

            alert(errorThrown + " -- " + textStatus);
        }
    });

    // Call Google Analytics
    var pageTracker = _gat._getTracker("UA-2332805-3");
    pageTracker._initData();
    var googleResult = pageTracker._trackEvent("Page Rating", "Rated Page", document.location);


    $("#divPageRatingWidgetStep1").css("display", "none");
    $("#divPageRatingWidgetStep2").css("display", "block");
    $("#divPageRatingWidgetStep3").css("display", "none");

    return false;
}

function pageRating_Submit()
{

    var jsonData = "{id: " + [parseInt($("#hfPageRatingId").val())] + "," +
                    "comments: '" + $("#taPageRatingComments").val().replace(/'/g, "\\'") + "'" +
                    "}";
    $.ajax(
    {
        type: "POST",
        url: "/WebService/NsccService.asmx/UpdatePageRating",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(msg)
        {
            //alert("Posted");
        },
        error: function(XMLHttpRequest, textStatus, errorThrown)
        {
            // typically only one of textStatus or errorThrown will have info
            this; // the options for this ajax request

            alert(errorThrown + " -- " + textStatus);
        }
    });


    $("#divPageRatingWidgetStep1").css("display", "none");
    $("#divPageRatingWidgetStep2").css("display", "none");
    $("#divPageRatingWidgetStep3").css("display", "block");

    return false;
}

function pageRating_CheckMaxLength()
{    
    if ($("#taPageRatingComments").val().length > pageRatingMaxCommentLength)
    {
        $("#taPageRatingComments").val($("#taPageRatingComments").val().substring(0, pageRatingMaxCommentLength));
    }

    var charsLeft = (pageRatingMaxCommentLength - $("#taPageRatingComments").val().length);
    $("#spnPageRatingCharsLeft").html(charsLeft);
}
