import { useNavigate } from "react-router";
import HamburgerButton from "../../ui/HamburgerButton";
import { useState } from "react";

const Header = () => {
    const navigate = useNavigate();

    const [ open, setOpen ] = useState(false);

    return (
        <header className= "w-full px-6 py-3 flex justify-between shadow-lg">
            <button className="text-2xl" onClick={() => navigate("")}>SPHERE</button>
            <HamburgerButton open={open} onClick={() => setOpen(!open)} />
        </header> 
    )
}

export default Header;