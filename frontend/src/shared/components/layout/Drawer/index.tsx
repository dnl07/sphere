import type { ReactNode } from "react"

type Props = {
    isOpen: boolean
    children: ReactNode
    width: string
}

const Drawer = ({ isOpen, children, width }: Props) => {
    return (
        <div
            className={`fixed z-25 top-0 right-0 w-${width} transition-all duration-300 ease-in-out ${isOpen ? "translate-x-0" : "translate-x-full"}`}
        >
            {children}
        </div>
    )
}

export default Drawer
