var tasks = {
    url: '/api/tasks',
    type: 'GET',
    dataType: 'json'
};

function getTasks() {
    $.ajax(tasks).then(querySucceeded).fail(queryFailed);
}

function querySucceeded(data) {
    var taskArray = [];
    for (var key in data) {
        taskArray[key] = JSON.stringify(data[key]);
        console.log("key is: " + key + " and value is: " + taskArray[key]);
    }
    displayTable(taskArray);
}

function displayTable(param) {

    var length = Object.keys(param).length;
    
        // get the reference for the body
        var body = document.getElementsByTagName("body")[0];
 
        // creates a <table> element and a <tbody> element
        var tbl = document.createElement("table");
        var tblBody = document.createElement("tbody");
 
        // creating all cells
        for (var i = 0; i < length; i++) {
            // creates a table row
            var row = document.createElement("tr");
                var cell = document.createElement("td");
                var cellText = document.createTextNode(param[i]);
                cell.appendChild(cellText);
                row.appendChild(cell);
            
                tblBody.appendChild(row);
        }
        // add the row to the end of the table body
        //tblBody.appendChild(row);
        // put the <tbody> in the <table>
        tbl.appendChild(tblBody);
        // appends <table> into <body>
        body.appendChild(tbl);
        // sets the border attribute of tbl to 2;
        tbl.setAttribute("border", "2");
    }
 

function queryFailed(jqXHR, textStatus) {
    var msg = 'Error retreiving data. ' + jqXHR + " " + textStatus;
    console.log(msg);
}