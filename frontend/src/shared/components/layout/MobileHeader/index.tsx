import { useState } from "react"
import HamburgerButton from "../../ui/icons/HamburgerButton"
import ClickableBackground from "../ClickableBackground"
import Sphere from "../../Sphere"
import { useNavigate } from "react-router"
import SideBar from "../SideBar"
import Drawer from "../Drawer"

const MobileHeader = () => {
    const [open, setOpen] = useState(false)

    const navigate = useNavigate()

    return (
        <header className="w-full top-0 px-6 py-3 flex justify-between items-center">
            <div className="cursor-pointer" onClick={() => navigate("")}>
                <Sphere numberOfLines={10} width={40} height={40} lineWidth={0.3} speed={0.005} />
            </div>
            <HamburgerButton open={open} onClick={() => setOpen(!open)} />
            <Drawer width="60" isOpen={open}>
                <SideBar clickOnLink={() => setOpen(false)} />
            </Drawer>
            {open && <ClickableBackground bgColor="" onClick={() => setOpen(false)} />}
        </header>
    )
}

export default MobileHeader
