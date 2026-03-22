import { useState } from "react";
import Cross from "../../ui/icons/Cross";
import FilterBox from "../FilterBox";
import FilterDropDown from "../FilterDropDown";

type Props = {
    open: boolean,
    closeFilter: () => void
}

const FilterMenu = ({ open, closeFilter }: Props) => {
    const [ openLabel, setOpenLabel ] = useState<string | null>(null);

    const toggleBox = (label: string) => {
        if (openLabel === label) {
            setOpenLabel(null);
        } else {
            setOpenLabel(label);
        }
    }


    const filterOptions: {label: string, paramKey: string}[] = [
        { label: "Category", paramKey: "category" },
        { label: "Color", paramKey: "color" },
        { label: "Material", paramKey: "material" },
        { label: "Size", paramKey: "size" },
        { label: "Price", paramKey: "price" }
    ]

    const test: Record<string, number> = {
        "Shirts": 10,
        "Pants": 5,
        "Shoes": 3,
        "gergbeqrg": 10,
        "vqeareqa": 5,
        "vqre": 3,
        "Shievgrrts": 10,
        "vre": 5,
        "Shoveevres": 3,
        "Shirevrts": 10,
        "Parvents": 5,
        "Shvreoes": 3
    }

    return (
        <div className={`fixed w-full top-0 z-30 flex justify-end transition-all ease-in-out duration-300 ${open ? "opacity-100" : "invisible opacity-0"}`}>
            <div className="bg-bg inset-0 w-full h-screen md:max-w-2xl shadow-xl px-5">
                <div className="py-7 flex justify-end">
                    <Cross onClick={closeFilter}/>
                </div>
                {filterOptions.map(({ label, paramKey }) => (
                    <FilterDropDown label={label} open={openLabel === label} onToggle={() => toggleBox(label)}><FilterBox options={test} paramKey={paramKey}/></FilterDropDown>
                ))}
            </div>
        </div>
    )
}

export default FilterMenu;