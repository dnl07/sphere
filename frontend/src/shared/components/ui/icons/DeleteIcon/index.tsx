import type { IconProps } from "../IconBase";
import IconBase from "../IconBase";

const DeleteIcon = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <rect x="4" y="5" width="16" height="3" rx="1.5"/>
            <path d="M9 2.5H15C15.8284 2.5 16.5 3.17157 16.5 4V5H7.5V4L7.50781 3.84668C7.58461 3.09028 8.22334 2.5 9 2.5Z"/>
            <path d="M18.5 8V20C18.5 20.8284 17.8284 21.5 17 21.5H7C6.17157 21.5 5.5 20.8284 5.5 20V8H18.5Z"/>
            <line x1="9" y1="18.5" x2="9" y2="10.5"/>
            <line x1="12" y1="18.5" x2="12" y2="10.5"/>
            <line x1="15" y1="18.5" x2="15" y2="10.5"/>
        </IconBase>
    );
};

export default DeleteIcon;