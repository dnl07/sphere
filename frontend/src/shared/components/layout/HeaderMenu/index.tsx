import MenuNavLink from "../../ui/MenuNavLink";

type Props = {
    open: boolean
}

const HeaderMenu = ({ open }: Props) => {
    return (
        <div className={`bg-bg fixed h-screen top-0 z-20 pr-10 pl-10 pt-16 right-0 transition-all ease-in-out duration-500 ${open ? "translate-0 shadow-2xl" : "translate-x-full"}`}>
            <nav className="flex flex-col gap-10">
                <MenuNavLink to="/boutique" label="Boutique" />
                <MenuNavLink to="/closet" label="Closet" />
                <MenuNavLink to="/atelier" label="Atelier" />
                <MenuNavLink to="/faq" label="FAQ" />
                <MenuNavLink to="/about" label="About" />
            </nav>
        </div>
    );
}

export default HeaderMenu;