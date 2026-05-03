import { useNavigate } from "react-router-dom";
import PageWrapper from "../../shared/components/layout/PageWrapper";

const Atelier = () => {
    const navigate = useNavigate();

    return (
        <PageWrapper title="Atelier">
            <button 
                className="bg-black text-white py-15 px-20 rounded-xl text-xl font-semibold cursor-pointer"
                onClick={() => navigate("create")}
            >
                Create a new clothing item
            </button>
        </PageWrapper>
    );
};

export default Atelier;