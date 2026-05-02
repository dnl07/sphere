import { useEffect, useState } from "react";
import LoadingScreen from "../../../../../shared/components/LoadingScreen";
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
    const [showEmpty, setShowEmpty] = useState(false);

    useEffect(() => {
        if (items?.length === 0) {
            const timer = setTimeout(() => setShowEmpty(true), 300);
            return () => clearTimeout(timer);
        } else {
            setShowEmpty(false);
        }
    }, [items])

    if (error) return <div>Error: Could not fetch items</div>;
    if (showEmpty) return <div className="my-4 text-lg">No clothing items found :(</div>;

    return (
        <div className="w-full">
            <div style={{gridTemplateColumns: `repeat(${columns}, minmax(0, 1fr))`}} className={`grid gap-3`}>
                {items?.map((item) => (
                    <ClothingGalleryItem key={item.id} item={item} />   
                ))}
            </div>
            { (!items || isLoading) && 
                <div className="w-full my-10">
                    <LoadingScreen />
                </div>
            }

            <ClothingGalleryPaginator />
        </div>
    );
};

export default ClothingGallery;