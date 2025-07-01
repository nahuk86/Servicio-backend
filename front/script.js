const API_BASE = 'https://localhost:32773/api';

document.addEventListener('DOMContentLoaded', () => {
  const citySelector = document.getElementById('citySelector');
  const latitudeInput = document.getElementById('latitude');
  const longitudeInput = document.getElementById('longitude');
  const calculateBtn = document.getElementById('calculateBtn');
  const resultDiv = document.getElementById('result');

  // Cargar ciudades desde el backend
  fetch(`${API_BASE}/cities`, { mode: 'cors' })
    .then(response => {
      if (!response.ok) throw new Error(`HTTP ${response.status}`);
      return response.json();
    })
    .then(data => {
      data.forEach(city => {
        const option = document.createElement('option');
        option.value = city.id;
        option.textContent = city.name;
        citySelector.appendChild(option);
      });
    })
    .catch(error => {
      console.error('Error al cargar ciudades:', error);
      resultDiv.textContent = 'Error al cargar ciudades.';
    });

  calculateBtn.addEventListener('click', () => {
    const cityId = citySelector.value;
    const lat = parseFloat(latitudeInput.value);
    const lng = parseFloat(longitudeInput.value);
    resultDiv.textContent = '';

    if (!cityId) {
      resultDiv.textContent = 'Por favor, selecciona una ciudad.';
      return;
    }
    if (isNaN(lat) || lat < -90 || lat > 90) {
      resultDiv.textContent = 'Latitud inválida. Debe estar entre -90 y 90.';
      return;
    }
    if (isNaN(lng) || lng < -180 || lng > 180) {
      resultDiv.textContent = 'Longitud inválida. Debe estar entre -180 y 180.';
      return;
    }

    // Enviar JSON con clave 'cityId' para coincidir con DTO
    const payload = {
      cityId: parseInt(cityId, 10),
      latitude: lat,
      longitude: lng
    };

    fetch(`${API_BASE}/calculardistancia`, {
      method: 'POST',
      mode: 'cors',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(payload)
    })
      .then(response => response.json())
      .then(data => {
        if (data.distance === undefined) {
          resultDiv.textContent = `Error: ${data.error || 'Respuesta inesperada'}`;
        } else {
          resultDiv.innerHTML = `Distancia: ${data.distance.toFixed(2)} km<br>Área: ${data.area.toFixed(2)} km²`;
        }
      })
      .catch(error => {
        console.error('Error al calcular distancia:', error);
        resultDiv.textContent = 'Error al calcular distancia.';
      });
  });
});
