import type { ReactNode } from "react";

type Props = {
    children: ReactNode[];
}

const Carousel = ({ children }: Props) => {
    return (
        <div className="w-full flex gap-4 overflow-x-auto no-scrollbar">
            {children.map((child, idx) => (
                <div key={idx}>
                    {child}
                </div>
            ))}
        </div>
    )
}

export default Carousel;