import axiosInstance from "../axiosInstance";
import { clothingEndpoints } from "../endpoints";

export const createClothing = async (formData: FormData) => {
    const response = await axiosInstance.post(clothingEndpoints.createClothing(), formData, {
        headers: {
            "Content-Type": "multipart/form-data"
        }
    })

    return response.data;
};