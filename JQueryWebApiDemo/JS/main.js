(function () {

    function getTasks() {
        return $.ajax({
            url: '/api/tasks',
            type: 'GET',
            dataType: 'json'
        });
    };

    function getUsers() {
        return $.ajax({
            url: '/api/users',
            type: 'GET',
            dataType: 'json'
        });
    };

    function parseTasksResponse(tasksResponse, usersResponse) {      

        var users = {}

        for (var i = 0; i < usersResponse[0].length; i++) {
            var current = usersResponse[0][i];
            users[current.id] = current;
        }

        for (i = 0; i < tasksResponse[0].length; i++) {
            var currentTask = tasksResponse[0][i];

            if (currentTask.creatorId in users) {
                currentTask.userName = users[currentTask.creatorId].name;
            }
        }

        return tasksResponse[0];
    };

    $(document).ready(function () {

        $.when(getTasks(), getUsers())
            .then(function (tasksResponse, usersResponse) {

                querySucceeded(parseTasksResponse(tasksResponse, usersResponse));

            }, queryFailed);

        function querySucceeded(data) {

            displayTable(data);

            $("#filterTasks").keyup(function () {

                var tempArray = [];

                var keyword = $(this).val();

                for (var i = 0; i < data.length; i++) {
                    if ((data[i].name.indexOf(keyword) !== -1) || (data[i].description.indexOf(keyword) !== -1)) {
                        tempArray.push(data[i]);
                    }
                }

                displayTable(tempArray);

            });
        }

        function queryFailed(jqXHR, textStatus) {
            var msg = 'Error retreiving data. ' + jqXHR + " " + textStatus;
            console.log(msg);
        }

        function displayTable(param) {


            var $table = $("<table>");
            $table.attr("border", "1");
            var $tr = $("<tr>");
            var $td = $("<td>");
            var $tbody = $("<tbody>");
            var $thead = $("<thead>");

            $thead.append($tr.html("<td>ID</td><td>Creator Name</td><td>Name</td><td>Description</td><td>Completed</td>"));
            $table.append($thead);

            for (var i = 0; i < param.length; i++) {
                var $tr = $("<tr>");
                $tdId = $("<td>" + param[i].id + "</td>");
                $tdUserName = $("<td>" + param[i].userName + "</td>");
                $tdName = $("<td>" + param[i].name + "</td>");
                $tdUserDescription = $("<td>" + param[i].description + "</td>");
                $tdDone = $("<td>" + param[i].done + "</td>");
                $tr.append($tdId).append($tdUserName).append($tdName).append($tdUserDescription).append($tdDone);
                $tbody.append($tr);
                //append($tdUserName).append($tdName).append($tdUserDescription).append($tdDone);
            }
            $table.append($tbody);
            $('#tableDiv').append($table);
        }

        //// creating all cells
        //for (var i = 0; i < param.length; i++) {

        //        var row = document.createElement("tr");

        //        var cell = document.createElement("td");
        //        var cellText = document.createTextNode(param[i].id);
        //        cell.appendChild(cellText);
        //        row.appendChild(cell);

        //        var cell1 = document.createElement("td");
        //        var cellText1 = document.createTextNode(param[i].userName);
        //        cell1.appendChild(cellText1);
        //        row.appendChild(cell1);


        //        var cell2 = document.createElement("td");
        //        var cellText2 = document.createTextNode(param[i].name);
        //        cell2.appendChild(cellText2);
        //        row.appendChild(cell2);

        //        var cell3 = document.createElement("td");
        //        var cellText3 = document.createTextNode(param[i].description);
        //        cell3.appendChild(cellText3);
        //        row.appendChild(cell3);

        //        var cell4 = document.createElement("td");
        //        var cellText4 = document.createTextNode(param[i].done);
        //        cell4.appendChild(cellText4);
        //        row.appendChild(cell4);


        //        tblBody.appendChild(row);

        //        tbl.appendChild(tblBody);

        //        var results = jQuery('#results');
        //        results.empty();
        //        results.append(tbl);

        //        tbl.setAttribute("border", "2");





    });
    
})();