import { useState } from "react";
import { removeBackground } from "../api/services/backgroundRemoverService";

export const useBackgroundRemover = () => {
    const [ loading, setLoading ] = useState(false);
    const [ resultUrl, setResultUrl ] = useState<string | null>(null);

    const processImage = async (file: File) => {
        try {
            setLoading(true);

            const blob = await removeBackground(file);

            const url = URL.createObjectURL(blob);
            setResultUrl(url);

            return blob;
        } finally {
            setLoading(false);
        }
    };

    return { processImage, loading, resultUrl };
}