import { Link, useLocation } from "react-router"
import FilterIcon from "../icons/FilterIcon"

type Props = {
    to: string
    label: string
    onClick?: () => void
}

const SideBarNavLink = ({ to, label, onClick }: Props) => {
    const location = useLocation()
    const isActive = location.pathname === to

    return (
        <Link
            onClick={onClick}
            to={to}
            className={`flex items-center gap-4 w-full py-2 text-xl rounded-xl px-3 font-semibold ${isActive ? "bg-black text-white" : "hover:bg-bg-sunken"}`}
        >
            <div
                className={`aspect-square h-8 rounded-xl flex justify-center items-center ${isActive ? "bg-bg-dark-elevated" : "bg-bg-sunken"}`}
            >
                <FilterIcon className="h-[60%]" color={`${isActive ? "#F2F2F2" : "#000000"}`} />
            </div>
            {label}
            <div className="aspect-square w-2 bg-bg-elevated rounded-full ml-auto" />
        </Link>
    )
}

export default SideBarNavLink
