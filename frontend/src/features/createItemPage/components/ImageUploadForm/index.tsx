import { useRef, useState, type ChangeEvent } from "react";
import { useBackgroundRemover } from "../../hooks/useBackgroundRemover";
import useImageState from "../../../../shared/hooks/useImageState";
import LoadingScreen from "../../../../shared/components/LoadingScreen";

type Props = {
    preview: string | null,
    file: Blob | null,
    setImage: (blob: Blob) => void,
    clearImage: () => void
}

const ImageUploadForm = ({ preview, file, setImage, clearImage }: Props) => {
    const inputRef = useRef<HTMLInputElement>(null);

    const [isProcessed, setIsProcessed] = useState<boolean>(false);

    const { processImage, loading } = useBackgroundRemover();

    const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0];
        if (!file) return;

        setImage(file);
        setIsProcessed(false);
    }

    const handleRemoveBackground = async () => {
        if (file) {
            await processImage(file)
                .then(blob => setImage(blob))
                .finally(() => setIsProcessed(true));
        }
    }

    return(
        <div className="flex flex-col justify-center items-center w-full p-5">
            <div className="w-full max-w-sm min-w-50 aspect-3/4 rounded-xl flex flex-col justify-center items-center cursor-pointer">
                {loading ?
                    <div className="w-full h-full">
                        <LoadingScreen />
                    </div>
                :
                    preview ?
                        <div className="w-full max-w-sm min-w-50 flex flex-col justify-center items-center drop-shadow-lg">
                            <img src={preview ?? ""} alt="Preview" className="w-full" />
                        </div>
                    :
                        <div className="w-full max-w-sm min-w-50 border-2 border-dashed aspect-3/4 rounded-xl flex flex-col gap-5 justify-center items-center cursor-pointer"
                            onClick={() => inputRef.current?.click()}>
                            <span className="text-center text-gray-500 cursor-pointer">Click to select a file</span>
                            <div className="bg-black text-white py-2 px-4 cursor-pointer">Upload image</div>
                            <span className="text-center text-gray-500 cursor-pointer">Accepted formats: png, jpg, jpeg</span>
                            <input type="file" name="image" accept="image/png, image/jpeg" className="appearance-none hidden" ref={inputRef} onChange={handleFileChange}/>
                        </div>
                }
            </div>
            {(preview && !isProcessed) && <button className="bg-black text-white text-xl py-2 px-4 mt-6 cursor-pointer" onClick={handleRemoveBackground}>Remove background</button>}
            {preview && <div className="flex gap-6 w-full max-w-sm min-w-50">
                <button className="bg-black text-white py-2 px-4 mt-6 cursor-pointer flex-1" onClick={() => inputRef.current?.click()}>
                    Upload again
                    <input type="file" name="image" accept="image/png, image/jpeg" className="appearance-none hidden" ref={inputRef} onChange={handleFileChange}/>
                </button>
                <button className="bg-black text-white py-2 px-4 mt-6 cursor-pointer flex-1" onClick={clearImage}>Remove image</button>
            </div>}
        </div>
    );
}

export default ImageUploadForm;