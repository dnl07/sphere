import type { ReactNode } from "react"
import FilterIcon from "../../../shared/components/ui/icons/FilterIcon"
import Slider from "../../../shared/components/ui/Slider"
import type { ActionControlProps, ActionTool, EditorTool, FilterControlProps, FilterTool } from "./types"
import type { IconProps } from "../../../shared/components/ui/icons/IconBase"

export const BasicTools: FilterTool[] = [
    {
        type: "filter",
        key: "brightness",
        label: "Brightness",
        min: 0,
        max: 200,
        initial: 100,
        unit: "%",
        cssFilter: "brightness",
        renderControl: (props: FilterControlProps) => createSlider(props),
    },
    {
        type: "filter",
        key: "contrast",
        label: "Contrast",
        min: 0,
        max: 200,
        initial: 100,
        unit: "%",
        cssFilter: "contrast",
        renderControl: (props: FilterControlProps) => createSlider(props),
    },
    {
        type: "filter",
        key: "saturate",
        label: "Saturation",
        min: 0,
        max: 200,
        initial: 100,
        unit: "%",
        cssFilter: "saturate",
        renderControl: (props: FilterControlProps) => createSlider(props),
    },
]

const createSlider = (props: FilterControlProps) => {
    return (
        <Slider
            key={props.tool.label}
            initial={props.value}
            min={props.tool.min}
            max={props.tool.max}
            onChange={props.onChange}
            label={props.tool.label}
        />
    )
}

export const BackgroundRemovalTool: ActionTool[] = [
    {
        type: "action",
        key: "removal",
        label: "Removal",
        renderControl: (props: ActionControlProps) => (
            <div key={"removal"} className="w-full flex justify-center items-center">
                <button className="bg-black text-2xl mt-4 text-white py-2 px-6 rounded-xl" onClick={props.onAction}>
                    Remove
                </button>
            </div>
        ),
    },
]

export const allFilterTools: FilterTool[] = [...BasicTools]

export const toolGroups: {
    key: string
    label: string
    icon: (props: IconProps) => ReactNode
    type: "action" | "filter"
    tools: EditorTool[]
}[] = [
    {
        key: "backgroundRemoval",
        label: "Background",
        icon: FilterIcon,
        type: "action",
        tools: BackgroundRemovalTool,
    },
    {
        key: "basic",
        label: "Basic Adjustments",
        icon: FilterIcon,
        type: "filter",
        tools: BasicTools,
    },
]

export type ToolGroupKey = (typeof toolGroups)[number]["key"]
