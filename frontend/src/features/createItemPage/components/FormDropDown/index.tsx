import { useEffect, useState } from "react"
import DropDownArrow from "../../../../shared/components/ui/icons/DropDownArrow"
import DropDownBox from "../../../../shared/components/ui/DropDownBox"

type Props = {
    className?: string
    headerClassName?: string
    values: string[]
    setValue: (value: string) => void
    defaultValue?: string
}

const FormDropdown = ({ className, headerClassName, values, setValue, defaultValue }: Props) => {
    const [isOpen, setOpen] = useState<boolean>(false)
    const [activeValue, setActiveValue] = useState<string | null>(defaultValue ?? null)

    useEffect(() => {
        if (activeValue) {
            setValue(activeValue)
        }
    }, [activeValue])

    return (
        <div className={`relative ${className}`}>
            <div
                className={`flex flex-row justify-between items-center cursor-pointer ${headerClassName}`}
                onClick={() => setOpen(!isOpen)}
            >
                {activeValue ? (
                    <span className="text-black">{activeValue}</span>
                ) : (
                    <span className="text-gray-500">Jacket</span>
                )}
                <DropDownArrow open={isOpen} />
            </div>
            <DropDownBox
                values={values}
                setActiveValue={setActiveValue}
                activeValue={activeValue}
                setOpen={setOpen}
                isOpen={isOpen}
            />
        </div>
    )
}

export default FormDropdown
