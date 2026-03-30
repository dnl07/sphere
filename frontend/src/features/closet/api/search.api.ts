// GET /search 

import axiosInstance from "../../../shared/api/axiosInstance";
import type { ClothingItemDto } from "../../clothing/clothing.types";

export interface SearchResponse {
    items?: ClothingItemDto[] | null;
}

export async function searchClothing(query: string): Promise<SearchResponse> {
    const response = await axiosInstance.get<SearchResponse>("/search", { params: query });
    return response.data;
}