import { useState } from "react";
import { useBlob } from "../../../../shared/hooks/useBlob";
import { api } from "../../../../shared/api/api";
import LoadingScreen from "../../../../shared/components/LoadingScreen";

type Props = {
    imageId: string
}

const ItemDisplay = ({ imageId }: Props) => {
    const [clicked, setClicked] = useState<boolean>(false);

    const { imageUrl, isLoading, error } = useBlob(() => api.image.getImage(imageId));

    return (
        <div className="w-full flex flex-col items-center">
            <div className="p-5 aspect-square cursor-pointer bg-bg-elevated  transition-all duration-200 hover:scale-102  rounded-xl" onClick={() => setClicked(!clicked)}>
                {isLoading && 
                    <div className="w-full h-full">
                        <LoadingScreen />
                    </div>
                }
                {imageUrl && <img src={imageUrl} className="object-contain drop-shadow-2xl"/>}
            </div>    
            <div className={`transition-all duration-300 ${clicked ? "max-h-20 opacity-100 mb-10" : "max-h-0 opacity-0"}`}>
                <button className="bg-black text-white px-5 py-2 text-lg transition-all duration-200 hover:scale-105 cursor-pointer">Change image</button>
            </div>        
        </div>
    );
};

export default ItemDisplay;