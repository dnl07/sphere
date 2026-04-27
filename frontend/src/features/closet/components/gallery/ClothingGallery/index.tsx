import { useClosetContext } from "../../../context/ClosetContext";
import ClothingGalleryItem from "../ClothingGalleryItem";
import ClothingGalleryPaginator from "../ClothingGalleryPaginator";

type Props = {
    columns: number
}

/**
 * Clothing gallery component, located on the closet page. Displays the user's clothing items in a grid layout.
 */
const ClothingGallery = ({ columns }: Props) => {    
    const { items, isLoading, error } = useClosetContext();
    console.log("gallery render", items?.length, isLoading);

    if (error) return <div>Error: Could not fetch items</div>;
    if (!items || isLoading) return <div>Loading...</div>;

    console.log(items?.length)

    if (items?.length === 0) return <div>No clothing items found :(</div>

    return (
        <div>
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