// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function vote(uniquity, movieId, rate) {

    $.get("https://localhost:44382/Movie/Vote?movieId=" + movieId + "&rate=" + rate, function (data) {
        
        $("#" + uniquity).html(data);
        alert("Your vote has been saved");
    });
}