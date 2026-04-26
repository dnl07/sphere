import { deleteClothingItem } from "../api/clothingApi";
import { useApi } from "../../../shared/api/useApi";

// DELETE: clothing item
export function useDeleteClothingItem() {
    const { execute, ...state } = useApi(deleteClothingItem, { initialLoading: true})

    return {
        deleteItem: (id: string) => execute(id),
        ...state,
    }
}