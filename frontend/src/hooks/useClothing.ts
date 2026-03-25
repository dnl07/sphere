import { useEffect, useState } from "react";
import { getClothingItems, type GetClothingItemsResponse, type GetClothingParams } from "../api/clothing.api";

interface UseGetClothingState {
    data: GetClothingItemsResponse | null;
    isLoading: boolean;
    error: Error | null;
}

interface UseGetClothingReturn extends UseGetClothingState {
    refetch: () => void;
    updateFilters: (newFilters: Partial<GetClothingParams>) => void;
}

export function useGetClothing(initial: GetClothingParams = {}): UseGetClothingReturn {
    const [ params, setParams ] = useState<GetClothingParams>(initial);
    const [ state, setState ] = useState<UseGetClothingState>({
        data: null,
        isLoading: true,
        error: null,
    });

    const fetchItems = async () => {
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            const data = await getClothingItems(params)
            setState({ data: data, isLoading: false, error: null})
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}))
        }
    };
    
    useEffect(() => {
        fetchItems();
    }, [params]);
    
    const updateFilters = (newFilters: Partial<GetClothingParams>) => {
        setParams(prev => ({ ...prev, ...newFilters, PageNumber: 1}));
    };

    return {
        ...state,
        refetch: fetchItems,
        updateFilters
    }
}