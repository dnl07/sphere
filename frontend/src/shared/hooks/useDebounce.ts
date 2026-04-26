import { useCallback, useEffect, useRef } from "react"

const useDebounce = <T extends (...args: any[]) => void>(fn: T, delay: number) => {
    const timer = useRef<ReturnType<typeof setTimeout> | null>(null);

    const fnRef = useRef(fn);
    useEffect(() => { fnRef.current = fn; }, [fn])

    return useCallback((...args: Parameters<T>) => {
        if (timer.current) clearTimeout(timer.current);
        timer.current = setTimeout(() => fnRef.current(...args), delay)
    }, [delay]);
}

export default useDebounce;