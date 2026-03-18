import { Outlet } from "react-router"
import Header from "../../components/layout/Header";

const MainLayout = () => {
    return (
        <div className="min-h-svh flex flex-col">
            <Header />
            <Outlet />
        </div>
    )
}

export default MainLayout;