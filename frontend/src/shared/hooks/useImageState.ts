import { useState } from "react";

const useImageState = () => {
    const [preview, setPreview] = useState<string | null>(null);
    const [file, setFile] = useState<File | null>(null);

    const setImage = (file: File) => {
        if (preview) {
            URL.revokeObjectURL(preview);
        }

        setPreview(URL.createObjectURL(file));
        setFile(file);
    }

    const clearImage = () => {
        setPreview(null);
        setFile(null);
    }

    return { preview, file, setImage, clearImage};
};

export default useImageState;