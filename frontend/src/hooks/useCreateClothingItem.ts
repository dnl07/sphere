import { useState } from "react";
import { createClothing } from "../api/services/createClothingService";

export const useCreateClothingItem = () => {
    const [ loadingCreate, setLoadingCreate ] = useState(false);

    const create = async (data: FormData) => {
        try {
            setLoadingCreate(true);

            await createClothing(data);
        } finally {
            setLoadingCreate(false);
        }
    }

    return { create, loadingCreate };
}