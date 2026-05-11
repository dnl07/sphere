import { useLocation, useNavigate } from "react-router";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import ImageEditor from "./components/ImageEditor";
import { useState } from "react";

const ImageEditorPage = () => {
    const navigate = useNavigate();
    const { state } = useLocation();
    const imageUrl: string = state?.preview;
    const file: File = state?.file;


    return (
        <PageWrapper 
            title="Image Editor"
            subtitle="Adjust and enhance your product image"
        >
            <ImageEditor imageUrl={imageUrl} file={file}/>
        </PageWrapper>

    )
} 

export default ImageEditorPage;