import { useRef, type ChangeEvent } from "react";

type Props = {
    previewUrl: string | null,
    loading: boolean,
    setPreviewUrl: (url: string | null) => void
}

const ImageUploadForm = ({ previewUrl, setPreviewUrl, loading }: Props) => {
    const inputRef = useRef<HTMLInputElement>(null);

    const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files?.[0];
        if (!file) return;

        const url = URL.createObjectURL(file);
        setPreviewUrl(url);
    }

    return(
        <div className="flex justify-center items-start w-full p-5">
            {loading ? 
                <p>Loading...</p>
            :
                previewUrl ? 
                    <div className="w-full max-w-sm min-w-50 aspect-2/3 flex flex-col justify-center items-center drop-shadow-lg">
                        <img src={previewUrl} alt="Preview" className="w-full" />
                    </div>
                : 
                    <div className="w-full max-w-sm min-w-50 border-2 border-dashed rounded-xl aspect-2/3 flex flex-col justify-center items-center cursor-pointer"
                        onClick={() => inputRef.current?.click()}>
                        <label htmlFor="image" className="text-center text-gray-500 mt-10">Click to select a file</label>
                        <input type="file" name="image" accept="image/png, image/jpeg" className="appearance-none hidden" ref={inputRef} onChange={handleFileChange}/>
                    </div>      
            }
        </div>
    );
}

export default ImageUploadForm;