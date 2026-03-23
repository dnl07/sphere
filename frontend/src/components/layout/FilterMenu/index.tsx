import { useState } from "react";
import Cross from "../../ui/icons/Cross";
import FilterBox from "../FilterBox";
import FilterDropDown from "../FilterDropDown";
import type { ClothingMeta } from "../../../models/ClothingMeta";
import useClothingMeta from "../../../hooks/useClothingMeta";

type Props = {
    open: boolean,
    closeFilter: () => void
}

const FilterMenu = ({ open, closeFilter }: Props) => {
    const [ openLabel, setOpenLabel ] = useState<string | null>(null);

    const { meta } = useClothingMeta();

    const toggleBox = (label: string) => {
        if (openLabel === label) {
            setOpenLabel(null);
        } else {
            setOpenLabel(label);
        }
    }

    const getMetaOptions = (value: string): Record<string, number> | number => {
        const field = meta?.[value as keyof ClothingMeta];

        if (typeof field === "object" && field !== null) {
            return field as Record<string, number>;
        } else if (typeof field === "number") {
            return field as number;
        }
        return {};
    }

    const filterOptions: {label: string, paramKey: string, options: Record<string, number>}[] = [
        { label: "Category", paramKey: "category", options: getMetaOptions("categories") as Record<string, number> },
        { label: "Color", paramKey: "color", options: getMetaOptions("colors") as Record<string, number>  },
        { label: "Material", paramKey: "material", options: getMetaOptions("materials") as Record<string, number>  },
        { label: "Size", paramKey: "size", options: getMetaOptions("sizes") as Record<string, number>  },
    ]




    return (
        <div className={`fixed w-full top-0 z-30 flex justify-end transition-all ease-in-out duration-300 ${open ? "opacity-100" : "invisible opacity-0"}`}>
            <div className="bg-bg inset-0 w-full h-screen md:max-w-2xl shadow-xl px-5">
                <div className="py-7 flex justify-end">
                    <Cross onClick={closeFilter}/>
                </div>
                {filterOptions.map(({ label, paramKey, options }) => (
                    <FilterDropDown label={label} open={openLabel === label} onToggle={() => toggleBox(label)}><FilterBox options={options} paramKey={paramKey}/></FilterDropDown>
                ))}
            </div>
        </div>
    )
}

export default FilterMenu;