import { useState } from "react";
import FilterDropDown from "../FilterDropDown";
import { useSearchParams } from "react-router";
import { useClosetContext } from "../../context/ClosetContext";
import type { FilterOption, GetClothingParams } from "../../../clothing/api/clothingApi";
import Cross from "../../../../shared/components/ui/icons/Cross";
import FilterBox from "../FilterBox";

type Props = {
    open: boolean,
    closeFilter: () => void
}

const FilterMenu = ({ open, closeFilter }: Props) => {
    const [ openLabel, setOpenLabel ] = useState<string | null>(null);
    const [searchParams, _] = useSearchParams();

    const { data, updateFilters } = useClosetContext();

    const toggleBox = (label: string) => {
        if (openLabel === label) {
            setOpenLabel(null);
        } else {
            setOpenLabel(label);
        }
    }

    const filterOptions: {label: string, paramKey: string, options: FilterOption[]}[] = [
        { label: "Category", paramKey: "categories", options: data?.filters?.categories ?? [] },
        { label: "Color", paramKey: "colors", options: data?.filters?.colors ?? [] },
        { label: "Material", paramKey: "materials", options: data?.filters?.materials ?? [] },
        { label: "Size", paramKey: "sizes", options: data?.filters?.sizes ?? [] },
    ]

    const paramKeyMap: Record<string, keyof GetClothingParams> = {
        categories: "CategoryNames",
        colors: "Colors",
        materials: "Materials",
        sizes: "Sizes"
    }

    const applyFilters = () => {
        const clothingParams: GetClothingParams = {};

        filterOptions.forEach(({ paramKey }) => {
            const paramValues = searchParams.get(paramKey)?.split(",");
            const mappedKey = paramKeyMap[paramKey];

            if (paramValues && paramValues.length > 0) {
                (clothingParams[mappedKey] as string[]) = paramValues;
            }
        });

        console.log("params:", clothingParams)

        updateFilters(clothingParams);
    }

    return (
        <div className={`fixed w-full top-0 z-30 flex justify-end transition-all ease-in-out duration-300 ${open ? "opacity-100" : "invisible opacity-0"}`}>
            <div className="bg-bg inset-0 w-full h-screen md:max-w-2xl shadow-xl px-5">
                <div className="py-7 flex justify-end">
                    <Cross onClick={closeFilter}/>
                </div>
                {filterOptions.map(({ label, paramKey, options }) => (
                    <FilterDropDown label={label} open={openLabel === label} onToggle={() => toggleBox(label)}><FilterBox options={options} paramKey={paramKey}/></FilterDropDown>
                ))}
                <button onClick={applyFilters}>Submit</button>
            </div>
        </div>
    )
}

export default FilterMenu;