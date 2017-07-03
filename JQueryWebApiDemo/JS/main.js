(function () {
    $(document).ready(function () {
             

        var fetchedData; // Fetched tasks
        
        

        $.when(
            $.ajax({
                url: '/api/tasks',
                type: 'GET',
                dataType: 'json'
            }),
          $.ajax({
              url: '/api/users',
              type: 'GET',
              dataType: 'json'
          })).done(function (r1, r2) {
              console.log(r1);
              console.log(r2);
              r1[0].userName;
              for (i = 0; i < r1[0].length; i++) {
                  for (j = 0; j < r2[0].length; j++) {
                      if (r1[0][i].creatorId === r2[0][j].id) {
                         r1[0][i].userName = r2[0][j].name;
                          
                      }
                  }
              }
              
          }).then(querySucceeded, queryFailed);

        function querySucceeded(data) {
            console.log(data);
            displayTable(data);

            
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

        function displayTable(param) {

            //var length = Object.keys(param).length;

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
            var titleuseridtext = document.createTextNode('Creator Name');
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
                
                    var row = document.createElement("tr");

                    var cell = document.createElement("td");
                    var cellText = document.createTextNode(param[0][i].id);
                    cell.appendChild(cellText);
                    row.appendChild(cell);

                    var cell1 = document.createElement("td");
                    var cellText1 = document.createTextNode(param[0][i].userName);
                    cell1.appendChild(cellText1);
                    row.appendChild(cell1);
                    

                    var cell2 = document.createElement("td");
                    var cellText2 = document.createTextNode(param[0][i].name);
                    cell2.appendChild(cellText2);
                    row.appendChild(cell2);

                    var cell3 = document.createElement("td");
                    var cellText3 = document.createTextNode(param[0][i].description);
                    cell3.appendChild(cellText3);
                    row.appendChild(cell3);

                    var cell4 = document.createElement("td");
                    var cellText4 = document.createTextNode(param[0][i].done);
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

    });

})();