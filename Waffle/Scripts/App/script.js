///Previews an uploaded class cover art
function readUrl(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#imgpreview").attr("src", e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

function ajaxFailed(id,title) {
    $(id).addClass("text-danger").html("Sorry, an error occurred and " + title + " request cannot be processed. Please try again");
}

function ajaxSuccess(id, title) {
    $(id).addClass("text-success").html(title + " request has been completed successfully");
}

///shows the hidden cover art dummy image placeholder.....
///reconsider using a dummy image throughout
$("#fileupload").change(function () {
    $("#imgpreview").removeAttr("style");
    readUrl(this);
})



///Class playlist addition ajax success function
//function success() {
//    $("#topicOrder").val = "";
//    $("#topicTitle").val = "";
//    $("#status").addClass("text-success").html("Topic has been successfully added to list");
//    $("#statustoast").toast("show");
//    //replace above with a toast popover

//}



///Class playlist addition ajax failure function
//function failed() {
//    $("#status").addClass("text-danger").html("Sorry, an error occurred. Please try again!");
//}



$("#document").ready(function () {

    //dropzone function
    //Dropzone.options.dropzoneForm = {

    //    //prevents Dropzone from uploading dropped files immediately
    //    autoProcessQueue: false,
    //    paramName: "Uploads",
    //    maxFilesize: 20, //MB
    //    maxFiles: 1,
    //    dictDefaultMessage: "Drop your resource file here to upload (one at a time)",
    //    init: function () {
    //        var submitButton = $("#submitResources");
    //        var myDropzone = this; //closure

    //        submitButton.on("click", function () {
    //            //tell Dropzone to process all queued files
    //            myDropzone.processQueue();
    //        });
    //    }
    //};

})

