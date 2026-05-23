import { useState } from "react"
import PageWrapper from "../../shared/components/layout/PageWrapper"
import { ClosetProvider } from "./context/ClosetContext"
import FilterMenu from "./components/filter/FilterMenu"
import FilterIconButton from "./components/filter/FilterIconButton"
import ClothingGallery from "./components/gallery/ClothingGallery"
import useColumns from "./hooks/useColumns"
import ClosetToolbar from "./components/ClosetToolbar"
import { useNavigate } from "react-router"
import Plus from "../../shared/components/ui/icons/Plus"
import { useBreakpointContext } from "../../shared/context/BreakPointContext"

const Closet = () => {
    const navigate = useNavigate()
    const [filterMenuOpen, setFilterMenuOpen] = useState(false)
    const { isMobile } = useBreakpointContext()
    const columnsMeta = useColumns(isMobile ? 2 : 3, 2, 4)

    return (
        <PageWrapper
            header={{
                mode: "breadcrumb",
                title: "Closet",
                subtitle: "Browse all items",
                items: [{ label: "Closet", to: "/closet" }],
            }}
            sideChildren={
                <button
                    className="bg-black text-white px-4 py-2 mr-4 text-nowrap rounded-lg cursor-pointer flex gap-2"
                    onClick={() => navigate("/atelier/clothing")}
                >
                    Add <Plus className="w-3" strokeWidth={3} />
                </button>
            }
        >
            <ClosetProvider>
                <ClosetToolbar columnsMeta={columnsMeta} />
                <ClothingGallery columns={columnsMeta.columns} />
                <FilterMenu open={filterMenuOpen} closeFilter={() => setFilterMenuOpen(false)} />
                <FilterIconButton onFilter={() => setFilterMenuOpen(!filterMenuOpen)} />
            </ClosetProvider>
        </PageWrapper>
    )
}

export default Closet
