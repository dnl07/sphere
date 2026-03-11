import useClothingItems from "../../../hooks/useClothingItems";
import { clothingEndpoints } from "../../../api/endpoints";

const ClothingGallery = () => {    
    const { items, loading, error } = useClothingItems();

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (<div>
        {items.map((item) => (
            <div key={item.id}>
                <img src={clothingEndpoints.getImage(item.imageId)} />
            </div>
        ))}
    </div>
    );
};

export default ClothingGallery;