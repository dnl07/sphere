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
    brands?: FilterOption[] | null;
    stores?: FilterOption[] | null;
}

export interface FilterOption {
    name: string;
    count: number;
}

export interface PriceRange {
    min?: number | null;
    max?: number | null;
}

export interface PagedResult {
    totalCount: number;
    pageNumber: number;
    hasNextPage: boolean;
    hasPreviousPage: boolean;    
}

// Filter parameters
export type GetClothingParams = {
    SearchQuery?: string;
    Categories?: string[];
    Colors?: string[];
    Sizes?: string[];
    Materials?: string[];
    PriceMin?: number[];
    PriceMax?: number[];
    Brands?: string[];
    Stores?: string[];
    SortBy?: string;
    PageNumber?: number;
    PageSize?: number;
};

// POST /clothing request types
export type CreateClothingItemRequest = {
    category: string;
    size?: string | null;
    material?: string | null;
    color?: string | null;
    priceAmount?: number | null;
    boughtAt?: Date | null,
    store?: string | null,
    brand?: string | null,
    isArchived: false,
    notes?: string | null,  
    image: Blob;  
}

// PUT /clothing request types
export type UpdateClothingItemByIdRequest = {
    category?: string;
    description?: string;
    size?: string;
    material?: string;
    color?: string;
    priceAmount?: number;
    currency?: string;
    image?: Blob;
};

export type GetAllCategories = {
    categories: string[]
}