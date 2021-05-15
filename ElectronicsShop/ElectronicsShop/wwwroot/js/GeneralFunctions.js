let General = {

    sendAjax: (url, callBack ,data,method,contentType) => {
        method = method || "GET";
        contentType = (contentType == false) ? false : undefined;
        $.ajax({
            type: method,
            url: url,
            data: data,
            contentType: contentType,
            processData: !(contentType == false),
            async: true,
            success: (res) => {
                callBack(res);
            },
            error: (error) => {
                Swal.fire({ icon: 'error', title: 'Error!', text: error.responseText })
                console.log(error.responseText);
            }
        });
    },

    createElement: (initObj)=> {
        var element = document.createElement(initObj.Tag);
        for (var prop in initObj) {
            if (prop === "childNodes") {
                initObj.childNodes.forEach(function (node) { element.appendChild(node); });
            }
            else if (prop === "attributes") {
                initObj.attributes.forEach(function (attr) { element.setAttribute(attr.key, attr.value) });
            }
            else element[prop] = initObj[prop];
        }
        return element;
    },

    emptyNode: (node)=> {
        while (node.firstChild) { node.removeChild(node.firstChild); }
    },

    emptyNodeById: (id) => {
        General.emptyNode(document.getElementById(id));
    },

    emptyInputById: (id)=> {
        document.getElementById(id).value = "";
    },

    showGridError:(args) => {
        let err = (args.error) ? Array.isArray(args.error) ? args.error[0].error.responseText : args.error.message : args[0].error.responseText;
        Swal.fire({ icon: 'error', title: 'Error!', text: err })
    },

    convertDate: (inputFormat) => {
        if (inputFormat == "Thu Jan 01 1970 02:00:00 GMT+0200 (Eastern European Standard Time)") return "";
        function pad(s) { return (s < 10) ? '0' + s : s; }
        var d = new Date(inputFormat);
        return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
    }
}