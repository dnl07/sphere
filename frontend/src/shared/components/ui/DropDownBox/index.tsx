import ClickableBackground from "../../layout/ClickableBackground"

type Props = {
    values: string[],
    setActiveValue: (value: string) => void,
    activeValue: string | null,
    setOpen: (isOpen: boolean) => void,
    isOpen: boolean
}

const DropDownBox = ({values, setActiveValue, activeValue, setOpen, isOpen}: Props) => {
    return (
        <>
            <ul className={`bg-black z-20 text-white transition-all duration-200 absolute overflow-y-scroll top-full overflow-x-hidden ${isOpen ? "max-h-77" : "max-h-0"} translate-y-2`}>
                {values.map((value) => (
                    <li key={value} className="text-xl">
                        <button 
                            className={`w-full flex justify-start pl-4 pr-8 py-2 cursor-pointer transition-all duration-100 ${value === activeValue ? "bg-bg text-black  ring-2 ring-inset ring-black" : ""}`}
                            onPointerUp={() => setActiveValue(value)}
                        >{value}</button> 
                    </li>
                ))}
            </ul>
            {isOpen && <ClickableBackground onClick={() => setOpen(false)}/>}        
        </>
    )
}

export default DropDownBox;