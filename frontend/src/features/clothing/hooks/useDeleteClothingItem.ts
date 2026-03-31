import { useEffect, useState } from "react";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import { deleteClothingItem } from "../api/clothingApi";

// DELETE: clothing item
interface UseDeleteClothingItemState extends ApiState<void> { }

export interface UseDeleteClothingItemReturn extends UseDeleteClothingItemState, ApiActions { }

export function useDeleteClothingItem(id: string): UseDeleteClothingItemReturn {
    const [ state, setState ] = useState<UseDeleteClothingItemState>({
        data: null,
        isLoading: true,
        error: null,
    });

    const deleteItem = async () => {
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            await deleteClothingItem(id)
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}))
        }
    };

    useEffect(() => {
        deleteItem();
    }, [id]);

    return {
        ...state,
        refetch: deleteItem
    }
}