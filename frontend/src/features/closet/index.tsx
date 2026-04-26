import { useState } from "react";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import { ClosetProvider } from "./context/ClosetContext";
import FilterMenu from "./components/filter/FilterMenu";
import FilterIconButton from "./components/filter/FilterIconButton";
import ClothingGallery from "./components/gallery/ClothingGallery";
import useColumns from "./hooks/useColumns";
import ClosetToolbar from "./components/ClosetToolbar";

const Closet = () => {
    const [ filterMenuOpen, setFilterMenuOpen ] = useState(false);

    const columnsMeta = useColumns(3, 2, 4);
    return (
        <PageWrapper title="Closet">
            <ClosetProvider>
                <ClosetToolbar 
                    columnsMeta={columnsMeta}
                />
                <ClothingGallery columns={columnsMeta.columns} />
                <FilterMenu 
                    open={filterMenuOpen} 
                    closeFilter={() => setFilterMenuOpen(false)}
                />
                <FilterIconButton filterMenuOpen={filterMenuOpen} onFilter={() => setFilterMenuOpen(!filterMenuOpen)}/>
            </ClosetProvider>
        </PageWrapper>
    );
};

export default Closet;