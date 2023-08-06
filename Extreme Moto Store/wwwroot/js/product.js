var dataTable; //Creating a var so that it can call the reload when deleting
$(document).ready(function () {
    dataTable=$('#DT_load').DataTable({
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
                //Important Note: With ASP 7, It is important to clear browser catch while using anchor tag with ajax call, Sometimes it will route you to somewhere doesn't exist

                "data": "id",
                "render": function (data) {                  
                    return `<div class="w-75 btn-group" >
                            <a href="/Admin/Products/Upsert?id=${data}"  class="btn btn-success text-white mx-2">
                            <i class="bi bi-pencil-square"></i>  </a>
                            <a onClick=Delete('/api/Product/'+${data})  class="btn btn-danger text-white mx-2">
                             <i class="bi bi-trash3"></i>  </a>
                            </div>`
                },

                "width": "15%"
            }
        ],
        "width": "100%"
    });
});

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        //success notification
                        toastr.success(data.message);
                    }
                    else {
                        //failsure notification
                        toastr.error(data.message);
                    }
                }
            })
        }
    })

}