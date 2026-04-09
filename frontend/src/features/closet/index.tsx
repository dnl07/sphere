import { useState } from "react";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import { ClosetProvider } from "./context/ClosetContext";
import FilterMenu from "./components/filter/FilterMenu";
import FilterIconButton from "./components/filter/FilterIconButton";
import ClothingGallery from "./components/gallery/ClothingGallery";
import useColumns from "./hooks/useColumns";

const Closet = () => {
    const [ filterMenuOpen, setFilterMenuOpen ] = useState(false);

    const columnsMeta = useColumns(3, 2, 6);

    return (
        <PageWrapper title="Closet">
            <ClosetProvider>
                <ClothingGallery columns={columnsMeta.columns} />
                <FilterMenu 
                    open={filterMenuOpen} 
                    closeFilter={() => setFilterMenuOpen(false)}
                    columnsMeta={columnsMeta}/>
                <FilterIconButton filterMenuOpen={filterMenuOpen} onFilter={() => setFilterMenuOpen(!filterMenuOpen)}/>
            </ClosetProvider>
        </PageWrapper>
    );
};

export default Closet;