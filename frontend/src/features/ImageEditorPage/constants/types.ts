import type { ReactNode } from "react"

type BaseTool = {
    type: string
    key: string
    label: string
}

// Filter
export type FilterControlProps = {
    value: number
    onChange: (v: number) => void
    tool: FilterTool
}

export type FilterTool = BaseTool & {
    type: "filter"
    min: number
    max: number
    initial: number
    unit: "%"
    cssFilter: string
    renderControl: (props: FilterControlProps) => ReactNode
}

// Action
export type ActionControlProps = {
    onAction: () => void | Promise<void>
}

export type ActionTool = BaseTool & {
    type: "action"
    renderControl: (props: ActionControlProps) => ReactNode
}

export type EditorTool = ActionTool | FilterTool
