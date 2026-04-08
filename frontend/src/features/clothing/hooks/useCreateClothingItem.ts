import { useState } from "react";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import { createClothingItem } from "../api/clothingApi";
import type { ClothingItemDto } from "../clothing.types";
import type { CreateClothingItemRequest } from "../api/clothingApi.types";

// POST: create item
interface UseCreateClothingItemState extends ApiState<ClothingItemDto> {
    data: ClothingItemDto | null;
}

export interface UseCreateClothingItemReturn extends UseCreateClothingItemState, ApiActions {
    create: () => void;
    request: Partial<CreateClothingItemRequest> | null,
    updateRequest: (fields: Partial<CreateClothingItemRequest>) => void
}

export function useCreateClothingItem(): UseCreateClothingItemReturn {
    const [ state, setState ] = useState<UseCreateClothingItemState>({
        data: null,
        isLoading: true,
        error: null,
    });

    const [request, setRequest] = useState<Partial<CreateClothingItemRequest> | null>(null)

    const updateRequest = (fields: Partial<CreateClothingItemRequest>) => {
        setRequest(prev => ({...prev, ...fields}));
    }

    const create = async () => {

        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            const data = await createClothingItem(request as CreateClothingItemRequest);
            setState({ data: data, isLoading: false, error: null});
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}));
        }
    };

    return {
        ...state,
        refetch: () => {},
        create: create,
        request: request,
        updateRequest: updateRequest
    }
}