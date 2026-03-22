import { useSearchParams } from "react-router";

type Props = {
    options: Record<string, number>,
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
            {Object.entries(options).map(([label, count]) => (
                <button 
                    key={label} 
                    onPointerDown={() => toggle(label)}
                    className={`px-2 py-1 border-2 cursor-pointer ${active.includes(label) ? "bg-black text-white border-2 border-black" : ""}`}
                >
                    <p>{label} ({count})</p>
                </button>
            ))}
        </div>
    )
}

export default FilterBox;