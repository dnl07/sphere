import { getCategories } from "../api/clothingApi";
import { useApi } from "../../../shared/api/useApi";
import { useEffect } from "react";

// GET: categories
export function useGetCategories() {
    const { execute, data, ...state } = useApi(getCategories, { initialLoading: true})

    useEffect(() => {
        execute()
    }, [])

    return {
        ...state,
        categories: data?.categories,
        refetch: execute
    }
}