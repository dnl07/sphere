import { useNavigate } from "react-router";
import Button from "../../../common/Button";

const HeroSection = () => {
    const navigate = useNavigate();

    return (
        <div>
            <h1>SPHERE</h1>
            <Button onClick={() => navigate("/closet")}>Go to Closet</Button>
        </div>
    );
}

export default HeroSection;