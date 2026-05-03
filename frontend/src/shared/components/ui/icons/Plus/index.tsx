import IconBase, { type IconProps } from "../IconBase";

const Plus = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <line x1="12" y1="0" x2="12" y2="24" />     
            <line x1="0" y1="12" x2="24" y2="12" />        
        </IconBase>
    );
}

export default Plus;