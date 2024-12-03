var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})

var popoverTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="popover"]'))
var popoverList = popoverTriggerList.map(function (popoverTriggerEl) {
    return new bootstrap.Popover(popoverTriggerEl)
})

ko.bindingHandlers.Timestamp = {
    init: function (element, valueAccessor) {
        const In = valueAccessor();
        var value = ko.unwrap(In);
        setInterval(() => { $(element).text(moment(value).fromNow()); }, 1000 * 1);
    }
}

ko.bindingHandlers.GPS = {
    init: function (element, valueAccessor, allBindings) {
        const options = valueAccessor();
        var enableMessage = allBindings.get('ShowGPSMessage') || false;
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition((p) => {
                var coord = p.coords;
                if (ko.isObservable(options.Latitude)) {
                    options.Latitude(coord.latitude);
                }
                if (ko.isObservable(options.Longitude)) {
                    options.Longitude(coord.longitude);
                }
                if (enableMessage) {
                    $(element).addClass('text-muted user-select-none text-center').text(`Your location: ${coord.latitude},${coord.longitude}`);
                }
            });
            if (enableMessage) {
                $(element).addClass('text-warning user-select-none text-center').text(`Please enable your device location`);
            }
        }

    }
}

ko.bindingHandlers.dateFormat = {
    init: function (element, valueAccessor, allBindings) {
        var format = ko.unwrap(valueAccessor());
        var date = allBindings.get('text');
        if (date) {
            $(element).text(moment(date).format(format));
        } else {
            $(element).text('Invalid Date');
        }
    }
}


ko.bindingHandlers.daterangepicker = {
    init: function (element, valueAccessor, allBindings) {
        const options = valueAccessor();
        var HourDuration = allBindings.get('HourDuration') || 8;
        var Format = allBindings.get('Format') || 'M/DD hh:mm A';
        //Startup value
        if (ko.isObservable(options.startDate)) {
            options.startDate(moment().startOf('hour').format('YYYY-MM-DD hh:mm a'));
        }
        if (ko.isObservable(options.endDate)) {
            options.endDate(moment().startOf('hour').add(HourDuration, 'hour').format('YYYY-MM-DD hh:mm a'));
        }
        // Initialize the daterangepicker
        $(element).daterangepicker({
            timePicker: true,
            startDate: moment().startOf('hour'),
            endDate: moment().startOf('hour').add(HourDuration, 'hour'),
            locale: {
                format: Format
            }
        }, function (start, end) {
            // Update observables on date selection
            if (ko.isObservable(options.startDate)) {
                options.startDate(start.format('YYYY-MM-DD hh:mm a'));
            }
            if (ko.isObservable(options.endDate)) {
                options.endDate(end.format('YYYY-MM-DD hh:mm a'));
            }
        });

        // Dispose of daterangepicker when the element is removed
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).daterangepicker('destroy');
        });
    }
};

function TextEditor(field) {
    tinymce.init({
        selector: field,
        plugins: [
        'advlist', 'autolink', 'lists', 'link', 'image', 'charmap', 'preview',
        'anchor', 'searchreplace', 'visualblocks', 'code', 'fullscreen',
        'insertdatetime', 'media', 'table', 'help', 'wordcount'
        ],
        toolbar: 'blocks | ' +
        'bold italic backcolor forecolor | alignleft aligncenter ' +
        'alignright alignjustify | bullist numlist outdent indent | ' +
        'removeformat | help image',
        image_title: true,
        automatic_uploads: true,
        file_picker_types: 'image',
        file_picker_callback: (cb, value, meta) => {
            const input = document.createElement('input');
            input.setAttribute('type', 'file');
            input.setAttribute('accept', 'image/*');
            input.addEventListener('change', (e) => {
                const file = e.target.files[0];
                if (file.size > 2097152) {
                    alert("File is too big! Must be less than or equal to 2MB only");
                    return;
                };
                const reader = new FileReader();
                reader.addEventListener('load', () => {
                    const id = 'blobid' + (new Date()).getTime();
                    const blobCache = tinymce.activeEditor.editorUpload.blobCache;
                    const base64 = reader.result.split(',')[1];
                    const blobInfo = blobCache.create(id, file, base64);
                    blobCache.add(blobInfo);
                    cb(blobInfo.blobUri(), { title: file.name });
                });
                reader.readAsDataURL(file);
            });
            input.click();
        },
        content_style: 'body { font-family:Helvetica,Arial,sans-serif; font-size:16px }',
        branding: false,
        promotion: false
    });
}


$(document).ready(function () {
    var bootstrapButton = $.fn.button.noConflict()
    $.fn.bootstrapBtn = bootstrapButton;
});

var popupCenter = (d) => {
    // Fixes dual-screen position                             Most browsers      Firefox
    const dualScreenLeft = window.screenLeft !== undefined ? window.screenLeft : window.screenX;
    const dualScreenTop = window.screenTop !== undefined ? window.screenTop : window.screenY;

    const width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
    const height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

    const systemZoom = width / window.screen.availWidth;
    const left = (width - d.w) / 2 / systemZoom + dualScreenLeft;
    const top = (height - d.h) / 2 / systemZoom + dualScreenTop;
    const _data = $.parseJSON(d.data);
    const _param = d.data || d.data != undefined ? '?' + $.param(_data) : '';
    const newWindow = window.open(d.url + _param, d.title,
      `
      scrollbars=yes,
      width=${d.w / systemZoom},
      height=${d.h / systemZoom},
      top=${top},
      left=${left}
      `
    )

    if (window.focus) newWindow.focus();
}

$(document).on('ajaxSuccess', () => {
    $('#spinner').hide();
});

$(document).on('ajaxSend', () => {
    $('#spinner').show();
});

$('body').on('shown.bs.modal', '.modal', function () {
    $(this).find('.searchbox').each(function () {
        var dropdownParent = $(document.body);
        if ($(this).parents('.modal').length !== 0)
            dropdownParent = $(this).parents('.modal');
        $(this).select2({
            width: 'style',
            dropdownParent: dropdownParent
        });
    });
});


function stateResult(d) {
    var output = { Status: d.Status, Message: d.Message, Content: d.Content };
    if (output.Status == undefined) {
        toastr.error('Session has been expired, please refresh the page.', 'Error', { "positionClass": "toast-top-center", "preventDuplicates": true });
        return null;
    }
    return output;
}

$(document).ready(function () {
    $('.searchbox').select2({ width: 'style' });
    $.each($('#sidebar-nav .nav-item .nav-link, #sidebar-nav .nav-item a'), function (i, item) {
        if ($(item).attr('href') == location.pathname.replace('/Create', '').replace(/\/Edit\/([\d]+)/, '') + location.search.replace('?Length=0', '')) {
            $(item).parent('li').parent('ul').addClass('show');
            $(item).parent('li').parent('ul').siblings('a').removeClass('collapsed');
            $(item).addClass('active');
            $(item).removeClass('collapsed');
        }
    });
});