import IconBase, { type IconProps } from "../IconBase";

const Cross = (props: IconProps) => {
    return (
        <IconBase {...props}>
            <line className="block w-6 h-0.5 rotate-45" />
            <line className="block w-6 h-0.5-rotate-45 -translate-y-0.5" />
        </IconBase>
    );
}

export default Cross;