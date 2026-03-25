import { useState } from "react";

export const useBackgroundRemover = () => {
    const [ loading, setLoading ] = useState(false);

    const processImage = async (file: File) => {
        try {
            setLoading(true);

            // return await removeBackground(file);
        } finally {
            setLoading(false);
        }
    };

    return { processImage, loading};
}