function receiveTraceTransactionCallback(traceTransactionId) {
    ReceiveGridView.PerformCallback({ traceTransactionId: traceTransactionId });
}


function TraceDocumentIdValueChanged(s, e) {
    cbpAddEditTransmit.PerformCallback({ traceTransactionId: s.GetValue() });
}

$(document).ready(function () {

    var tour = new Tour({
        steps: [
            {
                element: ".login-box-body",
                title: "Login",
                content: "Enter your UserName and Password provided by the administrator"
            },
            {
                element: ".login-box-body .btn",
                title: "Logging In",
                content: "Click the Submit Button to login"

            },
            {
                element: "#li-trace-document",
                title: "Creating Barcode",
                content: "Click on the Document Link"
            },
            {
                element: "#TraceDocumentGridView #TraceDocumentGridView_DXCBtn0",
                title: "Creating New Barcode",
                content: "Click on New then fill up the form and click the Update button to Create Barcode"
            },
            {
                element: "#TraceDocumentGridView #TraceDocumentGridView_DXCBtn0",
                title: "Print Barcode",
                content: "Click on Print to show the print Dialog Box then click on print icon on the dialog box"
            },
            {
                element: "#li-transmit",
                title: "Transmit Document",
                content: "Click on the Transmit Link"
            },
            {
                element: "#TransmitGridView_DXCBtn0",
                title: "Transmit Document",
                content: "Click on New then click on Trace Document Combo box and Scan the document barcode and Select the Receiving Department and Click Update to Transmit"
            },
            {
                element: "#li-receive",
                title: "Receive Document",
                content: "Click on the Receive Link and Click on Receive Button to Receive the Documents"
            }
        ]
    });

    // Initialize the tour
    tour.init();

    // Start the tour
    tour.start();

});

