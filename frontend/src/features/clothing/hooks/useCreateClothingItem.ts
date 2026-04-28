import { useState } from "react";
import { createClothingItem } from "../api/clothingApi";
import type { CreateClothingItemRequest } from "../api/clothingApi.types";
import { useApi } from "../../../shared/api/useApi";

// POST: create item

export type ClothingValidationErrors = Partial<Record<keyof CreateClothingItemRequest, string>>;

export function useCreateClothingItem() {
    const { execute, data, ...state } = useApi(createClothingItem, { initialLoading: true})

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

        if (request) {
            const item = await execute(request as CreateClothingItemRequest)
            return item;
        }
    };

    return {
        ...state,
        create: create,
        request: request,
        updateRequest: updateRequest,
        validationErrors: validationErrors
    }
}