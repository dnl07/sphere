import { useSearchParams } from "react-router";
import type { FilterOption } from "../../../../clothing/api/clothingApi.types";

type Props = {
    options: FilterOption[],
    paramKey: string
}

const FilterBox = ({ options, paramKey }: Props) => {
    const [searchParams, setSearchParams] = useSearchParams();
    const active = searchParams.get(paramKey)?.split(",") ?? [];

    const toggle = (value: string) => {
        const params = new URLSearchParams(searchParams);

        const next = active.includes(value)
            ? active.filter(v => v !== value)
            : [...active, value];

        if (next.length === 0) {
            params.delete(paramKey);
        } else {
            params.set(paramKey, next.join(","));
        }

        setSearchParams(params);
    }

    return(
        <div className="flex flex-wrap gap-2 py-2">
            {options.map(option => (
                <button 
                    key={option.name} 
                    onPointerDown={() => toggle(option.name)}
                    className={`px-2 py-1 border-2 cursor-pointer ${active.includes(option.name) ? "bg-black text-white border-2 border-black" : ""}`}
                >
                    <p>{option.name} ({option.count})</p>
                </button>
            ))}
        </div>
    )
}

export default FilterBox;