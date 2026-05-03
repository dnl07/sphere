import IconBase, { type IconProps } from "../IconBase";

const Cross = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <line x1="0" y1="0" x2="24" y2="24" />     
            <line x1="24" y1="0" x2="0" y2="24" />        
        </IconBase>
    );
}

export default Cross;