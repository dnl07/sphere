import { useRef, useState, type ChangeEvent } from "react";
import { useBackgroundRemover } from "../../hooks/useBackgroundRemover";
import LoadingScreen from "../../../../shared/components/LoadingScreen";
import { convertToPng } from "../../../../shared/utils/convertToPng";
import Cross from "../../../../shared/components/ui/icons/Cross";
import Card from "../../../../shared/components/layout/Card";
import { useNavigate } from "react-router";

type Props = {
    preview: string | null,
    file: File | null,
    setImage: (file: File) => void,
    clearImage: () => void
}

const ImageUploadForm = ({ preview, file, setImage, clearImage }: Props) => {
    const navigate = useNavigate();

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
        <div className="flex flex-col justify-center items-center w-full mb-4 gap-4">
            <Card className="max-h-80" title="Item image">
                {file ? 
                <div className="bg-bg-sunken py-2 px-4 rounded-xl flex items-center justify-between">
                    <div className="flex gap-3">
                        <span>{file.name}</span>
                        <span className="text-text-sub">{(file.size / (1000 * 1000)).toFixed(2)} MB</span>
                    </div>
                    <button className="cursor-pointer" onClick={clearImage}>
                        <Cross className="w-8" strokeWidth={1} color="black"/>
                    </button>
                </div>
                :
                <div 
                    className="w-full border-2 border-dashed py-4 border-[#00000025] rounded-xl flex flex-col gap-4 justify-center items-center cursor-pointer"
                    onClick={() => inputRef.current?.click()}
                >
                    <span className="text-center font-semibold cursor-pointer">Click to select your image</span>
                    <div className="bg-bg-sunken rounded-xl py-2 px-4 cursor-pointer">Browse files</div>
                    <input type="file" name="image" accept="image/*" className="appearance-none hidden" ref={inputRef} onChange={handleFileChange}/>                    
                </div>  
                }
            </Card>
            <Card title="Preview">
                 {loading ?
                    <div className="w-full h-full">
                        <LoadingScreen />
                    </div>
                :
                    preview ?
                        <div className="w-full flex flex-col justify-center items-center aspect-square drop-shadow-lg">
                            <img src={preview ?? ""} alt="Preview" className="w-full object-contain" />
                        </div>
                    :
                        <div className="w-full border border-border bg-bg-sunken py-4 aspect-square rounded-xl 
                            flex flex-col gap-5 justify-center items-center">
                            <span className="text-center text-gray-500">No image uploaded</span>
                        </div>
                }               
            </Card>
            <Card title="Advanced Editor">
                <p className="text-text-sub">Open the full editor for background removal, image adjustments and color grading.</p>
                <button className="bg-black w-full text-white py-4 rounded-xl mt-6 font-semibold cursor-pointer" onClick={() => navigate("/image-editor", { state: { preview, file }})}>Open Image Editor</button>
            </Card>
        </div>
    );
}

export default ImageUploadForm;