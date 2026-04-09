import { useState } from "react";
import DropDownArrow from "../icons/DropDownArrow";

type Props = {
    className?: string,
    values: string[],
    setValue: (value: string) => void
}

const Dropdown = ({ className, values, setValue }: Props) => {
    const [ open, setOpen ] = useState<boolean>(false);

    return(
        <div className={` ${className}`}>
            <div 
                className="text-xl border-2 border-black px-4 py-2 text-gray-500 flex flex-row justify-between items-center cursor-pointer"
                onClick={() => setOpen(!open)}
            >
                <span>Jacket</span>
                <DropDownArrow open={open}/>
            </div>
            <ul className={`bg-black text-white transition-all duration-200 absolute overflow-hidden ${open ? "max-h-40" : "max-h-0"} translate-y-2`}>
                {values.map((value) => (
                    <li key={value} className="px-4 py-2">
                        {value}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Dropdown;