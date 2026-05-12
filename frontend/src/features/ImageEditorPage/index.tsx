import { useLocation } from "react-router";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import ImageEditor from "./components/ImageEditor";

const ImageEditorPage = () => {
    const { state } = useLocation();
    const file: File = state?.file;

    return (
        <PageWrapper 
            title="Image Editor"
        >
            <ImageEditor file={file}/>
        </PageWrapper>

    )
} 

export default ImageEditorPage;