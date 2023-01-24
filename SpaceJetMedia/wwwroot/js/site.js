// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#searchButton").click(function () {
        var searchQuery = $.trim($("#searchQueryInput").val());
        $("table tbody").html("");
        $.ajax({
            type: "POST",
            url: "/Home/GetData",
            data: "\"" + searchQuery + "\"",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (users) {
                var table = $("#userTable");
                table.find("tr:not(:first)").remove();
                $.each(users, function (i, user) {
                    $("tbody").append($("<tr>"));
                    appendElement = $("tbody tr").last();
                    appendElement.append($("<td>").html(user.firstName));
                    appendElement.append($("<td>").html(user.lastName));
                    appendElement.append($("<td>").html(user.firstName + " " + user.lastName));
                    appendElement.append($("<td>").html(user.email));
                });
            },
            error: function (xhr, status, error) {
                console.log(xhr)
            }
        });
    });
});
