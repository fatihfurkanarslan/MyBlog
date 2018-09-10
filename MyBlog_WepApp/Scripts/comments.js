

function DoComment(btn, e, commentId, commentTextId, noteid) {

    var button = $(btn);
    var mode = button.data('edit-mode');


    if (e === 'editted') {
        if (!mode) {
            button.data('edit-mode', true);
            button.removeClass('btn-warning');
            button.addClass('btn-success');

            var btnSpan = button.find('span');
            $(commentTextId).attr('contenteditable', true);
            btnSpan.removeClass('fa-edit');
            btnSpan.addClass('fa-check');
        }
        else {
            button.data('edit-mode', false);
            button.removeClass('btn-success');
            button.addClass('btn-warning');

            var btnSpan = button.find('span');
            $(commentTextId).attr('contenteditable', false);
            btnSpan.removeClass('fa-check');
            btnSpan.addClass('fa-edit');

            var txt = $(commentTextId).text();  

            $.ajax({
                method: "POST",
                url: "/Home/CommentUpdate/" + commentId,
                data: { text: txt }
            }).done(function (data) {
                if (data.result) {
                    //burda modelcommentbody id ile yenilenmesi gerekiyor yorumların
                    alert("basarılı");
                    $('#modal_comment_body').load("/Home/CommentList/" + noteid);
                }
                else {
                    alert("yorum güncellenemedi");
                }
            }).fail(function () {
                alert("sunucuya bağlanamadı");           
            });

        }
    }

    if (e === "deleted") {
        var dialog_res = confirm("Yorum silinsin mi?");
        if (!dialog_res) return false;

        $.ajax({
            method: "GET",
            url: "/Home/CommentDelete/" + commentId
        }).done(function (data) {

            alert("data: " + data.result);

            if (data.result) {
                // yorumlar partial tekrar yüklenir..
                $('#modal_comment_body').load("/Home/CommentList/" + noteid);
            } else {
                alert("Yorum silinemedi.");
            }

        }).fail(function () {
            alert("Sunucu ile bağlantı kurulamadı.");
        });


    }

    if (e === 'makecomment') {

        var commentText = $("#commentfield").val();

        $.ajax({
            method: "POST",
            url: "/Home/MakeComment?text=" + commentText + "&noteid=" + noteidm
        }).done(function (data) {

            alert("datamız " + data.result);
            if (data.result) {
                $('#modal_comment_body').load("/Home/CommentList/" + noteid);
            } else {
                alert("Yorum Yapılamadı..");
            }
            //burda ki commenttextid aslında yukardaki onclick'ta noteid olarak gelmesi sağlandı..
     

        }).fail(function () {
            alert("Yorum Yapılamadı..");
        });

    }

}
