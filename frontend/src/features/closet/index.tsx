import { useState } from "react";
import PageWrapper from "../../shared/components/layout/PageWrapper";
import { ClosetProvider } from "./context/ClosetContext";
import FilterMenu from "./components/filter/FilterMenu";
import FilterIconButton from "./components/filter/FilterIconButton";
import ClothingGallery from "./components/gallery/ClothingGallery";
import useColumns from "./hooks/useColumns";
import ClosetToolbar from "./components/ClosetToolbar";
import { useNavigate } from "react-router";
import Plus from "../../shared/components/ui/icons/Plus";

const Closet = () => {
    const navigate = useNavigate();
    const [ filterMenuOpen, setFilterMenuOpen ] = useState(false);

    const columnsMeta = useColumns(3, 2, 4);
    return (
        <PageWrapper 
            title="Closet" 
            subtitle="Browse all items" 
            sideChildren={
                <button 
                    className="bg-black text-white px-4 py-2 mr-4 text-nowrap rounded-lg cursor-pointer flex gap-2"
                    onClick={() => navigate("/atelier/clothing")}
                >
                    Add <Plus className="w-3" strokeWidth={3}/>
                </button>
            }
        >
            <ClosetProvider>
                <ClosetToolbar 
                    columnsMeta={columnsMeta}
                />
                <ClothingGallery columns={columnsMeta.columns} />
                <FilterMenu 
                    open={filterMenuOpen} 
                    closeFilter={() => setFilterMenuOpen(false)}
                />
                <FilterIconButton onFilter={() => setFilterMenuOpen(!filterMenuOpen)}/>
            </ClosetProvider>
        </PageWrapper>
    );
};

export default Closet;