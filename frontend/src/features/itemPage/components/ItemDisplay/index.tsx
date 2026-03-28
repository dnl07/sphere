import { clothingEndpoints } from "../../../../shared/api/endpoints";

type Props = {
    imageId: string
}

const ItemDisplay = ({ imageId }: Props) => {
    return (
        <div className="max-w-md shadow-2xl my-3">
            <img src={clothingEndpoints.getImage(imageId)}/>
        </div>
    )
};

export default ItemDisplay;