import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Home from "../pages/Home";
import MainLayout from "../layouts/MainLayout";
import Closet from "../pages/Closet";
import Atelier from "../pages/Atelier";
import CreateClothingPage from "../pages/CreateClothingPage";

const router = createBrowserRouter([
    {
        path: "/",
        element: <MainLayout />,
        children: [
            {index: true, element: <Home />},
            {path: "closet", element: <Closet />},
            {path: "atelier", element: <Atelier />},
            {path: "atelier/create", element: <CreateClothingPage />},
            { path: "*", element: <h1>404 Not Found</h1> }
        ]
    }
])

function AppRoutes() {
    return <RouterProvider router={router} />
}

export default AppRoutes;