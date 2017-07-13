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

    $("#tabs").tabs();
     
        $.when(getTasks(), getUsers())
            .then(function (tasksResponse, usersResponse) {

                querySucceeded(parseTasksResponse(tasksResponse, usersResponse));

            }, queryFailed);

        function querySucceeded(data) {
            $("#tabs").tabs("option", "active", 0);
            $('#allResults').append(createTableResults(data));
            $(".loading").fadeOut();
            $(".content").fadeIn();

            $("#filterTasks").keyup(function () {
                var tempArray = [];
                var keyword = $(this).val();
                if (!keyword) { $('#filteredResults').empty(); $("#tabs").tabs("option", "active", 0); } else {
                    $("#tabs").tabs("option", "active", 1);
                    for (var i = 0; i < data.length; i++) {
                        if ((data[i].name.indexOf(keyword) !== -1) || (data[i].description.indexOf(keyword) !== -1)) {
                            tempArray.push(data[i]);
                        }
                    }
                    $('#filteredResults').empty();
                    $('#filteredResults').append(createTableResults(tempArray));
                    
                }
               
            });
        }

        function queryFailed(jqXHR, textStatus) {
            var msg = 'Error retreiving data. ' + jqXHR + " " + textStatus;
            console.log(msg);
        }

        function createTableResults(param) {

            var $table = $("<table />");
            $table.attr("border", "1");
            var $tbody = $("<tbody>");
            var $thead = $("<thead>");

            $thead.append($("<tr>").html("<td>ID</td><td>Creator Name</td><td>Name</td><td>Description</td><td>Completed</td>"));
            $table.append($thead);

            for (var i = 0; i < param.length; i++) {
                var $tr = $("<tr>");
                $("<td />").text(param[i].id).appendTo($tr);
                $("<td />").text(param[i].userName).appendTo($tr);
                $("<td />").text(param[i].name).appendTo($tr);
                $("<td />").text(param[i].description).appendTo($tr);
                $("<td />").text(param[i].done).appendTo($tr);
                $tbody.append($tr);
            }

            $table.append($tbody);
            return $table;
        }



})();