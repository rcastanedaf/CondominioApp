const API_URL = "http://localhost:5002/MotivoVisita";

export const getMotivos = async () => {
  const response = await fetch(`${API_URL}/get-all`);
  return await response.json();
};

export const createMotivo = async (motivo) => {
  const response = await fetch(`${API_URL}/create`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(motivo)
  });

  return await response.json();
};

export const updateMotivo = async (motivo) => {
  const response = await fetch(`${API_URL}/update`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(motivo)
  });

  return await response.json();
};

export const deleteMotivo = async (id) => {
  const response = await fetch(`${API_URL}/delete/${id}`, {
    method: "DELETE"
  });

  return await response.json();
};