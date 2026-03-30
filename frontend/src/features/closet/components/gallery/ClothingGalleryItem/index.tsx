import { useNavigate } from "react-router-dom";
import { clothingEndpoints } from "../../../../../shared/api/endpoints";
import type { ClothingItemDto } from "../../../../clothing/clothing.types";
type Props = {
    item: ClothingItemDto
}

const ClothingGalleryItem = ({ item }: Props) => {
    const navigate = useNavigate();

    return (
        <div key={item.id} className="flex items-center justify-center aspect-square hover:scale-105 transition-all duration-200" onClick={() => navigate(`/item/${item.id}`)}>
            <img src={clothingEndpoints.getImage(item.imageId)} className="drop-shadow-lg h-full w-full object-contain cursor-pointer"/>
        </div>
    );
}

export default ClothingGalleryItem;