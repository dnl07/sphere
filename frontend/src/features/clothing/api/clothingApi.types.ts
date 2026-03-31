import type { ClothingItemDto } from "../clothing.types";

// GET ALL
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
    SearchQuery?: string;
    CategoryNames?: string[];
    Colors?: string[];
    Sizes?: string[];
    Materials?: string[];
    PageNumber?: number;
    PageSize?: number;
    FromPage?: number;
    ToPage?: number;
};

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