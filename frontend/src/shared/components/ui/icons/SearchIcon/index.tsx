import type { IconProps } from "../IconBase";
import IconBase from "../IconBase";

const SearchIcon = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <line x1="20.9393" y1="21" x2="15.2218" y2="15.2825"strokeLinecap="round"/>
            <circle cx="10" cy="10" r="7.25"/>
        </IconBase>
    );
}

export default SearchIcon;