import { useParams } from "react-router-dom";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import { useClothingItem } from "../clothing/hooks/useClothingItem";
import ItemDisplay from "./components/ItemDisplay";
import ItemDescription from "./components/ItemDescription";

const ItemPage = () => {
    const { id } = useParams();

    if (!id) {
        return (<div>Invalid item</div>)
    }

    const { data, isLoading } = useClothingItem(id);
    
    if (isLoading) {
        return (
            <div>Loading item...</div>
        )
    }

    return (
        <PageWrapper>
            {data && 
                <div className="w-full flex flex-col items-center">
                    <h1 className="text-2xl mt-3 self-start">{data?.name}</h1>
                    <ItemDisplay imageId={data?.imageId}/>
                    <ItemDescription item={data} />         
                </div>
            }

        </PageWrapper>
    )
}

export default ItemPage;