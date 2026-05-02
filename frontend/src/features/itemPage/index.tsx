import { useParams } from "react-router-dom";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import { useClothingItem } from "../clothing/hooks/useClothingItem";
import ItemDisplay from "./components/ItemDisplay";
import ItemDescription from "./components/ItemDescription";
import LoadingScreen from "../../shared/components/LoadingScreen";
import ItemActions from "./components/ItemActions";

const ItemPage = () => {
    const { id } = useParams();

    if (!id) {
        return (<div>Invalid item</div>)
    }

    const { item, isLoading } = useClothingItem(id);

    return (
        <PageWrapper
            title="Item Details"
            subtitle={`ID: ${item?.id}`}
        >
            {item && 
                <div className="w-full flex flex-col items-center max-w-xl">
                    { (isLoading) && 
                        <div className="w-full h-dvh">
                            <LoadingScreen />
                        </div>
                    }
                    <ItemDisplay imageId={item?.imageId}/>
                    <ItemDescription item={item} />   
                    <ItemActions itemId={item.id} />
                </div>
            }

        </PageWrapper>
    )
}

export default ItemPage;