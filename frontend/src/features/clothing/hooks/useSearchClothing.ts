import { searchClothing } from "../../closet/api/search.api";
import { useApi } from "../../../shared/api/useApi";

export function useSearchClothing() {
    const { execute, data, ...state } = useApi(searchClothing, { initialLoading: true})

    return {
        items: data?.items,
        search: (query: string) => execute(query),
        ...state,
    }
}