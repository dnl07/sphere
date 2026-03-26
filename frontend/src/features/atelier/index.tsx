import { NavLink } from "react-router";
import PageWrapper from "../../shared/components/layout/PageWrapper";

const Atelier = () => {
    return (
        <PageWrapper title="Atelier">
            <h1 className="text-3xl">Atelier</h1>
            <NavLink to="create" className=" hover:underline">Create New Clothing Item</NavLink>
        </PageWrapper>
    );
};

export default Atelier;