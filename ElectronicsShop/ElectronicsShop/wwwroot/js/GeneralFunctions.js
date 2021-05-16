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

    createNavigationButtons : (pageNum, totalPages, navBtnDivId , callBack) => {
        let navBtnsSpan = document.getElementById(navBtnDivId);
        General.emptyNode(navBtnsSpan);
        let btnStyle = "btn btn-outline-primary";
        for (var i = 1; i <= totalPages; i++) {
            navBtnsSpan.appendChild(General.createElement({
                Tag: "button",
                classList: btnStyle + ((pageNum == i) ? " active" : ""),
                innerHTML: i,
                onclick: callBack.bind(this,i)
            }))
        }
    },

    populateTypesDdl : (types, ddlContainerId) => {
        var selectionsDiv = document.getElementById(ddlContainerId);
        types.forEach(t => selectionsDiv.appendChild(
            General.createElement({ Tag: "option", value: t.ProductTypeId, classList: "dropdown-item", innerHTML: t.Name })
        ))
    }
}