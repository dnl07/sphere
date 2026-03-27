import { useNavigate } from "react-router-dom";
import { clothingEndpoints } from "../../../../shared/api/endpoints";
import type { ClothingItemDto } from "../../../../shared/api/clothing.types";

type Props = {
    item: ClothingItemDto
}

const ClothingGalleryItem = ({ item }: Props) => {
    const navigate = useNavigate();

    return (
        <div key={item.id} className="flex items-center justify-center aspect-square" onClick={() => navigate(`/item/${item.id}`)}>
            <img src={clothingEndpoints.getImage(item.imageId)} className="drop-shadow-lg h-full w-full object-contain"/>
        </div>
    );
}

export default ClothingGalleryItem;