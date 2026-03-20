import useClothingItems from "../../../../hooks/useClothingItems";
import ClothingGalleryItem from "../ClothingGalleryItem";

const ClothingGallery = () => {    
    const { items, loading, error } = useClothingItems();

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
    <div className="grid grid-cols-3 gap-2">
        {items.map((item) => (
            <ClothingGalleryItem key={item.id} item={item} />   
        ))}
    </div>
    );
};

export default ClothingGallery;