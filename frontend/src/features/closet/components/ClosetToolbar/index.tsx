import { useEffect, useState } from "react"
import DropDownBox from "../../../../shared/components/ui/DropDownBox"
import useMultiParam from "../../../../shared/hooks/useMultiParam"
import arrayRange from "../../../../shared/utils/arrayRange"
import type { ColumnsMeta } from "../../hooks/useColumns"

type Props = {
    columnsMeta: ColumnsMeta
}

/**
 * Toolbar component for the closet page, allowing users to sort items and adjust the number of columns in the gallery view.
 * Is located under the closet header and above the gallery.
 */
const ClosetToolbar = ({ columnsMeta }: Props) => {
    const sortOption = {
        paramKey: "sort",
        options: ["Newest", "Oldest", "NameAsc", "NameDesc", "PriceAsc", "PriceDesc"],
        defaultValue: "Newest",
    }

    const { values, toggle } = useMultiParam(sortOption.paramKey, true)

    const [isSortOpen, setOpenSort] = useState<boolean>(false)
    const [activeSortValue, setActiveSortValue] = useState<string | null>(values[0] ?? sortOption.defaultValue)

    useEffect(() => {
        if (activeSortValue) {
            toggle(activeSortValue)
        }
    }, [activeSortValue])

    return (
        <div className="flex justify-between w-full mb-4">
            <div
                className="flex items-center relative cursor-pointer gap-2 bg-bg-elevated py-2 px-2 rounded-xl"
                onClick={() => setOpenSort(!isSortOpen)}
            >
                <span className="text-text-sub">SORT BY</span>
                <span>{activeSortValue}</span>
                <DropDownBox
                    values={sortOption.options}
                    setActiveValue={setActiveSortValue}
                    activeValue={activeSortValue}
                    setOpen={setOpenSort}
                    isOpen={isSortOpen}
                />
            </div>
            <div className="flex flex-row items-center text-black gap-3 bg-bg-elevated py-2 px-2 rounded-xl">
                <span className="text-text-sub">VIEW</span>
                {arrayRange(columnsMeta.minColumns, columnsMeta.maxColumns).map((value) => (
                    <button
                        className={`cursor-pointer aspect-square border border-border h-8 rounded-md flex items-center justify-center 
                            ${value === columnsMeta.columns ? "bg-black text-white" : "bg-bg-elevated"}`}
                        onClick={() => columnsMeta.setColumnCount(value)}
                        key={value}
                    >
                        {value}
                    </button>
                ))}
            </div>
        </div>
    )
}

export default ClosetToolbar
