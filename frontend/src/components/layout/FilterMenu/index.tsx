import Cross from "../../ui/icons/Cross";
import FilterDropDown from "../FilterDropDown";

type Props = {
    open: boolean,
    closeFilter: () => void
}

const FilterMenu = ({ open, closeFilter }: Props) => {
    return (
        <div className={`fixed w-full top-0 z-30 flex justify-end transition-all ease-in-out duration-300 ${open ? "opacity-100" : "invisible opacity-0"}`}>
            <div className="bg-bg inset-0 w-full h-screen md:max-w-2xl shadow-xl">
                <div className="p-7 flex justify-end">
                    <Cross onClick={closeFilter}/>
                </div>
                <FilterDropDown label="Material"><p>Material</p></FilterDropDown>
                <FilterDropDown label="Size"><p>Size</p></FilterDropDown>
            </div>
        </div>
    )
}

export default FilterMenu;