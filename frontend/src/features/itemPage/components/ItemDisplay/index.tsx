import { useState } from "react";
import { clothingEndpoints } from "../../../../shared/api/endpoints";

type Props = {
    imageId: string
}

const ItemDisplay = ({ imageId }: Props) => {
    const [clicked, setClicked] = useState<boolean>(false);

    return (
        <div className="max-w-md flex justify-center flex-col items-center mt-2">
            <div className="w-full h-90 cursor-pointer" onClick={() => setClicked(!clicked)}>
                <img src={clothingEndpoints.getImage(imageId)} className="w-full h-full object-contain transition-all duration-200 hover:scale-105 drop-shadow-2xl"/>
            </div>    
            <div className={`transition-all duration-300 ${clicked ? "max-h-20 opacity-100 mb-10" : "max-h-0 opacity-0"}`}>
                <button className="bg-black text-white px-5 py-2 text-lg transition-all duration-200 hover:scale-105 cursor-pointer">Change image</button>
            </div>        
        </div>
    );
};

export default ItemDisplay;