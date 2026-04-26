import { useState } from "react";
import { NavLink } from "react-router";
import HeaderMenu from "../HeaderMenu";
import HamburgerButton from "../../ui/icons/HamburgerButton";
import ClickableBackground from "../ClickableBackground";

const Header = () => {
    const [ open, setOpen ] = useState(false);

    return (
        <header className= "w-full px-6 py-3 flex justify-between shadow-lg">
            <NavLink to={""} className="text-2xl">SPHERE</NavLink>
            <HamburgerButton open={open} onClick={() => setOpen(!open)} />
            <HeaderMenu open={open} closeMenu={() => setOpen(false)} />
            {open && <ClickableBackground bgColor="" onClick={() => setOpen(false)}/>}
        </header>
    )
}

export default Header;