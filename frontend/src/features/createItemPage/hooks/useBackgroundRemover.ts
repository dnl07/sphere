import { useState } from "react";
import { removeBackground } from "../api/inferenceApi";

export const useBackgroundRemover = () => {
    const [ loading, setLoading ] = useState(false);

    const processImage = async (file: Blob): Promise<Blob> => {
        try {
            setLoading(true);

            return await removeBackground(file);
        } finally {
            setLoading(false);
        };
    }

    return { processImage, loading};
}