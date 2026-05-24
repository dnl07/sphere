import type { LucideProps } from "lucide-react"
import IconBase from "../IconBase"

const ClosetIcon = (props: LucideProps) => {
    return (
        <IconBase {...props}>
            <rect x="3" y="2" width="18" height="20" rx="1" />
            <line x1="12" y1="2" x2="12" y2="22" />
            <line x1="8" y1="10" x2="9" y2="10" />
            <line x1="15" y1="10" x2="16" y2="10" />
        </IconBase>
    )
}

export default ClosetIcon
