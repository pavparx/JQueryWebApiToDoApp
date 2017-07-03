(function () {



    $(document).ready(function () {

        var tasks = {
            url: '/api/tasks',
            type: 'GET',
            dataType: 'json'
        };

        var users = {
            url: '/api/users',
            type: 'GET',
            dataType: 'json'
        };

        var fetchedData; // Fetched tasks
        var fetchedUsers; // Fetched users

        function getTasks() {
            $.ajax(tasks).then(querySucceeded).fail(queryFailed);
        }

        function getUsers() {
            $.ajax(users).then(querySucceeded2).fail(queryFailed);
        }

        function querySucceeded2(data) {
            fetchedUsers = data;
        }

        function querySucceeded(data) {
            fetchedData = data;
        }

        function queryFailed(jqXHR, textStatus) {
            var msg = 'Error retreiving data. ' + jqXHR + " " + textStatus;
            console.log(msg);
        }



        $("#filterTasks").keyup(function () {
            var keyword = $(this).val();
            console.log(keyword);
            var tempArray = new Array();

            for (item in fetchedData) {
                if ((fetchedData[item].name.indexOf(keyword) !== -1) || (fetchedData[item].description.indexOf(keyword) !== -1)) {
                    tempArray.push(fetchedData[item]);
                }

                displayTable(tempArray);
            }
        });






        function displayTable(param, param2) {

            var length = Object.keys(param).length;

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

            var titleuserid = document.createElement("td");
            var titleuseridtext = document.createTextNode('User ID');
            titleuserid.appendChild(titleuseridtext);
            titlerow.appendChild(titleuserid);

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
            for (var i = 0; i < param.length; i++) {
                for (var j = 0; j < param2.length; j++) {
                    var row = document.createElement("tr");

                    var cell = document.createElement("td");
                    var cellText = document.createTextNode(param[i].id);
                    cell.appendChild(cellText);
                    row.appendChild(cell);

                    var cell1 = document.createElement("td");
                    var cellText1
                    if (param[i].creatorId === param2[j].id) {
                        
                        cellText1 = document.createTextNode(param2[j].name);
                        cell1.appendChild(cellText1);
                        row.appendChild(cell1);
                    } else {
                        cellText1 = document.createTextNode("User Unknown");
                        cell1.appendChild(cellText1);
                        row.appendChild(cell1);
                    }

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

                    tbl.appendChild(tblBody);

                    var results = jQuery('#results');
                    results.empty();
                    results.append(tbl);

                    tbl.setAttribute("border", "2");


                }
            }
        }

        getTasks();
        getUsers();
        displayTable(fetchedData, fetchedUsers);


    });

})();