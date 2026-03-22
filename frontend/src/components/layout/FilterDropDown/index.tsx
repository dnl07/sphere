import { useState, type ReactNode } from "react";
import DropDownArrow from "../../ui/icons/DropDownArrow";

type Props = {
    children: ReactNode,
    label: string
}

const FilterDropDown = ({ children, label }: Props) => {
    const [ onExpanded, setOnExpanded ] = useState(false);

    return (
        <div className="bg-gray-400 w-full px-2">
            <button className="bg-gray-600 w-full flex justify-between items-center text-2xl p-2" onClick={() => setOnExpanded(!onExpanded)}>
                {label}
                <DropDownArrow open={onExpanded}/>
            </button>
            {onExpanded && children}
        </div>

    )
}

export default FilterDropDown;