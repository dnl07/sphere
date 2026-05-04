import { api } from "../../../shared/api/api";
import type { ClothingItemDto } from "../clothing.types";
import type { CreateClothingItemRequest, GetAllCategories, GetClothingItemsResponse, GetClothingParams, UpdateClothingItemByIdRequest } from "./clothingApi.types";

// GET
export async function getClothingItem(id: string) {
    const response = await api.clothing.getItem(id);
    return response.data;
}

// GET ALL
export async function getClothingItems(
    params: GetClothingParams = {}
): Promise<GetClothingItemsResponse> {
    const response = await api.clothing.getAll(params);
    return response.data;
}

// POST /clothing request types
export async function createClothingItem(
    request: CreateClothingItemRequest
): Promise<ClothingItemDto> {
    const formData = new FormData();
    formData.append("Category", request.category);

    if (request.size) formData.append("Size", request.size);
    if (request.material) formData.append("Material", request.material);
    if (request.color) formData.append("Color", request.color);
    if (request.priceAmount) formData.append("PriceAmount", request.priceAmount.toString());
    if (request.currency) formData.append("Color", request.currency);

    formData.append("Image", request.image, "image.png");


    const response = await api.clothing.createItem(formData);
    return response.data;
}

// PUT /clothing request types
export async function updateClothingItemById(
    params: UpdateClothingItemByIdRequest = {}
): Promise<ClothingItemDto> {
    const response = await api.clothing.updateItem(params);
    return response.data;
}

// DELETE /clothing 
export async function deleteClothingItem(id: string) {
    await api.clothing.deleteItem(id);
}

// GET /category
export async function getCategories(): Promise<GetAllCategories> {
    const response = await api.categories.getAll();
    return response.data;
}