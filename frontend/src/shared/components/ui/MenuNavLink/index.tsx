import { NavLink } from "react-router";

type Props = {
    to: string,
    label: string,
    onClick?: () => void
}

const MenuNavLink = ({ to, label, onClick }: Props) => {
    return (
        <NavLink onClick={onClick} to={to} className={({ isActive }) => `text-3xl w-50 h-10 ${isActive ? "underline text-4xl" : ""}`}>{label}</NavLink>
    );
}

export default MenuNavLink;