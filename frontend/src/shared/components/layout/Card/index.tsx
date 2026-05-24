import type { LucideProps } from "lucide-react"
import type { ReactNode } from "react"

type Props = {
    title?: string
    children: React.ReactNode
    className?: string
    TitleIcon?: (props: LucideProps) => ReactNode
}

const Card = ({ title, TitleIcon, children, className = "" }: Props) => (
    <div className={`w-full bg-bg-elevated rounded-xl px-6 py-4 ${className}`}>
        <div className="flex items-center gap-2 mb-2">
            {TitleIcon && <TitleIcon size={20} />}
            {title && <h3 className="text-lg font-semibold">{title}</h3>}
        </div>
        {children}
    </div>
)

export default Card
