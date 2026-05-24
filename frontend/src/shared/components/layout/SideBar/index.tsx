import { useNavigate } from "react-router"
import Sphere from "../../Sphere"
import SideBarNavLink from "../../ui/SideBarNavLink"
import { useBreakpointContext } from "../../../context/BreakPointContext"
import ClosetIcon from "../../ui/icons/ClosetIcon"
import { CircleQuestionMark, Info, Spool } from "lucide-react"

type Props = {
    clickOnLink: () => void
}

const SideBar = ({ clickOnLink }: Props) => {
    const navigate = useNavigate()
    const { isAbove } = useBreakpointContext()

    return (
        <div className="bg-bg-elevated  w-60 fixed h-dvh px-4 flex flex-col shadow-xl ">
            {isAbove("xl") && (
                <div className="flex gap-4 items-center py-4">
                    <div className="cursor-pointer" onClick={() => navigate("")}>
                        <Sphere numberOfLines={10} width={40} height={40} lineWidth={0.3} speed={0.005} />
                    </div>
                    <span className="text-2xl">SPHERE</span>
                </div>
            )}

            <div className={`w-full self-center bg-border h-px  ${isAbove("xl") ? "" : "mt-15"}`} />
            <nav className="flex flex-col gap-2 mt-2 text-text-sub">
                <SideBarNavLink onClick={clickOnLink} to="/closet" label="Closet" Icon={ClosetIcon} />
                <SideBarNavLink onClick={clickOnLink} to="/atelier" label="Atelier" Icon={Spool} />
                <SideBarNavLink onClick={clickOnLink} to="/faq" label="FAQ" Icon={CircleQuestionMark} />
                <SideBarNavLink onClick={clickOnLink} to="/about" label="About" Icon={Info} />
            </nav>
            <div className="w-full self-center bg-border h-px mt-auto" />
            <div className="w-full flex justify-center text-sm text-text-sub py-4">
                <span>sphere v1.0</span>
            </div>
        </div>
    )
}

export default SideBar
