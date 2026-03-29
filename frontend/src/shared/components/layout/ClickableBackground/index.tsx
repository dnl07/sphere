import type { ReactNode } from "react";

type Props = {
    bgColor?: string,
    onClick: () => void,
    children?: ReactNode
}

const ClickableBackground = ({ bgColor, onClick, children }: Props) => {
    return (
        <div className={`${bgColor} z-10 fixed top-0 left-0 w-full h-full flex justify-center items-center`} onClick={onClick}>
            {children}
        </div>
    )
}

export default ClickableBackground;