import { useEffect, useState } from "react";
import DropDownArrow from "../../../../shared/components/ui/icons/DropDownArrow";
import DropDownBox from "../../../../shared/components/ui/DropDownBox";

type Props = {
    className?: string,
    headerClassName?: string,
    values: string[],
    setValue: (value: string) => void
}

const FormDropdown = ({ className, headerClassName, values, setValue }: Props) => {
    const [ isOpen, setOpen ] = useState<boolean>(false);
    const [ activeValue, setActiveValue ] = useState<string | null>(null);

    useEffect(() => {
        if (activeValue) {
            setValue(activeValue);
        }
    }, [activeValue]);

    return(
        <div className={`relative ${className}`}>
            <div 
                className={`text-xl border-2 border-black px-4 py-2  flex flex-row justify-between items-center ${headerClassName}`}
                onClick={() => setOpen(!isOpen)}
            >
                {activeValue ? <span className="text-black">{activeValue}</span> : <span className="text-gray-500">Jacket</span>}
                <DropDownArrow open={isOpen}/>
            </div>
            <DropDownBox
                values={values}
                setActiveValue={setActiveValue}
                activeValue={activeValue}
                setOpen={setOpen}
                isOpen={isOpen}
            />
        </div>
    );
};

export default FormDropdown;