import type { GetClothingItemsResponse, GetClothingParams, UpdateClothingItemByIdRequest } from "../../features/clothing/api/clothingApi.types";
import type { ClothingItemDto } from "../../features/clothing/clothing.types";
import axiosInstance from "./axiosInstance";

export const API_BASE = "";

export const api = {
    clothing: {
        getAll: (params: GetClothingParams) => axiosInstance.get<GetClothingItemsResponse>(`${API_BASE}/clothing`, { params }),
        getItem: (id: string) => axiosInstance.get<ClothingItemDto>(`${API_BASE}/clothing/${id}`),
        createItem: (formData: FormData) => axiosInstance.post<ClothingItemDto>(`${API_BASE}/clothing`, { formData }),
        updateItem: (params: UpdateClothingItemByIdRequest) => axiosInstance.put<ClothingItemDto>(`${API_BASE}/clothing`, { params }),
        deleteItem: (id: string) => axiosInstance.delete<ClothingItemDto>(`${API_BASE}/clothing/${id}`),
        getImage: (id: string) => axiosInstance.get<Blob>(`${API_BASE}/clothing/${id}/image`),
    },
    image: {
        getImage: (imageId: string): Promise<Blob> => axiosInstance.get<Blob>(`${API_BASE}/image/${imageId}`, { responseType: "blob"}).then(image => image.data)
    },
    inference: {
        inference: (formData: FormData) => axiosInstance.post<Blob>(`${API_BASE}/inference`, { formData })
    }, 
    search: {
        search: (query: string) => axiosInstance.get<Blob>(`${API_BASE}/search`)
    }
}