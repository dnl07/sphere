import { useState } from "react";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import { deleteClothingItem } from "../api/clothingApi";

// DELETE: clothing item
interface UseDeleteClothingItemState extends ApiState<void> { }

export interface UseDeleteClothingItemReturn extends UseDeleteClothingItemState, ApiActions<void> { }

export function useDeleteClothingItem(id: string): UseDeleteClothingItemReturn {
    const [ state, setState ] = useState<UseDeleteClothingItemState>({
        data: null,
        isLoading: false,
        error: null,
    });

    const deleteItem = async () => {
        console.log("delete")
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            await deleteClothingItem(id)
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}))
        }
    };

    return {
        ...state,
        refetch: () => deleteItem(),
    }
}