import { NavLink } from "react-router";
import PageWrapper from "../../shared/components/layout/PageWrapper";

const Atelier = () => {
    return (
        <PageWrapper title="Atelier">
            <NavLink to="create" className=" hover:underline">Create New Clothing Item</NavLink>
        </PageWrapper>
    );
};

export default Atelier;