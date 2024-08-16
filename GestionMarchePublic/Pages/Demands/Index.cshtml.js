$(function (){
    var l = abp.localization.getResource('GestionMarchePublic');

    var createModal = new abp.ModalManager(abp.appPath + 'Demands/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Demands/EditModal');
    
    var service = gestionMarchePublic.services.demand;

    var dataTable = $('#DemandsTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                title: l('Title'),
                data: "title",
            },
            { 
                title: l('Description'),
                data: "description" 
            },
            { 
                title: l('Amount'),
                data: "amount" 
            },
            { 
                title: l('Status'),
                data: "status" 
            },
            { 
                title: l('SubmissionDate'),
                data: "submissionDate",
                render: function (data) {
                    return luxon
                        .DateTime
                        .fromISO(data, {
                            locale: abp.localization.currentCulture.name
                        }).toLocaleString();
                }
            },
            {
                title: l('Actions'),
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                action: function (data) {
                                }
                            },
                            {
                                text: l('Validate'),
                                action: function (data) {
                                }
                            },
                            {
                                text: l('Reject'),
                                action: function (data) {
                                }
                            },
                            {
                                text: l('Delete'),
                                confirmMessage: function (data) {
                                    return "Are you sure to delete the book " + data.record.name;
                                },
                                action: function (data) {
                                    service
                                        .delete(data.record.id)
                                        .then(function() {
                                            abp.notify.info("Successfully deleted!");
                                            data.table.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewDemandButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
})