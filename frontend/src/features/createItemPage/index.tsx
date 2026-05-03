import { useEffect, useState } from "react";
import PageWrapper from "../../shared/components/layout/PageWrapper"
import useImageState from "../../shared/hooks/useImageState";
import { useCreateClothingItem } from "../clothing/hooks/useCreateClothingItem";
import ImageUploadForm from "./components/ImageUploadForm"
import ItemForm from "./components/ItemForm";
import ConfirmDialog from "../../shared/components/ConfirmDialog";
import { useNavigate } from "react-router";

const CreateItemPage = () => {
    const navigate = useNavigate();

    const { request, updateRequest, create, error, validationErrors } = useCreateClothingItem();
    const { preview, file, setImage, clearImage } = useImageState();

    const [ confirmMessage, setConfirmMessage ] = useState<string | null>(null);

    useEffect(() => {
        if (file) updateRequest({ image: file})
    }, [file])

    const submitForm = async () => {
        const item = await create();

        if (error) {
            setConfirmMessage(`An error occurred while creating.`)
        } else {
            setConfirmMessage(`Creating "${item?.name}" was successfull!`)
        }
    }

    return (
        <PageWrapper 
            title="Create a new item"
            subtitle="Upload an image and add information"
        >
            <ImageUploadForm preview={preview} file={file} setImage={setImage} clearImage={clearImage}/>
            <ItemForm request={request} updateRequest={updateRequest} validationErrors={validationErrors}/>
            <button
                className="bg-black px-16 text-lg font-semibold py-4 rounded-xl text-white my-4 cursor-pointer" 
                onClick={submitForm}
            >
                Submit form
            </button>
            {confirmMessage && <ConfirmDialog 
                message={confirmMessage}
                confirmMessage="Go to closet"
                cancelMessage="Create another item"
                onConfirm={() => navigate("/closet")}
                onCancel={() => window.location.reload()}
            />}
        </PageWrapper>
    );
}

export default CreateItemPage;