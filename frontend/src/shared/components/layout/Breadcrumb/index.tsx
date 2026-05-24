import { Link } from "react-router"
import { useBreakpointContext } from "../../../context/BreakPointContext"
import { ChevronRight } from "lucide-react"

export type BreadcrumbItem = {
    label: string
    to?: string
}

type Props = {
    items: BreadcrumbItem[]
}

const Breadcrumb = ({ items }: Props) => {
    const { isBelow } = useBreakpointContext()

    return (
        <div className={`w-full border-b border-border flex items-center gap-1 ${isBelow("xl") ? "px-4 py-2" : "p-5"}`}>
            {items.map((item, i) => (
                <>
                    <span
                        key={i}
                        className={`text-md ${i === items.length - 1 ? "text-text-main font-semibold" : "text-text-sub"}`}
                    >
                        {item.to ? <Link to={item.to}>{item.label}</Link> : <span>{item.label}</span>}{" "}
                    </span>
                    {i !== items.length - 1 && <ChevronRight size={15} color="#00000080" />}
                </>
            ))}
        </div>
    )
}

export default Breadcrumb
