const uri = 'api/Restaurants';
let restaurants = [];

function getRestaurants() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayRestaurants(data))
        .catch(error => console.error('Unable to get restaurants.', error));
}

function addRestaurant() {
    const addNameTextbox = document.getElementById('add-name');
    const addCityTextbox = document.getElementById('add-city');
    const addInfoTextbox = document.getElementById('add-info');

    const restaurant = {
        name: addNameTextbox.value.trim(),
        city: addCityTextbox.value.trim(),
        info: addInfoTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(restaurant)
    })
        .then(response => response.json())
        .then(() => {
            getRestaurants();
            addNameTextbox.value = '';
            addCityTextbox.value = '';
            addInfoTextbox.value = '';
        })
        .catch(error => console.error('Unable to add restaurant.', error));
}

function deleteRestaurant(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getRestaurants())
        .catch(error => console.error('Unable to delete restaurant.', error));
}

function displayEditForm(id) {
    const restaurant = restaurants.find(restaurant => restaurant.id === id);

    document.getElementById('edit-id').value = restaurant.id;
    document.getElementById('edit-name').value = restaurant.name;
    document.getElementById('edit-city').value = restaurant.city;
    document.getElementById('edit-info').value = restaurant.info;
    document.getElementById('editForm').style.display = 'block';
}

function updateRestaurant() {
    const restaurantId = document.getElementById('edit-id').value;
    const restaurant = {
        id: parseInt(restaurantId, 10),
        name: document.getElementById('edit-name').value.trim(),
        city: document.getElementById('edit-city').value.trim(),
        info: document.getElementById('edit-info').value.trim()
    };

    fetch(`${uri}/${restaurantId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(restaurant)
    })
        .then(() => getRestaurants())
        .catch(error => console.error('Unable to update restaurant.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayRestaurants(data) {
    const tBody = document.getElementById('restaurants');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(restaurant => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${ restaurant.id })`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteRestaurant(${ restaurant.id })`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(restaurant.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeCity = document.createTextNode(restaurant.city);
        td2.appendChild(textNodeCity);
        
        let td3 = tr.insertCell(2);
        let textNodeInfo = document.createTextNode(restaurant.info);
        td3.appendChild(textNodeInfo);
        
        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    restaurants = data;
}
