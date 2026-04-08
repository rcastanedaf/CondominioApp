import axios from "axios";

const API_URL = "http://localhost:44352/Pais";

export const getPaises = async () => {
    return await axios.get(`${API_URL}/get-all`);
};

export const createPais = async (data) => {
    return await axios.post(`${API_URL}/create`, data);
};

export const updatePais = async (id, data) => {
    return await axios.put(`${API_URL}/update/${id}`, data);
};

export const deletePais = async (id) => {
    return await axios.delete(`${API_URL}/delete/${id}`);
};