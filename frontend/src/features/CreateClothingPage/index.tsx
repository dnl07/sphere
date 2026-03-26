import { useState } from "react";
import ImageUploadForm from "../atelier/ImageUploadForm";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import LongRoundButton from "../../shared/components/ui/form/LongRoundButton";
import { useBackgroundRemover } from "../atelier/hooks/useBackgroundRemover";

const CreateClothingPage = () => {
    const [ preview, setPreview ] = useState<string | null>(null);

    const { processImage, loading } = useBackgroundRemover();
    
    const handleRemoveBackground =async () => {
        if (!preview) return;

        const blob = await fetch(preview).then(file => file.blob())
        const file = new File([blob], "image.png", { type: blob.type });

        const result = await processImage(file);

        /*if (result) {
            setPreview(URL.createObjectURL(result));
        }*/
    }

    return (
        <PageWrapper title="Create Item">
            <ImageUploadForm previewUrl={preview} setPreviewUrl={setPreview} loading={loading}/>
            {preview && <LongRoundButton label="Remove background" onClick={handleRemoveBackground} />}
{            /*
            <div className="w-full flex flex-row justify-between px-2 max-w-6xl mx-auto sm:justify-center sm:gap-20">
                <RoundIconButton icon="Edit" />
                <UploadButton onClick={() => {}} />
                <RoundIconButton icon="Reset" />
            </div>
            */}
        </PageWrapper>
    )
}

export default CreateClothingPage;