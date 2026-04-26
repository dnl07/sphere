import { createContext, useContext, useMemo, type ReactNode } from "react";
import { useClothingItems } from "../../clothing/hooks/useClothingItems";
import type { ClothingItemDto } from "../../clothing/clothing.types";
import type { ClothingItemFilterResponse, GetClothingItemsResponse, GetClothingParams, PagedResult } from "../../clothing/api/clothingApi.types";

const ClosetContext = createContext<ContextReturnType | null>(null);

interface ContextReturnType {
    items: ClothingItemDto[] | null;
    meta: PagedResult | null;
    filters: ClothingItemFilterResponse | null;
    refetch: () => Promise<GetClothingItemsResponse | null>;
    updateFilters: (newFilters: Partial<GetClothingParams>) => void;
    loadNextPage: () => void;
    reset: () => void;
    isLoading: boolean;
    error: Error | null;
}

type ContextProps = {
    children: ReactNode;
}

export const ClosetProvider = ({ children }: ContextProps) => {
    const { items, meta, filters, isLoading, error, updateFilters, loadNextPage, refetch, reset } = useClothingItems();
    
    const value = useMemo(() => ({
        items,
        meta,
        filters,
        isLoading,
        error,
        updateFilters,
        loadNextPage,
        refetch,
        reset
    }), [items, meta, filters, isLoading, error]);    

    return (
        <ClosetContext.Provider value={value}>
            {children}
        </ClosetContext.Provider>
    )
}

export const useClosetContext = () => {
    const context = useContext(ClosetContext);

    if (!context) {
        throw new Error("useClosetContext must be used within a ClosetProvider")
    }

    return context;
}