import { useClosetContext } from "../../../context/ClosetContext";

const ClothingGalleryPaginator = () => {
    const { meta, loadNextPage } = useClosetContext();

    return (
        <div className="w-full flex justify-center my-15">
            {meta?.hasNextPage && 
                <button 
                    className="bg-black text-white py-2 px-6 cursor-pointer"
                    onClick={loadNextPage}
                >
                    Load more
                </button>
            }
        </div>
    );
}

export default ClothingGalleryPaginator;