import { useState } from "react"
import { updateClothingItemById } from "../api/clothingApi"
import type { UpdateClothingItemByIdRequest } from "../api/clothingApi.types"
import { useApi } from "../../../shared/api/useApi"

// POST: create item

export type ClothingValidationErrors = Partial<Record<keyof UpdateClothingItemByIdRequest, string>>

export function useUpdateClothingItem(id: string) {
    const { execute, ...state } = useApi(updateClothingItemById, { initialLoading: true })

    const [request, setRequest] = useState<Partial<UpdateClothingItemByIdRequest> | null>(null)

    const updateRequest = (fields: Partial<UpdateClothingItemByIdRequest>) => {
        setRequest((prev) => ({ ...prev, ...fields }))
    }

    const [validationErrors, setValidationErrors] = useState<ClothingValidationErrors>({})

    const validate = (): boolean => {
        const errors: ClothingValidationErrors = {}

        setValidationErrors(errors)
        return Object.keys(errors).length === 0
    }

    const update = async () => {
        if (!validate()) return
        console.log(request)

        if (request) {
            const item = await execute(id, request)
            console.log(item)
            return item
        }
    }

    return {
        ...state,
        update: update,
        request: request,
        updateRequest: updateRequest,
        validationErrors: validationErrors,
    }
}
