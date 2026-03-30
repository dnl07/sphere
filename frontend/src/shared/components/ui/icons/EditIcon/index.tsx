import type { IconProps } from "../IconBase";
import IconBase from "../IconBase";

const EditIcon = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <path d="M11 2H4C2.89543 2 2 2.89543 2 4V20C2 21.1046 2.89543 22 4 22H20C21.1046 22 22 21.1046 22 20V14" stroke-linecap="round"/>
            <path d="M9.46252 10.947L18.0852 2.3243C18.671 1.73856 19.6208 1.73856 20.2065 2.3243L21.7713 3.88905C22.3571 4.47483 22.357 5.42458 21.7713 6.01037L13.1486 14.6331L9.46252 10.947Z"/>
            <path d="M20.2281 6.77194L17.2281 3.77194" />
            <path d="M12.8107 15.0022L7.86074 15.8969" stroke-linecap="round"/>
            <path d="M9.09338 11.285L7.86074 15.8969" stroke-linecap="round"/>
        </IconBase>
    );
}

export default EditIcon;