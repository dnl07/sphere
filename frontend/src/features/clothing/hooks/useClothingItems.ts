import { useEffect, useState } from "react";
import type { GetClothingParams, PagedResult } from "../api/clothingApi.types";
import { getClothingItems } from "../api/clothingApi";
import { useApi } from "../../../shared/api/useApi";
import type { ClothingItemDto } from "../clothing.types";

const PAGESIZE = 30

// GET: items
export function useClothingItems(initial: GetClothingParams = {}) {
    const { execute, data, ...state } = useApi(getClothingItems, { initialLoading: true})

    const [ params, setParams ] = useState<GetClothingParams>({
        PageNumber: 1,
        PageSize: PAGESIZE,
        ...initial
    });

    const [ items, setItems ] = useState<ClothingItemDto[] | null>([])

    useEffect(() => {
        execute(params);
    }, [params]);

    useEffect(() => {
        if (!data?.items) return;
        console.log(data.items, data.pageNumber)
       

        if (data.pageNumber === 0 || data.pageNumber === 1) {

            setItems(data.items);
        } else {
            setItems((prev) => {
                const existingIds = new Set(prev!.map(i => i.id))
                const newItems = data.items!.filter(i => !existingIds.has(i.id))
                return [...prev!, ...newItems]
            })
        }
    }, [data])

    const meta: PagedResult | null = data ? {
        totalCount: data.totalCount ?? 0,
        pageNumber: data.pageNumber ?? 1,
        hasNextPage: data.hasNextPage ?? false,
        hasPreviousPage: data.hasPreviousPage ?? false,
    } : null;

    const loadNextPage = () => {
        if (data?.hasNextPage) {
            setParams(prev => ({ ...prev, PageNumber: (prev.PageNumber ?? 1) + 1 }))
        }
    }

    const updateFilters = (newFilters: Partial<GetClothingParams>) => {
        setParams({ ...newFilters, PageSize: PAGESIZE, PageNumber: 1});
    };

    return {
        items: items,
        meta,
        filters: data?.filters ?? null,
        refetch: () => execute(params),
        loadNextPage,
        updateFilters,
        ...state
    }
}