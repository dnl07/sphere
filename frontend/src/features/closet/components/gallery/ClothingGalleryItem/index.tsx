import { useNavigate } from "react-router-dom";
import type { ClothingItemDto } from "../../../../clothing/clothing.types";
import { useBlob } from "../../../../../shared/hooks/useBlob";
import { api } from "../../../../../shared/api/api";
type Props = {
    item: ClothingItemDto
}

const ClothingGalleryItem = ({ item }: Props) => {
    const navigate = useNavigate();

    const { url, isLoading, error } = useBlob(() => api.image.getImage(item.imageId));
    
    return (
        <div key={item.id} className="flex items-center justify-center aspect-square hover:scale-105 transition-all duration-200" onClick={() => navigate(`/item/${item.id}`)}>
            {url && <img src={url} className="drop-shadow-lg h-full w-full object-contain cursor-pointer"/>}
        </div>
    );
}

export default ClothingGalleryItem;