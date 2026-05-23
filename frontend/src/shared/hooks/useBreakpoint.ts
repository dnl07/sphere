import { useEffect, useState } from "react"

const breakpoints = {
    sm: 640,
    md: 768,
    lg: 1024,
    xl: 1280,
    "2xl": 1536,
} as const

type Breakpoint = keyof typeof breakpoints

const getBreakpoint = (width: number): Breakpoint => {
    if (width < breakpoints.sm) return "sm"
    if (width < breakpoints.md) return "md"
    if (width < breakpoints.lg) return "lg"
    if (width < breakpoints.xl) return "xl"
    return "2xl"
}

export const useBreakpoint = () => {
    const [width, setWidth] = useState(window.innerWidth)
    const breakpoint = getBreakpoint(width)

    useEffect(() => {
        const observer = new ResizeObserver(([entry]) => {
            setWidth(entry.contentRect.width)
        })
        observer.observe(document.documentElement)
        return () => observer.disconnect()
    }, [])

    return {
        breakpoint,
        isMobile: width < breakpoints.md,
        isTablet: width >= breakpoints.md && width < breakpoints.lg,
        isDesktop: width >= breakpoints.lg,
        isAbove: (bp: Breakpoint) => width >= breakpoints[bp],
        isBelow: (bp: Breakpoint) => width < breakpoints[bp],
        width,
    }
}
