import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Home from "../pages/Home";
import MainLayout from "../layouts/MainLayout";
import Closet from "../pages/Closet";
import CreateClothingPage from "../pages/CreateClothingPage";

const router = createBrowserRouter([
    {
        path: "/",
        element: <MainLayout />,
        children: [
            {path: "/", element: <Home />},
            {path: "/closet", element: <Closet />},
            {path: "/create", element: <CreateClothingPage />},
        ]
    }
])

function AppRoutes() {
    return <RouterProvider router={router} />
}

export default AppRoutes;