import { useClosetContext } from "../../../context/ClosetContext";
import ClothingGalleryItem from "../ClothingGalleryItem";

type Props = {
    columns: number
}

const ClothingGallery = ({ columns }: Props) => {    
    const { data, isLoading, error } = useClosetContext();

    if (isLoading) return <div>Loading...</div>;
    if (error) return <div>Error: Could not fetch items</div>;

    if (data?.items?.length === 0) return <div>No clothing items found :(</div>

    return (
        <div style={{gridTemplateColumns: `repeat(${columns}, minmax(0, 1fr))`}} className={`grid gap-10`}>
            {data?.items?.map((item) => (
                <ClothingGalleryItem key={item.id} item={item} />   
            ))}
        </div>
    );
};

export default ClothingGallery;