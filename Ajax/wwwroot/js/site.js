// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#button").click(function clickFunc() {
    let author = document.getElementById("nameInput").value;
    console.log(author); $.ajax({
        url: '/Home/BookSearch', method: 'get',
        dataType: 'html', data: { author: author },
        success: function (data) {
            document.getElementById("searchresults")
            resultdiv.innerHTML = data;
        }
    });
});