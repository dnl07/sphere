import { useEffect, useState } from "react";
import type { GetClothingParams, PagedResult } from "../api/clothingApi.types";
import { getClothingItems } from "../api/clothingApi";
import { useApi } from "../../../shared/api/useApi";

const PAGESIZE = 3

// GET: items
export function useClothingItems(initial: GetClothingParams = {}) {
    const [ params, setParams ] = useState<GetClothingParams>({
        PageNumber: 1,
        PageSize: PAGESIZE,
        ...initial
    });

    const { execute, data, ...state } = useApi(getClothingItems, { initialLoading: true})

    useEffect(() => {
        execute(params);
    }, [params]);

    const meta: PagedResult | null = data ? {
        totalCount: data.totalCount ?? 0,
        pageNumber: data.pageNumber ?? 1,
        hasNextPage: data.hasNextPage ?? false,
        hasPreviousPage: data.hasPreviousPage ?? false,
    } : null;

    const updateFilters = (newFilters: Partial<GetClothingParams>) => {
        setParams({ ...newFilters, PageSize: PAGESIZE, PageNumber: 1});
    };

    return {
        ...state,
        items: data?.items ?? null,
        meta,
        filters: data?.filters ?? null,
        refetch: () => execute(params),
        updateFilters
    }
}