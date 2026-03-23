import { useEffect, useState } from "react";
import axiosInstance from "../api/axiosInstance";
import type { ClothingItem, ClothingResponseDto } from "../models/ClothingItem";
import { clothingEndpoints } from "../api/endpoints";

const useClothingItems = () => {
    const [items, setItems] = useState<ClothingItem[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    const getClothingItems = async (): Promise<ClothingItem[]> => {
        const response = await axiosInstance.get<ClothingResponseDto>(clothingEndpoints.getAll());
        return response.data.clothingResponses;
    };

    useEffect(() => {
        getClothingItems()
            .then(((data) => setItems(data)))
            .catch((err) => setError(err.message))
            .finally(() => setLoading(false));
    }, []);

    console.log(items);

    return { items, loading, error };
}

export default useClothingItems;