(function () {
    $(document).ready(function () {

        var tasks = {
            url: '/api/tasks',
            type: 'GET',
            dataType: 'json'
        };

        // TODO: do this on load    

        function getTasks() {
            $.ajax(tasks).then(querySucceeded).fail(queryFailed);
        }

        function querySucceeded(data) {
            displayTable(data);
            console.log(data[0].Description);
        }

        function displayTable(param) {

            var length = Object.keys(param).length;

            // get the reference for the body
            var body = document.getElementsByTagName("body")[0];
            //var body = jQuery('body').first(); 


            // creates a <table> element and a <tbody> element
            var tbl = document.createElement("table");
            //var tbl = jQuery('<table />');


            var tblBody = document.createElement("tbody");
            //var tblBody = jQuery('<tbody />');

            var titlerow = document.createElement("tr");
            var titleid = document.createElement("td");
            var titleidtext = document.createTextNode('ID');
            titleid.appendChild(titleidtext);
            titlerow.appendChild(titleid);

            var titlename = document.createElement("td");
            var titlenametext = document.createTextNode('Name');
            titlename.appendChild(titlenametext);
            titlerow.appendChild(titlename);

            var titledescription = document.createElement("td");
            var titledescriptiontext = document.createTextNode('Description');
            titledescription.appendChild(titledescriptiontext);
            titlerow.appendChild(titledescription);

            var titledone = document.createElement("td");
            var titledonetext = document.createTextNode('Completed');
            titledone.appendChild(titledonetext);
            titlerow.appendChild(titledone);

            tblBody.appendChild(titlerow);

            // creating all cells
            for (var i = 0; i < param.length;i++) {
                var row = document.createElement("tr");
                var cell = document.createElement("td");
                var cellText = document.createTextNode(param[i].id);
                cell.appendChild(cellText);
                row.appendChild(cell);

                var cell2 = document.createElement("td");
                var cellText2 = document.createTextNode(param[i].name);
                cell2.appendChild(cellText2);
                row.appendChild(cell2);

                var cell3 = document.createElement("td");
                var cellText3 = document.createTextNode(param[i].description);
                cell3.appendChild(cellText3);
                row.appendChild(cell3);

                var cell4 = document.createElement("td");
                var cellText4 = document.createTextNode(param[i].done);
                cell4.appendChild(cellText4);
                row.appendChild(cell4);


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

        getTasks();
    });
})();