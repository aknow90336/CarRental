var CarRental = CarRental || {};
CarRental.Common =
{
    AjaxErrorHandle: function (data, textStatus) {
        try {
            var text = data.responseText;
            //判斷是否為Json
            if (/^[\],:{}\s]*$/.test(text.replace(/\\["\\\/bfnrtu]/g, '@').
                replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g, ']').
                replace(/(?:^|:|,)(?:\s*\[)+/g, ''))) {
                var result = $.parseJSON(data.responseText);
                if (result.IsError) {
                    toastr.error(result.Message);
                }
            }
            else {
                document.write(data.responseText);
            }
        }
        catch (e) { }
        if (textStatus === 'timeout') {
            toastr.error("系統忙碌中");
        }
    },
    GetPartialInfo: function (route, renderTarget, data) {
        $.ajax({
            method: "POST",
            url: route,
            data: data,
            dataType: "json",
            success: function (data, textStatus, jqXHR) {
                if (!data.IsError) {
                    renderTarget.html(data.Result1);
                }
                else {
                    toastr.error(data.Message);
                }
            },
            error: this.AjaxErrorHandle,
            complete: function () {
                setTimeout(function () {
                    $("#Sidebar-wrapper").css("height", 'calc(' + $(document).height() + 'px - 5rem)')
                }, 200);
            },
        });
    },
}