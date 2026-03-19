import { useNavigate } from "react-router";
import Button from "../../components/ui/Button";
import ClothingGallery from "../../components/features/ClothingGallery";

const Closet = () => {
    const navigate = useNavigate();

    return (
        <div>
            <h1>Closet</h1>
            <Button onClick={() => navigate("/")}>Go back to Home</Button>
            <ClothingGallery />
        </div>
    );
};

export default Closet;