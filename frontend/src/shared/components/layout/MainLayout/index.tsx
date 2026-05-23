import { Outlet } from "react-router"
import MobileHeader from "../MobileHeader"
import SideBar from "../SideBar"
import { useBreakpointContext } from "../../../context/BreakPointContext"

const MainLayout = () => {
    const { isBelow } = useBreakpointContext()

    return (
        <div className={`min-h-svh flex ${isBelow("xl") ? "flex-col" : ""}`}>
            {isBelow("xl") ? <MobileHeader /> : <SideBar clickOnLink={() => {}} />}
            <div className="w-60" />

            <Outlet />
        </div>
    )
}

export default MainLayout
