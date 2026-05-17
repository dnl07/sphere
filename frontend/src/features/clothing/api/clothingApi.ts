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

// GET count
export async function getClothingCount(
    params: GetClothingParams = {}
): Promise<number> {
    const response = await api.clothing.getCount(params);
    return response.data.count;
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
    if (request.price !== undefined && request.price !== null) formData.append("PriceAmount", request.price.toString());
    if (request.boughtAt) formData.append("BoughtAt", request.boughtAt.toISOString());
    if (request.store) formData.append("Store", request.store);
    if (request.brand) formData.append("Brand", request.brand);
    formData.append("IsArchived", String(request.isArchived ?? false));
    if (request.notes) formData.append("Notes", request.notes);

    formData.append("Image", request.image, "image.png");

    const response = await api.clothing.createItem(formData);
    return response.data;
}

// PUT /clothing request types
export async function updateClothingItemById(
    id: string,
    params: UpdateClothingItemByIdRequest = {}
): Promise<ClothingItemDto> {
    const formData = new FormData();

    if (params.category) formData.append("Category", params.category);
    if (params.size) formData.append("Size", params.size);
    if (params.material) formData.append("Material", params.material);
    if (params.color) formData.append("Color", params.color);
    if (params.price !== undefined && params.price !== null) formData.append("Price", params.price.toString());
    if (params.boughtAt) formData.append("BoughtAt", params.boughtAt);
    if (params.store) formData.append("Store", params.store);
    if (params.brand) formData.append("Brand", params.brand);
    if (params.isArchived !== undefined && params.isArchived !== null) formData.append("IsArchived", String(params.isArchived));
    if (params.notes) formData.append("Notes", params.notes);
    if (params.image) formData.append("Image", params.image);

    const response = await api.clothing.updateItem(id, formData);
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