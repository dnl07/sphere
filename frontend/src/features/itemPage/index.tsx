import { useParams } from "react-router-dom";
import PageWrapper from "../../shared/components/layout/PageWrapper";

const ItemPage = () => {
    const { id } = useParams();

    return (
        <PageWrapper>
            <div>
                Item {id}
            </div>            
        </PageWrapper>
    )
}

export default ItemPage;