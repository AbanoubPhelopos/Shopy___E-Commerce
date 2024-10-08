var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/Product/getall' },
        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'auther', "width": "20%" },
            { data: 'price', "width": "10%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'category.name', "width": "20%" },
            {
                data: 'id', // Update to 'id' for the 'Id' column
                "render": function (data) {
                    return `<div>
                         <a href="/admin/Product/Upsert?id=${data}" class="btn btn-outline-primary">
                         <i class="bi bi-pencil-square"></i> Edit
                         </a>
                         <a onclick="Delete('/admin/Product/Delete/${data}')" class="btn btn-outline-danger">
                          <i class="bi bi-trash3"></i> Delete
                         </a>
                    </div>`;
                },
                "width": "20%"
            }

        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });
}
