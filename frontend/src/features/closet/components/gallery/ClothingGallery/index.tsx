import { useClosetContext } from "../../../context/ClosetContext";
import ClothingGalleryItem from "../ClothingGalleryItem";
import ClothingGalleryPaginator from "../ClothingGalleryPaginator";

type Props = {
    columns: number
}

const ClothingGallery = ({ columns }: Props) => {    
    const { items, isLoading, error } = useClosetContext();

    if (error) return <div>Error: Could not fetch items</div>;

    console.log(items?.length)

    if (items?.length === 0) return <div>No clothing items found :(</div>

    return (
        <div>
            {isLoading && <div>Loading...</div>}
            <div style={{gridTemplateColumns: `repeat(${columns}, minmax(0, 1fr))`}} className={`grid gap-10`}>
                {items?.map((item) => (
                    <ClothingGalleryItem key={item.id} item={item} />   
                ))}
            </div>
            <ClothingGalleryPaginator />
        </div>
    );
};

export default ClothingGallery;