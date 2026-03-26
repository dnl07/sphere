import { useState } from "react";
import ClothingGallery from "./components/ClothingGallery";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import FilterIconButton from "../../shared/components/ui/FilterIconButton";
import { ClosetProvider } from "./context/ClosetContext";
import FilterMenu from "./components/FilterMenu";

const Closet = () => {
    const [ filterMenuOpen, setFilterMenuOpen ] = useState(false);



    return (
        <PageWrapper title="Closet">
            <ClosetProvider>
                <div className=" w-full border-b mb-2">
                    <h1 className="text-3xl align-self-end px-2 py-1">Closet</h1>
                </div>
                <ClothingGallery />
                <FilterMenu open={filterMenuOpen} closeFilter={() => setFilterMenuOpen(false)}/>
                <FilterIconButton onExpand={() => {}} onFilter={() => setFilterMenuOpen(!filterMenuOpen)}/>
            </ClosetProvider>
        </PageWrapper>
    );
};

export default Closet;