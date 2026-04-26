import { useParams } from "react-router-dom";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import { useClothingItem } from "../clothing/hooks/useClothingItem";
import ItemDisplay from "./components/ItemDisplay";
import ItemDescription from "./components/ItemDescription";
import ItemActions from "./components/ItemActions";

const ItemPage = () => {
    const { id } = useParams();

    if (!id) {
        return (<div>Invalid item</div>)
    }

    const { item, isLoading } = useClothingItem(id);
    
    if (isLoading) {
        return (
            <div>Loading item...</div>
        )
    }

    return (
        <PageWrapper>
            {item && 
                <div className="w-full flex flex-col items-center max-w-xl">
                    <ItemDisplay imageId={item?.imageId}/>
                    <div className="w-full flex justify-between items-center my-2">
                        <h1 className="text-2xl">{item?.name}</h1>
                        <ItemActions itemId={id}/>      
                    </div>
                    <ItemDescription item={item} />   
                </div>
            }

        </PageWrapper>
    )
}

export default ItemPage;