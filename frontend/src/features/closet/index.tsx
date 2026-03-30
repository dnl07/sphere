import { useState } from "react";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import { ClosetProvider } from "./context/ClosetContext";
import FilterMenu from "./components/filter/FilterMenu";
import FilterIconButton from "./components/filter/FilterIconButton";
import ClothingGallery from "./components/gallery/ClothingGallery";

const Closet = () => {
    const [ filterMenuOpen, setFilterMenuOpen ] = useState(false);

    return (
        <PageWrapper>
            <ClosetProvider>
                <div className=" w-full border-b mb-2">
                    <h1 className="text-3xl align-self-end px-2 py-1">Closet</h1>
                </div>
                <ClothingGallery />
                <FilterMenu open={filterMenuOpen} closeFilter={() => setFilterMenuOpen(false)}/>
                <FilterIconButton filterMenuOpen={filterMenuOpen} onFilter={() => setFilterMenuOpen(!filterMenuOpen)}/>
            </ClosetProvider>
        </PageWrapper>
    );
};

export default Closet;