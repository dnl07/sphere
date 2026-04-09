import { useEffect, useState } from "react";
import { getCategories } from "../api/clothingApi";
import type { ApiActions, ApiState } from "../../../shared/api/api.types";
import type { GetAllCategories } from "../api/clothingApi.types";

// GET: item
interface UseGetCategoriesState extends ApiState<GetAllCategories> {
    data: GetAllCategories | null;
}

export interface UseGetCategoriesReturn extends UseGetCategoriesState, ApiActions { }

export function useGetCategories(): UseGetCategoriesReturn {
    const [ state, setState ] = useState<UseGetCategoriesState>({
        data: null,
        isLoading: true,
        error: null,
    });

    const fetchCategories = async () => {
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            const data = await getCategories()
            console.log(data)
            setState({ data: data, isLoading: false, error: null})
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}))
        }
    };

    useEffect(() => {
        fetchCategories();
    }, [])

    return {
        ...state,
        refetch: fetchCategories
    }
}