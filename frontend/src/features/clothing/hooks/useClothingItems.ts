import { useEffect, useState } from "react";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import type { GetClothingItemsResponse, GetClothingParams } from "../api/clothingApi.types";
import { getClothingItems } from "../api/clothingApi";

// GET: items
interface UseClothingItemsState extends ApiState<GetClothingItemsResponse> {
    data: GetClothingItemsResponse | null;
}

export interface UseGetClothingItemsReturn extends UseClothingItemsState, ApiActions {
    updateFilters: (newFilters: Partial<GetClothingParams>) => void;
}

export function useClothingItems(initial: GetClothingParams = {}): UseGetClothingItemsReturn {
    const [ params, setParams ] = useState<GetClothingParams>(initial);
    const [ state, setState ] = useState<UseClothingItemsState>({
        data: null,
        isLoading: true,
        error: null,
    });

    const fetchItems = async () => {
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            const data = await getClothingItems(params);
            setState({ data: data, isLoading: false, error: null});
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}));
        }
    };

    useEffect(() => {
        fetchItems();
    }, [params]);

    const updateFilters = (newFilters: Partial<GetClothingParams>) => {
        setParams({ ...newFilters, PageNumber: 1});
    };

    return {
        ...state,
        refetch: fetchItems,
        updateFilters
    }
}