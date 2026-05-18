import { useState } from "react"

type Props = {
    onChange: (value: boolean) => void
    size: string
    className?: string
    defaultValue: boolean
}

const Checkbox = ({ onChange, size, defaultValue, className }: Props) => {
    const [activeValue, setActiveValue] = useState<boolean>(defaultValue)

    const toggleCheckbox = () => {
        const next = !activeValue
        setActiveValue(next)
        onChange(next)
    }

    const styles = (className ?? "") + ` h-${size}`

    return (
        <div
            className={`border-2 rounded-sm aspect-square cursor-pointer ${styles} ${activeValue ? "bg-black" : ""}`}
            onClick={() => toggleCheckbox()}
        />
    )
}

export default Checkbox
