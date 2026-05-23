import { createContext, useContext, type ReactNode } from "react"
import { useBreakpoint } from "../hooks/useBreakpoint"

const BreakpointContext = createContext<ReturnType<typeof useBreakpoint> | null>(null)

export const BreakpointProvider = ({ children }: { children: ReactNode }) => {
    const value = useBreakpoint()

    return <BreakpointContext.Provider value={value}>{children}</BreakpointContext.Provider>
}

export const useBreakpointContext = () => {
    const context = useContext(BreakpointContext)

    if (!context) {
        throw new Error("useBreakpointContext must be used within a BreakpointProvider")
    }

    return context
}
