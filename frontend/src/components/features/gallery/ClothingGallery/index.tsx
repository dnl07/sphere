import { useClosetContext } from "../../../../context/ClosetContext";
import ClothingGalleryItem from "../ClothingGalleryItem";

const ClothingGallery = () => {    
    const { data, isLoading, error } = useClosetContext();

    if (isLoading) return <div>Loading...</div>;
    if (error) return <div>Error: {error.message}</div>;
    console.log(data?.items)
    return (
    <div className="grid grid-cols-3 gap-2">
        {data?.items?.map((item) => (
            <ClothingGalleryItem key={item.id} item={item} />   
        ))}
    </div>
    );
};

export default ClothingGallery;