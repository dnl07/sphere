import { useEffect, useState } from "react";
import DropDownArrow from "../icons/DropDownArrow";
import ClickableBackground from "../../layout/ClickableBackground";

type Props = {
    className?: string,
    values: string[],
    setValue: (value: string) => void
}

const Dropdown = ({ className, values, setValue }: Props) => {
    const [ open, setOpen ] = useState<boolean>(false);
    const [ activeValue, setActiveValue ] = useState<string | null>(null);

    useEffect(() => {
        if (activeValue) {
            setValue(activeValue);
        }
    }, [activeValue]);

    return(
        <div className={` ${className}`}>
            <div 
                className="text-xl border-2 border-black px-4 py-2  flex flex-row justify-between items-center"
                onClick={() => setOpen(!open)}
            >
                {activeValue ? <span className="text-black">{activeValue}</span> : <span className="text-gray-500">Jacket</span>}
                <DropDownArrow open={open}/>
            </div>
            <ul className={`bg-black z-20 text-white transition-all duration-200 absolute overflow-y-scroll overflow-x-hidden ${open ? "max-h-77" : "max-h-0"} translate-y-2`}>
                {values.map((value) => (
                    <li key={value} className="text-xl">
                        <button 
                            className={`w-full flex justify-start pl-4 pr-8 py-2 cursor-pointer transition-all duration-100 ${value === activeValue ? "bg-bg text-black  ring-2 ring-inset ring-black" : ""}`}
                            onPointerUp={() => setActiveValue(value)}
                        >{value}</button> 
                    </li>
                ))}
            </ul>
            {open && <ClickableBackground onClick={() => setOpen(false)}/>}
        </div>
    );
};

export default Dropdown;