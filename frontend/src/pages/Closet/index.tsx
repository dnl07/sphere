import { useNavigate } from "react-router";
import Button from "../../components/common/Button";
import ClothingGallery from "../../components/features/ClothingGallery";

const Closet = () => {
    const navigate = useNavigate();

    return (
        <div>
            <Button onClick={() => navigate("/")}>Go back to Home</Button>
            <ClothingGallery />
        </div>
    );
};

export default Closet;