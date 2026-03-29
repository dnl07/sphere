import type { ReactNode } from "react"

export type IconProps = {
    className? : string,
    color?: string,
    strokeWidth?: number
}

const IconBase = ({
    className = "w-10 h-10",
    color = "#F2F2F2",
    strokeWidth = 1.5,
    children
}: IconProps & { children: ReactNode }) => {
    return (
        <svg
        className={className}
        viewBox="0 0 24 24"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
        stroke={color}
        strokeWidth={strokeWidth}
        strokeLinecap="round"
        strokeLinejoin="round"
        >
            {children}
        </svg>        
    )
}

export default IconBase;