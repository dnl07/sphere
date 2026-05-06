import { useState } from "react";
import type { FilterTool } from "../constants/types";

export type FilterState = Record<string, number>;

const useImageFilters = (tools: FilterTool[]) => {
    const getInitialFilterState = (): FilterState =>
        Object.fromEntries(tools.map(f => [f.key, f.initial]));

    const [filters, setFilters] = useState<FilterState>(getInitialFilterState());

    const updateFilter = (key: string, value: number) => {
        setFilters(prev => ({...prev, [key]: value}));
    }

    const resetFilters = () => {
        setFilters(getInitialFilterState());
    }

    const buildFilterString = (state: FilterState): string => {
        return tools    
            .map(f => `${f.cssFilter}(${state[f.key]}${f.unit})`)
            .join(" ");
    }

    return {filters, filterString: buildFilterString(filters), updateFilter, resetFilters}
}

export default useImageFilters;