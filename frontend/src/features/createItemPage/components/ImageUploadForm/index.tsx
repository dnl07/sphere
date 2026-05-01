import { useRef, useState, type ChangeEvent } from "react";
import { useBackgroundRemover } from "../../hooks/useBackgroundRemover";
import LoadingScreen from "../../../../shared/components/LoadingScreen";
import { convertToPng } from "../../../../shared/utils/convertToPng";
import ImageEditor from "../../../imageEditor";

type Props = {
    preview: string | null,
    file: File | null,
    setImage: (file: File) => void,
    clearImage: () => void
}

const ImageUploadForm = ({ preview, file, setImage, clearImage }: Props) => {
    const inputRef = useRef<HTMLInputElement>(null);

    const [isProcessed, setIsProcessed] = useState<boolean>(false);
    const { processImage, loading } = useBackgroundRemover();

    const handleFileChange = async (e: ChangeEvent<HTMLInputElement>) => {
        let file = e.target.files?.[0];
        if (!file) return;
        console.log(file)

        file = await convertToPng(file);

        console.log(file)

        setImage(file);
        setIsProcessed(false);
    }

    const handleRemoveBackground = async () => {
        if (!file) return;

        const blob = await processImage(file);

        const processedFile = new File([blob], file.name, { type: blob.type });
        setImage(processedFile);
        setIsProcessed(true);
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
                            <input type="file" name="image" accept="image/*" className="appearance-none hidden" ref={inputRef} onChange={handleFileChange}/>
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
            {/*<ImageEditor image={file}/>*/}
        </div>
    );
}

export default ImageUploadForm;