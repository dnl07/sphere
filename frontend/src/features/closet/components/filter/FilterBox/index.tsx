import type { FilterOption } from "../../../../clothing/api/clothingApi.types";
import useMultiParam from "../../../../../shared/hooks/useMultiParam";

type Props = {
    options: FilterOption[],
    paramKey: string
}

/**
 * Filter box component, allowing users to filter items based on various criteria.
 * Gets options and the paramKey as props, and uses the useMultiParam hook to manage the selected filters in the URL query parameters.
 */

const FilterBox = ({ options, paramKey }: Props) => {
    const { values, toggle } = useMultiParam(paramKey);

    return(
        <div className="flex flex-wrap gap-2 py-2">
            { options.length === 0 ? 
                <p>No filters available</p>          
            :
                options.map(option => (
                    <button 
                        key={option.name} 
                        onPointerDown={() => toggle(option.name)}
                        className={`px-2 py-1 border-2 cursor-pointer ${values.includes(option.name) ? "bg-black text-white border-2 border-black" : ""}`}
                    >
                        <p>{option.name} ({option.count})</p>
                    </button>
                ))
            }
        </div>
    )
}

export default FilterBox;