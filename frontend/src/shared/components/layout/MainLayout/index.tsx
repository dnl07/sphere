import { Outlet } from "react-router"
import Header from "../Header";

const MainLayout = () => {
    return (
        <div className="min-h-svh flex flex-col">
            <Header />
            <Outlet />
        </div>
    )
}

export default MainLayout;