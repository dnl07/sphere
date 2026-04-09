import { useState } from "react";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import { createClothingItem } from "../api/clothingApi";
import type { ClothingItemDto } from "../clothing.types";
import type { CreateClothingItemRequest } from "../api/clothingApi.types";

// POST: create item
interface UseCreateClothingItemState extends ApiState<ClothingItemDto> {
    data: ClothingItemDto | null;
    validationErrors: ClothingValidationErrors;
}

export interface UseCreateClothingItemReturn extends UseCreateClothingItemState, ApiActions {
    create: () => void;
    request: Partial<CreateClothingItemRequest> | null,
    updateRequest: (fields: Partial<CreateClothingItemRequest>) => void
}

export type ClothingValidationErrors = Partial<Record<keyof CreateClothingItemRequest, string>>;

export function useCreateClothingItem(): UseCreateClothingItemReturn {
    const [ state, setState ] = useState<UseCreateClothingItemState>({
        data: null,
        isLoading: true,
        error: null,
        validationErrors: {}
    });

    const [request, setRequest] = useState<Partial<CreateClothingItemRequest> | null>(null)

    const updateRequest = (fields: Partial<CreateClothingItemRequest>) => {
        setRequest(prev => ({...prev, ...fields}));
    }

    const [validationErrors, setValidationErrors] = useState<ClothingValidationErrors>({})

    const validate = (): boolean => {
        const errors: ClothingValidationErrors = {};

        if (!request?.name) {
            errors.name = "Name is required"
        }

        if (!request?.category) {
            errors.category = "Category is required"
        }    

        if (!request?.image) {
            errors.image = "Image is required"
        }    

        setValidationErrors(errors);
        return Object.keys(errors).length === 0;
    }

    const create = async () => {
        if (!validate()) return;

        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {

            const data = await createClothingItem(request as CreateClothingItemRequest);
            setState({ data: data, isLoading: false, error: null, validationErrors: {}});
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}));
        }
    };

    return {
        ...state,
        refetch: () => {},
        create: create,
        request: request,
        updateRequest: updateRequest,
        validationErrors: validationErrors
    }
}