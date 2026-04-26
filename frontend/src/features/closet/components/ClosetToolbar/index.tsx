import { useEffect, useState } from "react";
import DropDownBox from "../../../../shared/components/ui/DropDownBox";
import useMultiParam from "../../../../shared/hooks/useMultiParam";
import arrayRange from "../../../../shared/utils/arrayRange";
import type { ColumnsMeta } from "../../hooks/useColumns";

type Props = {
    columnsMeta: ColumnsMeta
}

const ClosetToolbar = ({ columnsMeta }: Props) => {
    const sortOption = {
        paramKey: "sort",
        options: [
            "Newest",
            "Oldest",
            "NameAsc",
            "NameDesc",
            "PriceAsc",
            "PriceDesc"
        ],
        defaultValue: "Newest"
    }

    const { values, toggle } = useMultiParam(sortOption.paramKey, true);

    const [ isSortOpen, setOpenSort ] = useState<boolean>(false);
    const [ activeSortValue, setActiveSortValue ] = useState<string | null>(values[0] ?? sortOption.defaultValue);

    useEffect(() => {
        if (activeSortValue) {
            toggle(activeSortValue)
        }
    }, [activeSortValue])

    return (
        <div className="flex justify-between w-full mb-2">
            <div className="flex items-center relative cursor-pointer gap-2" onClick={() => setOpenSort(!isSortOpen)}>
                <p>Sort by:</p>
                <span>{activeSortValue}</span>
                <DropDownBox 
                    values={sortOption.options}
                    setActiveValue={setActiveSortValue}
                    activeValue={activeSortValue}
                    setOpen={setOpenSort}
                    isOpen={isSortOpen}
                />
            </div>
            <div className="flex flex-row items-center text-black gap-3">
                <p>View:</p>
                {arrayRange(columnsMeta.minColumns, columnsMeta.maxColumns).map((value) => (
                    <button 
                        className={`cursor-pointer aspect-square flex items-center justify-center 
                            ${value === columnsMeta.columns ? "underline" : ""}`} 
                        onClick={() => columnsMeta.setColumnCount(value)}
                        key={value}
                    >
                        {value}
                    </button>
                ))}
            </div>
        </div>
    );
}

export default ClosetToolbar;