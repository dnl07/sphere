import axiosInstance from "../axiosInstance";
import { clothingEndpoints } from "../endpoints";

export const removeBackground = async (file: File): Promise<Blob> => {
    const formData = new FormData();
    formData.append("image", file);

    const response = await axiosInstance.post(clothingEndpoints.inference(), formData, 
        {
            responseType: "blob",    
            headers: {
                "Content-Type": "multipart/form-data"
            }
        });

    if (response.status !== 200) {
        throw new Error("Failed to remove background");
    }

    return response.data;
}