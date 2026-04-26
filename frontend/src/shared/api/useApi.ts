import { useCallback, useEffect, useRef, useState } from "react";

interface ApiState<T> {
    data: T | null;
    isLoading: boolean;
    error: Error | null;
}

interface UseApiReturn<T, TArgs extends unknown[]> extends ApiState<T> {
    execute: (...args: TArgs) => Promise<T | null>;
    reset: () => void;
}

export function useApi<T, TArgs extends unknown[]>(
    fn: (...args: TArgs) => Promise<T>,
    options?: { initialLoading?: boolean }
): UseApiReturn<T, TArgs> {
    const [state, setState] = useState<ApiState<T>>({
        data: null,
        isLoading: options?.initialLoading ?? false,
        error: null
    })

    const fnRef = useRef(fn);

    useEffect(() => { fnRef.current = fn; }, [fn])

    const execute = useCallback( async (...args: TArgs) => {
        setState(prev => ({ ...prev, isLoading: true, error: null }));
        try {
            const data = await fnRef.current(...args);
            setState({ data: data, isLoading: false, error: null});
            return data;
        } catch (e) {
            setState(prev => ({ ...prev, isLoading: false, error: e instanceof Error ? e : new Error("Unknown Error")}));
            return null;
        }
    }, [])
    

    const reset = () => {
            setState({ data: null, isLoading: false, error: null});
    }

    return { ...state, execute, reset };
}