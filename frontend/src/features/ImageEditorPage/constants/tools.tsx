import FilterIcon from "../../../shared/components/ui/icons/FilterIcon";
import Slider from "../../../shared/components/ui/Slider";
import type { ActionControlProps, ActionTool, EditorTool, FilterControlProps, FilterTool } from "./types";

export const BasicTools: FilterTool[] = [
    { 
        type: "filter",
        key: "brightness", 
        label: "Brightness", 
        icon: FilterIcon, 
        min: 0, 
        max: 200, 
        initial: 100, 
        unit: "%", 
        cssFilter: "brightness",
        renderControl: (props: FilterControlProps) => createSlider(props)
    },    
    {
        type: "filter",
        key: "contrast", 
        label: "Contrast", 
        icon: FilterIcon, 
        min: 0, 
        max: 200, 
        initial: 100, 
        unit: "%", 
        cssFilter: "contrast",
        renderControl: (props: FilterControlProps) => createSlider(props)
    },
    { 
        type: "filter",
        key: "saturate", 
        label: "Saturation", 
        icon: FilterIcon, 
        min: 0, 
        max: 200, 
        initial: 100, 
        unit: "%", 
        cssFilter: "saturate",
        renderControl: (props: FilterControlProps) => createSlider(props)
    }
]

const createSlider = (props: FilterControlProps) => {
    return (
        <Slider 
            initial={props.value} 
            min={props.tool.min}
            max={props.tool.max}
            onChange={props.onChange}
            label={props.tool.label}
        />
    )
}

export const BackgroundRemovalTool: ActionTool  [] = [
    { 
        type: "action",
        key: "removal", 
        label: "Removal", 
        icon: FilterIcon, 
        renderControl: (props: ActionControlProps) => (
            <div className="w-full flex justify-center items-center">
                <button className="bg-black text-2xl text-white py-2 px-4 rounded-xl" onClick={props.onAction}>
                    Remove background
                </button>
            </div>

        )
    }
]

export const allFilterTools: FilterTool[] = [
    ...BasicTools
]

export const allEditorTools: EditorTool[] = [
    ...BackgroundRemovalTool,
    ...BasicTools,
]