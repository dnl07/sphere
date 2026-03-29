import { useEffect, useState, type ChangeEvent } from "react";
import { useSearchParams } from "react-router";
import SearchIcon from "../../../../shared/components/ui/icons/SearchIcon";
import FilterIcon from "../../../../shared/components/ui/icons/FilterIcon";

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

    const addQueryToUrl = () => {
        const params = new URLSearchParams(searchParams);

        if (query) {
            params.set("q", query);
        } else if (!query || query === "") {
            params.delete("q");
        }

        setSearchParams(params)
    }

    useEffect(() => {
        addQueryToUrl();
    }, [query]);

    return (
        <div className={`fixed bottom-1 md:bottom-3 z-30 max-w-6xl w-full flex px-3 `}>
            <div className={`bg-black p-3 flex gap-3 transition-all ease-in-out duration-200 ${onExpanded ? "w-full" : "w-39"}`}>
                <div className={`flex justify-center items-center text-white text-xl border-white border-2 h-15 p-2 transition-all ease-in-out duration-200 cursor-pointer ${onExpanded ? "w-full" : "w-15"}`} onClick={() => setOnExpanded(!onExpanded)}>
                    {onExpanded ? 
                      <input type="text" name="search"
                        className="text-white outline-none w-full pl-3"
                        placeholder="Search..."
                        value={query ?? ""}
                        onChange={handleSearchQuery} 
                        onClick={(e) => e.stopPropagation()}
                        />
                    :     
                        <SearchIcon className="w-8 h-8"/>             
                }
                </div>
                <button className="text-white flex justify-center items-center border-white border-2 h-15 p-2 aspect-square cursor-pointer" onClick={() => {onFilter(); setOnExpanded(!onExpanded)}}>
                    <FilterIcon className="w-8 h-8" strokeWidth={1.25}/>
                </button>
            </div>
        </div>
    )
}

export default FilterIconButton;