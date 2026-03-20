import ClothingGallery from "../../components/features/gallery/ClothingGallery";
import PageWrapper from "../../components/layout/PageWrapper";

const Closet = () => {
    return (
        <PageWrapper title="Closet">
            <h1 className="text-3xl">Closet</h1>
            <ClothingGallery />
        </PageWrapper>
    );
};

export default Closet;