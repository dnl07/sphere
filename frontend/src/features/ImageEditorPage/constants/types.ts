import type { ReactNode } from "react";
import type { IconProps } from "../../../shared/components/ui/icons/IconBase";

type BaseTool = {
    type: string;
    key: string;
    label: string;
    icon: (props: IconProps) => ReactNode;  // only for mobile 
}

// Filter
export type FilterControlProps = {
    value: number;
    onChange: (v: number) => void;
    tool: FilterTool;
}

export type FilterTool = BaseTool & {
    type: "filter";
    min: number,
    max: number;
    initial: number;
    unit: "%"
    cssFilter: string;
    renderControl: (props: FilterControlProps) => ReactNode;
}

// Action
export type ActionControlProps = {
    onAction: () => void | Promise<void>;
}

export type ActionTool = BaseTool & {
    type: "action";
    renderControl: (props: ActionControlProps) => ReactNode;
}

export type EditorTool = ActionTool | FilterTool;

export const isFilterTool = (tool: EditorTool): tool is FilterTool => tool.type === "filter";
export const isActionTool = (tool: EditorTool): tool is ActionTool => tool.type === "action";