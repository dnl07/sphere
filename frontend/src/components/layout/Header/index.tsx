import HamburgerButton from "../../ui/icons/HamburgerButton";
import { useState } from "react";
import ClickableBackground from "../ClickableBackground";
import { NavLink } from "react-router";
import HeaderMenu from "../HeaderMenu";

const Header = () => {

    const [ open, setOpen ] = useState(false);

    return (
        <header className= "w-full px-6 py-3 flex justify-between shadow-lg">
            <NavLink to={""} className="text-2xl">SPHERE</NavLink>
            <HamburgerButton open={open} onClick={() => setOpen(!open)} />
            <HeaderMenu open={open} />
            {open && <ClickableBackground bgColor="" onClick={() => setOpen(false)}/>}
        </header> 
    )
}

export default Header;