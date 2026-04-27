import { useEffect, useState, type ChangeEvent } from "react";
import SearchIcon from "../../../../../shared/components/ui/icons/SearchIcon";
import FilterIcon from "../../../../../shared/components/ui/icons/FilterIcon";
import useMultiParam from "../../../../../shared/hooks/useMultiParam";

type Props = {
    onFilter: () => void
}

/**
 * Filter icon button component, located in the bottom right corner of the closet page.
 * Contains the search input and the filter button, which opens the filter sidebar.
 * Expands to show the search input when clicked, and collapses when clicked again.
 */
const FilterIconButton = ({ onFilter }: Props) => {
    const [ isExpanded, setIsExpanded ] = useState(false);
    const { toggle } = useMultiParam("q", true)
    
    const [query, setQuery] = useState<string | null>(null)

    const handleSearchQuery = (e: ChangeEvent<HTMLInputElement>) => {
        setQuery(e.target.value);
    }

    const addQueryToUrl = () => {
        if (query && query.length >= 3) {
            toggle(query);
        } else if (!query || query === "") {
            toggle("")
        }
    }

    useEffect(() => {
        addQueryToUrl();
    }, [query]);

    const toggleExpansion = () => {
        setIsExpanded(!isExpanded);
    };

    const toggleFilter = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.stopPropagation();
        onFilter();
    };

    return (
        <div className={`fixed bottom-1 md:bottom-3 z-30 max-w-6xl w-full flex px-3 pointer-events-none`}>
            <div 
                className={`bg-black p-3 flex gap-3 transition-all ease-in-out duration-200 cursor-pointer pointer-events-auto ${isExpanded ? "w-full" : "w-39"}`}
                onClick={toggleExpansion}
            >
                <div className={`flex justify-center items-center text-white text-xl border-white border-2 h-15 p-2 transition-all ease-in-out duration-200  ${isExpanded ? "w-full" : "w-15"}`}>
                    {isExpanded ? 
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
                <button className="text-white flex justify-center items-center border-white border-2 h-15 p-2 aspect-square cursor-pointer" onClick={toggleFilter}>
                    <FilterIcon className="w-8 h-8" strokeWidth={1.25}/>
                </button>
            </div>
        </div>
    )
}

export default FilterIconButton;