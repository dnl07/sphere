import { useEffect, useState } from "react";
import { getClothingItem } from "../api/clothingApi";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import type { ClothingItemDto } from "../clothing.types";

// GET: item
interface UseClothingItemState extends ApiState<ClothingItemDto> {
    data: ClothingItemDto | null;
}

export interface UseGetClothingItemReturn extends UseClothingItemState, ApiActions { }

export function useClothingItem(id: string): UseGetClothingItemReturn {
    const [ state, setState ] = useState<UseClothingItemState>({
        data: null,
        isLoading: true,
        error: null,
    });

    const fetchItem = async () => {
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            const data = await getClothingItem(id)
            setState({ data: data, isLoading: false, error: null})
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}))
        }
    };

    useEffect(() => {
        fetchItem();
    }, [id]);

    return {
        ...state,
        refetch: fetchItem
    }
}