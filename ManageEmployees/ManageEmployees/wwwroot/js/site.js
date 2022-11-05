// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#table_id').DataTable();
});

$(document).on('click', '.btnDel', function () {
    let empId = $(this).attr("data-id");
    var row = $(this).closest("tr");
    $("#empNameDel").text(row.find("td:nth-child(1)").text());
    $("#btnConfirmDel").attr("data-id", empId);
    $("#btnConfirmDel").on('click', function () {
        $.ajax({
            type: "Delete",
            url: '/Employees/Delete',
            data: {
                id: empId
            },
            success: function (response) {
                row.remove();
                $(".noti").addClass("alert-success").text(response).show().delay(5000).fadeOut(2000);
            }
        });
    })
})

$("#frmCreate").submit(function (e) {
    e.preventDefault();
    var Name = $("#inputName").val();
    var Email = $("#inputEmail").val();
    var Phone = $("#inputPhone").val();
    var Address = $("#inputAddress").val();
    var formData = {
        Name: Name,
        Email: Email,
        Phone: Phone,
        Address: Address,
    };
    $.ajax({
        type: "POST",
        url: '/Employees/Create',
        data: formData,
        success: function (response) {
            var html = "<tr><td>" + Name + "</td><td>" + Email + "</td><td>" + Address + "</td><td>" + Phone + "</td>\
                <td><button type=\"button\" class=\"btn btn-outline-danger btnDel\" data-toggle=\"modal\" data-target=\"#modalDelete\"\
                data-id="+ response + "><i class=\"bi bi-trash2-fill\"></i></button></td></tr>";
            if (response == "00") {
                $(".noti").addClass("alert-danger").text("Check Fields").show().delay(5000).fadeOut(2000);
            } else {
                if (response == "0") {
                    $(".noti").addClass("alert-danger").text("Email or Phone already exists").show().delay(5000).fadeOut(2000);
                } else {
                    $("#tbodyEmp").prepend(html);
                    $(".noti").addClass("alert-success").text("Create Success").show().delay(5000).fadeOut(2000);
                }
            }
        }
    });
});