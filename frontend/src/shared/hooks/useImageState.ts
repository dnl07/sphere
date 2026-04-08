import { useState } from "react";

const useImageState = () => {
    const [preview, setPreview] = useState<string | null>(null);
    const [file, setFile] = useState<Blob | null>(null);

    const setImage = (blob: Blob) => {
        if (preview) {
            URL.revokeObjectURL(preview);
        }

        setPreview(URL.createObjectURL(blob));
        setFile(blob);
    }

    const clearImage = () => {
        setPreview(null);
        setFile(null);
    }

    return { preview, file, setImage, clearImage};
};

export default useImageState;