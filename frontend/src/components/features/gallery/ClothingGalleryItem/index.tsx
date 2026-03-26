import { clothingEndpoints } from "../../../../api/endpoints";
import type { ClothingItemDto } from "../../../../api/types/types";

type Props = {
    item: ClothingItemDto
}

const ClothingGalleryItem = ({ item }: Props) => {
    return (
        <div key={item.id} className="flex items-center justify-center aspect-square">
            <img src={clothingEndpoints.getImage(item.imageId)} className="drop-shadow-lg h-full w-full object-contain"/>
        </div>
    );
}

export default ClothingGalleryItem;