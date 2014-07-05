
$(document).ready(function () {
    $('#h1').hide();
    $('.category-btn').click(function (e) {
        $('#h1').show();
        //var value = $("#catName").val();
        var value = e.target.value;
        $("#tbl1 tr:gt(0)").remove();
        //$.getJSON('/Ad/search?title=' + $('#t1').val() + '& price=' + $('#p1').val(),
        $.getJSON('/Ad/getAds?catName=' + value,
           function (data) {
               $.each(data, function (i, item) {
                  // $("#tbl1").append('<tr><td><img src="' + item.image + '"></td><td>' + item.title + '</td><td>' + item.price + '</td><td><button name="' + item.title + '" type="submit" value="' + item.Id + '"id="b">View</button></td></tr>');
                   //alert(data);
                   $("#tbl1").append('<tr><td><img src="' + item.image + '"></td><td>' + item.title + '</td><td>' + item.price + '</td><td><a href = "/Ad/ViewAd?info='+item.title+'">Details</td></tr>');
                   
               });
           });

    });
});
