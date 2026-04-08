import { useState } from "react";
import PageWrapper from "../../shared/components/layout/PageWrapper"
import ImageUploadForm from "./components/ImageUploadForm"

const CreateItemPage = () => {

    return (
        <PageWrapper title="Create a clothing item">
            <ImageUploadForm />
        </PageWrapper>
    );
}

export default CreateItemPage;