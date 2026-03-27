import axiosInstance from "../../../shared/api/axiosInstance";
import type { ClothingItemDto } from "../../../shared/api/clothing.types";

// GET /clothing response types

export interface GetClothingItemsResponse {
    items?: ClothingItemDto[] | null;
    totalCount?: number;
    pageNumber?: number;
    hasNextPage?: boolean;
    hasPreviousPage?: boolean;
    filters?: ClothingItemFilterResponse;
}

export interface ClothingItemFilterResponse {
    categories?: FilterOption[] | null;
    colors?: FilterOption[] | null;
    sizes?: FilterOption[] | null;
    materials?: FilterOption[] | null;
    priceRange?: PriceRange;
}

export interface FilterOption {
    name: string;
    count: number;
}

export interface PriceRange {
    min?: number | null;
    max?: number | null;
}

// Filter parameters
export type GetClothingParams = {
    CategoryNames?: string[];
    Colors?: string[];
    Sizes?: string[];
    Materials?: string[];
    PageNumber?: number;
    PageSize?: number;
    FromPage?: number;
    ToPage?: number;
};

export async function getClothingItems(
    params: GetClothingParams = {}
): Promise<GetClothingItemsResponse> {
    const response = await axiosInstance.get<GetClothingItemsResponse>("/clothing", { params });
    return response.data;
}

// POST /clothing request types

export type CreateClothingItemRequest = {
    name: string | null;
    category: string;
    description?: string | null;
    size?: string | null;
    material?: string | null;
    color?: string | null;
    priceAmount?: number | null;
    currency?: string | null;
    image: Blob;  
}

export async function createClothingItem(
    request: CreateClothingItemRequest
): Promise<ClothingItemDto> {
    const formData = new FormData();
    formData.append("Name", request.name ?? "");
    formData.append("Category", request.category);

    if (request.description) formData.append("Description", request.description);
    if (request.size) formData.append("Size", request.size);
    if (request.material) formData.append("Material", request.material);
    if (request.color) formData.append("Color", request.color);
    if (request.priceAmount) formData.append("PriceAmount", request.priceAmount.toString());
    if (request.currency) formData.append("Color", request.currency);

    formData.append("Image", request.image);

    const response = await axiosInstance.post<ClothingItemDto>("/clothing", formData);

    if (response.status !== 200) {
        throw new Error(`Failed to create clothing item: ${response.statusText}`);
    }

    return response.data;
}

// PUT /clothing request types

export type UpdateClothingItemByIdRequest = {
    Name?: string;
    Category?: string;
    Description?: string;
    Size?: string;
    Material?: string;
    Color?: string;
    PriceAmount?: number;
    Currency?: string;
    Image?: Blob;
};

export async function updateClothingItemById(
    params: UpdateClothingItemByIdRequest = {}
): Promise<ClothingItemDto> {
    const response = await axiosInstance.post<ClothingItemDto>("/clothing", { params });

    if (response.status !== 200) {
        throw new Error(`Failed to update clothing item: ${response.statusText}`);
    }

    return response.data;
}