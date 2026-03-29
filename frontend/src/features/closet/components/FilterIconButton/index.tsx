import { useEffect, useState, type ChangeEvent } from "react";
import { useSearchParams } from "react-router";

type Props = {
    onExpand: () => void,
    onFilter: () => void
}

const FilterIconButton = ({ onExpand, onFilter }: Props) => {
    const [ onExpanded, setOnExpanded ] = useState(false);
    const [searchParams, setSearchParams] = useSearchParams();
    
    const [query, setQuery] = useState<string | null>(null)

    const handleSearchQuery = (e: ChangeEvent<HTMLInputElement>) => {
        setQuery(e.target.value);
    }

    useEffect(() => {
        const params = new URLSearchParams(searchParams);

        if (query) {
            params.set("q", query);
        } else if (!query || query === "") {
            params.delete("q");
        }

        setSearchParams(params)
    }, [query]);

    return (
        <div className={`fixed bottom-1 md:bottom-3 z-30 max-w-6xl w-full flex px-3 `}>
            <div className={`bg-black p-3 flex gap-3 transition-all ease-in-out duration-200 ${onExpanded ? "w-full" : "w-39"}`}>
                <div className={`flex pl-5 text-white text-xl border-white border-2 h-15 p-2 transition-all ease-in-out duration-200 cursor-pointer ${onExpanded ? "w-full" : "w-15"}`} onClick={() => setOnExpanded(!onExpanded)}>
                    <input type="text" name="search"
                        className="bg-transparent text-white outline-none w-full"
                        placeholder="Search..."
                        value={query ?? ""}
                        onChange={handleSearchQuery} 
                        onClick={(e) => e.stopPropagation()}
                    />
                </div>
                <button className="text-white border-white border-2 h-15 p-2 aspect-square cursor-pointer" onClick={() => {onFilter(); setOnExpanded(!onExpanded)}}>
                    <p>F</p>
                </button>
            </div>
        </div>
    )
}

export default FilterIconButton;