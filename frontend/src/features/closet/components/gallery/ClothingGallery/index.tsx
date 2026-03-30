import { useClosetContext } from "../../../context/ClosetContext";
import ClothingGalleryItem from "../ClothingGalleryItem";

const ClothingGallery = () => {    
    const { data, isLoading, error } = useClosetContext();

    if (isLoading) return <div>Loading...</div>;
    if (error) return <div>Error: Could not fetch items</div>;

    if (data?.items?.length === 0) return <div>No clothing items found :(</div>

    return (
        <div className="grid grid-cols-3 gap-2">
            {data?.items?.map((item) => (
                <ClothingGalleryItem key={item.id} item={item} />   
            ))}
        </div>
    );
};

export default ClothingGallery;