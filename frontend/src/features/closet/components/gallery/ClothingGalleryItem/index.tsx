import { useNavigate } from "react-router-dom";
import type { ClothingItemDto } from "../../../../clothing/clothing.types";
import { useBlob } from "../../../../../shared/hooks/useBlob";
import { api } from "../../../../../shared/api/api";
import { memo } from "react";

type Props = {
    item: ClothingItemDto
}

/**
 * Clothing gallery item component, representing a single clothing item in the gallery on the closet page.
 */
const ClothingGalleryItem = ({ item }: Props) => {
    const navigate = useNavigate();

    const { imageUrl, isLoading, error } = useBlob(() => api.image.getImage(item.imageId));
    
    return (
        <div key={item.id} className="flex items-center justify-center aspect-square hover:scale-105 transition-all duration-200" onClick={() => navigate(`/item/${item.id}`)}>
            {imageUrl && <img src={imageUrl} className="drop-shadow-lg h-full w-full object-contain cursor-pointer"/>}
        </div>
    );
}

export default memo(ClothingGalleryItem);