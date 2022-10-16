$(function () {
    var $headerForm = $("#invoiceMasterDetails");
    if ($headerForm.length) {
        $headerForm.validate({

            rules: {
                InvoiceSerial: {
                    minlength: 11,
                    required: true,
                    maxlength: 20
                },
                Date: {
                    required: true,
                },
                CustomerId: {
                    required: true
                },
                productSelect: {
                    required: true
                },
                Quantity: {
                    required: true
                },
                prdtPriceInput: {
                    required: true
                }
            },
            messages: {

                InvoiceSerial: {
                    required: "Searial Error",
                    minlength: "Enter valid name from 11-20 char in length",
                    maxlength: "not valid"
                },
                Date: {
                    required: "Please select date"
                },

                CustomerId: {
                    required: "Select Customer"
                },
                productSelect: {
                    required: "Select Product"
                },
                Quantity: {
                    required: "Enter Quantity"
                },
                prdtPriceInput: {
                    required: "Enter Price"

                }

            }, submitHandler: function (form) {
                form.submit();
            }

        })
    }
});




































   