import { useEffect, useState } from "react";
import type { ClothingMeta } from "../models/ClothingMeta";

const useClothingMeta = () => {
    const [meta, setMeta] = useState<ClothingMeta>();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    /*useEffect(() => {
        getClothingMeta()
            .then(((data) => setMeta(data)))
            .catch((err) => setError(err.message))
            .finally(() => setLoading(false));
    }, []);*/

    return { meta, loading, error };
}

export default useClothingMeta;