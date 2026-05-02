import { useState } from "react";
import HeaderMenu from "../HeaderMenu";
import HamburgerButton from "../../ui/icons/HamburgerButton";
import ClickableBackground from "../ClickableBackground";
import Sphere from "../../Sphere";
import { useNavigate } from "react-router";

const Header = () => {
    const [ open, setOpen ] = useState(false);

    const navigate = useNavigate();

    return (
        <header className= "w-full top-0 px-6 pt-3 flex justify-between">
            <div onClick={() => navigate("")}>
                <Sphere width={40} height={40} lineWidth={0.3} speed={0.005}/>
            </div>
            <HamburgerButton open={open} onClick={() => setOpen(!open)} />
            <HeaderMenu open={open} closeMenu={() => setOpen(false)} />
            {open && <ClickableBackground bgColor="" onClick={() => setOpen(false)}/>}
        </header>
    )
}

export default Header;