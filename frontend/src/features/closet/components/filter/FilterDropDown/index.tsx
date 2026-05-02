import type { ReactNode } from "react";
import DropDownArrow from "../../../../../shared/components/ui/icons/DropDownArrow";

type Props = {
    open: boolean,
    onToggle: () => void,
    children: ReactNode,
    label: string
}

/**
 * Filter drop down component, used in the filter sidebar on the closet page.
 */
const FilterDropDown = ({ open, onToggle, children, label }: Props) => {
    return (
        <div className=" w-full">
            <button className=" w-full flex justify-between items-center text-2xl py-2 cursor-pointer" onClick={onToggle}>
                {label}
                <DropDownArrow open={open}/>
            </button>
            <div className={`border-b border-border overflow-hidden transition-all duration-200 ${open ? "max-h-96" : "max-h-0"}`}>
                {children}
            </div>
        </div>

    )
}

export default FilterDropDown;