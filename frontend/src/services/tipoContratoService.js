const API_URL = "http://localhost:5002/TipoContrato";

export const getTiposContrato = async () => {
  const response = await fetch(`${API_URL}/get-all`);
  const data = await response.json();
  return data.data;
};

export const createTipoContrato = async (tipo) => {
  const response = await fetch(`${API_URL}/create`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(tipo)
  });

  return await response.json();
};

export const updateTipoContrato = async (tipo) => {
  const response = await fetch(`${API_URL}/update`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(tipo)
  });

  return await response.json();
};

export const deleteTipoContrato = async (id) => {
  const response = await fetch(`${API_URL}/delete/${id}`, {
    method: "DELETE"
  });

  return await response.json();
};
