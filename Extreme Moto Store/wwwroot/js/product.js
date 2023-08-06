$(document).ready(function () {
    $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Product",
            "type": "GET",
            "datatype": "json"
        },

        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "itemType.name", "width": "15%" },
            {
                //*Note: It is important to clear catch while using anchor tag with ajax call, Sometimes it will route you to somewhere doesn't exist

                "data": "id",
                "render": function (data) {                  
                    return `<div class="w-75 btn-group" >
                            <a href="/Admin/Products/Upsert?id=${data}"  class="btn btn-success text-white mx-2">
                            <i class="bi bi-pencil-square"></i>  </a>
                            <a href="/Admin/Products/Upsert?id=${data}"  class="btn btn-danger text-white mx-2">
                            <i class="bi bi-trash3"></i>  </a>
                            </div>`
                },

                "width": "15%"
            }
        ],
        "width": "100%"
    });
});