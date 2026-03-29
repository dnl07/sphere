import { useState } from "react";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import type { ClothingItemDto } from "../clothing.types";
import { searchClothing } from "../../closet/api/search.api";

interface UseSearchClothingState extends ApiState<ClothingItemDto[]> { }

export interface UseSearchClothingReturn extends UseSearchClothingState, ApiActions<string> { }

export function useSearchClothing(): UseSearchClothingReturn {
    const [state, setState] = useState<UseSearchClothingState>({
        data: [],
        isLoading: true,
        error: null
    });

    const search = async (query: string) => {
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            const data = await searchClothing(query);
            setState({ data: data.items ?? [], isLoading: false, error: null})
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}));
        }
    };

    return {
        ...state,
        refetch: search
    }
}