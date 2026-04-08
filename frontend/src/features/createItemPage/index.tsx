import { useEffect } from "react";
import PageWrapper from "../../shared/components/layout/PageWrapper"
import useImageState from "../../shared/hooks/useImageState";
import { useCreateClothingItem } from "../clothing/hooks/useCreateClothingItem";
import ImageUploadForm from "./components/ImageUploadForm"
import ItemForm from "./components/ItemForm";

const CreateItemPage = () => {
    const { request, updateRequest, create, isLoading, error, validationErrors } = useCreateClothingItem();
    const { preview, file, setImage, clearImage } = useImageState();

    useEffect(() => {
        if (file) updateRequest({ image: file})
    }, [file])

    return (
        <PageWrapper title="Create a clothing item">
            <ImageUploadForm preview={preview} file={file} setImage={setImage} clearImage={clearImage}/>
            <ItemForm request={request} updateRequest={updateRequest} validationErrors={validationErrors}/>
            <button className="bg-black py-4 px-8 text-2xl text-white mb-10  cursor-pointer" onClick={create}>Submit form</button>
            {error && <div>{error.message}</div>}
        </PageWrapper>
    );
}

export default CreateItemPage;