
//LoadData();
document.onload = function(){
        LoadDataSample();
}
function LoadDataSample() {
    //$("#tblStudent tbody tr").remove();
    $.ajax({
        type: 'GET',
        url: '@Url.Action("JsonSample")',
        dataType: 'json',
        //data: { id: '' },
        success: function (strSample) {
            let items = '';
            let main = document.querySelector("#main");
            //$.each(data, function (i, item) {
                let rows =
                    "<div>\
                        <label>\
                            Sample Label\
                        </label>\
                        <div id='strSample' name='strSample'>\
                            ${strSample}\
                        </div>\
                    </div>";
                main.appendChild(rows);
            //});
        },
        error: function (ex) {
            //var r = jQuery.parseJSON(response.responseText);
            //alert("Message: " + r.Message);
            //alert("StackTrace: " + r.StackTrace);
            //alert("ExceptionType: " + r.ExceptionType);
            console.log("error");
        }
    });
    return false;
}
