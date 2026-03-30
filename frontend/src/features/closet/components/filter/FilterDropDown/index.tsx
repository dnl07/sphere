import type { ReactNode } from "react";
import DropDownArrow from "../../../../../shared/components/ui/icons/DropDownArrow";

type Props = {
    open: boolean,
    onToggle: () => void,
    children: ReactNode,
    label: string
}

const FilterDropDown = ({ open, onToggle, children, label }: Props) => {
    return (
        <div className=" w-full">
            <button className=" w-full flex justify-between items-center text-2xl py-2 cursor-pointer" onClick={onToggle}>
                {label}
                <DropDownArrow open={open}/>
            </button>
            {open && children}
        </div>

    )
}

export default FilterDropDown;