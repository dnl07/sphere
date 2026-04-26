import MenuNavLink from "../../ui/MenuNavLink";

type Props = {
    open: boolean,
    closeMenu: () => void
}

const HeaderMenu = ({ open, closeMenu }: Props) => {
    return (
        <div className={`bg-bg fixed h-screen top-0 z-20 pr-10 pl-10 pt-16 right-0 transition-all ease-in-out duration-500 ${open ? "translate-0 shadow-2xl" : "translate-x-full"}`}>
            <nav className="flex flex-col gap-10">
                <MenuNavLink onClick={closeMenu} to="/boutique" label="Boutique" />
                <MenuNavLink onClick={closeMenu} to="/closet" label="Closet" />
                <MenuNavLink onClick={closeMenu} to="/atelier" label="Atelier" />
                <MenuNavLink onClick={closeMenu} to="/faq" label="FAQ" />
                <MenuNavLink onClick={closeMenu} to="/about" label="About" />
            </nav>
        </div>
    );
}

export default HeaderMenu;