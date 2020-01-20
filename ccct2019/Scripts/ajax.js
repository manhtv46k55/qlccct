//Đăng nhập
function loginAction() {
    $userName = $('#Username').val();
    $pass = $('#Password').val();
    $.ajax({
        url: "/User/LoginAction",
        data: { username: $userName, pass: $pass },
        success: function (result) {
            if (result == 1) {
                window.location = "/Home/Index";

            } else {
                alert("Kiểm tra lại thông tin đăng nhập");
            }
        }
    });
}
//Đăng xuất
function logout() {
    window.location = "/User/Logout";
}

//search nganchangiaitoa
function searchNganchangiaitoa() {
    var $Search = $("#searchncgt").val();
    $.ajax({
        url: "/NganchanGiaitoa/search",
        data: { page: 1, search: $Search },
        success: function (result) {
            $("#tblncgt").html(result);
        }
    });
}

//search nganchangiaitoaMod
function searchNganchangiaitoaMod() {
    var $Search = $("#searchncgtMod").val();
    $.ajax({
        url: "/NganchanGiaitoa/searchMod",
        data: { page: 1, search: $Search },
        success: function (result) {
            $("#tblncgtMod").html(result);
        }
    });
}
//upload file
function fileValidation() {
    var fileInput = document.getElementById('file');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.pdf|\.doc|\.docx)$/i;
    if (!allowedExtensions.exec(filePath)) {
        swal("Tệp đính kèm không hợp lệ!", "Tệp phải có định dạng: png, jpg, pdf, doc, docx", "error");
        fileInput.value = '';
        return false;
    } else {
        if (fileInput.files[0].size > 5000000) {
            swal("File đính kèm phải nhỏ hơn 5MB!", "", "error");
            $(fileInput).val('');
        }
        else {
            //Image preview
            if (fileInput.files && fileInput.files[0]) {
                //tạo đối tượng formData
                var formData = new FormData();
                //đưa data vào form
                formData.append('file', fileInput.files[0]);
                $.ajax(
                    {
                        type: 'POST',
                        url: '/NganchanGiaitoa/UploadFile',
                        contentType: false, //không có header
                        processData: false, //không xử lý dữ liệu
                        data: formData,
                        success: function (urlFile) {
                            //$('#msg').html('Đã thêm file đính kèm')
                            //$("#btnUpload").val("Sửa file đính kèm");
                            //$("#btnUpload").css("background", "orange");
                            ////$('#Filedinhkem').attr('href', urlFile);//xem file
                            //urlFile = urlFile.split('#').pop().split('?').pop();
                            //var linkf = urlFile.substring(urlFile.lastIndexOf('/') + 1);
                            //$('#Filedinhkem').val(linkf); //hiển thị đường dẫn để sau này dùng ****
                            ////swal("Đã thêm file đính kèm!", "", "success");
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                document.getElementById('imagePreview').innerHTML = '<img src="' + e.target.result + '"/>';
                            };
                            $("#msg").val(urlFile);
                            reader.readAsDataURL(fileInput.files[0]);

                        },
                        error: function (err) {
                            alert('Có lỗi khi Upload:' + err.statusText);
                        }
                    });

            }
        }
    }
}

//thay đổi file upload
function updatefileValidation() {
    var fileInput = document.getElementById('updatefile');
    var filePath = fileInput.value;
    var allowedExtensions = /(\.jpg|\.jpeg|\.png|\.pdf|\.doc|\.docx)$/i;
    if (!allowedExtensions.exec(filePath)) {
        swal("Tệp đính kèm không hợp lệ!", "Tệp phải có định dạng: png, jpg, pdf, doc, docx", "error");
        fileInput.value = '';
        return false;
    } else {
        if (fileInput.files[0].size > 5000000) {
            swal("File đính kèm phải nhỏ hơn 5MB!", "", "error");
            $(fileInput).val('');
        }
        else {
            //Image preview
            if (fileInput.files && fileInput.files[0]) {
                //tạo đối tượng formData
                var formData = new FormData();
                //đưa data vào form
                formData.append('file', fileInput.files[0]);
                $.ajax(
                    {
                        type: 'POST',
                        url: '/NganchanGiaitoa/UploadFile',
                        contentType: false, //không có header
                        processData: false, //không xử lý dữ liệu
                        data: formData,
                        success: function (urlFile) {
                            //$('#msg').html('Đã thêm file đính kèm')
                            //$("#btnUpload").val("Sửa file đính kèm");
                            //$("#btnUpload").css("background", "orange");
                            ////$('#Filedinhkem').attr('href', urlFile);//xem file
                            //urlFile = urlFile.split('#').pop().split('?').pop();
                            //var linkf = urlFile.substring(urlFile.lastIndexOf('/') + 1);
                            //$('#Filedinhkem').val(linkf); //hiển thị đường dẫn để sau này dùng ****
                            ////swal("Đã thêm file đính kèm!", "", "success");
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                document.getElementById('imagePreview').innerHTML = '<img src="' + e.target.result + '"/>';
                            };
                            $("#updatemsg").val(urlFile);
                            reader.readAsDataURL(fileInput.files[0]);

                        },
                        error: function (err) {
                            alert('Có lỗi khi Upload:' + err.statusText);
                        }
                    });

            }
        }
    }
}

//thêm ngăn chặn - giải tỏa
function addNcgt() {

    $.ajax({
        url: "/NganchanGiaitoa/Add",
        data: {
            SoGCN: $("#gcn").val(),
            noicap: $("#noicap").val(),
            ngaycap: $("#ngaycap").val(),
            hoten: $("#hoten").val(),
            diachi: $("#diachi").val(),
            thuadat: $("#thuadat").val(),
            bandoso: $("#bandoso").val(),
            diachithuadat: $("#diachithuadat").val(),
            dientich: $("#dientich").val(),
            sudungchung: $("#sudungchung").val(),
            mucdichsudung: $("#mucdichsudung").val(),
            sudungrieng: $("#sudungrieng").val(),
            thoihansudung: $("#thoihansudung").val(),
            nguongoc: $("#nguongoc").val(),
            loaivb: $("#loaivb").val(),
            sokyhieu: $("#sokyhieu").val(),
            ngayvb: $("#ngayvb").val(),
            noigui: $("#noigui").val(),
            lydo: $("#lydo").val(),
            filedinhkem: $("#msg").val(),
            UserID: $("#UserID").val()
        },
        success: function (result) {
            if (result == 1) {
                swal({
                    title: "Thông báo?",
                    text: "Thêm thành công",
                    type: "success",
                });
                searchNganchangiaitoa();
                $("#modal-themncgt").modal("hide");

            } else {
                swal({
                    title: "Thông báo?",
                    text: "Thất bại",
                    type: "error",
                });
            }
        }
    });

}

//Xem ngăn chặn giải tỏa

function btnGetXemncgtID($ncgtID) {
    $.ajax({
        url: "/NganchanGiaitoa/GetDetail",
        data: { ncgtID: $ncgtID },
        success: function (result) {
            $("#Xemncgt").html(result);
            $("#XemncgtModal").modal("show");
        }
    });

}

//Xem ngăn chặn giải tỏa

function btnGetXemncgtID($ncgtID) {
    $.ajax({
        url: "/NganchanGiaitoa/GetDetail",
        data: { ncgtID: $ncgtID },
        success: function (result) {
            $("#Xemncgt").html(result);
            $("#XemncgtModal").modal("show");
        }
    });

}

function btnGetXemncgtIDMod($ncgtID) {
    $.ajax({
        url: "/NganchanGiaitoa/GetDetailMod",
        data: { ncgtID: $ncgtID },
        success: function (result) {
            $("#XemncgtMod").html(result);
            $("#XemncgtModalMod").modal("show");
        }
    });

}

//get id ngăn chặn giải tỏa

function btnGetSuancgtID($sncgtID) {
    $.ajax({
        url: "/NganchanGiaitoa/GetUpdate",
        data: { sncgtID: $sncgtID },
        success: function (result) {
            $("#Suancgt").html(result);
            $("#SuancgtModal").modal("show");
        }
    });

}

// sửa ngăn chặn giải tỏa
function btnEditNcgt() {

    $.ajax({
        url: "/NganchanGiaitoa/Edit",
        data: {
            SoGCN: $("#updategcn").val(),
            noicap: $("#updatenoicap").val(),
            ngaycap: $("#updatengaycap").val(),
            hoten: $("#updatehoten").val(),
            diachi: $("#updatediachichusohuu").val(),
            thuadat: $("#updatethuadatso").val(),
            bandoso: $("#updatebandoso").val(),
            diachithuadat: $("#updatediachithuadat").val(),
            dientich: $("#updatedientich").val(),
            sudungchung: $("#updatesudungchung").val(),
            mucdichsudung: $("#updatemucdichsudung").val(),
            sudungrieng: $("#updatesudungrieng").val(),
            thoihansudung: $("#updatethoihansudung").val(),
            nguongoc: $("#updatenguongoc").val(),
            loaivb: $("#updateloaivb").val(),
            sokyhieu: $("#updatesokyhieu").val(),
            ngayvb: $("#updatengayvb").val(),
            noigui: $("#updatenoigui").val(),
            lydo: $("#updatelydo").val(),
            filedinhkem: $("#updatemsg").val(),
            UserID: $("#updateUserID").val(),
            NcgtID:$("#ncgtID").val()
        },
        success: function (result) {
            if (result == 1) {
                swal({
                    title: "Thông báo?",
                    text: "Sửa thành công",
                    type: "success",
                });
                searchNganchangiaitoa();
                $("#SuancgtModal").modal("hide");

            } else {
                swal({
                    title: "Thông báo?",
                    text: "Thất bại",
                    type: "error",
                });
            }
        }
    });

}

//get ID xóa ncgt
function btnGetDeletencgt($ncgtID) {
    $.ajax({
        url: "/NganchanGiaitoa/GetDelete",
        data: { ncgtID: $ncgtID },
        success: function (result) {
            $("#Xoancgt").html(result);
            $("#XoancgtModal").modal("show");
        }
    });

}

//Xóa ncgt
function btnDeletencgt($ncgtID) {
    $.ajax({
        url: "/NganchanGiaitoa/Delete",
        data: { ID: $ncgtID},
        success: function (result) {
            if (result == 1) {
                swal({
                    title: "Thông báo?",
                    text: "Xóa thành công",
                    type: "success",
                });
                searchNganchangiaitoa();
                $("#XoancgtModal").modal("hide");

            } else {
                swal({
                    title: "Thông báo?",
                    text: "Xóa thất bại",
                    type: "error",
                });
            }
        }
    });
}