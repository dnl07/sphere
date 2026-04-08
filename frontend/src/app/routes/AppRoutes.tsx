import { createBrowserRouter, RouterProvider } from "react-router-dom";
import MainLayout from "../../shared/components/layout/MainLayout";
import Home from "../../features/home";
import Closet from "../../features/closet";
import Atelier from "../../features/atelier";
import ItemPage from "../../features/itemPage";
import CreateItemPage from "../../features/createItemPage";

const router = createBrowserRouter([
    {
        path: "/",
        element: <MainLayout />,
        children: [
            {index: true, element: <Home />},
            {path: "closet", element: <Closet />},
            {path: "atelier", element: <Atelier />},
            {path: "item/:id", element: <ItemPage />},
            {path: "atelier/create", element: <CreateItemPage />},
            { path: "*", element: <h1>404 Not Found</h1> }
        ]
    }
])

function AppRoutes() {
    return <RouterProvider router={router} />
}

export default AppRoutes;