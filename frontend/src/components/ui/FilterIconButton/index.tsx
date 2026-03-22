import { useState } from "react";

type Props = {
    onExpand: () => void,
    onFilter: () => void
}

const FilterIconButton = ({ onExpand, onFilter }: Props) => {
    const [ onExpanded, setOnExpanded ] = useState(false);

    return (
        <div className={`fixed bottom-1 md:bottom-3 z-30 max-w-6xl w-full flex px-3 `}>
            <div className={`bg-black p-3 flex gap-3 transition-all ease-in-out duration-200 ${onExpanded ? "w-full" : "w-39"}`}>
                <button className={`text-white border-white border-2 h-15 p-2 transition-all ease-in-out duration-200 cursor-pointer ${onExpanded ? "w-full" : "w-15"}`} onClick={() => setOnExpanded(!onExpanded)}>
                    <p>S</p>
                </button>
                <button className="text-white border-white border-2 h-15 p-2 aspect-square cursor-pointer" onClick={() => {onFilter(); setOnExpanded(!onExpanded)}}>
                    <p>F</p>
                </button>
            </div>
        </div>
    )
}

export default FilterIconButton;