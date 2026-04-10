import axios from "axios";

const API_URL = "http://localhost:5000/Parentesco";

export const getParentesco = async () => {
    return await axios.get(`${API_URL}/get-all`);
};

export const createParentesco = async (data) => {
    return await axios.post(`${API_URL}/create`, data);
};

export const updateParentesco = async (id, data) => {
    return await axios.put(`${API_URL}/update/${id}`, data);
};

export const deleteParentesco = async (id) => {
    return await axios.delete(`${API_URL}/delete/${id}`);
};