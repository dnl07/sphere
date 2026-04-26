import { getClothingItem } from "../api/clothingApi";
import { useApi } from "../../../shared/api/useApi";
import { useEffect } from "react";

// GET: item
export function useClothingItem(id: string) {
    const { execute, data, ...state } = useApi(getClothingItem, { initialLoading: true})

    useEffect(() => {
        execute(id);
    }, [id]);

    return {
        ...state,
        item: data,
        refetch: () => execute(id)
    }
}