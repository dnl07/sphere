import type { IconProps } from "../IconBase";
import IconBase from "../IconBase";

const FilterIcon = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <line x1="2.5" y1="5.5" x2="5.5" y2="5.5"/>
            <line x1="9.5" y1="5.5" x2="21.5" y2="5.5"/>
            <circle cx="7.5" cy="5.5" r="2" fill="none"/>

            <line x1="2.5" y1="12" x2="14.5" y2="12"/>
            <line x1="18.5" y1="12" x2="21.5" y2="12"/>
            <circle cx="16.5" cy="12" r="2" fill="none"/>

            <line x1="2.5" y1="18.5" x2="5.5" y2="18.5"/>
            <line x1="9.5" y1="18.5" x2="21.5" y2="18.5"/>
            <circle cx="7.5" cy="18.5" r="2" fill="none"/>
        </IconBase>
    );
}

export default FilterIcon;