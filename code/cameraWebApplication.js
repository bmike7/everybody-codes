let map

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
      center: { lat: 52.093421, lng: 5.118278 },
      zoom: 8,
    });
  }
  

async function getData() {
    const response = await fetch("https://localhost:5001/api/v1/cameras");
    return response.json();
}

function alterTable(tableID, tableData = []) {
    let table = document.getElementById(tableID);
    tableData.forEach((item, idx) => {
        let row = table.insertRow(2);
        let number = row.insertCell(0);
        let name = row.insertCell(1);
        let latitude = row.insertCell(2);
        let longitude = row.insertCell(3);
        number.innerHTML = idx;
        name.innerHTML = item.name;
        latitude.innerHTML = item.latitude;
        longitude.innerHTML = item.longitude;
    });
}

function showMapMarkers(cameraData = []) {
    cameraData.forEach(camera => {
        new google.maps.Marker({
            position: { 
                lat: parseFloat(camera.latitude), 
                lng: parseFloat(camera.longitude) 
            },
            map,
            title: camera.name,
        })
    })
}

// I will use the index from the item in the array that is retreived.
// Did not get number from reading out the file in the backend projects
(function() {
    const column3 = [];
    const column5 = [];
    const column15 = [];
    const columnOther = [];

    getData().then(data => {
        showMapMarkers(data)

        for (let idx = 0; idx < data.length; idx++) {
            if (idx % 15 == 0) {
                column15.push(data[idx]);
                continue;
            };
            if (idx % 5 == 0) {
                column5.push(data[idx]);
                continue;
            };
            if (idx % 3 == 0) {
                column3.push(data[idx]);
                continue;
            };
            columnOther.push(data[idx]);
        }

        alterTable("column3", column3);
        alterTable("column5", column5);
        alterTable("column15", column15);
        alterTable("columnOther", columnOther);
    });
})();
